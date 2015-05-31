using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Net;
using System.Drawing;
using System.Security.Cryptography;
using System.Web;
using BitcoinNET.RPCClient;
using ADD.Tools;
using System.Threading;
using System.Windows.Media;
using System.Text.RegularExpressions;
using Secp256k1;
using System.Numerics;
using Microsoft.Win32;

namespace ADD
{
    public partial class Main : Form
    {

        public static Dictionary<string, byte> coinVersion;
        public static Dictionary<string, string> coinShortName;
        public static Dictionary<string, int> coinPayloadByteSize;
        public static Dictionary<string, string> coinPort;
        public static Dictionary<string, string> coinIP;
        public static Dictionary<string, string> coinUser;
        public static Dictionary<string, string> coinPassword;
        public static Dictionary<string, string> coinSigningAddress;
        public static Dictionary<string, string> coinTrackingAddress;
        public static Dictionary<string, decimal> coinTransactionFee;
        public static Dictionary<string, decimal> coinMinTransaction;
        public static Dictionary<string, int> coinTransactionSize;
        public static Dictionary<string, Boolean> coinEnableMonitoring;
        public static Dictionary<string, Boolean> coinFeePerAddress;
        public static Dictionary<string, Boolean> coinEnabled;
        public static Dictionary<string, Boolean> coinEnableSigning;
        public static Dictionary<string, Boolean> coinEnableTracking;
        public static Dictionary<string, string> coinHelperUrl;
        IDictionary<string, decimal> allAccounts;
        Dictionary<string, IEnumerable<string>> coinLastMemoryDump;

        Decimal fileSize;
        int transactionsSearched = 0;
        int transactionsFound = 0;
        int msgId = 0;
        int fileId = 0;
        Boolean trustTrustedlistContent = false;
        Boolean blockBlockedListContent = false;
        Boolean blockUnSignedContent = false;
        Boolean blockUntrustedContent = false;
        Boolean followFollowedlistContent = false;
        HashSet<string> hashTrustedList = new HashSet<string>(StringComparer.Ordinal);
        HashSet<string> hashBlockedList = new HashSet<string>(StringComparer.Ordinal);
        HashSet<string> hashFollowedList = new HashSet<string>(StringComparer.Ordinal);
        HashSet<string> hashFavoritedList = new HashSet<string>(StringComparer.Ordinal);
        static readonly object _batchLocker = new object();
        static readonly object _buildLocker = new object();
        GlyphTypeface glyphTypeface = new GlyphTypeface(new Uri("file:///C:\\WINDOWS\\Fonts\\Arial.ttf"));
        IDictionary<int, ushort> characterMap;
        string[] infoArray;
        bool Loading = true;
       
        public Main()
        {
            InitializeComponent();
            Startup();
            FixBrowser();

        }

        private void FixBrowser()
        {
               RegistryKey key;
               decimal keyValueDecimal = 11000;
               string subKey = "SOFTWARE\\Microsoft\\Internet Explorer\\MAIN\\FeatureControl\\FEATURE_BROWSER_EMULATION";


               try
               {
                   key = Registry.CurrentUser.CreateSubKey(subKey);
                   key.SetValue(Path.GetFileName(Application.ExecutablePath),keyValueDecimal,RegistryValueKind.DWord);
                   key.SetValue("ADD.vshost.exe", keyValueDecimal, RegistryValueKind.DWord);

                   key.Close();
 
               }
               catch(Exception ex)
               {
               } 
        }


        public void Startup()
    {
            tmrProcessBatch.Start();
            characterMap = glyphTypeface.CharacterToGlyphMap;
            infoArray = "Apertus immutably stores and interprets data on blockchains.|Never build files or click links from sources you do not trust.|Click Help, then info for assistance.|Create a Folder and start sharing your thoughts.|#keywords allow people to discover and follow your causes.|Encrypt items by archiving them in the Vault.|Signing your archives allows people to trust you.|Press CTRL while submitting a search to rebuild the cache.|You can search by Trans ID, Address or #Keyword".Split('|');
            URLSecurityZoneAPI.InternetSetFeatureEnabled(URLSecurityZoneAPI.InternetFeaturelist.DISABLE_NAVIGATION_SOUNDS, URLSecurityZoneAPI.SetFeatureOn.PROCESS, true);
            
        }
        private char GetRandomDivider()
        {
            char[] chars = "\\/:*?\"><|".ToCharArray();
            Random r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int i = r.Next(chars.Length);
            System.Threading.Thread.Sleep(100);

            return chars[i];
        }

        private string GetURL(string url)
        {
            if (url.ToUpper().StartsWith("HTTP"))
            {
                return url;
            }

            return "http://" + url;
        }

        private string GetRandomBuffer(int BufferLength)
        {
            //Quick Fix to allow Keyword functionality  will eventually deprecate this call.
            const string allowedChars = "####################";
            char[] chars = new char[BufferLength];
            var rd = new Random();

            for (int i = 0; i < BufferLength; i++)
            {
                chars[i] = allowedChars[rd.Next(0, allowedChars.Length)];
            }

            return new string(chars);
        }

        private void processLedger(string processId)
        {

            System.IO.StreamReader readLGR = new System.IO.StreamReader("process\\" + processId + ".LGR");
            string line = "";
            string TransId = null;
            int lineCount = 0;
            while ((line = readLGR.ReadLine()) != null && lineCount <= 1)
            {
                if (TransId == null) { TransId = line; }
                lineCount++;
            }
            readLGR.Close();

            if (lineCount > 1)
            {
                CreateLedgerFile(coinPayloadByteSize[cmbCoinType.Text], GetRandomBuffer(coinPayloadByteSize[cmbCoinType.Text]), coinIP[cmbCoinType.Text], coinPort[cmbCoinType.Text], coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text], cmbWalletLabel.Text, coinVersion[cmbCoinType.Text], coinMinTransaction[cmbCoinType.Text], "process\\" + processId + ".LGR", TransId, "");
            }
            else
            {
                lock (_buildLocker)
                {
                    CreateArchive(TransId, cmbCoinType.Text, false, false);
                }
            }

        }

        private void CreateLedgerFile(int PayloadByteSize, string Padding, string WalletRPCIP, string WalletRPCPort, string WalletRPCUser, string WalletRPCPassword, string WalletLabel, byte CoinVersion, decimal CoinMinTransaction, string FilePath = null, string ledgerId = null, string TextMessage = null)
        {

            String processId = Guid.NewGuid().ToString();
            byte[] arcPayloadBytes = new byte[PayloadByteSize + 1];
            byte[] arcPadding = UTF8Encoding.UTF8.GetBytes(Padding);
            arcPayloadBytes[0] = CoinVersion;
            int payloadBytePosition = 1;
            byte[] fileBytes = null;
            byte[] buffer = null;
            byte[] msgBytes = null;
            string cglText = "";
            Dictionary<string, decimal> toMany = new Dictionary<string, decimal>();
            Dictionary<string, decimal> lastTransaction = new Dictionary<string, decimal>();
            string lastTransactionID = null;
            string line;
            int tranCount = 1;
            int ledgerCount = 0;
            string transactionId = "";
            int fileCount = 0;
            int totalMsgSize = 0;


            CoinRPC b = new CoinRPC(new Uri(GetURL(WalletRPCIP) + ":" + WalletRPCPort), new NetworkCredential(WalletRPCUser, WalletRPCPassword));
            b.SetTXFee(coinTransactionFee[cmbCoinType.Text]);

            try
            {
                if (!FilePath.ToUpper().EndsWith(".ADD"))
                {
                    if (TextMessage.Length > 0)
                    {
                        msgBytes = Encoding.UTF8.GetBytes(TextMessage);
                        cglText = GetRandomDivider() + msgBytes.Length.ToString().PadLeft(coinPayloadByteSize[cmbCoinType.Text] - 2, '0') + GetRandomDivider();
                        totalMsgSize = msgBytes.Length + cglText.Length;
                    }

                    if (FilePath.Length > 0)
                    {


                        var mergeFiles = FilePath.Split(',');
                        

                        foreach (var f in mergeFiles)
                        {
                            //additional logic and padding to ensure text data begins at byte[0] to assist in future searching.
                            //files will have a few bytes of unsearchable content at the begining of each file due to the random delimiter set.
                            fileCount++;
                            var intCurrentSize = 0;
                            var readFileBytes = System.IO.File.ReadAllBytes(f);
                            if (fileBytes != null) { intCurrentSize = fileBytes.Length; }

                            if (ledgerId != null)
                            {
                                cglText = ledgerId + GetRandomDivider() + readFileBytes.Length.ToString() + GetRandomDivider();
                            }
                            else
                            {
                                int totalFileSize = Path.GetFileName(f).Length + readFileBytes.Length.ToString().Length + readFileBytes.Length + 2;
                                int filePadding = coinPayloadByteSize[cmbCoinType.Text] - (totalFileSize % coinPayloadByteSize[cmbCoinType.Text]);
                                if (fileCount == mergeFiles.Length &&  totalMsgSize > 0) 
                                {
                                    filePadding = filePadding + (coinPayloadByteSize[cmbCoinType.Text] - (totalMsgSize % coinPayloadByteSize[cmbCoinType.Text]));
                                }
                                
                                cglText = Path.GetFileName(f) + GetRandomDivider() + readFileBytes.Length.ToString().PadLeft(filePadding + readFileBytes.Length.ToString().Length, '0') + GetRandomDivider();
                            }

                            buffer = new byte[cglText.Length + intCurrentSize + readFileBytes.Length];
                            Encoding.UTF8.GetBytes(cglText).CopyTo(buffer, 0);
                            readFileBytes.CopyTo(buffer, cglText.Length);
                            if (fileBytes != null) { fileBytes.CopyTo(buffer, (readFileBytes.Length + cglText.Length)); }
                            fileBytes = buffer;
                        }
                        
                        progressBar.Maximum = fileBytes.Length;
                        progressBar.Value = 1;
                        progressBar.Visible = true;
                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Encoding data.";

                    }

                    if (TextMessage.Length > 0)
                    {
                        cglText = GetRandomDivider() + msgBytes.Length.ToString().PadLeft(coinPayloadByteSize[cmbCoinType.Text] - 2, '0') + GetRandomDivider();
                        buffer = new byte[cglText.Length + msgBytes.Length];
                        Encoding.UTF8.GetBytes(cglText).CopyTo(buffer, 0);
                        msgBytes.CopyTo(buffer, cglText.Length);
                        msgBytes = buffer;

                        if (fileBytes != null)
                        {
                            buffer = new byte[msgBytes.Length + fileBytes.Length];
                            msgBytes.CopyTo(buffer, 0);
                            fileBytes.CopyTo(buffer, msgBytes.Length);
                            fileBytes = buffer;
                        }
                        else
                        {
                            fileBytes = msgBytes;
                        }
                    }
                    if (cmbSignature.SelectedIndex > 0 && ledgerId == null)
                    {
                        CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                        //Sign and 0 pad the signature allowing the archive data to always begin at byte[0]. Allows for future file and keyword lookup
                        System.Security.Cryptography.SHA256 mySHA256 = SHA256Managed.Create();
                        byte[] hashValue = mySHA256.ComputeHash(fileBytes);
                        IEnumerable<string> Address = a.GetAddressesByAccount("~~" + cmbSignature.Text);
                        string signature = b.SignMessage(Address.First(), BitConverter.ToString(hashValue).Replace("-", String.Empty));
                        var sigBytes = Encoding.UTF8.GetBytes(signature);
                        int totalSigSize = sigBytes.Length + sigBytes.Length.ToString().Length + 5;
                        int zeroPadding = coinPayloadByteSize[cmbCoinType.Text] - (totalSigSize % coinPayloadByteSize[cmbCoinType.Text]);

                        cglText = "SIG" + GetRandomDivider() + sigBytes.Length.ToString().PadLeft(zeroPadding + sigBytes.Length.ToString().Length, '0') + GetRandomDivider();

                        buffer = new byte[cglText.Length + fileBytes.Length + sigBytes.Length];
                        Encoding.UTF8.GetBytes(cglText).CopyTo(buffer, 0);
                        sigBytes.CopyTo(buffer, cglText.Length);
                        if (fileBytes != null) { fileBytes.CopyTo(buffer, (sigBytes.Length + cglText.Length)); }
                        fileBytes = buffer;

                    }

                    if (ledgerId == null && cmbVault.SelectedIndex > 0 && Path.GetFileName(FilePath) != "SEC")
                    {
                        CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                        IEnumerable<string> Address = a.GetAddressesByAccount("~~~" + cmbVault.Text);
                        var privKeyHex = BitConverter.ToString(Base58.Decode(a.DumpPrivateKey(Address.First()))).Replace("-", "");
                        privKeyHex = privKeyHex.Substring(2, 64);
                        BigInteger privateKey = Hex.HexToBigInteger(privKeyHex);
                        ECPoint publicKey = Secp256k1.Secp256k1.G.Multiply(privateKey);
                        ECEncryption encryption = new ECEncryption();
                        byte[] encrypted = encryption.Encrypt(publicKey, fileBytes);
                        Directory.CreateDirectory("process\\" + processId);
                        File.WriteAllBytes("process\\" + processId + "\\SEC", encrypted);
                        CreateLedgerFile(coinPayloadByteSize[cmbCoinType.Text], GetRandomBuffer(coinPayloadByteSize[cmbCoinType.Text]), coinIP[cmbCoinType.Text], coinPort[cmbCoinType.Text], coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text], cmbWalletLabel.Text, coinVersion[cmbCoinType.Text], coinMinTransaction[cmbCoinType.Text], System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\process\\" + processId + "\\SEC", null, "");
                        return;
                    }


                    System.IO.StreamWriter arcFile = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);

                    for (int arcBytePosition = 0; arcBytePosition < fileBytes.Length; arcBytePosition++)
                    {

                        if (payloadBytePosition > PayloadByteSize)
                        {
                            arcFile.WriteLine(Base58.EncodeWithCheckSum(arcPayloadBytes));
                            payloadBytePosition = 1;
                            arcPayloadBytes = new byte[PayloadByteSize + 1];
                            arcPayloadBytes[0] = CoinVersion;
                        }

                        arcPayloadBytes[payloadBytePosition] = fileBytes[arcBytePosition];
                        payloadBytePosition++;
                        progressBar.PerformStep();


                    }

                    for (int i = payloadBytePosition; i < PayloadByteSize; i++)
                    {
                        arcPayloadBytes[i] = arcPadding[i];
                    }

                    arcFile.WriteLine(Base58.EncodeWithCheckSum(arcPayloadBytes));
                    arcFile.Close();
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Encoded " + fileBytes.Length.ToString() + " bytes of data.";
                    progressBar.Value = 1;
                    progressBar.Maximum = (fileBytes.Length + PayloadByteSize) / PayloadByteSize;
                    progressBar.PerformStep();


                }
                else
                {
                    processId = FilePath.ToUpper().Remove(0, FilePath.Length - 40).Replace(".ADD", "");
                }

                if (chkKeywords.Checked)
                { var keywords = GetKeyWords(txtMessage.Text, "#");
                if (keywords != null)
                {
                    foreach (string keyword in keywords)
                    {
                        //allow Keyword functionality by putting keyword addresses on the end of the archive
                        System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                        arcSign.WriteLine(keyword);
                        arcSign.Close();
                    }
                }
                }

                if (chkEnableRecipients.Checked)
                {
                    var keywords = GetKeyWords(txtMessage.Text, "@");
                    if (keywords != null)
                    {
                        foreach (string keyword in keywords)
                        {
                            //allow Send to @Address functionality by putting Deliver To addresses on the end of the archive
                            System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                            arcSign.WriteLine(keyword);
                            arcSign.Close();
                        }
                    }
                }

                //Folder address should always be the last or second to the last address in the array to allow for Folder Lookups.
                if (cmbFolder.SelectedIndex > 0)
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    //allow tracking by putting a signature address on the end of the file
                    System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                    IEnumerable<string> Address = a.GetAddressesByAccount("~" + cmbFolder.Text);
                    arcSign.WriteLine(Address.First());
                    arcSign.Close();
                }

                if (cmbVault.SelectedIndex > 0 && chkTrackVault.Checked)
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    //allow tracking by putting a signature address on the end of the file
                    System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                    IEnumerable<string> Address = a.GetAddressesByAccount("~~~" + cmbVault.Text);
                    arcSign.WriteLine(Address.First());
                    arcSign.Close();
                }

                //Signing address should always be the last address in the array to allow for Signature Lookups.
                if (cmbSignature.SelectedIndex > 0)
                {

                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    //allow tracking by putting a signature address on the end of the file
                    System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                    IEnumerable<string> Address = a.GetAddressesByAccount("~~" + cmbSignature.Text);

                    arcSign.WriteLine(Address.First());
                    arcSign.Close();

                }

                

                System.IO.StreamReader readARC = new System.IO.StreamReader("process\\" + processId + ".ADD");
                System.IO.StreamWriter arcLedger = new System.IO.StreamWriter("process\\" + processId + ".LGR", true);


                while ((line = readARC.ReadLine()) != null)
                {
                    try
                    {
                        toMany.Add(line, CoinMinTransaction);
                        progressBar.PerformStep();

                    }
                    catch
                    {
                        //Cannot send to the same address more than twice in any transaction
                        //If data is identical use previous transaction instead of archiving identical data.
                        if (lastTransaction.SequenceEqual(toMany))
                        { transactionId = lastTransactionID; }
                        else
                        {
                            transactionId = b.SendMany(WalletLabel, toMany);
                        }

                        arcLedger.WriteLine(transactionId);
                        arcLedger.Flush();
                        lastTransaction = new Dictionary<string, decimal>(toMany);
                        lastTransactionID = transactionId;
                        toMany.Clear();
                        toMany.Add(line, CoinMinTransaction);
                        progressBar.PerformStep();
                        tranCount = 0;
                        GetTransactionResponse transLookup = b.GetTransaction(transactionId);
                        //Wait for the wallet to catch up.
                        while (transLookup.confirmations < 1 && ledgerCount > (coinTransactionSize[cmbCoinType.Text] * 10))
                        {
                            System.Threading.Thread.Sleep(1000);
                            transLookup = b.GetTransaction(transactionId);

                        }
                        if (transLookup.confirmations > 0) { ledgerCount = 0; }


                    }


                    if (tranCount == coinTransactionSize[cmbCoinType.Text])
                    {
                        //Breaking transaction file into size specified in wallet settings
                        transactionId = b.SendMany(WalletLabel,toMany);
                        arcLedger.WriteLine(transactionId);
                        arcLedger.Flush();
                        lastTransaction = new Dictionary<string, decimal>(toMany);
                        lastTransactionID = transactionId;
                        toMany.Clear();
                        tranCount = 0;

                        GetTransactionResponse transLookup = b.GetTransaction(transactionId);
                        //Wait for the wallet to catch up.
                        while (transLookup.confirmations < 1 && ledgerCount > (coinTransactionSize[cmbCoinType.Text] * 10))
                        {
                            System.Threading.Thread.Sleep(1000);
                            transLookup = b.GetTransaction(transactionId);
                        }
                        if (transLookup.confirmations > 0) { ledgerCount = 0; }



                    }
                    tranCount++;
                    ledgerCount++;
                }
                if (toMany.Count > 0)
                {
                    //Catching the straglers
                    transactionId = b.SendMany(WalletLabel, toMany);
                    arcLedger.WriteLine(transactionId);
                    arcLedger.Flush();
                    lastTransaction = new Dictionary<string, decimal>(toMany);
                    lastTransactionID = transactionId;
                    toMany.Clear();
                    tranCount = 0;
                    GetTransactionResponse transLookup = b.GetTransaction(transactionId);
                    //Wait for the wallet to catch up.
                    while (transLookup.confirmations < 1 && ledgerCount > (coinTransactionSize[cmbCoinType.Text] * 10))
                    {
                        System.Threading.Thread.Sleep(1000);
                        transLookup = b.GetTransaction(transactionId);
                    }

                }
                arcLedger.Close();
                readARC.Close();
                processLedger(processId.ToString());


            }
            catch (Exception e)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Error: " + e.Message;
                tmrStatusUpdate.Start();
                tmrProgressBar.Start();
                return;
            }
            lblStatusInfo.ForeColor = System.Drawing.Color.Black;
            lblStatusInfo.Text = "Encoded " + (progressBar.Maximum * PayloadByteSize) + " bytes of data.";
            tmrStatusUpdate.Start();
            tmrProgressBar.Start();
            if (!chkMonitorBlockChains.Checked)
            {
                txtTransIDSearch.Text = transactionId;
                performTransIDSearch(false);
            }


        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            PerformArchive();
        }

        private void PerformArchive()
        {
            if (chkWarnArchive.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("NOTICE: Files or messages with repetitive data will greatly increase the cost of archivng.", "Confirm Saving", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CreateLedgerFile(coinPayloadByteSize[cmbCoinType.Text], GetRandomBuffer(coinPayloadByteSize[cmbCoinType.Text]), coinIP[cmbCoinType.Text], coinPort[cmbCoinType.Text], coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text], cmbWalletLabel.Text, coinVersion[cmbCoinType.Text], coinMinTransaction[cmbCoinType.Text], txtFileName.Text, null, txtMessage.Text);
                }
                else
                {
                    return;
                }

            }
            else
            {
                CreateLedgerFile(coinPayloadByteSize[cmbCoinType.Text], GetRandomBuffer(coinPayloadByteSize[cmbCoinType.Text]), coinIP[cmbCoinType.Text], coinPort[cmbCoinType.Text], coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text], cmbWalletLabel.Text, coinVersion[cmbCoinType.Text], coinMinTransaction[cmbCoinType.Text], txtFileName.Text, null, txtMessage.Text);

            }
            txtMessage.Text = "";
            txtFileName.Text = "";
            if (cmbFolder.SelectedIndex > 0) { RefreshFolderList(); }
            else if (cmbSignature.SelectedIndex > 0) { RefreshSignatureList(); }
            else if (cmbVault.SelectedIndex > 0) { RefreshVaultList(); }
        }

        private void btnAttachFiles_Click(object sender, EventArgs e)
        {

            DialogResult result = attachFiles.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileSize = (decimal)0;
                txtFileName.Text = String.Join(",", attachFiles.FileNames);

                foreach (var f in attachFiles.FileNames)
                {
                    var filebytes = new System.IO.FileInfo(f).Length;
                    fileSize = fileSize + filebytes;
                }

                updateEstimatedCost();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("root");
            Directory.CreateDirectory("process");
            RefreshCoinTypes();
            RefreshHashCache();
            tmrStatusUpdate.Start();
            LoadUserPref();
            LoadFavorites();
     
        }

        public void LoadFavorites()
        {
            string favoritesLine = "";
            if (System.IO.File.Exists("favorites.txt"))
            {
                System.IO.StreamReader readFavorite = new System.IO.StreamReader("favorites.txt");
                while ((favoritesLine = readFavorite.ReadLine()) != null)
                {
                    try
                    {
                        string transactionID = favoritesLine.Substring(99, favoritesLine.Length - 99);
                        treeView1.Nodes["favorites"].Nodes.Add(favoritesLine.Substring(0, 99)).Tag = transactionID;
                    }
                    catch { }
                }
                readFavorite.Close();
            }

        }
        
        public void LoadUserPref()
        {
            this.Width = Properties.Settings.Default.AppWidth;
            this.Height = Properties.Settings.Default.AppHeight;


            try
            {
                System.Drawing.Point windowLocation = new System.Drawing.Point(Convert.ToInt16(Properties.Settings.Default.AppLocation.Split(',').First()), Convert.ToInt16(Properties.Settings.Default.AppLocation.Split(',').Last()));
                this.DesktopLocation = windowLocation;
                splitMain.SplitterDistance = Properties.Settings.Default.MainPanel;
                chkEnableRecipients.Checked = Properties.Settings.Default.EnableRecipients;
                chkKeywords.Checked = Properties.Settings.Default.EnableKeyWords;
                chkFilterUnSafeContent.Checked = Properties.Settings.Default.EnableFilter;
                chkMonitorBlockChains.Checked = Properties.Settings.Default.EnableMonitor;
                chkTrackVault.Checked = Properties.Settings.Default.EnableTrackVault;
                chkWarnArchive.Checked = Properties.Settings.Default.EnableSaveWarning;
                chkSaveOnEnter.Checked = Properties.Settings.Default.EnableEnterEqualsSave;
                splitArchiveTools.SplitterDistance = Properties.Settings.Default.ArchivePanel;
                splitHistoryBrowser.SplitterDistance = Properties.Settings.Default.BrowserPanel;
                splitMain.Panel2Collapsed = Properties.Settings.Default.HideArchive;
                splitHistoryBrowser.Panel1Collapsed = Properties.Settings.Default.HideHistory;
                if (Properties.Settings.Default.HideArchive)
                {
                    imgOpenUp.Visible = true;
                    imgOpenDown.Visible = false;
                }
                else
                {
                    imgOpenUp.Visible = false;
                    imgOpenDown.Visible = true;
                }

                if (Properties.Settings.Default.HideHistory)
                {
                    imgOpenRight.Visible = true;
                    imgOpenLeft.Visible = false;
                }
                else
                {
                    imgOpenRight.Visible = false;
                    imgOpenLeft.Visible = true;
                }
            }
            catch { }
        }

        public void RefreshHashCache()
        {
            if (!System.IO.File.Exists("trust.conf"))
            {
                System.IO.StreamWriter writeTrustConf = new StreamWriter("trust.conf");
                writeTrustConf.WriteLine("True True False False True");
                writeTrustConf.Close();
            }

            System.IO.StreamReader readTrustConf = new System.IO.StreamReader("trust.conf");
            while (!readTrustConf.EndOfStream)
            {
                var trustSettings = readTrustConf.ReadLine().Split(' ');

                try
                {
                    trustTrustedlistContent = Convert.ToBoolean(trustSettings[0]);
                    blockBlockedListContent = Convert.ToBoolean(trustSettings[1]);
                    blockUnSignedContent = Convert.ToBoolean(trustSettings[2]);
                    blockUntrustedContent = Convert.ToBoolean(trustSettings[3]);
                    followFollowedlistContent = Convert.ToBoolean(trustSettings[4]);
                }
                catch { }
            }
            readTrustConf.Close();

            hashTrustedList.Clear();
            if (System.IO.File.Exists("trust.txt"))
            {
                System.IO.StreamReader readTrust = new System.IO.StreamReader("trust.txt");
                while (!readTrust.EndOfStream)
                {
                    hashTrustedList.Add(readTrust.ReadLine());
                }
                readTrust.Close();
            }

            hashBlockedList.Clear();
            if (System.IO.File.Exists("block.txt"))
            {
                System.IO.StreamReader readBlock = new System.IO.StreamReader("block.txt");
                while (!readBlock.EndOfStream)
                {
                    hashBlockedList.Add(readBlock.ReadLine());
                }
                readBlock.Close();
            }

            hashFollowedList.Clear();
            if (System.IO.File.Exists("follow.txt"))
            {
                System.IO.StreamReader readFollow = new System.IO.StreamReader("follow.txt");
                while (!readFollow.EndOfStream)
                {
                    hashFollowedList.Add(readFollow.ReadLine());
                }
                readFollow.Close();
            }
           
            hashFavoritedList.Clear();
            if (System.IO.File.Exists("favorite.txt"))
            {
                System.IO.StreamReader readFavorite = new System.IO.StreamReader("favorite.txt");
                while (!readFavorite.EndOfStream)
                {
                    string favorite = readFavorite.ReadLine();
                    hashFavoritedList.Add(favorite.Substring(99, favorite.Length - 99));
                }
                readFavorite.Close();
            }

        }

        public void RefreshCoinTypes()
        {
            try
            {
                coinVersion = new Dictionary<string, byte>();
                coinShortName = new Dictionary<string, string>();
                coinPayloadByteSize = new Dictionary<string, int>();
                coinTransactionFee = new Dictionary<string, decimal>();
                coinMinTransaction = new Dictionary<string, decimal>();
                coinTransactionSize = new Dictionary<string, int>();
                coinPort = new Dictionary<string, string>();
                coinIP = new Dictionary<string, string>();
                coinUser = new Dictionary<string, string>();
                coinPassword = new Dictionary<string, string>();
                coinSigningAddress = new Dictionary<string, string>();
                coinTrackingAddress = new Dictionary<string, string>();
                coinEnableMonitoring = new Dictionary<string, bool>();
                coinFeePerAddress = new Dictionary<string, bool>();
                coinEnableSigning = new Dictionary<string, bool>();
                coinEnableTracking = new Dictionary<string, bool>();
                coinHelperUrl = new Dictionary<string, string>();
                coinEnabled = new Dictionary<string, bool>();
                coinLastMemoryDump = new Dictionary<string, IEnumerable<string>>();
                string confLine;

                if (!System.IO.File.Exists("coin.conf"))
                {
                    System.IO.StreamWriter writeCoinConf = new StreamWriter("coin.conf");
                    writeCoinConf.WriteLine("Bitcoin 0 20 .0001 .00000548 330 8332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False False  BTC False  ");
                    writeCoinConf.WriteLine("Litecoin 48 20 .001 .00000001 330 9332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  LTC False  ");
                    writeCoinConf.WriteLine("Dogecoin 30 20 1 .00000001 330 22555 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  DOGE False  ");
                    writeCoinConf.WriteLine("Mazacoin 50 20 .0001 .000055 330 12832 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  MZC False  ");
                    writeCoinConf.WriteLine("Anoncoin 23 20 .01 .00000001 330 9376 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  ANC False  ");
                    writeCoinConf.WriteLine("Devcoin 0 20 .6 .0000548 330 52332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  DVC False  ");
                    writeCoinConf.WriteLine("Potcoin 55 20 .001 .0000548 330 42000 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  POT False  ");
             
                    writeCoinConf.Close();
                }


                if (!System.IO.Directory.Exists("root\\includes"))
                {
                    System.IO.Directory.CreateDirectory("root\\includes");

                    System.IO.StreamWriter writeIncludes = new StreamWriter("root\\includes\\meta.ssi");
                    writeIncludes.WriteLine("");
                    writeIncludes.Close();

                    writeIncludes = new StreamWriter("root\\includes\\header.ssi");
                    writeIncludes.WriteLine("");
                    writeIncludes.Close();

                    writeIncludes = new StreamWriter("root\\includes\\css.css");
                    writeIncludes.WriteLine("body {font-family: Arial, Helvetica, sans-serif;background:white;}");
                    writeIncludes.WriteLine("a {color: #A0A0A0;}");
                    writeIncludes.WriteLine("img {max-width: 100%;height: auto;}");
                    writeIncludes.WriteLine(".main{max-width: 100%;}");
                    writeIncludes.WriteLine(".main .item {margin: 5px;}");
                    writeIncludes.WriteLine(".main .item .content {word-wrap: break-word;background: #E6E6E6;color: #151515;padding: 10px;text-align: center;-webkit-border-radius:10px;-moz-border-radius:10px;border-radius:10px;}");
                    writeIncludes.WriteLine(".main .item .content table {word-break: break-all;word-wrap: break-word;padding: 10px;}");
                    writeIncludes.Close();

                    writeIncludes = new StreamWriter("root\\includes\\footer.ssi");
                    writeIncludes.WriteLine("");
                    writeIncludes.Close();
                }

                System.IO.StreamReader readCoinConf = new System.IO.StreamReader("coin.conf");
                while ((confLine = readCoinConf.ReadLine()) != null)
                {
                    string[] coins = new string[] { "Coin", "0", "20", ".00001", ".00000001", "330", "0000", "127.0.0.1", "RPC_USER_CHANGE_ME", "RPC_PASSWORD_CHANGE_ME", "True", "True", "False", "False", "", "", "False","", "" };
                    string[] loadCoin = confLine.Split(' ');
                    int intSetting = 0;
                    foreach (string s in loadCoin)
                    {
                        try
                        {
                            coins[intSetting] = s;
                            intSetting++;
                        }
                        catch { }
                    }

                    coinVersion.Add(coins[0], byte.Parse(coins[1]));
                    coinShortName.Add(coins[0], coins[15]);
                    coinPayloadByteSize.Add(coins[0], int.Parse(coins[2]));
                    coinTransactionFee.Add(coins[0], decimal.Parse(coins[3]));
                    coinMinTransaction.Add(coins[0], decimal.Parse(coins[4]));
                    // Transaction Sizes under 12 can cause an infinite loop that would drain a users wallet
                    if (int.Parse(coins[5]) > 11)
                    {
                        coinTransactionSize.Add(coins[0], int.Parse(coins[5]));
                    }
                    else { coinTransactionSize.Add(coins[0], 12); }
                    coinPort.Add(coins[0], coins[6]);
                    coinIP.Add(coins[0], coins[7]);
                    coinUser.Add(coins[0], coins[8]);
                    coinPassword.Add(coins[0], coins[9]);
                    if (coins[10].ToUpper() == "TRUE") { coinEnableMonitoring.Add(coins[0], true); } else { coinEnableMonitoring.Add(coins[0], false); }
                    if (coins[11].ToUpper() == "TRUE") { coinFeePerAddress.Add(coins[0], true); } else { coinFeePerAddress.Add(coins[0], false); }
                    if (coins[12].ToUpper() == "TRUE") { coinEnabled.Add(coins[0], true); } else { coinEnabled.Add(coins[0], false); }
                    if (coins[13].ToUpper() == "TRUE") { coinEnableSigning.Add(coins[0], true); } else { coinEnableSigning.Add(coins[0], false); }
                    coinSigningAddress.Add(coins[0], coins[14]);
                    coinTrackingAddress.Add(coins[0], coins[17]);
                    coinHelperUrl.Add(coins[0], coins[18]);
                    if (coins[16].ToUpper() == "TRUE") { coinEnableTracking.Add(coins[0], true); } else { coinEnableTracking.Add(coins[0], false); }
                    coinLastMemoryDump.Add(coins[0], null);

                }
                readCoinConf.Close();

                cmbCoinType.Items.Add("Select Blockchain");
                foreach (string item in coinVersion.Keys)
                {
                    if (coinEnabled[item])
                    {
                        cmbCoinType.Items.Add(item.ToString());
                    }
                }

                cmbCoinType.SelectedIndex = 0;
            }

            catch (Exception coinTypeException)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Error: " + coinTypeException.Message + " check coin.conf file.";
                cmbCoinType.SelectedIndex = 0;
                cmbWalletLabel.SelectedIndex = 0;
                cmbWalletLabel.Enabled = false;
                cmbFolder.SelectedIndex = 0;
                cmbFolder.Enabled = false;
                btnAddFolder.Enabled = false;
                cmbVault.SelectedIndex = 0;
                cmbVault.Enabled = false;
                btnAddVault.Enabled = false;
                cmbSignature.SelectedIndex = 0;
                cmbSignature.Enabled = false;
                btnAddSignature.Enabled = false;
                tmrStatusUpdate.Start();
            }
        }

        private void updateEstimatedCost()
        {

            if (cmbCoinType.SelectedIndex != 0)
            {

                var estTotalCost = (decimal)0;
                var totalTransactionCost = (decimal)0;
                var totalFeeCost = (decimal)0;

                var totalSize = fileSize + txtMessage.TextLength;

                if (totalSize > 0)
                {
                    //does an ok job of estimating the archive cost
                    //
                    if (coinEnableSigning[cmbCoinType.Text]) { totalSize = totalSize + 160; }
                    //does an ok job of estimating the ledger size
                    if ( totalSize > (coinPayloadByteSize[cmbCoinType.Text] * coinTransactionSize[cmbCoinType.Text]))
                    {
                        totalSize = totalSize + (((Math.Round(totalSize / coinPayloadByteSize[cmbCoinType.Text], 0) / coinTransactionSize[cmbCoinType.Text]) * 64) + 70);
                    }
                    totalTransactionCost = Math.Round(totalSize / coinPayloadByteSize[cmbCoinType.Text], 0) * coinMinTransaction[cmbCoinType.Text];
                    if (coinFeePerAddress[cmbCoinType.Text]) { totalTransactionCost = totalTransactionCost + ((Math.Round(totalSize / coinPayloadByteSize[cmbCoinType.Text], 0)) * coinTransactionFee[cmbCoinType.Text]); }
                    totalFeeCost = Math.Round((Math.Round(totalSize / coinPayloadByteSize[cmbCoinType.Text], 0) / coinTransactionSize[cmbCoinType.Text]), 0) * coinTransactionFee[cmbCoinType.Text];
                    estTotalCost = totalTransactionCost + totalFeeCost + coinTransactionFee[cmbCoinType.Text] + coinMinTransaction[cmbCoinType.Text];
                    lblEstimatedCost.Text = estTotalCost.ToString();
                    lblTotalArchiveSize.Text = totalSize.ToString() + " bytes";
                }
                else
                {
                    lblEstimatedCost.Text = "0.00000000";
                }

            }


            else
            {
                lblEstimatedCost.Text = "0.00000000";
                lblCoinTotal.Text = "0.00000000";
            }
            CalculateLabelColors();

        }

        private void txtMessage_TextChanged(object sender, EventArgs e)
        {

            if (txtMessage.Text == "")
            {
                txtMessage.ScrollBars = ScrollBars.None;
                imgEnterMessageHere.Visible = true;
                if (txtFileName.TextLength < 1) { btnArchive.Enabled = false; }
            }
            else
            {
                txtMessage.ScrollBars = ScrollBars.Both;
                imgEnterMessageHere.Visible = false;

            }
            updateEstimatedCost();

        }


        private void cmbCoinType_SelectedIndexChanged(object sender, EventArgs e)
        {
            decimal totalValue = 0;
            searchToolStripMenuItem.Enabled = false;

            if (fileSize > 0 || txtMessage.TextLength > 0)
            {
                updateEstimatedCost();
            }
            lblCoinTotal.Text = "0.00000000";
            cmbWalletLabel.Items.Clear();
            cmbWalletLabel.Items.Add("Select Account");
            cmbWalletLabel.SelectedIndex = 0;
            cmbFolder.Items.Clear();
            cmbFolder.Items.Add("No Folder");
            cmbFolder.SelectedIndex = 0;
            cmbSignature.Items.Clear();
            cmbSignature.Items.Add("No Signature");
            cmbSignature.SelectedIndex = 0;
            cmbVault.Items.Clear();
            cmbVault.Items.Add("No Vault");
            cmbVault.SelectedIndex = 0;
            if (cmbCoinType.SelectedIndex > 0)
            {
                searchToolStripMenuItem.Enabled = true;

                try
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    allAccounts = a.ListAccounts(1);
                    tmrStatusUpdate.Start();

                    try
                    {
                        foreach (string Account in allAccounts.Keys)
                        {
                            if (allAccounts[Account] > 0) { cmbWalletLabel.Items.Add(Account); }
                            if (Account.LastIndexOf('~') == 0) { cmbFolder.Items.Add(Account.Substring(1, Account.Length - 1)); }
                            if (Account.LastIndexOf('~') == 1) { cmbSignature.Items.Add(Account.Substring(2, Account.Length - 2)); }
                            if (Account.LastIndexOf('~') == 2) { cmbVault.Items.Add(Account.Substring(3, Account.Length - 3)); }
                            totalValue = totalValue + allAccounts[Account];
                        }
                        lblCoinTotal.Text = totalValue.ToString();

                        var itemCountString = "";
                        if ((cmbWalletLabel.Items.Count - 1) > 1) { itemCountString = "s"; }
                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Connected: " + (cmbWalletLabel.Items.Count - 1).ToString() + " suitable account" + itemCountString + " Found";

                        cmbWalletLabel.Enabled = true;
                        cmbFolder.Enabled = true;
                        btnAddFolder.Enabled = true;
                        cmbSignature.Enabled = true;
                        btnAddSignature.Enabled = true;
                        cmbVault.Enabled = true;
                        btnAddVault.Enabled = true;


                    }
                    catch
                    {
                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Error: No accounts found.  Check wallet settings.";
                        cmbCoinType.SelectedIndex = 0;
                        cmbWalletLabel.SelectedIndex = 0;
                        cmbWalletLabel.Enabled = false;
                        cmbFolder.SelectedIndex = 0;
                        cmbFolder.Enabled = false;
                        btnAddFolder.Enabled = false;
                        cmbSignature.SelectedIndex = 0;
                        cmbSignature.Enabled = false;
                        btnAddSignature.Enabled =false;
                        cmbVault.SelectedIndex = 0;
                        cmbVault.Enabled = false;
                        btnAddVault.Enabled = false;
                        tmrStatusUpdate.Start();
                    }

                }
                catch (Exception walletException)
                {
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Error: " + walletException.Message + " check wallet settings.";
                    cmbCoinType.SelectedIndex = 0;
                    cmbWalletLabel.SelectedIndex = 0;
                    cmbWalletLabel.Enabled = false;
                    cmbFolder.SelectedIndex = 0;
                    cmbFolder.Enabled = false;
                    btnAddFolder.Enabled = false;
                    cmbVault.SelectedIndex = 0;
                    cmbVault.Enabled = false;
                    btnAddVault.Enabled = false;
                    cmbSignature.SelectedIndex = 0;
                    cmbSignature.Enabled = false;
                    btnAddSignature.Enabled = false;
                    tmrStatusUpdate.Start();
                }

            }


        }

        private void txtFileName_TextChanged(object sender, EventArgs e)
        {
            if (txtFileName.Text == "")
            {
                fileSize = (decimal).00000000;
                if (txtMessage.TextLength < 1) { btnArchive.Enabled = false; }
                updateEstimatedCost();
            }
        }

        private void cmbWalletLabel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbWalletLabel.SelectedIndex > 0)
            {
                lblCoinTotal.Text = allAccounts[cmbWalletLabel.Text].ToString();
                txtMessage.Enabled = true;
                txtFileName.Enabled = true;
                btnAttachFile.Enabled = true;
                proofToolStripMenuItem.Enabled = true;
                txtMessage.Select();
                if (txtMessage.TextLength < 1) { imgEnterMessageHere.Visible = true; }

            }
            else
            {
                txtMessage.Enabled = false;
                txtFileName.Enabled = false;
                btnAttachFile.Enabled = false;
                proofToolStripMenuItem.Enabled = false;
                imgEnterMessageHere.Visible = false;
                btnArchive.Enabled = false;
                               

            }
            updateEstimatedCost();

        }

        private void CalculateLabelColors()
        {
            if (Decimal.Parse(lblEstimatedCost.Text) > Decimal.Parse(lblCoinTotal.Text))
            {
                lblEstimatedCost.ForeColor = System.Drawing.Color.Red;
                btnArchive.Enabled = false;
            }
            else
            {
                lblEstimatedCost.ForeColor = System.Drawing.Color.Black;
                if ((Decimal.Parse(lblEstimatedCost.Text) + (Decimal.Parse(lblEstimatedCost.Text) / 2)) < Decimal.Parse(lblCoinTotal.Text))
                { lblEstimatedCost.ForeColor = System.Drawing.Color.Green;
                if (cmbWalletLabel.SelectedIndex > 0) { btnArchive.Enabled = true; }
                }

            }
            if (txtFileName.TextLength == 0 && txtMessage.TextLength == 0) { btnArchive.Enabled = false; }
            if (lblEstimatedCost.ForeColor != System.Drawing.Color.Green && lblCoinTotal.Text != "0.00000000")
            {
                lblStatusInfo.Text = "Deposit more to ensure a succesfull archive.";
                tmrStatusUpdate.Start();
            }
        }

        private string[] AddressArrayToLedger(string[] AddressArray, string WalletKey)
        {

            byte[] arcPayloadBytes = new byte[20];
            int intFileSize = 80;
            string strHeader = null;
            Boolean isLedgerFile = false;
            string[] headerArray = new String[2];
            byte[] fileArray = new byte[0];

            int f = 0;
            int h = 0;


            foreach (string line in AddressArray)
            {
                Base58.DecodeWithCheckSum(line, out arcPayloadBytes);
                for (int i = 1; i < arcPayloadBytes.Length; i++)
                {
                    if (f < intFileSize)
                    {

                        if (!isLedgerFile)
                        {
                            try
                            {
                                strHeader = strHeader + UTF8Encoding.UTF8.GetString(arcPayloadBytes, i, 1);
                            }
                            catch { return null; }

                            if (strHeader.IndexOfAny("\\/:*?\"><|".ToCharArray()) > -1)
                            {
                                headerArray[h] = strHeader.Remove(strHeader.Length - 1);
                                h++;
                                if (h > 1 && Int32.TryParse(headerArray[1], out intFileSize))
                                {
                                    var b = new CoinRPC(new Uri(GetURL(coinIP[WalletKey]) + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));


                                    try
                                    {
                                        try
                                        {
                                            var transaction = b.GetRawTransaction(headerArray[0], 1);
                                        }
                                        catch
                                        {
                                            var transaction = b.GetTransaction(headerArray[0]);
                                        }

                                    }
                                    catch
                                    {
                                        return null;
                                    }
                                    isLedgerFile = true;
                                    fileArray = new byte[intFileSize];

                                }
                                strHeader = null;
                            }
                        }
                        else
                        {
                            fileArray[f] = arcPayloadBytes[i];
                            f++;
                        }
                    }

                }
            }

            if (isLedgerFile)
            {
                var LedgerResult = UTF8Encoding.UTF8.GetString(fileArray, 0, fileArray.Length);
                LedgerResult = LedgerResult.Replace("\n", "").TrimEnd((char)13);
                return LedgerResult.Split((char)13);
            }

            return null;

        }

        private Boolean ConvertAddressArrayToFile(string[] AddressArray, byte[] RawBytes, string TransID, string WalletKey, bool DisplayResults)
        {
            try
            {
                int intFileByteCount = 0;
                int intPayLoadSize = 0;

                if (RawBytes == null)
                {
                    // Converting Addresses to RawBytes
                    foreach (string address in AddressArray)
                    {
                        byte[] arcPayloadBytes = null;
                        Base58.DecodeWithCheckSum(address, out arcPayloadBytes);

                        //Supporting different Payload Byte Sizes
                        if (RawBytes == null)
                        {
                            intPayLoadSize = arcPayloadBytes.Count() - 1;
                            RawBytes = new byte[(AddressArray.Count() * intPayLoadSize)];
                        }
                        //Building rawbytes
                        ArrayHelpers.SubArray(arcPayloadBytes, 1).CopyTo(RawBytes, intFileByteCount);
                        intFileByteCount = intFileByteCount + intPayLoadSize;
                    }
                }

                string strHeaderBuilder = "";
                string[] header = new string[2];
                int intHeaderPosition = 0;
                int intFilePosition = 0;
                int intFileSize = 0;
                string strFileName = "";
                byte[] buildingFile = null;
                Boolean containsData = false;
                int intStartSignedPosition = 0;
                int intEndSignedPosition = 0;
                string strSig = null;
                string strSigAddress = null;
                Boolean isSigned = false;
                Boolean trustContent = false;
                var buildFiles = new Dictionary<string, byte[]>();



                for (int i = 0; i < RawBytes.Length; i++)
                {
                    if (buildingFile == null)
                    {
                        if (UTF8Encoding.UTF8.GetString(RawBytes, i, 1).IndexOfAny("\\/:*?\"><|".ToCharArray()) > -1)
                        {
                            header[intHeaderPosition] = strHeaderBuilder;
                            strHeaderBuilder = "";
                            intHeaderPosition++;
                        }
                        else { strHeaderBuilder = strHeaderBuilder + UTF8Encoding.UTF8.GetString(RawBytes, i, 1); }

                        //Has Found enough Special Characters for a simple file Check
                        if (intHeaderPosition == 2)
                        {
                            var containsFileSize = int.TryParse(header[1], out intFileSize);
                            if (!containsFileSize || ((RawBytes.Length - i) < intFileSize) || header[0].Count() > 255 || header[0].IndexOfAny(Path.GetInvalidFileNameChars()) > -1 || (header[0].Count() == 0 && intFileSize == 0)) { if (!containsData) { return false; } else { break; } }
                            intHeaderPosition = 0;
                            intFilePosition = 0;
                            strFileName = header[0];
                            buildingFile = new byte[intFileSize];
                            containsData = true;
                            transactionsFound++;
                            intEndSignedPosition = i + intFileSize;

                        }
                    }
                    else
                    {

                        if (intFilePosition < intFileSize)
                        {
                            buildingFile[intFilePosition] = RawBytes[i];
                            intFilePosition++;
                            //intEndSignedPosition = i;
                        }
                        else
                        {
                            //checking for valid unicode characters to filter out noise
                            if (header[0] == "" && buildingFile.Length < 21)
                            {
                                for (int c = 0; c < buildingFile.Length; c++)
                                {
                                    if (!characterMap.ContainsKey(buildingFile[c])) { return false; };
                                }
                            }

                            buildFiles.Add(header[0], buildingFile);

                            i = i - 1;

                            if (Path.GetExtension(header[0]).ToUpper() == ".SIG" || header[0] == "SIG")
                            {
                                intStartSignedPosition = i;

                                if (header[0] == "SIG")
                                { strSigAddress = AddressArray[AddressArray.Count() - 1]; }
                                else { strSigAddress = Path.GetFileNameWithoutExtension(header[0]); }
                                strSig = Encoding.UTF8.GetString(buildingFile, 0, buildingFile.Length);

                            }
                            buildingFile = null;

                        }

                    }

                }
                //good enough for now
                if (intFilePosition == intFileSize && buildingFile != null)
                {
                    //checking for valid unicode characters to filter out noise
                    if (header[0] == "" && buildingFile.Length < 21)
                    {
                        for (int c = 0; c < buildingFile.Length; c++)
                        {
                            if (!characterMap.ContainsKey(buildingFile[c])) { return false; };
                        }
                    }
                    buildFiles.Add(header[0], buildingFile);
                    
                    
                }

                if (intStartSignedPosition > 0)
                {
                    System.Security.Cryptography.SHA256 mySHA256 = SHA256Managed.Create();
                    byte[] hashValue = mySHA256.ComputeHash(RawBytes.Skip(intStartSignedPosition + 1).Take(intEndSignedPosition - intStartSignedPosition).ToArray());
                    var a = new CoinRPC(new Uri(GetURL(coinIP[WalletKey]) + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));
                    isSigned = a.VerifyMessage(strSigAddress, strSig, BitConverter.ToString(hashValue).Replace("-", String.Empty));

                }
                if (!isSigned && blockUnSignedContent)
                {
                    CreateBlockedPage(TransID, "Blocked due to unsigned content restrictions");
                    return true;
                }

                if (blockUntrustedContent && (!isSigned || !hashTrustedList.Contains(strSigAddress)))
                {
                    CreateBlockedPage(TransID, "Blocked due to untrusted content restrictions");
                    return true;
                }

                if (blockBlockedListContent && hashBlockedList.Contains(strSigAddress))
                {
                    CreateBlockedPage(TransID, "Blocked due to Blocked Signer restrictions");
                    return true;
                }

                if (trustTrustedlistContent && isSigned && hashTrustedList.Contains(strSigAddress))
                {
                    trustContent = true;
                }

                if (followFollowedlistContent && isSigned && hashFollowedList.Contains(strSigAddress))
                {
                    DisplayResults = true;
                }

                if (containsData)
                {
                    Directory.CreateDirectory("root\\" + TransID);


                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Create);
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes("<html><head><meta charset=\"UTF-8\" /><title>" + WalletKey + " - " + TransID + "</title><meta name=\"description\" content=\"The following content was archived to the " + WalletKey + " blockchain.\" /><meta name=viewport content=\"width=device-width, initial-scale=1\"><!--#include file=\"..\\includes\\meta.ssi\" --><link rel=\"stylesheet\" type=\"text/css\" href=\"..\\includes\\css.css\"></head><body><div class=\"main\"><!--#include file=\"..\\includes\\header.ssi\" -->"), 0, 399 + (WalletKey.Length * 2) + TransID.Length);
                    fileStream.Close();

                    foreach (KeyValuePair<string, byte[]> entry in buildFiles)
                    {
                        if (cmbVault.SelectedIndex > 0 && entry.Key == "SEC")
                        {

                            byte[] arcPayloadBytes = new byte[coinPayloadByteSize[cmbCoinType.Text] + 1];
                            arcPayloadBytes[0] = coinVersion[cmbCoinType.Text];
                            CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                            IEnumerable<string> Address = a.GetAddressesByAccount("~~~" + cmbVault.Text);
                            var privKeyHex = BitConverter.ToString(Base58.Decode(a.DumpPrivateKey(Address.First()))).Replace("-", "");
                            privKeyHex = privKeyHex.Substring(2, 64);
                            BigInteger privateKey = Hex.HexToBigInteger(privKeyHex);
                            ECEncryption encryption = new ECEncryption();
                            
                            byte[] decrypted = encryption.Decrypt(privateKey, entry.Value);

                           
                            return ConvertAddressArrayToFile(AddressArray, decrypted, TransID, WalletKey, true);

                        }
                        else
                        {
                            ParseData(entry.Value, TransID, entry.Key, trustContent, (chkMonitorBlockChains.Checked & DisplayResults));
                        }
                        }

                    fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);

                    string printDate = "";
                    try
                    {
                        var b = new CoinRPC(new Uri(GetURL(coinIP[WalletKey]) + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));
                        var transaction = b.GetRawTransaction(TransID, 1);
                        printDate = "PENDING";
                        //place in batch queue to be tried again later.
                        if (transaction.blocktime == 0)
                        {
                            lock (_batchLocker)
                            {
                                if (!System.IO.File.Exists("batch.txt"))
                                {
                                    System.IO.File.AppendAllText("batch.txt", TransID + "@" + WalletKey + Environment.NewLine);
                                }
                                else
                                {
                                    if (!System.IO.File.ReadAllText("batch.txt").Contains(TransID))
                                    {
                                        System.IO.File.AppendAllText("batch.txt", TransID + "@" + WalletKey + Environment.NewLine);
                                    }
                                }
                            }
                        }
                        else
                        {
                            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                            dateTime = dateTime.AddSeconds(transaction.blocktime);
                            dateTime = dateTime.ToLocalTime();
                            printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
                        }

                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<div class=\"item\"><div class=\"content\"><table>"), 0, 46);
                        if (coinHelperUrl[WalletKey] != "")
                        { fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>ROOT ID</td></tr><tr><td><a href=\"" + coinHelperUrl[WalletKey].Replace("%s", transaction.txid) + "\">" + transaction.txid + "</a></td></tr>"), 0, 58 + transaction.txid.Length + coinHelperUrl[WalletKey].Replace("%s", transaction.txid).Length); }
                        else
                        { fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>ROOT ID</td></tr><tr><td>" + transaction.txid + "</td></tr>"), 0, 43 + transaction.txid.Length); }
                        if (isSigned)
                        {
                            fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>SIGNED BY</td></tr><tr><td><a href=\"SIG\"><div id=\"signature\">" + strSigAddress + "</div></a></td></tr>"), 0, 89 + (strSigAddress.Length));
                        }
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>BLOCK DATE</td></tr><tr><td nowrap><div id=\"block-date\">" + printDate + "</div></td></tr>"), 0, 80 + printDate.Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>VERSION</td></tr><tr><td>" + transaction.version + "</td></tr>"), 0, 43 + transaction.version.ToString().Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>BLOCKCHAIN</td></tr><tr><td><div id=\"blockchain\">" + WalletKey + "</div></td></tr>"), 0, 73 + WalletKey.Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>ADDRESS FILE</td></tr><tr><td><a href=\"ADD\">Address.dat</a></td></tr>"), 0, 77);
                        if (Properties.Settings.Default.ReportAbuseUrl != "")
                        { fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td align=right><a href=\"" + Properties.Settings.Default.ReportAbuseUrl.Replace("%s", transaction.txid) + "\">report abuse</a></td></tr>"), 0, 57 + Properties.Settings.Default.ReportAbuseUrl.Replace("%s", transaction.txid).Length); }
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("</table></div></div>"), 0, 20);
                    }catch{}

                   
                        FileStream dataFileStream = new FileStream("root\\" + TransID + "\\ADD", FileMode.Create);

                        foreach (string address in AddressArray)
                        {
                            dataFileStream.Write(UTF8Encoding.UTF8.GetBytes(address + "\n"), 0, address.Length + 1);
                        }
                        dataFileStream.Close();
                    

                    fileStream.Write(UTF8Encoding.UTF8.GetBytes("<!--#include file=\"..\\includes\\footer.ssi\" --></div></body></html>"), 0, 66);
                    fileStream.Close();
                    
                    //Don't crawl raw monitor results
                    if (DisplayResults && !chkMonitorBlockChains.Checked)
                    {
                        BuildBackLinks(TransID);
                        Uri BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/" + TransID + "/index.htm");
                        webBrowser1.Url = BrowseURL;
                        
                    }

                        if (!File.Exists("root\\catalog.htm")) {System.IO.File.AppendAllText("root\\catalog.htm","");}
                        var strFileDump = System.IO.File.ReadAllText("root\\catalog.htm");
                        if (!strFileDump.Contains(TransID))
                        {
                            System.IO.File.AppendAllText("root\\catalog.htm", Properties.Settings.Default.HistoryTransactionIDUrl.Replace("%s", TransID) + Environment.NewLine);
                            if (Properties.Settings.Default.SiteMapTransactionIdUrl != "")
                            { System.IO.File.AppendAllText("root\\sitemap.txt", Properties.Settings.Default.SiteMapTransactionIdUrl.Replace("%s", TransID) + Environment.NewLine); }
                        }
                        
                    
                }
                return containsData;
            }
            catch(Exception e) {
                lblStatusInfo.Text = "Error: " + e.Message;
                tmrStatusUpdate.Start();
                return false; }
        }

        private void BuildBackLinks(string TransID)
        {
            string strNoDuplicates = "";
            foreach (var files in Directory.GetFiles("root\\" + TransID))
            {
                FileInfo info = new FileInfo(files);
                var fileName = Path.GetFileName(info.FullName);

                string fileText = string.Empty;
                using (StreamReader streamReader = new StreamReader("root\\" + TransID + "\\" + fileName, Encoding.UTF8))
                {
                    fileText = streamReader.ReadToEnd();
                }
                Match match = Regex.Match(fileText, @"\/([a-fA-F0-9]{64})");
                if (match.Success)
                {
                    do
                    {
                        if (strNoDuplicates.IndexOf(match.ToString()) == -1)
                        {
                            var isFound = false;
                            foreach (string i in cmbCoinType.Items)
                            {
                                if (i != "Select Blockchain" && isFound == false)
                                {
                                    lock (_buildLocker)
                                    {
                                        isFound = CreateArchive(match.ToString().Replace("/", ""), i, false, true);
                                    }

                                    if (isFound)
                                    {
                                        break;
                                    }
                                }
                            }
                            strNoDuplicates = strNoDuplicates + match.ToString();
                        }
                        match = match.NextMatch();
                    } while (match.Success);
                }
            }
        }

        private void ParseData(byte[] ByteData, string TransID, string FileName, bool TrustContent, bool SendToMonitor)
        {

            Boolean foundType = false;
            string strPrintLine = "";

            if (FileName != "")
            {
                HashSet<string> safeExtensions =
               new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".gif", ".jpg", ".jpeg", ".txt", ".tiff", ".tif", ".mp3", ".mpeg", ".mpg", ".wav"
                };

                HashSet<string> embExtensions =
              new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".m2ts", ".aac", ".adt", ".adts", ".m4a", ".wmz", ".wms", ".ivf", ".cda", ".wav", ".au", ".snd", ".aif", ".aifc", ".aiff", ".mid", ".midi", ".rmi", ".mp2", ".mp3", ".mpa", ".m3u", ".wmd", ".dvr-ms", ".wpi", ".wax", ".wvx", ".wmx", ".asf", ".wma", ".wm", ".swf", ".pdf", ".3g2", ".3gp2", ".3gp", ".3gpp", ".aaf", ".asf", ".avchd", ".avi", ".cam", ".flv",".m1v", ".m2v", ".m4v",".mov", ".mpg", ".mpeg", ".mpe", ".mp4", ".ogg", ".wmv"
                };

                //HashSet<string> vidExtensions =
                //new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                //{
                ////    ".3g2", ".3gp2", ".3gp", ".3gpp", ".aaf", ".asf", ".avchd", ".avi", ".cam", ".flv",".m1v", ".m2v", ".m4v",".mov", ".mpg", ".mpeg", ".mpe", ".mp4", ".ogg", ".wmv"
                //};

               HashSet<string> imgExtensions =
               new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".jpg", ".jpeg", ".jpe", ".gif", ".png", ".tiff", ".tif", ".svg", ".svgz", ".xbm", ".bmp", ".ico"
                };

                if (chkFilterUnSafeContent.Checked && !TrustContent && !safeExtensions.Contains(Path.GetExtension(FileName)))
                {

                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><div id=\"file"+ fileId +"\">[ " + FileName + " ]</div></div>";
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                    fileStream.Close();
                    foundType = true;
                    fileId++;
                }
                else
                {
                    TrustContent = true;
                }


                if (!foundType && embExtensions.Contains(Path.GetExtension(FileName)))
                {
                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><embed src=\"" + HttpUtility.UrlPathEncode(FileName) + "\" /><p><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\"><div id=\"file" + fileId + "\">" + FileName + "</div></a></p></div></div>";
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                    fileStream.Close();
                    foundType = true;
                    fileId++;
                }

                //if (!foundType && vidExtensions.Contains(Path.GetExtension(FileName)))
                //{
                //    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                //    strPrintLine = "<div class=\"item\"><div class=\"content\"><video controls=\"controls\" width=\"100%\" height=\"100%\" name=\"" + FileName + "\" src=\"" + HttpUtility.UrlPathEncode(FileName) + "\"></video><p><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\">" + FileName + "</a></p></div></div>";
                //    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                //    fileStream.Close();
                //    foundType = true;
                //}

                if (!foundType && imgExtensions.Contains(Path.GetExtension(FileName)))
                {
                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><img src=\"" + HttpUtility.UrlPathEncode(FileName) + "\" /><br><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\"><div id=\"img0\">" + FileName + "</div></a></div></div>";
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                    fileStream.Close();
                    foundType = true;
                    fileId++;
                }

                if (!foundType)
                {
                    if (Path.GetExtension(FileName).ToUpper() != ".SIG" && FileName != "SIG")
                    {
                        FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                        strPrintLine = "<div class=\"item\"><div class=\"content\"><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\">" + HttpUtility.UrlPathEncode(FileName) + "</a></div></div>";
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                        fileStream.Close();
                    }
                }

              

            if (TrustContent)
                {
                    FileStream attachStream = new FileStream("root\\" + TransID + "\\" + FileName, FileMode.Create);
                    attachStream.Write(ByteData, 0, ByteData.Length);
                    attachStream.Close();
                }


  

            }
            else
            {
                string result = System.Text.UTF8Encoding.UTF8.GetString(ByteData);
                if (chkFilterUnSafeContent.Checked && !TrustContent)
                {
                    //Limited Protection From Injection Hacks
                    result = WebUtility.HtmlEncode(result);
                }

                msgId++;
                FileStream fileStream = new FileStream("root\\" + TransID + "\\MSG" + msgId , FileMode.Create);
                fileStream.Write(UTF8Encoding.UTF8.GetBytes(result), 0, UTF8Encoding.UTF8.GetBytes(result).Length);
                fileStream.Close();

                fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                strPrintLine = "<div class=\"item\"><div class=\"content\"><div id=\"msg" + msgId + "\">" + result + "</div><p><a href=\"MSG" + msgId + "\">MSG" + msgId + "</a></p></div></div>";
                fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                fileStream.Close();

                                  
            }

            if (SendToMonitor)
            {
                string line = "";

                if (!System.IO.File.Exists("monitor.htm"))
                {
                    StreamWriter newFile = new StreamWriter("monitor.htm");
                    newFile.WriteLine("<html><head><meta charset=\"UTF-8\" /></head><link rel=\"stylesheet\" type=\"text/css\" href=\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\root\\includes\\css.css\"><body><div class=\"main\">");
                    newFile.WriteLine("</div></body></html>");
                    newFile.Close();
                }
                StreamWriter tmpFile = new StreamWriter("~Monitor.htm");
                StreamReader readFile = new StreamReader("monitor.htm");
                tmpFile.WriteLine(readFile.ReadLine());
                strPrintLine = strPrintLine.Replace("href=\"", "href=\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\root\\" + TransID + "\\");
                strPrintLine = strPrintLine.Replace("src=\"", "src=\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\root\\" + TransID + "\\");
                strPrintLine = strPrintLine.Replace("%20", " ");
       
                tmpFile.WriteLine("<A href=\""+ System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\root\\" + TransID + "\\index.htm" + "\">" + strPrintLine + "</a>");
                while ((line = readFile.ReadLine()) != null)
                {
                    tmpFile.WriteLine(line);                    
                }
                tmpFile.Close();
                readFile.Close();
                File.Delete("monitor.htm");
                File.Move("~Monitor.htm", "monitor.htm");

                Uri MonitorUrl = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\monitor.htm");
                webBrowser1.Url = MonitorUrl;
                
            }
     

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            if (!Loading)
            {
                lblStatusInfo.Width = Main.ActiveForm.Width - 100;
                Properties.Settings.Default.AppHeight = this.Height;
                Properties.Settings.Default.AppWidth = this.Width;
                Properties.Settings.Default.Save();
            }
            
        }

        private void tmrStatusUpdate_Tick(object sender, EventArgs e)
        {
               lblStatusInfo.Text = "Monitor: " + transactionsSearched.ToString() + " / " + transactionsFound.ToString();
               tmrStatusUpdate.Stop();
               if (chkMonitorBlockChains.Checked) { lblStatusInfo.ForeColor = System.Drawing.Color.Blue; } else { lblStatusInfo.ForeColor = System.Drawing.Color.Black; }
          
        }

        private void tmrProgressBar_Tick(object sender, EventArgs e)
        {
            progressBar.Visible = false;
            tmrProgressBar.Stop();
        }

        public Boolean CreateArchive(string TransactionID, string WalletKey, bool DisplayResults, bool UseCache)
        {

            string[] AddressArray = null;
            string[] LedgerArray = null;
            msgId = 0;
           

            if (UseCache && System.IO.Directory.Exists("root\\" + TransactionID))
            {
                Uri BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/" + TransactionID + "/index.htm");
                webBrowser1.Url = BrowseURL;
                return true;
            }
            else { if (System.IO.Directory.Exists("root\\" + TransactionID) && TransactionID.ToUpper() != "INCLUDES")
            {
                System.IO.DirectoryInfo tranFolder = new DirectoryInfo("root\\" + TransactionID);

                foreach (FileInfo file in tranFolder.GetFiles())
                {
                    try
                    {
                        file.Delete();
                    }
                    catch {

                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Error: Unable to delete " + file.FullName;
                        tmrStatusUpdate.Start();
                    }
                }
            }
            }

            try
            {
                AddressArray = CreateAddressArrayFromTransactionID(TransactionID, WalletKey);
            }
            catch { return false; }

            try
            {
                do
                {

                    LedgerArray = AddressArrayToLedger(AddressArray, WalletKey);
                    var delimiter = "";
                    var LedgerDelimited = "";
                    if (LedgerArray != null)
                    {
                        foreach (string line in LedgerArray)
                        {

                            AddressArray = CreateAddressArrayFromTransactionID(line, WalletKey);
                            LedgerDelimited = LedgerDelimited + delimiter + string.Join(",", AddressArray);
                            delimiter = ",";
                        }
                        AddressArray = LedgerDelimited.Split(',');
                    }

                } while (LedgerArray != null);

                return ConvertAddressArrayToFile(AddressArray, null, TransactionID, WalletKey, DisplayResults);
            }
            catch { return false; }

        }

        private string[] CreateAddressArrayFromTransactionID(string TransactionId, string WalletKey)
        {
            var delimiter = "";
            string addressBuilder = "";
            var arcValue = (decimal)999999999;

            var b = new CoinRPC(new Uri(GetURL(coinIP[WalletKey]) + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));

            try {
                var transaction = b.GetRawTransaction(TransactionId, 1);


                foreach (BitcoinNET.RPCClient.GetRawTransactionResponse.Output detail in transaction.vout)
                {
                    if (arcValue > detail.value)
                    {
                        arcValue = detail.value;
                    }
                }

                foreach (BitcoinNET.RPCClient.GetRawTransactionResponse.Output detail in transaction.vout)
                {

                    if (detail.value == arcValue)
                    {
                        addressBuilder = addressBuilder + delimiter + detail.scriptPubKey.addresses[0];
                        delimiter = ",";
                    }
                }

            }
            catch (Exception e)
            {
                var transaction = b.GetTransaction(TransactionId);
                foreach (BitcoinNET.RPCClient.GetTransactionResponse.Details detail in transaction.details)
                {
                    if (arcValue > detail.amount && detail.amount > 0)
                    {
                        arcValue = detail.amount;
                    }
                }

                foreach (BitcoinNET.RPCClient.GetTransactionResponse.Details detail in transaction.details)
                {
                    if (detail.amount == arcValue && detail.category == "receive")
                    {
                        addressBuilder = addressBuilder + delimiter + detail.address;
                        delimiter = ",";
                    }
                }

            }

            return addressBuilder.Split(',');

        }

        private void chkMonitorBlockChains_CheckedChanged(object sender, EventArgs e)
        {
            var coinCount = 0;
            foreach (var i in coinIP)
            {
                if (coinEnableMonitoring[i.Key] && coinEnabled[i.Key])
                {
                    try
                    {
                        var b = new CoinRPC(new Uri(GetURL(coinIP[i.Key]) + ":" + coinPort[i.Key]), new NetworkCredential(coinUser[i.Key], coinPassword[i.Key]));
                        coinLastMemoryDump[i.Key] = b.GetRawMemPool();
                    }
                    catch (Exception ex)
                    {
                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Error: " + i.Key + " " + ex.Message;
                        tmrStatusUpdate.Start();
                    }
                    coinCount++;
                }


            }

            if (coinCount == 0)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Info: Nothing to Monitor.  Check Wallet Settings";
                tmrStatusUpdate.Start();
                chkMonitorBlockChains.Checked = false;
            }




            if (chkMonitorBlockChains.Checked)
            {
                tmrGetNewTransactions.Start();
                lblStatusInfo.ForeColor = System.Drawing.Color.Blue;
                
            }
            else
            {
                tmrGetNewTransactions.Stop();
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                
            }
            Properties.Settings.Default.EnableMonitor = chkMonitorBlockChains.Checked;
            Properties.Settings.Default.Save();
        }

        private void tmrGetNewTransactions_Tick(object sender, EventArgs e)
        {
            IEnumerable<string> transaction = null;
            try
            {
                foreach (var i in coinIP)
                {
                    if (coinEnabled[i.Key] && coinEnableMonitoring[i.Key])
                    {
                        try
                        {
                            var b = new CoinRPC(new Uri(GetURL(coinIP[i.Key]) + ":" + coinPort[i.Key]), new NetworkCredential(coinUser[i.Key], coinPassword[i.Key]));
                            transaction = b.GetRawMemPool();

                            IEnumerable<string> differenceQuery =
                            transaction.Except(coinLastMemoryDump[i.Key]);

                            foreach (var s in differenceQuery)
                            {
                                lock (_buildLocker)
                                {
                                    CreateArchive(s, i.Key, true, false);
                                }

                                transactionsSearched++;
                            }

                            coinLastMemoryDump[i.Key] = transaction;
                            if (lblStatusInfo.Text.StartsWith("Monitor"))
                            {
                                lblStatusInfo.Text = "Monitor: " + transactionsSearched.ToString() + " / " + transactionsFound.ToString();
                            }
                        }
                        catch (Exception ex)
                        {
                            lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                            lblStatusInfo.Text = "Error: " + i.Key + " Check Wallet Settings. " + ex.Message;
                            if (coinLastMemoryDump[i.Key] == null) { coinLastMemoryDump[i.Key] = transaction; }
                            tmrStatusUpdate.Start();
                        }
                    }
                }
            }
            catch
            {
                tmrGetNewTransactions.Stop();
                chkMonitorBlockChains.Checked = false;
            }

        }

        private void fontToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FontDialog fontDialog1 = new FontDialog();
            fontDialog1.Font = txtMessage.Font;
            fontDialog1.Color = txtMessage.ForeColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtMessage.Font = fontDialog1.Font;
                txtMessage.ForeColor = fontDialog1.Color;
            }
        }

        private void txtTransIDSearch_KeyDown(object sender, KeyEventArgs e)
        {
            
            if (e.KeyValue == 13)
            {
                if (txtTransIDSearch.Text.Contains("://"))
                {
                    try
                    {
                        Uri BrowseURL = new Uri(txtTransIDSearch.Text);
                        webBrowser1.Url = BrowseURL;
                        return;
                    }
                    catch { return; }
                }

                Match match = Regex.Match(txtTransIDSearch.Text, @"([a-fA-F0-9]{64})");
                if (match.Success) { performTransIDSearch(ModifierKeys != Keys.Control); }
                
                else { if (txtTransIDSearch.Text.StartsWith("@") || txtTransIDSearch.Text.StartsWith("#"))
                { performTextSearch(txtTransIDSearch.Text.Replace("@","").Replace("#","")); }
                else
                { Search.GetWindowsSearchResults(txtTransIDSearch.Text);
                var searchURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/search.htm");
                webBrowser1.Url = searchURL;
                }
                    
                    
                }
                if (ModifierKeys == Keys.Control)
                {
                    if (cmbFolder.SelectedIndex > 0) { RefreshFolderList(); }
                    else if (cmbSignature.SelectedIndex > 0) { RefreshSignatureList(); }
                    else if (cmbVault.SelectedIndex > 0) { RefreshVaultList(); }
                }
                                                   
            }

            if (e.KeyValue == (int)Keys.Delete)
            {

                txtTransIDSearch.Text = " ENTER SEARCH STRING";
                txtTransIDSearch.ForeColor = System.Drawing.Color.LightGray;
            }

             if (e.KeyValue == (int)Keys.Back)
            {

                if (txtTransIDSearch.Text == "ENTER SEARCH STRING")
                { txtTransIDSearch.Text = "ENTER SEARCH STRING";
                txtTransIDSearch.ForeColor = System.Drawing.Color.LightGray;
                }
            }
             
        }
       

        private void performTextSearch(string searchString)
        {
            bool isFound = false;
            TreeNode node = null;
            string msgData = "";
            string datTime = null;
            string i = cmbCoinType.Text;
            string addressString = searchString;
            ValidateAddressResponse result = null;
        
     
            try
            {
                if (cmbCoinType.SelectedIndex > 0)
                {
                    Match match = Regex.Match(searchString, @"^[\w]{1," + coinPayloadByteSize[i].ToString() + "}$");
                    if (match.Success)
                    {
                        byte[] keyword = Encoding.UTF8.GetBytes(searchString.PadRight(coinPayloadByteSize[i], '#'));
                        var keyPayloadBytes = new byte[coinPayloadByteSize[i] + 1];
                        keyPayloadBytes[0] = coinVersion[i];
                        keyword.CopyTo(keyPayloadBytes, 1);
                        addressString = Base58.EncodeWithCheckSum(keyPayloadBytes);
                    }    

                    var b = new CoinRPC(new Uri(GetURL(coinIP[i]) + ":" + coinPort[i]), new NetworkCredential(coinUser[i], coinPassword[i]));

                    result = b.ValidateAddress(addressString);

                    if (result != null && result.isvalid)
                    {
                        if (result.account != null)
                        {
                            isFound = true;
                            var transactions = b.ListTransactions(result.account, 100, 0, true);
                            if (treeView1.Nodes["Follow"].Nodes.ContainsKey(searchString)) { treeView1.Nodes["Follow"].Nodes.RemoveByKey(searchString); }
                            node = treeView1.Nodes["Follow"].Nodes.Add(searchString);
                            node.Name = searchString;
                            

                            if (transactions.Count() > 0)
                            {
                                txtTransIDSearch.Text = transactions.Last().txid;
                                performTransIDSearch(true);
                            }
                            foreach (var transaction in transactions)
                            {
                                msgData = "";
                                if (transaction.category == "receive")
                                {
                                    System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                                    dateTime = dateTime.AddSeconds(transaction.blocktime);
                                    dateTime = dateTime.ToLocalTime();
                                    datTime = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
                                    msgData = "";
                                    if (System.IO.File.Exists("root//" + transaction.txid + "//MSG1"))
                                    {
                                        using (StreamReader reader = new StreamReader("root//" + transaction.txid + "//MSG1"))
                                        {
                                            msgData = reader.ReadLine();
                                        }
                                    }

                                    node.Nodes.Insert(0, datTime.PadRight(20, ' ') + msgData.PadRight(100, ' ').Substring(0, 100)).Tag = transaction.txid;
                                }
                            }
                            treeView1.Nodes["Follow"].Expand();
                            treeView1.Nodes["Follow"].Nodes[searchString].ExpandAll();

                            if (!hashFollowedList.Contains(searchString))
                            {
                                hashFollowedList.Add(searchString);
                                StreamWriter writeFollowList = new StreamWriter("Follow.txt", true);
                                writeFollowList.WriteLine(searchString);
                                writeFollowList.Close();
                            }
                        }
                        else
                        {
                            DialogResult prompt = MessageBox.Show("Address import required. Do you want to perform a full index scan?", "Confirmation", MessageBoxButtons.YesNoCancel);
                            if (prompt == DialogResult.Yes)
                            {
                                try
                                {
                                    b.ImportAddress(addressString, "~~~~" + searchString, true);

                                }
                                catch (NullReferenceException)
                                {
                                    MessageBox.Show("A full index scan has begun. Please try again once it has completed.", "Apertus",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);

                                }
                                catch (Exception e)
                                {
                                    MessageBox.Show("This Blockchain does not support address importing.", "Apertus",
                                    MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                                }
                            }
                            else
                            {
                                try
                                {
                                    b.ImportAddress(addressString, "~~~~" + searchString, false);
                                    performTextSearch(searchString);
                                    return;
                                }
                                catch { }

                            }
                        }
                    }

                }
                else
                {
                    MessageBox.Show("Select a blockchain to search by Address", "Apertus",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
                }
                if (isFound)
                {
                    lblStatusInfo.Text = "Found in Blockchain";
                }
                else
                {
                    lblStatusInfo.Text = "Not Found in Blockchain";

                }
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                tmrStatusUpdate.Start();
            }
            catch (NullReferenceException)
            {
                MessageBox.Show("The " + i + " Blockchain is not responding. Please try again later.", "Apertus",
                MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk);
            }
            catch (Exception d)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Error: " + d.Message;
                tmrStatusUpdate.Start();
            }
        }

        private void performTransIDSearch(bool useCache)
        {
            var isFound = false;


             foreach (string i in cmbCoinType.Items)
            {
                if (i != "Select Blockchain" && isFound == false)
                {
                    lock (_buildLocker)
                    {
                        isFound = CreateArchive(txtTransIDSearch.Text, i, true, useCache);
                    }

                    if (isFound)
                    {
                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Found in Blockchain";
                        tmrStatusUpdate.Start();
                        break;
                    }
                }
            }
            if (!isFound)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Not found in linked Blockchains.";
                tmrStatusUpdate.Start();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("ADD.EXE");
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void walletsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenWalletForm));
            t.Start();
        }

        public static void OpenWalletForm()
        {
            Application.Run(new Wallets());
        }

        public static void OpenProfileForm()
        {
            Application.Run(new Profiles());
        }

        public static void OpenAboutForm()
        {
            Application.Run(new About());
        }

        public static void OpenTrustForm()
        {
            Application.Run(new Trust());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenAboutForm));
            t.Start();

        }

        private void txtTransIDSearch_Click(object sender, EventArgs e)
        {
            if (txtTransIDSearch.Text == "ENTER SEARCH STRING") {
                txtTransIDSearch.Text = "";
                txtTransIDSearch.ForeColor = System.Drawing.Color.Black;
            }

        }

        //private void searchResults_LinkClicked(object sender, LinkClickedEventArgs e)
        //{
        //    try
        //    {
        //        System.Diagnostics.Process.Start("root\\" + e.LinkText.Substring(6).Replace("/", "\\"));
        //    }
        //    catch (Exception ex)
        //    {
        //        lblStatusInfo.Text = "Error: " + ex.Message;
        //        tmrStatusUpdate.Start();
        //    }
        //}

        private void notarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openDigestFile.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                FileStream filestream;
                System.Security.Cryptography.SHA256 mySHA256 = SHA256Managed.Create();
                filestream = new FileStream(openDigestFile.FileName, FileMode.Open);
                filestream.Position = 0;
                byte[] hashValue = mySHA256.ComputeHash(filestream);
                filestream.Close();
                string strHash = BitConverter.ToString(hashValue).Replace("-", String.Empty);
                byte[] payLoadBytes = new byte[21];
                payLoadBytes[0] = coinVersion[cmbCoinType.Text];
                byte[] hashBytes = Encoding.UTF8.GetBytes(strHash.Substring(0,20));
                hashBytes.CopyTo(payLoadBytes,1);
                string strProofAddress = Base58.EncodeWithCheckSum(payLoadBytes);
           
                CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                try
                {
                    a.ImportAddress(strProofAddress, openDigestFile.FileName, false);
                }
                catch
                {

                    DialogResult dialogResult = MessageBox.Show("This blockchain does not support file proof Lookups at this time. Consider setting up a tracking address in the wallet settings BEFORE inserting the proof. Do you wish to continue?", "Limited functions", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        return;
                    }
                }
                
                CreateLedgerFile(coinPayloadByteSize[cmbCoinType.Text], GetRandomBuffer(coinPayloadByteSize[cmbCoinType.Text]), coinIP[cmbCoinType.Text], coinPort[cmbCoinType.Text], coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text], cmbWalletLabel.Text, coinVersion[cmbCoinType.Text], coinMinTransaction[cmbCoinType.Text], "", null, strHash +"\n" + "FileName:" + Path.GetFileName(openDigestFile.FileName));

            }

        }

        private void imgEnterMessageHere_Click(object sender, EventArgs e)
        {
            txtMessage.Select();
        }

        private void rebuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(RebuildRootIndex);
            t.Start();
        }

        private void RebuildRootIndex()
        {
            string[] folders = Directory.GetDirectories("root");

            foreach (string f in folders)
            {
                bool isFound = false;

                foreach (string i in cmbCoinType.Items)
                {
                    if (i != "Blockchain" && isFound == false)
                    {
                        string transID = f.Replace("root\\", "");
                        lock (_buildLocker)
                        {
                            isFound = CreateArchive(transID, i, true, false);
                        }
                        if (isFound)
                        {
                            lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                            lblStatusInfo.Text = "Found in Blockchain";
                            tmrStatusUpdate.Start();
                            break;
                        }
                    }
                }
                if (!isFound)
                {
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Not found in linked Blockchains.";
                    tmrStatusUpdate.Start();
                }

            }
        }

        private void trustToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenTrustForm));
            t.Start();

        }

        private void tmrProcessBatch_Tick(object sender, EventArgs e)
        {
            var batchLine = "";
            List<string> batchList = new List<string>();

            lock (_batchLocker)
            {
                try
                {
                    System.IO.StreamReader readBatch = new System.IO.StreamReader("batch.txt");
                    while ((batchLine = readBatch.ReadLine()) != null)
                    {
                        batchList.Add(batchLine);
                    }
                    readBatch.Close();
                    System.IO.File.Delete("batch.txt");
                }
                catch { }
            }


            foreach (string transIDKey in batchList)
            {
                var transArray = transIDKey.Split('@');
                try
                {
                    lock (_buildLocker)
                    {
                        CreateArchive(transArray[0], transArray[1], false,false);
                    }
                }
                catch { }
            }
        }

        public static byte[] StringToByteArray(string hex)
        {
            return Enumerable.Range(0, hex.Length)
                             .Where(x => x % 2 == 0)
                             .Select(x => Convert.ToByte(hex.Substring(x, 2), 16))
                             .ToArray();
        }

        private void tmrUpdateInfoText_Tick(object sender, EventArgs e)
        {
            Random random = new Random();
            txtInfoBox.Text = infoArray[random.Next(0, infoArray.Count())];
        }

        private void webBrowser1_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyCode == Keys.Down || e.KeyCode == Keys.Up || e.KeyCode == Keys.Left || e.KeyCode == Keys.Right)
            {
                e.IsInputKey = false;
                return;
            }
        }

        private void chkFilterUnSafeContent_CheckedChanged(object sender, EventArgs e)
        {
            if (!chkFilterUnSafeContent.Checked)
            {
                if (chkMonitorBlockChains.Checked)
                {
                    chkMonitorBlockChains.Checked = false;
                    DialogResult dialogResult = MessageBox.Show("NOTICE: Monitoring with the filter disabled is crazy dangerous. Do you want to continue?", "Confirm Saving", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.Yes)
                    {
                        chkMonitorBlockChains.Checked = true;
                    }
                }
            }
            Properties.Settings.Default.EnableFilter = chkFilterUnSafeContent.Checked;
            Properties.Settings.Default.Save();
        }

        private void button3_Click(object sender, EventArgs e)
        {


            CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));

            var privKeyHex = BitConverter.ToString(Base58.Decode(a.DumpPrivateKey("PECZDPtEhCF9jP1kzNJJxW8hq9RZ79xeDE"))).Replace("-", "");
            privKeyHex = privKeyHex.Substring(2, 64);
            BigInteger privateKey = Hex.HexToBigInteger(privKeyHex);
            ECPoint publicKey = Secp256k1.Secp256k1.G.Multiply(privateKey);
            //string bitcoinAddressUncompressed = publicKey.GetBitcoinAddress(false);
            //string bitcoinAddressCompressed = publicKey.GetBitcoinAddress(compressed: true);
            ECEncryption encryption = new ECEncryption();
            var readFileBytes = System.IO.File.ReadAllBytes(txtFileName.Text);
            byte[] encrypted = encryption.Encrypt(publicKey, readFileBytes);
            System.IO.File.WriteAllBytes("CNG", encrypted);
            //byte[] decrypted = encryption.Decrypt(privateKey, encrypted);
            //System.IO.File.WriteAllBytes(txtFileName.Text + ".new", decrypted);
            
        }

 

        //private void backgroundWorker1_RunWorkerCompleted(object sender, System.ComponentModel.RunWorkerCompletedEventArgs e)
        //{
        //    this.btnArchive.Enabled = true;
        //    this.txtFileName.Enabled = true;
        //    this.txtMessage.Enabled = true;
        //    this.chkKeywords.Enabled = true;
        //    //this.chkPrivate.Enabled = true;
        //    this.chkRecipients.Enabled = true;

        //}

        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {

            DialogResult result = openDigestFile.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                FileStream filestream;
                System.Security.Cryptography.SHA256 mySHA256 = SHA256Managed.Create();
                filestream = new FileStream(openDigestFile.FileName, FileMode.Open);
                filestream.Position = 0;
                byte[] hashValue = mySHA256.ComputeHash(filestream);
                filestream.Close();
                string strHash = BitConverter.ToString(hashValue).Replace("-", String.Empty);
                byte[] payLoadBytes = new byte[21];
                payLoadBytes[0] = coinVersion[cmbCoinType.Text];
                byte[] hashBytes = Encoding.UTF8.GetBytes(strHash.Substring(0, 20));
                hashBytes.CopyTo(payLoadBytes, 1);
                string strProofAddress = Base58.EncodeWithCheckSum(payLoadBytes);
                performTextSearch(strProofAddress);
                 
            }

        }


        private void rPCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Uri BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/info.html");
            webBrowser1.Url = BrowseURL;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
                imgOpenLeft.Visible = false;
                imgOpenRight.Visible = true;
                splitHistoryBrowser.Panel1Collapsed = true;
                Properties.Settings.Default.HideHistory = true;
                Properties.Settings.Default.Save();
        }

        private void imgOpenRight_Click(object sender, EventArgs e)
        {
            imgOpenLeft.Visible = true;
            imgOpenRight.Visible = false;
            splitHistoryBrowser.Panel1Collapsed = false;
            Properties.Settings.Default.HideHistory = false;
            Properties.Settings.Default.Save();
        }

        private void imgBackButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoBack();
        }

        private void imgNextButton_Click(object sender, EventArgs e)
        {
            webBrowser1.GoForward();
        }
        private void RefreshNavBtn()
        {
            if (webBrowser1.CanGoBack == true) { imgBackButton.Image = Properties.Resources.OpenLeft; }
            else { imgBackButton.Image = Properties.Resources.OpenLeftDisabled; }

            if (webBrowser1.CanGoForward == true) { imgNextButton.Image = Properties.Resources.OpenRight; }
            else { imgNextButton.Image = Properties.Resources.OpenRightDisabled; }

            Match match = Regex.Match(webBrowser1.Url.OriginalString, @"/([a-fA-F0-9]{64})", RegexOptions.RightToLeft);
            if (match.Success && webBrowser1.Url.OriginalString.StartsWith("file"))
             {
                 txtTransIDSearch.Text = match.Value.TrimStart('/');
             }
             else { txtTransIDSearch.Text = webBrowser1.Url.OriginalString; }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            RefreshNavBtn();
            
             if (System.IO.Directory.Exists("root\\" + txtTransIDSearch.Text))
             { imgTrash.Image = Properties.Resources.Trash; imgTrash.Enabled = true; }
             else { imgTrash.Image = Properties.Resources.TrashDisabled; imgTrash.Enabled = false; }
             
             if (webBrowser1.DocumentText == "")
             {   imgApertusSplash.Visible = true;
                 txtInfoBox.Visible = true;
                 txtTransIDSearch.ForeColor = System.Drawing.Color.Gray;
                 txtTransIDSearch.Text = "ENTER SEARCH STRING";
             }
             else
             {
                 txtInfoBox.Visible = false;
                 imgApertusSplash.Visible = false;
                 txtTransIDSearch.ForeColor = System.Drawing.Color.Black;
             }

        }

        private void imgOpenUp_Click(object sender, EventArgs e)
        {
            imgOpenUp.Visible = false;
            imgOpenDown.Visible = true;
            splitMain.Panel2Collapsed = false;
            Properties.Settings.Default.HideArchive = false;
            Properties.Settings.Default.Save();
        }

        private void imgOpenDown_Click(object sender, EventArgs e)
        {
            imgOpenUp.Visible = true;
            imgOpenDown.Visible = false;
            splitMain.Panel2Collapsed = true;
            Properties.Settings.Default.HideArchive = true;
            Properties.Settings.Default.Save();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            Uri BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/catalog.htm");
            webBrowser1.Url = BrowseURL;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string label = "";
            if (webBrowser1.Url != null)
            {
                if (!hashFavoritedList.Contains(txtTransIDSearch.Text))
                {
                    if (User.InputBox("Apertus", "Enter a label to save.", ref label) == DialogResult.OK)
                    {
                        if (File.Exists("root\\" + txtTransIDSearch.Text + "\\MSG1"))
                        {
                           label = label.PadRight(100, ' ').Substring(0, 99);
                        }
                        treeView1.Nodes["favorites"].Nodes.Add(label).Tag = txtTransIDSearch.Text;
                        StreamWriter writeFavoritesList = new StreamWriter("favorites.txt", true);
                        writeFavoritesList.WriteLine(label + txtTransIDSearch.Text);
                        writeFavoritesList.Close();
                        hashFavoritedList.Add(txtTransIDSearch.Text);
                    }
                 }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void imgTrash_Click(object sender, EventArgs e)
        {
            if (System.IO.Directory.Exists("root\\" + txtTransIDSearch.Text))
            { System.IO.Directory.Delete("root\\" + txtTransIDSearch.Text, true);
            webBrowser1.DocumentText = "";
            imgTrash.Image = Properties.Resources.TrashDisabled;
            imgTrash.Enabled = false;


            }
        }

        private string[] GetKeyWords(string message, string startsWith)
        {
            string strKeyWordAddress = null;
            char[] delimiters = new char[] { '\r', '\n', ' ' };
            string[] tokens = message.Split(delimiters);
            foreach (string token in tokens)
            {
                if (startsWith == "#" && token.StartsWith(startsWith) && token.Length < coinPayloadByteSize[cmbCoinType.Text] + 2)
                {

                    byte[] keyword = Encoding.UTF8.GetBytes(token.Substring(1).PadRight(coinPayloadByteSize[cmbCoinType.Text], Convert.ToChar(startsWith)));
                    var keyPayloadBytes = new byte[coinPayloadByteSize[cmbCoinType.Text] + 1];
                    keyPayloadBytes[0] = coinVersion[cmbCoinType.Text];
                    keyword.CopyTo(keyPayloadBytes, 1);
                    if (strKeyWordAddress == null)
                    {
                        strKeyWordAddress = Base58.EncodeWithCheckSum(keyPayloadBytes);
                    }
                    else { strKeyWordAddress = strKeyWordAddress + "," + Base58.EncodeWithCheckSum(keyPayloadBytes); }
                   
                }

                if (startsWith == "@" && token.StartsWith(startsWith))
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    var response = b.ValidateAddress(token.Substring(1,token.Length - 1));
                    if (response.isvalid)
                    {
                        if (strKeyWordAddress == null)
                        {
                            strKeyWordAddress = token.Substring(1, token.Length - 1);
                        }
                        else { strKeyWordAddress = strKeyWordAddress + "," + token.Substring(1, token.Length - 1); }
                    }
         
                }
            }
            if (strKeyWordAddress != null)
            { return strKeyWordAddress.Split(',');}
            else { return null; }
            
        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFolderList();
        }

        private void RefreshFolderList()
        {
            TreeNode node = null;
            string msgData = "";
            string datTime = null;
            if (cmbFolder.SelectedIndex > 0)
            {
                try
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    var transactions = b.ListTransactions("~" + cmbFolder.Text, 100, 0);
                    if (treeView1.Nodes["Folder"].Nodes.ContainsKey(cmbFolder.Text)) { treeView1.Nodes["Folder"].Nodes.RemoveByKey(cmbFolder.Text); }
                    node = treeView1.Nodes["Folder"].Nodes.Add(cmbFolder.Text);
                    node.Name = cmbFolder.Text;

                    foreach (var transaction in transactions)
                    {
                        msgData = "";
                        if (transaction.category == "receive")
                        {
                            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                            dateTime = dateTime.AddSeconds(transaction.blocktime);
                            dateTime = dateTime.ToLocalTime();
                            datTime = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
                            msgData = "";
                            if (System.IO.File.Exists("root//" + transaction.txid + "//MSG1"))
                            {
                                using (StreamReader reader = new StreamReader("root//" + transaction.txid + "//MSG1"))
                                {
                                    msgData = reader.ReadLine();
                                }
                            }

                            node.Nodes.Insert(0, datTime.PadRight(20, ' ') + msgData.PadRight(100, ' ').Substring(0, 100)).Tag = transaction.txid;
                        }
                    }
                    treeView1.Nodes["Folder"].Expand();
                    treeView1.Nodes["Folder"].Nodes[cmbFolder.Text].ExpandAll();

                }
                catch (Exception b)
                {
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Error: " + b.Message;
                    tmrStatusUpdate.Start();
                }

            }
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (treeView1.SelectedNode.Tag != null)
            {
                Uri uriResult = null;
                Match match = Regex.Match((string)treeView1.SelectedNode.Tag, @"([a-fA-F0-9]{64})", RegexOptions.RightToLeft);
                if (match.Success)
                {
                    txtTransIDSearch.Text = (string)treeView1.SelectedNode.Tag;
                    performTransIDSearch(true);
                }
                else
                {
                    bool isUrl = Uri.TryCreate((string)treeView1.SelectedNode.Tag, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
                    if (isUrl)
                    {
                        txtTransIDSearch.Text = (string)treeView1.SelectedNode.Tag;
                        webBrowser1.Url = uriResult;
                    }

                }
            }
        }

        private void splitContainer5_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!Loading)
            {
                Properties.Settings.Default.ArchivePanel = splitArchiveTools.SplitterDistance;
                Properties.Settings.Default.Save();
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            txtAddFolder.Visible = true;
            cmbFolder.Visible = false;
        }

        private void btnAddSignature_Click(object sender, EventArgs e)
        {
            txtAddSignature.Visible = true;
            cmbSignature.Visible = false;
        }

        private void btnAddVault_Click(object sender, EventArgs e)
        {
            txtAddVault.Visible = true;
            cmbVault.Visible = false;
        }

        private void txtAddFolder_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                     string label;
                     if (txtAddFolder.Text.LastIndexOf('~') > -1)
                     { label = txtAddFolder.Text; }
                     else { label = "~" + txtAddFolder.Text; }
                     label = a.GetNewAddress(label);
                     cmbFolder.Items.Add(txtAddFolder.Text);
                     txtAddFolder.Visible = false;
                     cmbFolder.Visible = true;
                     cmbFolder.SelectedItem = txtAddFolder.Text;
                     StreamWriter writeTrustList = new StreamWriter("trust.txt", true);
                     writeTrustList.WriteLine(label);
                     writeTrustList.Close();
                     RefreshHashCache();
                     txtAddFolder.Text = "";
                     lblStatusInfo.Text = "Folder linked to " + label;
                     tmrStatusUpdate.Start();
  
                }
                catch (Exception m)
                {
                    lblStatusInfo.Text = "Error: " + m.Message;
                    tmrStatusUpdate.Start();
                }

            }
            if (e.KeyValue == 27)
            { txtAddFolder.Text = ""; txtAddFolder.Visible = false; cmbFolder.Visible = true; }
        }

        private void txtAddSignature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    string label;
                    if (txtAddSignature.Text.LastIndexOf('~') > 0)
                    { label = txtAddSignature.Text; }
                    else { label = "~~" + txtAddSignature.Text; }
                    label = a.GetNewAddress(label);
                    cmbSignature.Items.Add(txtAddSignature.Text);
                    txtAddSignature.Visible = false;
                    cmbSignature.Visible = true;
                    cmbSignature.SelectedItem = txtAddSignature.Text;
                    StreamWriter writeTrustList = new StreamWriter("trust.txt", true);
                    writeTrustList.WriteLine(label);
                    writeTrustList.Close();
                    RefreshHashCache();
                    txtAddSignature.Text = "";
                    lblStatusInfo.Text = "Signature linked to " + label;
                    tmrStatusUpdate.Start();

                }
                catch (Exception m)
                {
                    lblStatusInfo.Text = "Error: " + m.Message;
                    tmrStatusUpdate.Start();
                }
            }
            if (e.KeyValue == 27)
            { txtAddSignature.Text = ""; txtAddSignature.Visible = false; cmbSignature.Visible = true; }
  
        }

        private void txtAddVault_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    string label;
                    if (txtAddVault.Text.LastIndexOf('~') > 1)
                    { label = txtAddVault.Text; }
                    else { label = "~~~" + txtAddVault.Text; }
                    label = a.GetNewAddress(label);
                    cmbVault.Items.Add(txtAddVault.Text);
                    txtAddVault.Visible = false;
                    cmbVault.Visible = true;
                    cmbVault.SelectedItem = txtAddVault.Text;
                    StreamWriter writeTrustList = new StreamWriter("trust.txt", true);
                    writeTrustList.WriteLine(label);
                    writeTrustList.Close();
                    RefreshHashCache();
                    txtAddVault.Text = "";
                    lblStatusInfo.Text = "Vault linked to " + label;
                    tmrStatusUpdate.Start();

                }
                catch (Exception m)
                {
                    lblStatusInfo.Text = "Error: " + m.Message;
                    tmrStatusUpdate.Start();
                }
            }
            if (e.KeyValue == 27)
            { txtAddVault.Text = ""; txtAddVault.Visible = false; cmbVault.Visible = true; }
  
        }

        private void txtMessage_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter && chkSaveOnEnter.Checked)
            {
                PerformArchive();
            }
        }

        private void splitContainer2_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!Loading)
            {
                Properties.Settings.Default.BrowserPanel = splitHistoryBrowser.SplitterDistance;
                Properties.Settings.Default.Save();
            }
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {
            if (!Loading)
            {
                Properties.Settings.Default.MainPanel = splitMain.SplitterDistance;
                Properties.Settings.Default.Save();
            }
        }

        private void Main_Shown(object sender, EventArgs e)
        {
            Loading = false;
            if (Main.ActiveForm.Width != null)
            {
                lblStatusInfo.Width = Main.ActiveForm.Width - 100;
            }
        }

        private void imgApertusSplash_Resize(object sender, EventArgs e)
        {
            if (imgApertusSplash.Height < 50) { imgApertusSplash.Visible = false; }
            else { if (webBrowser1.DocumentText == "") { imgApertusSplash.Visible = true; } }
        }

        private void cmbSignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshSignatureList();
        }

        private void RefreshSignatureList()
        {
            TreeNode node = null;
            string msgData = "";
            string datTime = null;
            if (cmbSignature.SelectedIndex > 0)
            {
                try
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    var transactions = b.ListTransactions("~~" + cmbSignature.Text, 100, 0);
                    if (treeView1.Nodes["Signature"].Nodes.ContainsKey(cmbSignature.Text)) { treeView1.Nodes["Signature"].Nodes.RemoveByKey(cmbSignature.Text); }
                    node = treeView1.Nodes["Signature"].Nodes.Add(cmbSignature.Text);
                    node.Name = cmbSignature.Text;

                    foreach (var transaction in transactions)
                    {
                        msgData = "";
                        if (transaction.category == "receive")
                        {
                            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                            dateTime = dateTime.AddSeconds(transaction.blocktime);
                            dateTime = dateTime.ToLocalTime();
                            datTime = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();

                            if (System.IO.File.Exists("root//" + transaction.txid + "//MSG1"))
                            {
                                using (StreamReader reader = new StreamReader("root//" + transaction.txid + "//MSG1"))
                                {
                                    msgData = reader.ReadLine();
                                }
                            }

                            node.Nodes.Insert(0, datTime.PadRight(20, ' ') + msgData.PadRight(100, ' ').Substring(0, 100)).Tag = transaction.txid;
                        }
                    }
                    treeView1.Nodes["Signature"].Expand();
                    treeView1.Nodes["Signature"].Nodes[cmbSignature.Text].ExpandAll();

                }
                catch (Exception b)
                {
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Error: " + b.Message;
                    tmrStatusUpdate.Start();
                }

            }
        }

        private void cmbVault_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshVaultList();
        }

        private void CreateBlockedPage(string transactionID, string reason)
        {
            try
            {
                System.IO.Directory.Delete("root\\" + transactionID, true);
                System.IO.Directory.CreateDirectory("root\\" + transactionID);
                StreamWriter newFile = new StreamWriter("root\\" + transactionID + "\\index.htm");
                newFile.WriteLine("<html><head><meta charset=\"UTF-8\" /></head><link rel=\"stylesheet\" type=\"text/css\" href=\"" + System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\root\\includes\\css.css\"><body><div class=\"main\">");
                newFile.WriteLine("<div class=\"item\"><div class=\"content\">" + reason + "</div></div>");
                newFile.WriteLine("</div></body></html>");
                newFile.Close();
                StreamWriter msgFile = new StreamWriter("root\\" + transactionID + "\\MSG1");
                msgFile.WriteLine("BLOCKED");
                msgFile.Close(); 
                StreamWriter nullFile = new StreamWriter("root\\" + transactionID + "\\ADD");
                nullFile.WriteLine("");
                nullFile.Close();   
            }
            catch { }

        }

        private void RefreshVaultList()
        {
            TreeNode node = null;
            string msgData = "";
            string datTime = null;
            if (cmbVault.SelectedIndex > 0)
            {
                try
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[cmbCoinType.Text]) + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    var transactions = b.ListTransactions("~~~" + cmbVault.Text, 100, 0);
                    if (treeView1.Nodes["Vault"].Nodes.ContainsKey(cmbVault.Text)) { treeView1.Nodes["Vault"].Nodes.RemoveByKey(cmbVault.Text); }
                    node = treeView1.Nodes["Vault"].Nodes.Add(cmbVault.Text);
                    node.Name = cmbVault.Text;

                    foreach (var transaction in transactions)
                    {
                        msgData = "";
                        if (transaction.category == "receive")
                        {
                            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                            dateTime = dateTime.AddSeconds(transaction.blocktime);
                            dateTime = dateTime.ToLocalTime();
                            datTime = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();


                            if (System.IO.File.Exists("root//" + transaction.txid + "//MSG1"))
                            {
                                using (StreamReader reader = new StreamReader("root//" + transaction.txid + "//MSG1"))
                                {
                                    msgData = reader.ReadLine();
                                }
                            }




                            node.Nodes.Insert(0, datTime.PadRight(20, ' ') + msgData.PadRight(100, ' ').Substring(0, 100)).Tag = transaction.txid;
                        }
                    }
                    treeView1.Nodes["Vault"].Expand();
                    treeView1.Nodes["Vault"].Nodes[cmbVault.Text].ExpandAll();

                }
                catch (Exception b)
                {
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Error: " + b.Message;
                    tmrStatusUpdate.Start();
                }

            }
        }

        private void splitHistoryBrowser_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void Main_LocationChanged(object sender, EventArgs e)
        {

            if (this.DesktopLocation.X > 0 && this.DesktopLocation.Y > 0)
            {
                Properties.Settings.Default.AppLocation = this.DesktopLocation.X.ToString() + "," + this.DesktopLocation.Y.ToString();
                Properties.Settings.Default.Save();
            }
        }

        private void profilesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenProfileForm));
            t.Start();
        }

        private void chkEnableRecipients_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableRecipients = chkEnableRecipients.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkKeywords_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableKeyWords = chkKeywords.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkTrackVault_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableTrackVault = chkTrackVault.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkWarnArchive_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableSaveWarning = chkWarnArchive.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkSaveOnEnter_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableEnterEqualsSave = chkSaveOnEnter.Checked;
            Properties.Settings.Default.Save();
        }

       }

}
