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
using System.ComponentModel;
using System.Drawing.Imaging;
using System.Diagnostics;


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
        public static Dictionary<string, decimal> coinTipAmount;
        public static Dictionary<string, int> coinTransactionSize;
        public static Dictionary<string, Boolean> coinEnableMonitoring;
        public static Dictionary<string, Boolean> coinFeePerAddress;
        public static Dictionary<string, Boolean> coinEnabled;
        public static Dictionary<string, Boolean> coinEnableSigning;
        public static Dictionary<string, Boolean> coinEnableTracking;
        public static Dictionary<string, string> coinHelperUrl;
        public static Dictionary<string, string> friendTransID;
        public static Dictionary<string, Boolean> coinVariablePayloadByteSize;
        public static string CoinType = "";
        public static string arcfileName = "";
        public static string arcmessage = "";
        public static string WalletLabel = "";
        public static string SignatureLabel = "";
        public static string FriendLabel = "";
        public static string VaultLabel = "";
        public static string ProfileLabel = "";
        public static string TransIDSearch = "";
        public static string ProfileID = "";
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
        HashSet<string> hashFriendList = new HashSet<string>(StringComparer.Ordinal);
        List<string> batchList = new List<string>();
        static readonly object _batchLocker = new object();
        static readonly object _buildLocker = new object();
        GlyphTypeface glyphTypeface = new GlyphTypeface(new Uri("file:///C:\\WINDOWS\\Fonts\\Arial.ttf"));
        IDictionary<int, ushort> characterMap;
        string[] infoArray;
        bool Loading = true;
        string PROLinks = "";
        string lastTransID = "";
        string strProofAddress = "";
        decimal totalTransactionCost = 0;

        public Main()
        {
            InitializeComponent();
            Startup();
            backgroundWorker1.WorkerReportsProgress = true;
            splitArchiveTools.SplitterWidth = 10;
        }

        

        public void Startup()
        {
            Tools.WebBrowserHelper.FixBrowserVersion();
            tmrProcessBatch.Start();
            characterMap = glyphTypeface.CharacterToGlyphMap;
            infoArray = "Apertus immutably stores and interprets data on blockchains.|Never build files or click links from sources you do not trust.|Send a direct message by using @ followed by Address.|Click Help, then info for assistance.|Create a Profile and start sharing your thoughts.|#keywords allow people to discover and follow your causes.|Encrypt items by creating and selecting a Vault.|Signing your archives allows people to trust you.|This is beta software use at your own risk!|Press CTRL while submitting a search to rebuild the cache.|Search by Trans ID, Address, Free Text or #Keyword|Publish your work using a profile, signature, & tip address".Split('|');
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
                CreateLedgerFile(coinPayloadByteSize[CoinType], GetRandomBuffer(coinPayloadByteSize[CoinType]), coinIP[CoinType], coinPort[CoinType], coinUser[CoinType], coinPassword[CoinType], WalletLabel, coinVersion[CoinType], coinMinTransaction[CoinType], "process\\" + processId + ".LGR", TransId, "");
            }
            else
            {
                lock (_buildLocker)
                {
                    totalTransactionCost = 0;
                    CreateArchive(TransId, CoinType, false, false, null, null, true);
                }
            }

        }

        public void CreateLedgerFile(int PayloadByteSize, string Padding, string WalletRPCIP, string WalletRPCPort, string WalletRPCUser, string WalletRPCPassword, string WalletLabel, byte CoinVersion, decimal CoinMinTransaction, string FilePath = null, string ledgerId = null, string TextMessage = null)
        {
            int HeaderPaddingSize = coinPayloadByteSize[CoinType];
            if (coinVariablePayloadByteSize[CoinType]) { HeaderPaddingSize = 10; }
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
            string lastT = null;
            string curT = null;
            string lastTransactionID = null;
            HashSet<string> addressHash = new HashSet<string>(StringComparer.Ordinal);
            string signingAddress = null;
            string line;
            int tranCount = 1;
            int ledgerCount = 0;
            string transactionId = "";
            int fileCount = 0;
            int totalMsgSize = 0;


            CoinRPC b = new CoinRPC(new Uri(GetURL(WalletRPCIP) + ":" + WalletRPCPort), new NetworkCredential(WalletRPCUser, WalletRPCPassword));
            if (coinTransactionFee[CoinType] > 0) { b.SetTXFee(coinTransactionFee[CoinType]); }

            try
            {
                if (!FilePath.ToUpper().EndsWith(".ADD"))
                {
                    if (TextMessage.Length > 0)
                    {
                        if (chkNoMessage.Checked) { TextMessage = ""; }
                        msgBytes = Encoding.UTF8.GetBytes(TextMessage);
                        cglText = GetRandomDivider() + msgBytes.Length.ToString().PadLeft(HeaderPaddingSize - 2, '0') + GetRandomDivider();
                        totalMsgSize = msgBytes.Length + cglText.Length;
                    }
                    //Links the Appropriate Profile if Profile is selected.
                    if (ProfileID != "" && Path.GetFileName(FilePath) != "SEC" && ledgerId == null) {
                        string CoinExtension = "";
                        if (coinVariablePayloadByteSize[CoinType]) { CoinExtension = "@" + coinShortName[CoinType].Substring(0, coinShortName[CoinType].IndexOf('-')); }
                        if (FilePath.Length == 0) { FilePath = ProfileID+CoinExtension; } else { FilePath = FilePath + "," + ProfileID+CoinExtension; }
                    }

                    if (FilePath.Length > 0)
                    {


                        var mergeFiles = FilePath.Split(',');
                        bool isLNKFile = false;
                        byte[] readFileBytes;
                        foreach (var f in mergeFiles)
                        {
                            //additional logic and padding to ensure text data begins at byte[0] to assist in future searching.
                            fileCount++;
                            var intCurrentSize = 0;
                            readFileBytes = null;
                            var fileName = f;
                            Match match = Regex.Match(fileName, @"([a-fA-F0-9]{64})");

                            if (match.Success)

                            {
                                if (!isLNKFile)
                                {
                                    var buildLNKFile = "";
                                    foreach (var l in mergeFiles)
                                    {
                                        var match2 = Regex.Match(l, @"([a-fA-F0-9]{64})");
                                        if (match2.Success)
                                        {
                                            buildLNKFile = buildLNKFile + l + Environment.NewLine;
                                        }
                                    }

                                    readFileBytes = Encoding.UTF8.GetBytes(buildLNKFile);
                                    fileName = "C:\\LNK";

                                }

                            }

                            if (!match.Success || (match.Success && !isLNKFile))
                            {
                                if (match.Success) { isLNKFile = true; }

                                if (readFileBytes == null) { readFileBytes = System.IO.File.ReadAllBytes(fileName); }

                                if (fileBytes != null) { intCurrentSize = fileBytes.Length; }

                                if (ledgerId != null)
                                {
                                    cglText = ledgerId + GetRandomDivider() + readFileBytes.Length.ToString() + GetRandomDivider();
                                }
                                else
                                {
                                    int totalFileSize = Path.GetFileName(fileName).Length + readFileBytes.Length.ToString().Length + readFileBytes.Length + 2;
                                    int filePadding = HeaderPaddingSize - (totalFileSize % HeaderPaddingSize);
                                    if (fileCount == mergeFiles.Length && totalMsgSize > 0)
                                    {
                                        filePadding = filePadding + (HeaderPaddingSize - (totalMsgSize % HeaderPaddingSize));
                                    }

                                    cglText = Path.GetFileName(fileName) + GetRandomDivider() + readFileBytes.Length.ToString().PadLeft(filePadding + readFileBytes.Length.ToString().Length, '0') + GetRandomDivider();
                                }

                                buffer = new byte[cglText.Length + intCurrentSize + readFileBytes.Length];
                                Encoding.UTF8.GetBytes(cglText).CopyTo(buffer, 0);
                                readFileBytes.CopyTo(buffer, cglText.Length);
                                if (fileBytes != null) { fileBytes.CopyTo(buffer, (readFileBytes.Length + cglText.Length)); }
                                fileBytes = buffer;
                            }
                        }

                        //progressBar.Maximum = fileBytes.Length;
                        //progressBar.Value = 1;
                        //progressBar.Visible = true;
                        //lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        //lblStatusInfo.Text = "Encoding data.";

                    }

                    if (TextMessage.Length > 0)
                    {
                        cglText = GetRandomDivider() + msgBytes.Length.ToString().PadLeft(HeaderPaddingSize - 2, '0') + GetRandomDivider();
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
                    if (SignatureLabel != "" && ledgerId == null)
                    {
                        CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                        //Sign and 0 pad the signature allowing the archive data to always begin at byte[0]. Allows for future file and keyword lookup
                        System.Security.Cryptography.SHA256 mySHA256 = SHA256Managed.Create();
                        byte[] hashValue = mySHA256.ComputeHash(fileBytes);
                        IEnumerable<string> Address = a.GetAddressesByAccount("~~" + SignatureLabel);
                        string signature = b.SignMessage(Address.First(), BitConverter.ToString(hashValue).Replace("-", String.Empty));
                        var sigBytes = Encoding.UTF8.GetBytes(signature);
                       

                        if (!coinVariablePayloadByteSize[CoinType])
                        {
                            int totalSigSize = sigBytes.Length + sigBytes.Length.ToString().Length + 5;
                            int zeroPadding = HeaderPaddingSize - (totalSigSize % HeaderPaddingSize);
                            cglText = "SIG" + GetRandomDivider() + sigBytes.Length.ToString().PadLeft(zeroPadding + sigBytes.Length.ToString().Length, '0') + GetRandomDivider();
                        }
                        else
                        {
                            int totalSigSize = sigBytes.Length + sigBytes.Length.ToString().Length + Address.First().Length + 6;
                            int zeroPadding = HeaderPaddingSize - (totalSigSize % HeaderPaddingSize);
                            cglText = Address.First() + ".SIG" + GetRandomDivider() + sigBytes.Length.ToString().PadLeft(zeroPadding + sigBytes.Length.ToString().Length, '0') + GetRandomDivider();

                        }
                        buffer = new byte[cglText.Length + fileBytes.Length + sigBytes.Length];
                        Encoding.UTF8.GetBytes(cglText).CopyTo(buffer, 0);
                        sigBytes.CopyTo(buffer, cglText.Length);
                        if (fileBytes != null) { fileBytes.CopyTo(buffer, (sigBytes.Length + cglText.Length)); }
                        fileBytes = buffer;

                    }

                    if (ledgerId == null && Path.GetFileName(FilePath) != "SEC" && (VaultLabel != "" || (FriendLabel != "" && btnFriendEncryption.Text == "Private")))
                    {
                        ECPoint publicKey = null;

                        if (VaultLabel != "")
                        {
                            CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                            IEnumerable<string> Address = a.GetAddressesByAccount("~~~" + VaultLabel);
                            var privKeyHex = BitConverter.ToString(Base58.Decode(a.DumpPrivateKey(Address.First()))).Replace("-", "");
                            privKeyHex = privKeyHex.Substring(2, 64);
                            BigInteger privateKey = Hex.HexToBigInteger(privKeyHex);
                            publicKey = Secp256k1.Secp256k1.G.Multiply(privateKey);

                        }
                        else
                        {

                            if (System.IO.File.Exists("root\\" + FriendLabel + "\\PRO"))
                            {
                                string readFile = System.IO.File.ReadAllText("root//" + FriendLabel + "//PRO");
                                int startx = readFile.IndexOf("PKX=") + 4;
                                int lengthx = readFile.IndexOf(Environment.NewLine, startx);
                                int starty = readFile.IndexOf("PKY=") + 4;
                                int lengthy = readFile.IndexOf(Environment.NewLine, starty);
                                if (lengthx > 10 && lengthy > 10)
                                {
                                    publicKey = new ECPoint(Hex.HexToBigInteger(readFile.Substring(startx, lengthx - startx)), Hex.HexToBigInteger(readFile.Substring(starty, lengthy - starty)));
                                }
                            }
                        }
                        ECEncryption encryption = new ECEncryption();
                        byte[] encrypted = encryption.Encrypt(publicKey, fileBytes);
                        Directory.CreateDirectory("process\\" + processId);
                        File.WriteAllBytes("process\\" + processId + "\\SEC", encrypted);
                        CreateLedgerFile(coinPayloadByteSize[CoinType], GetRandomBuffer(coinPayloadByteSize[CoinType]), coinIP[CoinType], coinPort[CoinType], coinUser[CoinType], coinPassword[CoinType], WalletLabel, coinVersion[CoinType], coinMinTransaction[CoinType], System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "\\process\\" + processId + "\\SEC", null, "");
                        return;
                    }



                    System.IO.StreamWriter arcFile = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);

                    for (int arcBytePosition = 0; arcBytePosition < fileBytes.Length; arcBytePosition++)
                    {

                        if (payloadBytePosition > coinPayloadByteSize[CoinType])
                        {
                            string EncodedBytes = "";
                           


                            if (!coinVariablePayloadByteSize[CoinType])
                            {
                                EncodedBytes = Base58.EncodeWithCheckSum(arcPayloadBytes);
                            }
                            else { EncodedBytes = Convert.ToBase64String(arcPayloadBytes); }

                            addressHash.Add(EncodedBytes);
                            arcFile.WriteLine(EncodedBytes);
                            payloadBytePosition = 1;
                            arcPayloadBytes = new byte[coinPayloadByteSize[CoinType] + 1];
                            arcPayloadBytes[0] = CoinVersion;
                        }

                        arcPayloadBytes[payloadBytePosition] = fileBytes[arcBytePosition];
                        payloadBytePosition++;


                    }

                    if (!coinVariablePayloadByteSize[CoinType])
                    {
                        for (int i = payloadBytePosition; i < PayloadByteSize; i++)
                        {
                            arcPayloadBytes[i] = arcPadding[i];
                        }
                        string EncodedBytes = Base58.EncodeWithCheckSum(arcPayloadBytes);
                        addressHash.Add(EncodedBytes);
                        arcFile.WriteLine(EncodedBytes);
                    }
                    else
                    {
                        byte[] remainingPayloadBytes = new byte[payloadBytePosition];
                        Buffer.BlockCopy(arcPayloadBytes, 0, remainingPayloadBytes, 0, remainingPayloadBytes.Length);
                       // remainingPayloadBytes[0] = CoinVersion;
                        string EncodedBytes = Convert.ToBase64String(remainingPayloadBytes);
                        addressHash.Add(EncodedBytes);
                        arcFile.WriteLine(EncodedBytes);

                    }

                    arcFile.Close();
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Encoded " + fileBytes.Length.ToString() + " bytes of data.";


                }
                else
                {
                    processId = FilePath.ToUpper().Remove(0, FilePath.Length - 40).Replace(".ADD", "");
                }

                if (SignatureLabel != "" && !coinVariablePayloadByteSize[CoinType])
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    IEnumerable<string> Address = a.GetAddressesByAccount("~~" + SignatureLabel);
                    signingAddress = Address.First();
                }


                if (chkKeywords.Checked && !coinVariablePayloadByteSize[CoinType])
                {
                    var keywords = GetKeyWords(txtMessage.Text, "#");
                    if (keywords != null)
                    {
                        foreach (string keyword in keywords)
                        {
                            var addressOnly = keyword.Split('>');
                            //allow Keyword functionality by putting keyword addresses on the end of the archive
                            if (addressOnly[0] != signingAddress)
                            {
                                if (!addressHash.Contains(addressOnly[0]))
                                {
                                    System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                                    arcSign.WriteLine(keyword);
                                    addressHash.Add(addressOnly[0]);
                                    arcSign.Close();
                                }
                            }
                        }
                    }
                }

                if (chkEnableRecipients.Checked && !coinVariablePayloadByteSize[CoinType])
                {
                    var keywords = GetKeyWords(txtMessage.Text, "@");
                    if (keywords != null)
                    {

                        foreach (string keyword in keywords)
                        {
                            var addressOnly = keyword.Split('>');
                            //allow Send to @Address functionality by putting Deliver To addresses on the end of the archive
                            if (addressOnly[0] != signingAddress)
                            {
                                if (!addressHash.Contains(addressOnly[0]))
                                {
                                    System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                                    arcSign.WriteLine(keyword);
                                    addressHash.Add(addressOnly[0]);
                                    arcSign.Close();
                                }
                            }
                        }
                    }
                }

                if (FriendLabel != "" && !coinVariablePayloadByteSize[CoinType])
                {
                    try
                    {
                        string readFile = System.IO.File.ReadAllText("root//" + cmbTo.SelectedValue + "//PRO");
                        int start = readFile.IndexOf("MSG=") + 4;
                        int length = readFile.IndexOf(Environment.NewLine, start);
                        string sendToAddress = readFile.Substring(start, length - start);
                        if (!addressHash.Contains(sendToAddress))
                        {
                            System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                            arcSign.WriteLine(sendToAddress);
                            addressHash.Add(sendToAddress);
                            arcSign.Close();
                        }

                    }
                    catch { }
                }

                if (VaultLabel != "" && chkTrackVault.Checked && !coinVariablePayloadByteSize[CoinType])
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    //allow tracking by putting a signature address on the end of the file
                    IEnumerable<string> Address = a.GetAddressesByAccount("~~~" + VaultLabel);
                    if (!addressHash.Contains(Address.First()))
                    {
                        System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                        arcSign.WriteLine(Address.First());
                        addressHash.Add(Address.First());
                        arcSign.Close();
                    }
                }

                if (strProofAddress != "" && ledgerId != null && !coinVariablePayloadByteSize[CoinType])
                {
                    //added to assist in Proof Lookups by ensuring proof address is included with Ledger etching
                    if (!addressHash.Contains(strProofAddress))
                    {
                        System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                        arcSign.WriteLine(strProofAddress);
                        addressHash.Add(strProofAddress);
                        arcSign.Close();
                    }

                }

                //Folder address should always be the last or second to the last address in the array to allow for Folder Lookups.
                if (ProfileLabel != "" && !coinVariablePayloadByteSize[CoinType])
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));

                    IEnumerable<string> Address = a.GetAddressesByAccount("~~~~" + ProfileLabel);
                    if (!addressHash.Contains(Address.First()))
                    {
                        System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                        arcSign.WriteLine(Address.First());
                        addressHash.Add(Address.First());
                        arcSign.Close();
                    }
                }

                //Signing address should always be the last address in the array to allow for Signature Lookups.
                if (SignatureLabel != "" && !coinVariablePayloadByteSize[CoinType])
                {

                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    //allow tracking by putting a signature address on the end of the file
                    System.IO.StreamWriter arcSign = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);
                    IEnumerable<string> Address = a.GetAddressesByAccount("~~" + SignatureLabel);

                    if (!addressHash.Contains(Address.First())) { arcSign.WriteLine(Address.First()); }
                    arcSign.Close();

                }



                System.IO.StreamReader readARC = new System.IO.StreamReader("process\\" + processId + ".ADD");
                System.IO.StreamWriter arcLedger = new System.IO.StreamWriter("process\\" + processId + ".LGR", true);
                GetTransactionResponse transLookup = null;

                    while ((line = readARC.ReadLine()) != null)
                    {
                    if (!coinVariablePayloadByteSize[CoinType])
                    {

                        try
                        {
                            if (line.Contains('>') && chkEnableTips.Checked)
                            {
                                var tip = line.Split('>');
                                decimal tipAmount = CoinMinTransaction;

                                try
                                {
                                    tipAmount = Convert.ToDecimal(tip[1]);
                                }
                                catch { }

                                toMany.Add(tip[0], tipAmount);
                            }
                            else
                            {
                                toMany.Add(line, CoinMinTransaction);
                            }

                        }
                        catch
                        {
                            //Cannot send to the same address more than twice in any one transaction
                            //If data is identical use previous transaction instead of archiving identical data.
                            if (lastTransaction.SequenceEqual(toMany))
                            { transactionId = lastTransactionID; }
                            else
                            {
                                if (lastTransaction.Count > 0 && toMany.Count > 0)
                                {
                                    lastT = lastTransaction.Last().Key;
                                    curT = toMany.Last().Key;
                                    //Wait for the wallet to catch up if sending to exact same address in a row.
                                    if (lastT == curT)
                                    {
                                        ledgerCount = 1;
                                        while (ledgerCount > 0)
                                        {
                                            transLookup = b.GetTransaction(lastTransactionID);
                                            if (transLookup.confirmations > 0) { ledgerCount = 0; } else { System.Threading.Thread.Sleep(5000); }
                                        }
                                    }
                                }

                                transactionId = b.SendMany(WalletLabel, toMany);
                                System.Threading.Thread.Sleep(1000);
                                ledgerCount++;
                            }

                            arcLedger.WriteLine(transactionId);
                            arcLedger.Flush();
                            lastTransaction = new Dictionary<string, decimal>(toMany);
                            lastTransactionID = transactionId;
                            toMany.Clear();

                            if (line.Contains('>'))
                            {
                                var tip = line.Split('>');
                                toMany.Add(tip[0], Convert.ToDecimal(tip[1]));
                            }
                            else
                            {
                                toMany.Add(line, CoinMinTransaction);
                            }

                            tranCount = 0;
                            
                            //Wait for the wallet to catch up.
                            while (ledgerCount > 5)
                            {
                                transLookup = b.GetTransaction(transactionId);
                                if (transLookup.confirmations > 0) { ledgerCount = 0; } else { System.Threading.Thread.Sleep(5000);}                                
                            }
                            


                        }


                        if (tranCount == coinTransactionSize[CoinType])
                        {
                            //Breaking transaction file into size specified in wallet settings


                            if (lastTransaction.Count > 0 && toMany.Count > 0)
                            {
                                lastT = lastTransaction.Last().Key;
                                curT = toMany.Last().Key;
                                //Wait for the wallet to catch up if sending to exact same address in a row.
                                if (lastT == curT)
                                {
                                    ledgerCount = 1;
                                    while (ledgerCount > 0)
                                    {
                                        transLookup = b.GetTransaction(lastTransactionID);
                                        if (transLookup.confirmations > 0) { ledgerCount = 0; } else { System.Threading.Thread.Sleep(5000); }
                                    }
                                }
                            }


                            transactionId = b.SendMany(WalletLabel, toMany);
                            System.Threading.Thread.Sleep(1000);
                            ledgerCount++;
                            arcLedger.WriteLine(transactionId);
                            arcLedger.Flush();
                            lastTransaction = new Dictionary<string, decimal>(toMany);
                            lastTransactionID = transactionId;
                            toMany.Clear();
                            tranCount = 0;

                            //Wait for the wallet to catch up.
                            while (ledgerCount > 5)
                            {
                                transLookup = b.GetTransaction(transactionId);
                                if (transLookup.confirmations > 0) { ledgerCount = 0; } else { System.Threading.Thread.Sleep(10000); }
                            }


                        }
                    }
                    else
                    {
                       
                        transactionId = b.SendData(line);
                        System.Threading.Thread.Sleep(1000);
                        ledgerCount++;
                        arcLedger.WriteLine(transactionId);
                        arcLedger.Flush();
                        lastTransactionID = transactionId;

                        //Wait for the wallet to catch up.
                        while (ledgerCount > 5)
                        {
                            transLookup = b.GetTransaction(transactionId);
                            if (transLookup.confirmations > 0) { ledgerCount = 0; } else { System.Threading.Thread.Sleep(10000); }
                        }

                    }
                    tranCount++;
                    
                    }
                    if (toMany.Count > 0)
                    {

                    if (lastTransaction.Count > 0 && toMany.Count > 0)
                    {
                        lastT = lastTransaction.Last().Key;
                        curT = toMany.Last().Key;
                        //Wait for the wallet to catch up if sending to exact same address in a row.
                        if (lastT == curT)
                        {
                            ledgerCount = 1;
                            while (ledgerCount > 0)
                            {
                                transLookup = b.GetTransaction(lastTransactionID);
                                if (transLookup.confirmations > 0) { ledgerCount = 0; } else { System.Threading.Thread.Sleep(5000); }
                            }
                        }
                    }

                    //Catching the straglers
                    transactionId = b.SendMany(WalletLabel, toMany);
                        arcLedger.WriteLine(transactionId);
                        arcLedger.Flush();
                        lastTransaction = new Dictionary<string, decimal>(toMany);
                        lastTransactionID = transactionId;
                        toMany.Clear();
                        tranCount = 0;
  
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
            if (fileBytes != null)
            {
                lblStatusInfo.Text = "Encoded " + fileBytes.Length.ToString() + " bytes of data.";
            }
            else
            {
                lblStatusInfo.Text = "Encoded something extra special.";
            }

            tmrStatusUpdate.Start();
            tmrProgressBar.Start();
            if (!chkMonitorBlockChains.Checked)
            {
                TransIDSearch = transactionId;
                performTransIDSearch(false);
            }


        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            PerformArchive();
        }

        public void PerformArchive(string coinType, string fileName, string message)
        {
            CreateLedgerFile(coinPayloadByteSize[coinType], GetRandomBuffer(coinPayloadByteSize[coinType]), coinIP[coinType], coinPort[coinType], coinUser[coinType], coinPassword[coinType], WalletLabel, coinVersion[coinType], coinMinTransaction[coinType], fileName, null, message);
        }

        public void PerformArchive()
        {
            if (chkWarnArchive.Checked)
            {
                DialogResult dialogResult = MessageBox.Show("You are about to permanently etch data on " + CoinType + "." + Environment.NewLine + "            !!! Apertus may lock up during this process !!!" + Environment.NewLine + "       Please be patient.  We will thread it better next time." + Environment.NewLine + Environment.NewLine + "NOTICE: Files or messages with repetitive data will greatly" + Environment.NewLine + "               increase the cost and time of archivng.", "Confirm Saving", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    CreateLedgerFile(coinPayloadByteSize[CoinType], GetRandomBuffer(coinPayloadByteSize[CoinType]), coinIP[CoinType], coinPort[CoinType], coinUser[CoinType], coinPassword[CoinType], WalletLabel, coinVersion[CoinType], coinMinTransaction[CoinType], txtFileName.Text, null, txtMessage.Text);
                }
                else
                {
                    return;
                }

            }
            else
            {
                CreateLedgerFile(coinPayloadByteSize[CoinType], GetRandomBuffer(coinPayloadByteSize[CoinType]), coinIP[CoinType], coinPort[CoinType], coinUser[CoinType], coinPassword[CoinType], WalletLabel, coinVersion[CoinType], coinMinTransaction[CoinType], txtFileName.Text, null, txtMessage.Text);

            }
            txtMessage.Text = "";
            txtFileName.Text = "";
            //if (cmbFolder.SelectedIndex > 0) { RefreshFolderList(); }
            //else if (cmbSignature.SelectedIndex > 0) { RefreshSignatureList(); }
            //else if (VaultLabel != "") { RefreshVaultList(); }
        }

        private void btnAttachFiles_Click(object sender, EventArgs e)
        {

            DialogResult result = attachFiles.ShowDialog();
            if (result == DialogResult.OK)
            {
                fileSize = (decimal)0;
                string fileNames = "";
                string processID = "";

                foreach (var f in attachFiles.FileNames)
                {
                    string fileName = f;
                    if (fileName.Contains(','))
                    {
                        DialogResult dialogResult = MessageBox.Show("One or more filename(s) contains special characters such as (/,). Please rename before etching.", "Notice", MessageBoxButtons.OK);
                        break;
                    }                    
                    if (chkCompressImages.Checked)
                    {

                        try
                        {
                            Bitmap bmp1 = new Bitmap(fileName);
                            if (processID == ""){ processID = Guid.NewGuid().ToString();}
                            Directory.CreateDirectory("process//" + processID);
                            ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                            System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                            EncoderParameters myEncoderParameters = new EncoderParameters(1);
                            EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 70L);
                            myEncoderParameters.Param[0] = myEncoderParameter;
                            
                            fileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\process\" + processID + @"\" + Path.GetFileNameWithoutExtension(f) + ".jpg";
                            bmp1.Save(fileName, jgpEncoder, myEncoderParameters);
                            FileInfo f1 = new FileInfo(f);
                            FileInfo f2 = new FileInfo(fileName);

                            //Files aren't always smaller especially when converting png files
                            if (f2.Length > f1.Length) { fileName = f;}
                        }
                        catch { }

                    }
                    
                    
                    if (fileNames != "") { fileNames = fileNames + ","; }
                    fileNames = fileNames + fileName;

                    var filebytes = new System.IO.FileInfo(fileName).Length;
                    fileSize = fileSize + filebytes;
                }
                txtFileName.Text = fileNames;
                updateEstimatedCost();

            }

        }

    private ImageCodecInfo GetEncoder(ImageFormat format)
{

    ImageCodecInfo[] codecs = ImageCodecInfo.GetImageDecoders();

    foreach (ImageCodecInfo codec in codecs)
    {
        if (codec.FormatID == format.Guid)
        {
            return codec;
        }
    }
    return null;
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
            this.Size = new System.Drawing.Size(Properties.Settings.Default.AppWidth, Properties.Settings.Default.AppHeight);
            btnFriendEncryption.Text = Properties.Settings.Default.DirectMessage;


            try
            {
                System.Drawing.Point windowLocation = new System.Drawing.Point(Convert.ToInt16(Properties.Settings.Default.AppLocation.Split(',').First()), Convert.ToInt16(Properties.Settings.Default.AppLocation.Split(',').Last()));
                this.DesktopLocation = windowLocation;
                splitMain.SplitterDistance = Properties.Settings.Default.MainPanel;
                chkEnableRecipients.Checked = Properties.Settings.Default.EnableRecipients;
                chkKeywords.Checked = Properties.Settings.Default.EnableKeyWords;
                chkMonitorBlockChains.Checked = Properties.Settings.Default.EnableMonitor;
                chkTrackVault.Checked = Properties.Settings.Default.EnableTrackVault;
                chkWarnArchive.Checked = Properties.Settings.Default.EnableSaveWarning;
                chkSaveOnEnter.Checked = Properties.Settings.Default.EnableEnterEqualsSave;
                chkCompressImages.Checked = Properties.Settings.Default.EnableImageCompression;
                chkEnableTips.Checked = Properties.Settings.Default.EnableTips;
                splitArchiveTools.SplitterDistance = Properties.Settings.Default.ArchivePanel;
                splitHistoryBrowser.SplitterDistance = Properties.Settings.Default.BrowserPanel;
                splitMain.Panel2Collapsed = Properties.Settings.Default.HideArchive;
                splitHistoryBrowser.Panel1Collapsed = Properties.Settings.Default.HideHistory;
                splitArchiveTools.Panel2Collapsed = Properties.Settings.Default.HideOptions;
                txtMessage.Font = Properties.Settings.Default.TextFont;
                txtMessage.ForeColor = Properties.Settings.Default.TextColor;
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

                if (Properties.Settings.Default.HideOptions)
                {
                    imgOptionsOpen.Visible = true;
                    imgOptionsClose.Visible = false;
                }
                else
                {
                    imgOptionsOpen.Visible = false;
                    imgOptionsClose.Visible = true;
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

            hashFriendList.Clear();
            if (System.IO.File.Exists("Friend.txt"))
            {
                System.IO.StreamReader readFriend = new System.IO.StreamReader("Friend.txt");
                while (!readFriend.EndOfStream)
                {
                    hashFriendList.Add(readFriend.ReadLine());
                }
                readFriend.Close();
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
                coinTipAmount = new Dictionary<string, decimal>();
                coinVariablePayloadByteSize = new Dictionary<string, bool>();
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
                    writeCoinConf.WriteLine("Bitcoin 0 20 0 .0000548 330 8332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME False False True False  BTC False   .001 False");
                    writeCoinConf.WriteLine("Bitcoin-T 111 20 0 .0000548 330 18332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False True False  BTC-T False   .001 False");
                    writeCoinConf.WriteLine("Litecoin 48 20 0 .00000001 330 9332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME False True True False  LTC False   .001 False");
                    writeCoinConf.WriteLine("Litecoin-T 111 20 0 .00001 330 19332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME False True True False  LTC-T False   .001 False");
                    writeCoinConf.WriteLine("Mazacoin 50 20 0 .000055 330 12832 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME False True True False  MZC False   .001 False");
                    writeCoinConf.WriteLine("Mazacoin-T 50 20 0 .000055 330 11832 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME False True True False  MZC-T False   .001 False");
                    writeCoinConf.WriteLine("Datacoin 30 20 0 0.05 330 11777 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False   DTC    .001 False");
                    writeCoinConf.WriteLine("Datacoin-V 30 90000 0 4.8 15 11777 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False   DTC-V    .001 True");
                    writeCoinConf.WriteLine("Datacoin-T 70 20 0 0.05 330 11777 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False   DTC-T    .001 False");
                    writeCoinConf.WriteLine("Datacoin-TV 30 90000 0 4.8 15 11777 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False   DTC-TV    .001 True");
                    writeCoinConf.WriteLine("Dogecoin 30 20 0 .00000001 330 22555 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  DOGE False   .001 False");
                    writeCoinConf.WriteLine("Anoncoin 23 20 0 .00000001 330 9376 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  ANC False   .001 False");
                    writeCoinConf.WriteLine("Devcoin 0 20 0 .0000548 330 52332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  DVC False   .001 False");
                    writeCoinConf.WriteLine("Potcoin 55 20 0 .0000548 330 42000 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False False  POT False   .001 False");
                    writeCoinConf.WriteLine("Florincoin 35 20 0 .00001 330 7317 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False False  FLC False   .001 False");
                    writeCoinConf.WriteLine("Curecoin 25 20 0 .00001 330 19911 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False False  CURE False   .001 False");
                    writeCoinConf.WriteLine("Namecoin 52 20 0 .01 330 8336 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False False  NMC False   .001 False");
                    writeCoinConf.WriteLine("Primecoin 23 20 0 .01 330 9912 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False False  XPM False   .001 False");
                    writeCoinConf.WriteLine("Primecoin-T 111 20 0 .01 330 9914 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False False  XPM-T False   .001 False");
                    writeCoinConf.WriteLine("Dash-T 139 20 0 .0001 330 19998 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False False  DASH-T False   .001 False");
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
                    writeIncludes.WriteLine("img {max-width: 400px;height: auto;}");
                    writeIncludes.WriteLine(".main{max-width: 100%;}");
                    writeIncludes.WriteLine(".main .item {margin: 5px;}");
                    writeIncludes.WriteLine(".main .item .content {word-wrap: break-word;background: #E6E6E6;color: #151515;padding: 10px;text-align: center;-webkit-border-radius:10px;-moz-border-radius:10px;border-radius:10px;}");
                    writeIncludes.WriteLine(".main .item .content table {word-break: break-all;word-wrap: break-word;padding: 10px;}");
                    writeIncludes.Close();


                    writeIncludes = new StreamWriter("root\\includes\\footer.ssi");
                    writeIncludes.WriteLine("");
                    writeIncludes.Close();
                }

                if (!System.IO.File.Exists("root\\includes\\monitor.css"))
                {
                    System.IO.StreamWriter writeIncludes = new StreamWriter("root\\includes\\monitor.css");
                    writeIncludes.WriteLine("div{border:1px solid gray;width:auto;margin-left:auto;margin-right:auto;margin-bottom:5px;max-width:1000px;overflow:auto;background-color:#fff;border-radius:10px;padding:4px}div:hover{background-color:#f5f5f5}a{color:gray;text-decoration:none;overflow-wrap:break-word;font-size:xx-small}pro img{border-radius:10px;max-width:90px;max-height:90px;margin-top:3px;margin-left:3px}section img{border-radius:10px;max-width:100%;height:auto;width:auto\\9}pro{float:left;width:96px;margin-top:10px;margin-bottom:10px;margin-left:10px}section{padding:5px;margin:10px 10px 10px 117px}body{background-color:#f5f5f5}");
                    writeIncludes.Close();
                }

                System.IO.StreamReader readCoinConf = new System.IO.StreamReader("coin.conf");
                while ((confLine = readCoinConf.ReadLine()) != null)
                {
                    string[] coins = new string[] { "Coin", "0", "20", "0", ".00000001", "330", "0000", "127.0.0.1", "RPC_USER_CHANGE_ME", "RPC_PASSWORD_CHANGE_ME", "True", "True", "False", "False", "", "", "False", "", "", ".001", "False" };
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
                    if (coins[20].ToUpper() == "TRUE") { coinVariablePayloadByteSize.Add(coins[0], true); } else { coinVariablePayloadByteSize.Add(coins[0], false); }
                    coinSigningAddress.Add(coins[0], coins[14]);
                    coinTrackingAddress.Add(coins[0], coins[17]);
                    coinHelperUrl.Add(coins[0], coins[18]);
                    coinTipAmount.Add(coins[0], decimal.Parse(coins[19]));

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
                cmbFollow.SelectedIndex = 0;
                cmbFollow.Enabled = false;
                btnAddFolder.Enabled = false;
                btnFriendEncryption.Enabled = false;
                cmbVault.SelectedIndex = 0;
                cmbVault.Enabled = false;
                btnAddVault.Enabled = false;
                cmbSignature.SelectedIndex = 0;
                cmbSignature.Enabled = false;
                btnAddSignature.Enabled = false;
                profilesToolStripMenuItem.Enabled = false;
                cmbTo.Enabled = false;
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
                    if (coinEnableSigning[CoinType]) { totalSize = totalSize + 160; }
                    //does an ok job of estimating the ledger size
                    if (totalSize > (coinPayloadByteSize[CoinType] * coinTransactionSize[CoinType]))
                    {
                        totalSize = totalSize + (((Math.Round(totalSize / coinPayloadByteSize[CoinType], 0) / coinTransactionSize[CoinType]) * 64) + 70);
                    }
                    totalTransactionCost = Math.Round(totalSize / coinPayloadByteSize[CoinType], 0) * coinMinTransaction[CoinType];
                    if (coinFeePerAddress[CoinType]) { totalTransactionCost = totalTransactionCost + ((Math.Round(totalSize / coinPayloadByteSize[CoinType], 0)) * coinTransactionFee[CoinType]); }
                    totalFeeCost = Math.Round((Math.Round(totalSize / coinPayloadByteSize[CoinType], 0) / coinTransactionSize[CoinType]), 0) * coinTransactionFee[CoinType];
                    estTotalCost = totalTransactionCost + totalFeeCost + coinTransactionFee[CoinType] + coinMinTransaction[CoinType];
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
            CoinType = cmbCoinType.Text;

            

            if (fileSize > 0 || txtMessage.TextLength > 0)
            {
                updateEstimatedCost();
            }
            lblCoinTotal.Text = "0.00000000";
            cmbWalletLabel.Items.Clear();
            cmbWalletLabel.Items.Add("Select Account");
            cmbWalletLabel.SelectedIndex = 0;
            cmbFolder.Items.Clear();
            cmbFolder.Items.Add("Profiles");
            cmbFolder.SelectedIndex = 0;
            cmbSignature.Items.Clear();
            cmbSignature.Items.Add("Signatures");
            cmbSignature.SelectedIndex = 0;
            cmbVault.Items.Clear();
            cmbVault.Items.Add("Vaults");
            cmbVault.SelectedIndex = 0;
            cmbFollow.Items.Clear();
            cmbFollow.Items.Add("Refresh Follow");
            cmbFollow.SelectedIndex = 0;

            friendTransID = new Dictionary<string, string>();
            friendTransID.Add("", "Friends");

            cmbTo.DataSource = new BindingSource(friendTransID, null);
            cmbTo.DisplayMember = "Value";
            cmbTo.ValueMember = "Key";
            cmbTo.SelectedIndex = 0;
            
            

            if (cmbCoinType.SelectedIndex > 0)
            {
                searchToolStripMenuItem.Enabled = true;

                if (System.IO.File.Exists("friend.txt"))
                {
                    System.IO.StreamReader readFriend = new System.IO.StreamReader("friend.txt");
                    string friendLine;

                    while ((friendLine = readFriend.ReadLine()) != null)
                    {
                        var friend = friendLine.Split('@');
                        if (friend[2] == coinShortName[cmbCoinType.Text])
                        {

                            try
                            { friendTransID.Add(friend[1], friend[0]); }
                            catch { }
                        }
                        
                    }
                    readFriend.Close();
                    
                }
                cmbTo.DataSource = new BindingSource(friendTransID, null);
                cmbTo.DisplayMember = "Value";
                cmbTo.ValueMember = "Key";
                cmbTo.SelectedIndex = 0;
 
                try
                {
                    CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    try
                    {
                        allAccounts = a.ListAccounts(1, true);
                    }
                    catch { allAccounts = a.ListAccounts(1); }

                    tmrStatusUpdate.Start();

                    try
                    {
                        foreach (string Account in allAccounts.Keys)
                        {
                            if (allAccounts[Account] > 0 && Account.LastIndexOf('~')<5) { cmbWalletLabel.Items.Add(Account); }
                            if (Account.LastIndexOf('~') == 3) { cmbFolder.Items.Add(Account.Substring(4)); }
                            if (Account.LastIndexOf('~') == 1) { cmbSignature.Items.Add(Account.Substring(2)); }
                            if (Account.LastIndexOf('~') == 2) { cmbVault.Items.Add(Account.Substring(3)); }
                            if (Account.LastIndexOf('~') == 5) { cmbFollow.Items.Add(Account.Substring(6)); }
                            totalValue = totalValue + allAccounts[Account];
                        }
                        lblCoinTotal.Text = totalValue.ToString();

                        var itemCountString = "";
                        if ((cmbWalletLabel.Items.Count - 1) > 1) { itemCountString = "s"; }
                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Connected: " + (cmbWalletLabel.Items.Count - 1).ToString() + " suitable account" + itemCountString + " Found";

                       

                            cmbWalletLabel.Enabled = true;
                            cmbFolder.Enabled = true;
                        if (!coinVariablePayloadByteSize[CoinType])
                        {
                            btnAddFolder.Enabled = true;
                            profilesToolStripMenuItem.Enabled = true;
                        }
                        else
                        {
                            btnAddFolder.Enabled = false;
                            profilesToolStripMenuItem.Enabled = false;
                        }
                            btnFriendEncryption.Enabled = true;
                            cmbSignature.Enabled = true;
                            btnAddSignature.Enabled = true;
                            cmbVault.Enabled = true;
                            cmbFollow.Enabled = true;
                            btnAddVault.Enabled = true;
                            cmbTo.Enabled = true;

                   


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
                        cmbFollow.SelectedIndex = 0;
                        cmbFollow.Enabled = false;
                        btnAddFolder.Enabled = false;
                        btnFriendEncryption.Enabled = false;
                        cmbSignature.SelectedIndex = 0;
                        cmbSignature.Enabled = false;
                        btnAddSignature.Enabled = false;
                        cmbVault.SelectedIndex = 0;
                        cmbVault.Enabled = false;
                        btnAddVault.Enabled = false;
                        cmbTo.Enabled = false;
                        profilesToolStripMenuItem.Enabled = false;
                        imgTip.Enabled = false;
                        imgTip.Image = Properties.Resources.TipDisabled;
                        imgFriend.Enabled = false;
                        imgFriend.Image = Properties.Resources.FriendDisabled;
                        imgLink.Enabled = false;
                        imgLink.Image = Properties.Resources.LinkDisabled;
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
                    btnFriendEncryption.Enabled = false;
                    cmbFollow.SelectedIndex = 0;
                    cmbFollow.Enabled = false;
                    cmbVault.SelectedIndex = 0;
                    cmbVault.Enabled = false;
                    btnAddVault.Enabled = false;
                    cmbSignature.SelectedIndex = 0;
                    cmbSignature.Enabled = false;
                    btnAddSignature.Enabled = false;
                    cmbTo.Enabled = false;
                    profilesToolStripMenuItem.Enabled = false;
                    imgTip.Enabled = false;
                    imgTip.Image = Properties.Resources.TipDisabled;
                    imgFriend.Enabled = false;
                    imgFriend.Image = Properties.Resources.FriendDisabled;
                    imgLink.Enabled = false;
                    imgLink.Image = Properties.Resources.LinkDisabled;
                    tmrStatusUpdate.Start();
                }

            }
            else
            {
                imgTip.Enabled = false;
                imgTip.Image = Properties.Resources.TipDisabled;
                imgFriend.Enabled = false;
                imgFriend.Image = Properties.Resources.FriendDisabled;
                imgLink.Enabled = false;
                imgLink.Image = Properties.Resources.LinkDisabled;
                profilesToolStripMenuItem.Enabled = false;
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
                WalletLabel = cmbWalletLabel.Text;
                lblCoinTotal.Text = allAccounts[WalletLabel].ToString();
                txtMessage.Enabled = true;
                txtFileName.Enabled = true;
                btnAttachFile.Enabled = true;
                proofToolStripMenuItem.Enabled = true;
                txtMessage.Select();
                if (txtMessage.TextLength < 1) { imgEnterMessageHere.Visible = true; }
                if (WalletLabel == "")
                {
                    MessageBox.Show("Accounts without a label are not supported. Assign a label using your wallet software and retry.");
                }


            }
            else
            {
                txtMessage.Enabled = false;
                txtFileName.Enabled = false;
                btnAttachFile.Enabled = false;
                proofToolStripMenuItem.Enabled = false;
                imgEnterMessageHere.Visible = false;
                btnArchive.Enabled = false;
                imgLink.Enabled = false;
                imgLink.Image = Properties.Resources.LinkDisabled;
                WalletLabel = "";


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
                {
                    lblEstimatedCost.ForeColor = System.Drawing.Color.Green;
                    if (WalletLabel != "") { btnArchive.Enabled = true; }
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

            byte[] arcPayloadBytes = null;
            int intFileSize = 80;
            string strHeader = null;
            Boolean isLedgerFile = false;
            string[] headerArray = new String[2];
            byte[] fileArray = new byte[0];

            int f = 0;
            int h = 0;


            foreach (string line in AddressArray)
            {

                if (!coinVariablePayloadByteSize[WalletKey])
                {
                    Base58.DecodeWithCheckSum(line, out arcPayloadBytes);
                }
                else { arcPayloadBytes = Convert.FromBase64String(line); }


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
                                                var transaction = b.GetRawDataTransaction(headerArray[0], 1);
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

        public Boolean ConvertAddressArrayToFile(string[] AddressArray, byte[] RawBytes, string TransID, string WalletKey, bool DisplayResults, bool? TrustLink, bool NavigateResults)
        {
            try
            {
                int intFileByteCount = 0;
                int intPayLoadSize = 0;
                int MakeUniqueFileName = 1;


                if (RawBytes == null)
                {
                    // Converting Addresses to RawBytes
                    foreach (string address in AddressArray)
                    {
                        byte[] arcPayloadBytes = null;

                        if (!coinVariablePayloadByteSize[WalletKey])
                        {
                            Base58.DecodeWithCheckSum(address, out arcPayloadBytes);
                                                            }
                        else { arcPayloadBytes = Convert.FromBase64String(address); }
                        
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
                string INQHTML = "";



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
                            if (!containsFileSize || ((RawBytes.Length - i) < intFileSize) || header[0].Count() > 555 || header[0].IndexOfAny(Path.GetInvalidFileNameChars()) > -1 || (header[0].Count() == 0 && intFileSize == 0)) {
                                if (!containsData)
                                {
                                    return false;
                                }
                                else
                                {
                                    break;
                                } 
                            }
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

                            try
                            {
                                buildFiles.Add(header[0], buildingFile);
                            }
                            catch
                            { MakeUniqueFileName++;
                            buildFiles.Add(header[0] + MakeUniqueFileName.ToString(), buildingFile);
                            }

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
                    try
                    {
                        buildFiles.Add(header[0], buildingFile);
                    }
                    catch {
                        MakeUniqueFileName++;
                        buildFiles.Add(header[0] + MakeUniqueFileName.ToString(), buildingFile);
                    }


                }

                if (intStartSignedPosition > 0)
                {
                    System.Security.Cryptography.SHA256 mySHA256 = SHA256Managed.Create();
                    byte[] hashValue = mySHA256.ComputeHash(RawBytes.Skip(intStartSignedPosition + 1).Take(intEndSignedPosition - intStartSignedPosition).ToArray());
                    var a = new CoinRPC(new Uri(GetURL(coinIP[WalletKey]) + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));
                    isSigned = a.VerifyMessage(strSigAddress, strSig, BitConverter.ToString(hashValue).Replace("-", String.Empty));

                }
                if (!isSigned && blockUnSignedContent && TrustLink == null)
                {
                    CreateBlockedPage(TransID, "Blocked due to unsigned content restrictions");
                    return true;
                }

                if (blockUntrustedContent && (!isSigned || !hashTrustedList.Contains(strSigAddress)) && TrustLink == null)
                {
                    CreateBlockedPage(TransID, "Blocked due to untrusted content restrictions");
                    return true;
                }

                if (blockBlockedListContent && hashBlockedList.Contains(strSigAddress))
                {
                    CreateBlockedPage(TransID, "Blocked due to Blocked Signer restrictions");
                    return true;
                }

                if ((trustTrustedlistContent && isSigned && hashTrustedList.Contains(strSigAddress)) || TrustLink == true)
                {
                    trustContent = true;
                }

                if (followFollowedlistContent && isSigned && hashFollowedList.Contains(strSigAddress) && TrustLink == null)
                {
                    DisplayResults = true;
                }

                if (containsData)
                {
                    FileStream fileStream = null;
                    string strHTML = "<html><head><meta charset=\"UTF-8\" /><title>" + WalletKey + " - " + TransID + "</title><meta name=\"description\" content=\"The following content was archived to the " + WalletKey + " blockchain.\" /><meta name=viewport content=\"width=device-width, initial-scale=1\"><!--#include file=\"..\\includes\\meta.ssi\" --><link rel=\"stylesheet\" type=\"text/css\" href=\"..\\includes\\css.css\"></head><body><div class=\"main\"><!--#include file=\"..\\includes\\header.ssi\" -->";

                    if (TrustLink == null)
                    {
                        Directory.CreateDirectory("root\\" + TransID);
                        fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Create);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes(strHTML), 0, strHTML.Length);
                        fileStream.Close();
                    }

                    foreach (KeyValuePair<string, byte[]> entry in buildFiles)
                    {
                        if (entry.Key == "SEC" && ( VaultLabel != "" || ProfileLabel != ""))
                        {
                            string decryptAddress = "";
                            byte[] arcPayloadBytes = new byte[coinPayloadByteSize[CoinType] + 1];
                            arcPayloadBytes[0] = coinVersion[CoinType];
                             CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
 
                            if (VaultLabel != "")
                            {
                                IEnumerable<string> Address = a.GetAddressesByAccount("~~~" + VaultLabel);
                                decryptAddress = Address.First();
                            }
                            else
                            {
                                IEnumerable<string> Address = a.GetAddressesByAccount("~~~~" + ProfileLabel);
                                decryptAddress = Address.First();
                            }

                            var privKeyHex = BitConverter.ToString(Base58.Decode(a.DumpPrivateKey(decryptAddress))).Replace("-", "");
                            privKeyHex = privKeyHex.Substring(2, 64);
                            BigInteger privateKey = Hex.HexToBigInteger(privKeyHex);
                            ECEncryption encryption = new ECEncryption();

                            try
                            {
                                byte[] decrypted = encryption.Decrypt(privateKey, entry.Value);
                                return ConvertAddressArrayToFile(AddressArray, decrypted, TransID, WalletKey, true, TrustLink, NavigateResults);
                            }
                            catch
                            {
                                lblStatusInfo.Text = "Error: Decryption failure. Check vault selection.";
                                tmrStatusUpdate.Start();
                            }
                        }
                        else
                        {
                            if (!entry.Key.Contains('.') && entry.Key.StartsWith("LNK"))
                            {
                                var LinkID = Encoding.UTF8.GetString(entry.Value).Split((Environment.NewLine.ToCharArray()));
                                foreach (string l in LinkID)
                                {

                                    Match match = Regex.Match(l, @"([a-fA-F0-9]{64})");
                                    if (match.Success)
                                    {
                                        var ForeignChain = l.Split('@');
                                        var wallet = WalletKey;
                                        if (ForeignChain.Count() > 1)
                                        {

                                            foreach (KeyValuePair<string, string> pair in coinShortName)
                                            {
                                                if (pair.Value == ForeignChain[1])
                                                {
                                                    wallet = pair.Key;
                                                    break;
                                                }
                                            }

                                        }
                                        CreateArchive(TransID, wallet, false, false, match.Value, trustContent, NavigateResults);
                                    }
                                }
                            }

                            ParseData(entry.Value, TransID, entry.Key, trustContent, (chkMonitorBlockChains.Checked & DisplayResults));

                        }
                    }
                    if (TrustLink != null) { return true; }

                    string printDate = "";
                    try
                    {
                        var b = new CoinRPC(new Uri(GetURL(coinIP[WalletKey]) + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));
                        var transaction = b.GetRawDataTransaction(TransID, 1);
                        printDate = "PENDING";
                        //place in batch queue to be tried again later.
                        if (transaction.blocktime == 0)
                        {
                            lock (_batchLocker)
                            {
                                if (!batchList.Contains(TransID + "@" + WalletKey))
                                {
                                    batchList.Add(TransID + "@" + WalletKey);
                                }
                             
                            }
                        }
                        else
                        {
                            lock (_batchLocker)
                            {
                                batchList.Remove(TransID + "@" + WalletKey);

                            }

                            System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                            dateTime = dateTime.AddSeconds(transaction.blocktime);
                            dateTime = dateTime.ToLocalTime();
                            printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
                        }
                      
                        // START CODE TO DISPLAY RESULTS OF INQ FILE

                        if (System.IO.File.Exists("root\\"+TransID + "\\INQ"))
                        {
                            string readFile = File.ReadAllText("root\\" + TransID + "\\INQ");

                            string[] INQLines = readFile.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                            string Inquiry = "";
                            string i = CoinType;
                            ValidateAddressResponse result = null;
                            Dictionary<string, int> inqCount = new Dictionary<string, int>();
                            Dictionary<string, string> inqLabels = new Dictionary<string, string>();

                            try
                            {


                                    string rootAddress = INQLines[0].Substring(0, INQLines[0].IndexOf('='));
                                    result = b.ValidateAddress(rootAddress);
                                    Inquiry = INQLines[0].Substring(INQLines[0].IndexOf('=') + 1).TrimEnd(new char[] { '\n', '\r' });




                                    if (result != null && result.isvalid)
                                    {


                                        foreach (string line in INQLines)
                                        {

                                            inqCount.Add(line.Substring(0, line.IndexOf('=')), 0);
                                            inqLabels.Add(line.Substring(0, line.IndexOf('=')), line.Substring(line.IndexOf('=') + 1).TrimEnd(new char[] { '\n', '\r' }));
                                        }

                                        if (result.account != null)
                                        {

                                            IEnumerable<ListTransactionsResponse> transactions;
                                            try { transactions = (IEnumerable<ListTransactionsResponse>)b.ListTransactions(inqLabels[rootAddress], 999999999, 0, true); }
                                            catch { transactions = (IEnumerable<ListTransactionsResponse>)b.ListTransactions(inqLabels[rootAddress], 999999999, 0); }


                                            foreach (var transact in transactions)
                                            {

                                                if (transact.category == "receive")
                                                {
                                                    var details = b.GetRawDataTransaction(transact.txid, 1);

                                                    foreach (BitcoinNET.RPCClient.GetRawDataTransactionResponse.Output detail in details.vout)
                                                    {
                                                        try { inqCount[detail.scriptPubKey.addresses[0]]++; } catch { }
                                                    }
                                                }
                                            }

                                        }
                                        else
                                        {
                                            DialogResult prompt = MessageBox.Show("A full index scan is required to include previously etched data. Do you want to perform a full index scan?", "Confirmation", MessageBoxButtons.YesNoCancel);
                                            if (prompt == DialogResult.Yes)
                                            {
                                                try
                                                {
                                                    b.ImportAddress(rootAddress, Inquiry, true);

                                                }
                                                catch (NullReferenceException)
                                                {
                                                    MessageBox.Show("A full index scan has begun. Press CTRL-ENTER to rebuild results once it has completed.", "Apertus",
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
                                                    b.ImportAddress(rootAddress, Inquiry, false);
                                                    
                                                }
                                                catch { }

                                            }
                                        }
                                    }
                                                             

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

                            INQHTML = "<div class=\"item\"><div class=\"content\"><form name=\"inqForm\"><table cellpadding=10>";
                            string strRootINQ = "";
                            foreach (var pair in inqLabels)
                            {
                                var key = pair.Key;
                                var value = pair.Value;
                                if (strRootINQ == "")
                                {
                                    strRootINQ = key;
                                    INQHTML = INQHTML + "<tr><td colspan=2>"+ value +"</td></tr>";

                                }
                                else
                                {
                                    INQHTML = INQHTML + "<tr><td><input type=\"radio\" name=\"vote\" onClick=\"document.inqForm.votescript.value = this.value;\" value = \"@" + strRootINQ + " @" + key + "\">"+ value +"</td><td>" + inqCount[key].ToString() + "</td></tr>";
                                }
                            }
                            INQHTML = INQHTML + "<tr><td>TOTAL TRANSACTIONS</td><td>" + inqCount[strRootINQ] + "</td></tr><tr><td colspan=2>ETCH THIS TO ANSWER<br><textarea name=\"votescript\" style=\"width: 100%\"></textarea></td></tr></table></form></div></div>";



                        }

               

                        //END CODE TO DISPLAY INQ FILE

                        strHTML = INQHTML + "<div class=\"item\"><div class=\"content\"><table>";
                        if (coinHelperUrl[WalletKey] != "")
                        { strHTML = strHTML + "<tr><td>ROOT ID</td></tr><tr><td><a href=\"" + coinHelperUrl[WalletKey].Replace("%s", transaction.txid) + "\">" + transaction.txid + "</a></td></tr>"; }
                        else
                        { strHTML = strHTML + "<tr><td>ROOT ID</td></tr><tr><td>" + transaction.txid + "</td></tr>"; }
                       
                        if (PROLinks != "")
                        { strHTML = strHTML + "<tr><td>PROFILES</td></tr><tr><td><div id=\"profiles\">" + PROLinks + "</div></td></tr>";
                        PROLinks = "";
                        }

                        if (isSigned)
                        { strHTML = strHTML + "<tr><td>SIGNED BY</td></tr><tr><td><a href=\"SIG\"><div id=\"signature\">" + strSigAddress + "</div></a></td></tr>"; }
                
                        strHTML = strHTML + "<tr><td>BLOCK DATE</td></tr><tr><td nowrap><div id=\"block-date\">" + printDate + "</div></td></tr>";
                        strHTML = strHTML + "<tr><td>VERSION</td></tr><tr><td>" + transaction.version + "</td></tr>";
                        strHTML = strHTML + "<tr><td>BLOCKCHAIN</td></tr><tr><td><div id=\"blockchain\">" + WalletKey + "</div></td></tr>";
                        strHTML = strHTML + "<tr><td>ADDRESS FILE</td></tr><tr><td><a href=\"ADD\">Address.dat</a></td></tr>";
                        strHTML = strHTML + "<tr><td>COST</td></tr><tr><td>"+ totalTransactionCost.ToString()+"</td></tr>";

                        if (File.Exists("root\\" + TransID + "\\LNK"))
                        { strHTML = strHTML + "<tr><td>LINK FILE</td></tr><tr><td><a href=\"LNK\">LNK</a></td></tr>"; }

                        if (Properties.Settings.Default.ReportAbuseUrl != "")
                        { strHTML = strHTML + "<tr><td align=right><a href=\"" + Properties.Settings.Default.ReportAbuseUrl.Replace("%s", transaction.txid) + "\">report abuse</a></td></tr>"; }
                        strHTML = strHTML + "<tr><td>BUILD DATE</td></tr><tr><td nowrap><div id=\"build-date\">" + DateTime.Now + "</div></td></tr>";
                        strHTML = strHTML + "<tr><td>BUILD MACHINE</td></tr><tr><td nowrap><div id=\"build-machine\">" + Environment.MachineName + "</div></td></tr>";
                        strHTML = strHTML + "</table></div></div>";
                        strHTML = strHTML + "<!--#include file=\"..\\includes\\footer.ssi\" --></div></body></html>";
                    }
                    catch {  }


                    FileStream dataFileStream = new FileStream("root\\" + TransID + "\\ADD", FileMode.Create);

                    foreach (string address in AddressArray)
                    {
                        dataFileStream.Write(UTF8Encoding.UTF8.GetBytes(address + "\n"), 0, address.Length + 1);
                    }
                    dataFileStream.Close();

                    fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strHTML), 0, strHTML.Length);
                    fileStream.Close();

                    BuildBackLinks(TransID);

                    if (DisplayResults && !chkMonitorBlockChains.Checked)
                    {
                        Uri BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/" + TransID + "/index.htm");

                        if (File.Exists("root\\" + TransID + "\\index.html"))
                        {
                            BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/" + TransID + "/index.html");
                        }
                        if (NavigateResults) { webBrowser1.Url = BrowseURL; }

                    }

                    if (!File.Exists("root\\catalog.htm")) { System.IO.File.AppendAllText("root\\catalog.htm", ""); }
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
            catch (Exception e)
            {
                lblStatusInfo.Text = "Error: " + e.Message;
                tmrStatusUpdate.Start();
                return false;
            }
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
                Match match = Regex.Match(fileText, @"([a-fA-F0-9]{64})");
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
                                        isFound = CreateArchive(match.ToString(), i, false, true, null, null, false);
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
                if (FileName.ToUpper() == "INDEX.HTM") { FileName = "Index.html"; }

                HashSet<string> safeExtensions =
               new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".gif", ".jpg", ".jpeg", ".txt", ".tiff", ".tif", ".mp3", ".mpeg", ".mpg", ".wav"
                };

                HashSet<string> embExtensions =
              new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".m2ts", ".aac", ".adt", ".adts", ".m4a", ".wmz", ".wms", ".ivf", ".cda", ".wav", ".au", ".snd", ".aif", ".aifc", ".aiff", ".mid", ".midi", ".rmi", ".ogg", ".mp2", ".mpa", ".m3u", ".wmd", ".dvr-ms", ".wpi", ".wax", ".wvx", ".wmx", ".asf", ".wma", ".wm", ".swf", ".pdf"
                };

                HashSet<string> vidExtensions =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                      ".3g2", ".3gp2", ".3gp", ".3gpp", ".aaf", ".asf", ".avchd", ".avi", ".cam", ".flv",".m1v", ".m2v", ".m4v",".mov", ".mpg", ".mpeg", ".mpe", ".mp4", ".wmv",".mp3"
                };

                HashSet<string> imgExtensions =
                new HashSet<string>(StringComparer.OrdinalIgnoreCase)
                {
                    ".jpg", ".jpeg", ".jpe", ".gif", ".png", ".tiff", ".tif", ".svg", ".svgz", ".xbm", ".bmp", ".ico"
                };


                if (chkFilterUnSafeContent.Checked && !TrustContent && !safeExtensions.Contains(Path.GetExtension(FileName)) && FileName != "PRO" && FileName != "SIG" && !FileName.EndsWith(".SIG") && FileName != "LNK")
                {
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><div id=\"file" + fileId + "\">[ " + FileName + " ]</div></div></div>";
                    foundType = true;
                    fileId++;
                }
                else
                {
                    TrustContent = true;
                }


                if (!foundType && embExtensions.Contains(Path.GetExtension(FileName)))
                {
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><embed src=\"" + HttpUtility.UrlPathEncode(FileName) + "\" /><p><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\"><div id=\"file" + fileId + "\">" + FileName + "</div></a></p></div></div>";
                    foundType = true;
                    fileId++;
                }

                if (!foundType && vidExtensions.Contains(Path.GetExtension(FileName)))
                {
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><video controls=\"controls\" width=\"1280\" height=\"720\" name=\"" + FileName + "\" src=\"" + HttpUtility.UrlPathEncode(FileName) + "\"></video><p><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\"><div id=\"vid0\">" + FileName + "</div></a></p></div></div>";
                    foundType = true;
                    fileId++;
                }

                if (!foundType && imgExtensions.Contains(Path.GetExtension(FileName)))
                {
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><img src=\"" + HttpUtility.UrlPathEncode(FileName) + "\" /><br><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\"><div id=\"img0\">" + FileName + "</div></a></div></div>";
                    foundType = true;
                    fileId++;
                }

                if (!foundType)
                {
                    if (FileName != "SIG" && !FileName.EndsWith(".SIG") && FileName != "LNK" && FileName != "PRO" && FileName != "INQ")
                    {
                        strPrintLine = "<div class=\"item\"><div class=\"content\"><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\">" + HttpUtility.UrlPathEncode(FileName) + "</a></div></div>";
                    }
                }

                if (FileName == "PRO" || FileName == "SIG" || FileName == "LNK" || FileName == "INQ")
                {
                    string readFile = Encoding.UTF8.GetString(ByteData, 0, ByteData.Length);
                    readFile = WebUtility.HtmlEncode(readFile);
                    ByteData = Encoding.UTF8.GetBytes(readFile);

                    if (FileName == "PRO")
                    {

                        string strTipAddress = "";
                        string strNickName = "";
                        string strProfileImage = "";
                        int start = 0;
                        int length = 0;

                        start = readFile.IndexOf("NIK=") + 4;
                        if (start > 3)
                        {
                            length = readFile.IndexOf(Environment.NewLine, start);
                            strNickName = readFile.Substring(start, length - start);
                        }

                        start = readFile.IndexOf("IMG=") + 4;
                        if (start > 3)
                        {
                            length = readFile.IndexOf(Environment.NewLine, start);
                            strProfileImage = readFile.Substring(start, length - start);
                        }

                        start = readFile.IndexOf("TIP=") + 4;
                        if (start > 3)
                        {
                            length = readFile.IndexOf(Environment.NewLine, start);
                            strTipAddress = readFile.Substring(start, length - start);
                        }
                        string newPro = "<div class=\"profile\"><font size=2>" + strNickName + "</font><br><img  width=80 height=80 src=\"" + strProfileImage + "\"><br><font size=1>" + strTipAddress + "</font></div>";
                        if (!PROLinks.Contains(newPro) && PROLinks.Length < 1000)
                        {
                            PROLinks = PROLinks + newPro;
                        }


                    }

                }

        

                if (TrustContent || FileName == "PRO" || FileName == "SIG")
                {
                    FileStream attachStream = null;
                    if (FileName == "LNK")
                    {
                        attachStream = new FileStream("root\\" + TransID + "\\" + FileName, FileMode.Append);
                        byte[] newline = Encoding.UTF8.GetBytes(Environment.NewLine);
                        attachStream.Write(newline, 0, newline.Length);
                    }
                    else { 
                        
                        attachStream = new FileStream("root\\" + TransID + "\\" + FileName, FileMode.Create); 
                    }

                   

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
                FileStream fileStream = new FileStream("root\\" + TransID + "\\MSG" + msgId, FileMode.Create);
                fileStream.Write(UTF8Encoding.UTF8.GetBytes(result), 0, UTF8Encoding.UTF8.GetBytes(result).Length);
                fileStream.Close();

                strPrintLine = "<div class=\"item\"><div class=\"content\"><div id=\"msg" + msgId + "\">" + result + "</div><p><a href=\"MSG" + msgId + "\">MSG" + msgId + "</a></p></div></div>";

            }
            if (strPrintLine.Length > 0)
            {
                FileStream indexStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                indexStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                indexStream.Close();
            }

            if (SendToMonitor)
            {
                Search.GetLatestArchives((int)totalResults.Value);
                var monitorURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/monitor.htm");
                webBrowser1.Url = monitorURL;
                tmrPauseBeforeRefreshingMonitor.Start();
            }


        }

        private void DisplayRecentTransactions()
        {

        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            try
            {
                lblStatusInfo.Width = Main.ActiveForm.Width - 150;
                Properties.Settings.Default.AppHeight = this.Height;
                Properties.Settings.Default.AppWidth = this.Width;
                Properties.Settings.Default.Save();
            }
            catch { }

        }

        private void tmrStatusUpdate_Tick(object sender, EventArgs e)
        {
            lblStatusInfo.Text = "Monitor: " + transactionsSearched.ToString() + " / " + transactionsFound.ToString();
            tmrStatusUpdate.Stop();
            if (chkMonitorBlockChains.Checked) { lblStatusInfo.ForeColor = System.Drawing.Color.Blue; } else { lblStatusInfo.ForeColor = System.Drawing.Color.Black; }

        }


        public Boolean CreateArchive(string TransID, string WalletKey, bool DisplayResults, bool UseCache, string LinkID, bool? TrustLink, bool NavigateResults)
        {

            string[] AddressArray = null;
            string[] LedgerArray = null;
            string TransactionID = TransID;


            if (LinkID != null) { TransactionID = LinkID; }
            else { msgId = 0; }




            if (UseCache && System.IO.Directory.Exists("root\\" + TransactionID))
            {
                Uri BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/" + TransID + "/index.htm");

                if (File.Exists("root\\" + TransID + "\\index.html"))
                {
                    BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/" + TransID + "/index.html");
                }
                if (NavigateResults) { webBrowser1.Url = BrowseURL; }
                return true;
            }
           
            try
            {
                AddressArray = CreateAddressArrayFromTransactionID(TransactionID, WalletKey);
            }
            catch { 
                return false;
            }

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

                if (System.IO.Directory.Exists("root\\" + TransactionID) && TransactionID.ToUpper() != "INCLUDES" && LinkID == null)
                {
                    System.IO.DirectoryInfo tranFolder = new DirectoryInfo("root\\" + TransactionID);

                    foreach (FileInfo file in tranFolder.GetFiles())
                    {
                        try
                        {
                            file.Delete();
                        }
                        catch
                        {

                            lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                            lblStatusInfo.Text = "Error: Unable to delete " + file.FullName;
                            tmrStatusUpdate.Start();
                        }
                    }
                }

                return ConvertAddressArrayToFile(AddressArray, null, TransID, WalletKey, DisplayResults, TrustLink, NavigateResults);
            }
            catch { return false; }

        }

        private string[] CreateAddressArrayFromTransactionID(string TransactionId, string WalletKey)
        {
            var delimiter = "";
            string addressBuilder = "";
            var arcValue = (decimal)999999999;
            

            var b = new CoinRPC(new Uri(GetURL(coinIP[WalletKey]) + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));

              try
                {
                    var transaction = b.GetRawDataTransaction(TransactionId, 1);
                    lastTransID = TransactionId;

                if (transaction.data != null && transaction.data.Length > 0)
                {
                    addressBuilder = addressBuilder + delimiter + transaction.data;
                    return addressBuilder.Split(',');
                }

                     if (transaction.vout.Length == 2)
                    {
                        if (coinMinTransaction[WalletKey] == transaction.vout[1].value) { arcValue = coinMinTransaction[WalletKey]; }
                        if (coinMinTransaction[WalletKey] == transaction.vout[0].value) { arcValue = coinMinTransaction[WalletKey]; }
                        if (arcValue == (decimal)999999999) { arcValue = transaction.vout[1].value; }
                     }
                    else
                    {
                        Dictionary<decimal, int> arcValues = new Dictionary<decimal, int>();
                        foreach (BitcoinNET.RPCClient.GetRawDataTransactionResponse.Output detail in transaction.vout)
                        {

                            if (!arcValues.ContainsKey(detail.value))
                            {
                                arcValues.Add(detail.value, 1);

                                if (detail.value == coinMinTransaction[WalletKey]) { arcValue = detail.value; }
                            }
                            else
                            { arcValues[detail.value] = arcValues[detail.value] + 1; }
                        }

                        if (arcValue == (decimal)999999999) { arcValue = arcValues.FirstOrDefault(x => x.Value == arcValues.Values.Max()).Key; }
                    }

                  
                    foreach (BitcoinNET.RPCClient.GetRawDataTransactionResponse.Output detail in transaction.vout)
                    {
                        
                        if (detail.value == arcValue)
                        {
                            totalTransactionCost = totalTransactionCost + detail.value;
                            addressBuilder = addressBuilder + delimiter + detail.scriptPubKey.addresses[0];
                            delimiter = ",";
                        }
                    }

                }
                catch (Exception e)
                {
                    try
                    {
                        var transaction = b.GetTransaction(TransactionId);
                        totalTransactionCost = totalTransactionCost + transaction.amount + transaction.fee;
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
                    catch (Exception f)
                    { }

                }

            return addressBuilder.Split(',');

        }

        private void chkMonitorBlockChains_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableMonitor = chkMonitorBlockChains.Checked;
            Properties.Settings.Default.Save();

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

                if (!chkFilterUnSafeContent.Checked)
                {
                    
                        
                        DialogResult dialogResult = MessageBox.Show("NOTICE: Monitoring with the filter disabled is crazy dangerous. Do you want to continue?", "Confirm Saving", MessageBoxButtons.YesNo);
                        if (dialogResult == DialogResult.Yes)
                        {
                            tmrGetNewTransactions.Start();
                            lblStatusInfo.ForeColor = System.Drawing.Color.Blue;
                        }
                        else { chkMonitorBlockChains.Checked = false; }
                    
                } else
                {
                    tmrGetNewTransactions.Start();
                    lblStatusInfo.ForeColor = System.Drawing.Color.Blue;
                }
                


            }
            else
            {
                tmrGetNewTransactions.Stop();
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;

            }

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
                                    totalTransactionCost = 0;
                                    CreateArchive(s, i.Key, true, false, null, null, true);
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
            fontDialog1.Font = Properties.Settings.Default.TextFont;
            fontDialog1.Color = Properties.Settings.Default.TextColor;

            if (fontDialog1.ShowDialog() != DialogResult.Cancel)
            {
                txtMessage.Font = fontDialog1.Font;
                Properties.Settings.Default.TextFont = fontDialog1.Font;
                txtMessage.ForeColor = fontDialog1.Color;
                Properties.Settings.Default.TextColor = fontDialog1.Color;
                Properties.Settings.Default.Save();
            }
        }

        private void txtTransIDSearch_KeyDown(object sender, KeyEventArgs e)
        {

            if (e.KeyValue == 13 && TransIDSearch.Length > 0)
            {
               

                if (TransIDSearch.Contains("://"))
                {
                    try
                    {
                        Uri BrowseURL = new Uri(TransIDSearch);
                        webBrowser1.Url = BrowseURL;
                        return;
                    }
                    catch
                    {
                      
                        return; }
                }

                Match match = Regex.Match(TransIDSearch, @"([a-fA-F0-9]{64})");
                if (match.Success) { performTransIDSearch(ModifierKeys != Keys.Control);
                
                }

                else
                {
                    if (TransIDSearch.StartsWith("@") || TransIDSearch.StartsWith("#"))
                    {

                        if (TransIDSearch.StartsWith("#"))
                        {
                            var safeKeyWord = TransIDSearch;
                            safeKeyWord = safeKeyWord.Replace("#", "");
                            safeKeyWord = safeKeyWord.Replace(" ", "");
                            safeKeyWord = safeKeyWord.Replace('\\', '#');
                            safeKeyWord = safeKeyWord.Replace('*', '#');
                            safeKeyWord = safeKeyWord.Replace('/', '#');
                            safeKeyWord = safeKeyWord.Replace('\'', '#');
                            safeKeyWord = safeKeyWord.Replace('>', '#');
                            safeKeyWord = safeKeyWord.Replace('<', '#');
                            safeKeyWord = safeKeyWord.Replace('|', '#');
                            safeKeyWord = safeKeyWord.Replace('.', '#');
                            performTextSearch(safeKeyWord);
                        }
                        else {performTextSearch(TransIDSearch.Replace("@", ""));}
                                       
                    }
                    else
                    {
                        Search.GetWindowsSearchResults(TransIDSearch, (int)totalResults.Value);
                        var searchURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/search.htm");
                        
                        webBrowser1.Url = searchURL;
                    }


                }
                //if (ModifierKeys == Keys.Control)
                //{
                //    if (cmbFolder.SelectedIndex > 0) { RefreshFolderList(); }
                //    else if (cmbSignature.SelectedIndex > 0) { RefreshSignatureList(); }
                //    else if (VaultLabel != "") { RefreshVaultList(); }
                //}

            }

            if (e.KeyValue == (int)Keys.Delete)
            {

                txtTransIDSearch.Text = " ENTER SEARCH STRING";
                txtTransIDSearch.ForeColor = System.Drawing.Color.LightGray;
            }

            if (e.KeyValue == (int)Keys.Back)
            {

                if (txtTransIDSearch.Text == "ENTER SEARCH STRING")
                {
                    txtTransIDSearch.Text = "ENTER SEARCH STRING";
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
            string i = CoinType;
            string addressString = searchString;
            ValidateAddressResponse result = null;


            try
            {
                if (cmbCoinType.SelectedIndex > 0)
                {
                    Match match = Regex.Match(searchString, @"^[A-Za-z0-9#+.-]{1," + coinPayloadByteSize[i].ToString() + "}$");
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
                            IEnumerable<ListTransactionsResponse> transactions;
                            try { transactions = (IEnumerable<ListTransactionsResponse>)b.ListTransactions(result.account, 500, 0, true); }
                            catch { transactions = (IEnumerable<ListTransactionsResponse>)b.ListTransactions(result.account, 500, 0); }

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
                                cmbFollow.Items.Add(searchString);
                                cmbFollow.SelectedIndex = cmbFollow.FindString(searchString);
                                
                            }
                        }
                        else
                        {
                            DialogResult prompt = MessageBox.Show("A full index scan is required to see old Transactions. Do you want to perform a full index scan?", "Confirmation", MessageBoxButtons.YesNoCancel);
                            if (prompt == DialogResult.Yes)
                            {
                                try
                                {
                                    b.ImportAddress(addressString, "~~~~~~" + searchString, true);

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
                                    b.ImportAddress(addressString, "~~~~~~" + searchString, false);
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
            Match match = Regex.Match(TransIDSearch, @"([a-fA-F0-9]{64})");
            string transID = match.Value;

            foreach (string i in cmbCoinType.Items)
            {
                if (i != "Select Blockchain" && isFound == false)
                {
                    lock (_buildLocker)
                    {
                        totalTransactionCost = 0;
                        isFound = CreateArchive(transID, i, true, useCache, null, null, true);
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
            if (txtTransIDSearch.Text == "ENTER SEARCH STRING")
            {
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
                payLoadBytes[0] = coinVersion[CoinType];
                byte[] hashBytes = Encoding.UTF8.GetBytes(strHash.Substring(0, coinPayloadByteSize[CoinType]));
                hashBytes.CopyTo(payLoadBytes, 1);
                strProofAddress = Base58.EncodeWithCheckSum(payLoadBytes);

                CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                try
                {
                    a.ImportAddress(strProofAddress, openDigestFile.FileName, false);
                }
                catch
                {

                    DialogResult dialogResult = MessageBox.Show("This blockchain does not support file proof Lookups at this time. Consider setting up a tracking address in the wallet settings BEFORE inserting the proof. Do you wish to continue?", "Limited functions", MessageBoxButtons.YesNo);
                    if (dialogResult == DialogResult.No)
                    {
                        strProofAddress = "";
                        return;
                    }
                }

                CreateLedgerFile(coinPayloadByteSize[CoinType], GetRandomBuffer(coinPayloadByteSize[CoinType]), coinIP[CoinType], coinPort[CoinType], coinUser[CoinType], coinPassword[CoinType], WalletLabel, coinVersion[CoinType], coinMinTransaction[CoinType], txtFileName.Text, null, strHash + "\n" + txtMessage.Text);
                strProofAddress = "";
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
                            totalTransactionCost = 0;
                            isFound = CreateArchive(transID, i, true, false, null, null, true);
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
                    try
                    {
                        lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                        lblStatusInfo.Text = "Not found in linked Blockchains.";
                        tmrStatusUpdate.Start();
                    }
                    catch { }
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
         

            lock (_batchLocker)
            {
                try
                {
                    System.IO.StreamReader readBatch = new System.IO.StreamReader("root\\batch.txt");
                    while ((batchLine = readBatch.ReadLine()) != null)
                    {
                        batchList.Add(batchLine);
                    }
                    readBatch.Close();
                    System.IO.File.Delete("root\\batch.txt");
                }
                catch { }
            }

            List<string> batchBatchList = new List<string>(batchList);
            foreach (string transIDKey in batchBatchList)
            {
                var transArray = transIDKey.Split('@');
                try
                {
                    lock (_buildLocker)
                    {
                        totalTransactionCost = 0;
                        CreateArchive(transArray[0], transArray[1], false, false, null, null, true);
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

        }


        private void searchToolStripMenuItem_Click(object sender, EventArgs e)
        {



        }

        private void searchByFile()
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
                payLoadBytes[0] = coinVersion[CoinType];
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
            imgOpenUp.Refresh();
            imgOpenRight.Refresh();
            if (webBrowser1.CanGoBack == true) { imgBackButton.Image = Properties.Resources.OpenLeft; }
            else { imgBackButton.Image = Properties.Resources.OpenLeftDisabled; }

            if (webBrowser1.CanGoForward == true) { imgNextButton.Image = Properties.Resources.OpenRight; }
            else { imgNextButton.Image = Properties.Resources.OpenRightDisabled; }

            Match match = Regex.Match(webBrowser1.Url.OriginalString, @"/([a-fA-F0-9]{64})", RegexOptions.RightToLeft);
            if (match.Success && webBrowser1.Url.OriginalString.StartsWith("file"))
            {
                txtTransIDSearch.Text = webBrowser1.Url.OriginalString.Substring(match.Index + 1).Replace(@"/index.html", "").Replace(@"/index.htm", "");

            }
            else {
                if (!webBrowser1.Url.OriginalString.Contains(@"/monitor.htm") && !webBrowser1.Url.OriginalString.Contains(@"/search.htm"))
                {
                    txtTransIDSearch.Text = webBrowser1.Url.OriginalString;
                }
                else
                {
                    if (webBrowser1.Url.OriginalString.Contains(@"/monitor.htm"))
                    {
                        txtTransIDSearch.Text = "ENTER SEARCH STRING";
                        txtTransIDSearch.ForeColor = System.Drawing.Color.LightGray;
                    }
                }


            }
        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            RefreshNavBtn();

            Match match = Regex.Match(TransIDSearch, @"([a-fA-F0-9]{64})");
            var transID = match.Value;
            if (match.Success && System.IO.Directory.Exists("root\\" + transID))
            {
                imgTrash.Image = Properties.Resources.Trash;
                imgTrash.Enabled = true;
                if (cmbCoinType.SelectedIndex > 0)
                {
                    imgLink.Image = Properties.Resources.Link;
                    imgLink.Enabled = true;
                }
            }
            else
            {
                imgTrash.Image = Properties.Resources.TrashDisabled;
                imgTrash.Enabled = false;
                imgLink.Image = Properties.Resources.LinkDisabled;
                imgLink.Enabled = false;
            }

            if (match.Success && System.IO.File.Exists("root\\" + transID + "\\PRO") && cmbCoinType.SelectedIndex > 0)
            {
                string readFile = System.IO.File.ReadAllText("root//" + match.Value + "//PRO");
                int start = readFile.IndexOf("TIP=") + 4;
                int length = readFile.IndexOf(Environment.NewLine, start);
                if (length > 10)
                {
                    imgTip.Image = Properties.Resources.Tip;
                    imgTip.Enabled = true;
                }
                else
                {
                    imgTip.Image = Properties.Resources.TipDisabled;
                    imgTip.Enabled = false;
                }

                imgFriend.Image = Properties.Resources.Friend;
                imgFriend.Enabled = true;
            }
            else
            {
                imgTip.Image = Properties.Resources.TipDisabled;
                imgTip.Enabled = false;
                imgFriend.Image = Properties.Resources.FriendDisabled;
                imgFriend.Enabled = false;
            }

            if (webBrowser1.DocumentText == "")
            {
                imgApertusSplash.Visible = true;
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
            //Uri BrowseURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/root/catalog.htm");
            //webBrowser1.Url = BrowseURL;

            Search.GetLatestArchives((int)totalResults.Value);
            var monitorURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/monitor.htm");
            webBrowser1.Url = monitorURL;
        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {
            string label = "";
            if (webBrowser1.Url != null)
            {
                if (!hashFavoritedList.Contains(TransIDSearch))
                {
                    if (User.InputBox("Apertus", "Enter a label to save.", ref label) == DialogResult.OK)
                    {
                        label = label.PadRight(100, ' ').Substring(0, 99);
                        treeView1.Nodes["favorites"].Nodes.Add(label).Tag = TransIDSearch;
                        StreamWriter writeFavoritesList = new StreamWriter("favorites.txt", true);
                        writeFavoritesList.WriteLine(label + TransIDSearch);
                        writeFavoritesList.Close();
                        hashFavoritedList.Add(TransIDSearch);
                    }
                }
            }
        }

        private void treeView1_DoubleClick(object sender, EventArgs e)
        {


        }

        private void imgTrash_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(TransIDSearch, @"([a-fA-F0-9]{64})");
            if (match.Success)
            {
                if (System.IO.Directory.Exists("root\\" + match.Value))
                {
                    System.IO.Directory.Delete("root\\" + match.Value, true);
                    webBrowser1.DocumentText = "";
                    imgTrash.Image = Properties.Resources.TrashDisabled;
                    imgTrash.Enabled = false;


                }
            }
        }

        private string[] GetKeyWords(string message, string startsWith)
        {
            string strKeyWordAddress = null;
            char[] delimiters = new char[] { '\r', '\n', ':', ';', ' ', ',', '\'','\'','!','?','.' };
            string[] tokens = message.Split(delimiters);
            string safeKeyWord = "";
            foreach (string token in tokens)
            {
                if (startsWith == "#" && token.StartsWith(startsWith) && token.Length < coinPayloadByteSize[CoinType] + 2)
                {
                    //prevents characters that may be considered new files from being used as keywords and corrupting a file.
                    safeKeyWord = token.Replace('\\', '#');
                    safeKeyWord = safeKeyWord.Replace('*', '#');
                    safeKeyWord = safeKeyWord.Replace('/', '#');
                    safeKeyWord = safeKeyWord.Replace('\'', '#');
                    safeKeyWord = safeKeyWord.Replace('>', '#');
                    safeKeyWord = safeKeyWord.Replace('<', '#');
                    safeKeyWord = safeKeyWord.Replace('|', '#');

                    
                    byte[] keyword = Encoding.UTF8.GetBytes(safeKeyWord.Substring(1).PadRight(coinPayloadByteSize[CoinType], Convert.ToChar(startsWith)));
                    var keyPayloadBytes = new byte[coinPayloadByteSize[CoinType] + 1];
                    keyPayloadBytes[0] = coinVersion[CoinType];
                    keyword.CopyTo(keyPayloadBytes, 1);
                    if (strKeyWordAddress == null)
                    {
                        strKeyWordAddress = Base58.EncodeWithCheckSum(keyPayloadBytes);
                    }
                    else { strKeyWordAddress = strKeyWordAddress + "," + Base58.EncodeWithCheckSum(keyPayloadBytes); }

                }

                if (startsWith == "@" && token.StartsWith(startsWith))
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    var addressArray = token.Substring(1).Split('>');
                    string addressOnly = addressArray[0];
                    var response = b.ValidateAddress(addressOnly);
                    if (response.isvalid)
                    {
                        if (strKeyWordAddress == null)
                        {
                            strKeyWordAddress = token.Substring(1);
                        }
                        else { strKeyWordAddress = strKeyWordAddress + "," + token.Substring(1); }
                    }
                    else
                    {
                        
                        if (friendTransID.ContainsValue(token.Substring(1)))
                        {
                            var keysWithMatchingValues = friendTransID.Where(p => p.Value == token.Substring(1)).Select(p => p.Key);
                            string TransId = "";
                            foreach (var key in keysWithMatchingValues)
                            { TransId = key;
                            break;
                            }
                             
                            
                            string readFile = System.IO.File.ReadAllText("root//" + TransId + "//PRO");
                            int start = readFile.IndexOf("MSG=") + 4;
                            int length = readFile.IndexOf(Environment.NewLine, start);
                            string sendToAddress = readFile.Substring(start, length - start);
                            if (strKeyWordAddress == null)
                            {
                                strKeyWordAddress = sendToAddress;
                            }
                            else { strKeyWordAddress = strKeyWordAddress + "," + sendToAddress; }

                        }
                    }

                }
            }
            if (strKeyWordAddress != null)
            { return strKeyWordAddress.Split(','); }
            else { return null; }

        }

        private void cmbFolder_SelectedIndexChanged(object sender, EventArgs e)
        {
            ProfileID = "";
            RefreshFolderList();
            if (cmbFolder.SelectedIndex > 0)
            {
                ProfileLabel = cmbFolder.Text;
                btnExportProfile.Enabled = true;
            }
            else
            {
                ProfileLabel = "";
                ProfileID = "";
                btnExportProfile.Enabled = false;
            }
        }

        private void RefreshFolderList()
        {
            TreeNode node = null;
            string msgData = "";
            string lstTransID = "";
            string datTime = null;
            List<string> followResults = new List<string>();
            if (cmbFolder.SelectedIndex > 0)
            {
                try
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    var transactions = b.ListTransactions("~~~~" + cmbFolder.Text, 500, 0);
                    if (treeView1.Nodes["Profile"].Nodes.ContainsKey(cmbFolder.Text)) { treeView1.Nodes["Profile"].Nodes.RemoveByKey(cmbFolder.Text); }
                    node = treeView1.Nodes["Profile"].Nodes.Add(cmbFolder.Text);
                    node.Name = cmbFolder.Text;

                    foreach (var transaction in transactions)
                    {
                        msgData = "";
                        lstTransID = transaction.txid;
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
                            followResults.Add(transaction.txid);
                        }
                    }
                    treeView1.Nodes["Profile"].Expand();
                    treeView1.Nodes["Profile"].Nodes[cmbFolder.Text].ExpandAll();
                    followResults.Reverse();
                    Search.DisplayResultsByTransactionID(followResults);
                    var searchURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/follow.htm");
                    webBrowser1.Url = searchURL;

                    if (System.IO.File.Exists("root//" + lstTransID + "//PRO"))
                    {
                        imgTip.Image = Properties.Resources.Tip;
                        imgTip.Enabled = true;

                    }
                    else
                    {
                        imgTip.Image = Properties.Resources.TipDisabled;
                        imgTip.Enabled = false;
                    }


                    transactions = b.ListTransactions("~~~~" + cmbFolder.Text, 1000, 0);

                    foreach (var transaction in transactions.Reverse())
                    {
                        if (transaction.category == "receive")
                        {
                            lock (_buildLocker)
                            {
                                totalTransactionCost = 0;
                                var mainForm = Application.OpenForms.OfType<Main>().Single();
                                if (mainForm.CreateArchive(transaction.txid, Main.CoinType, false, true, null, null, false))
                                {
                                    if (System.IO.File.Exists("root//" + transaction.txid + "//PRO"))
                                    {

                                        var doc = new HtmlAgilityPack.HtmlDocument();
                                        doc.Load("root\\" + transaction.txid + "\\index.htm");
                                        if (doc.GetElementbyId("signature") != null)
                                        {

                                            var signature = doc.GetElementbyId("signature").InnerText;
                                            if (transaction.address == signature)
                                            {
                                                ProfileID = transaction.txid;
                                                break;
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }





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
                        TransIDSearch = (string)treeView1.SelectedNode.Tag;
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
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenProfileForm));
            t.Start();
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



        private void txtAddSignature_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13 && txtAddSignature.Text.Length > 0)
            {
                try
                {

                    Match match = Regex.Match(txtAddSignature.Text, @"([a-zA-Z0-9]{51,})");
                    if (match.Success)
                    {
                        string label = "";
                        if (User.InputBox("Apertus", "Enter label to import key.", ref label) == DialogResult.OK)
                        {
                            CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                            var result = a.ImportPrivateKey(txtAddSignature.Text, "~~" + label, false);
                            cmbSignature.Items.Add(label);
                            txtAddSignature.Text = "";
                            txtAddSignature.Visible = false;
                            cmbSignature.Visible = true;
                            cmbSignature.SelectedItem = label;

                        }
                    }
                    else
                    {

                        CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
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
            if (e.KeyValue == 13 && txtAddVault.Text.Length > 0)
            {
                try
                {
                    
                    Match match = Regex.Match(txtAddVault.Text, @"([a-zA-Z0-9]{51,})");
                    if (match.Success)
                    {
                        string label = "";
                        if (User.InputBox("Apertus", "Enter label to import key.", ref label) == DialogResult.OK)
                        {
                            CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                            var result = a.ImportPrivateKey(txtAddVault.Text, "~~~" + label, false);
                            cmbVault.Items.Add(label);
                            txtAddVault.Text = "";
                            txtAddVault.Visible = false;
                            cmbVault.Visible = true;
                            cmbVault.SelectedItem = label;

                        }
                    }
                    else
                    {

                        CoinRPC a = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
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
            try
            {
                if (Main.ActiveForm.Width > 0)
                {
                    lblStatusInfo.Width = Main.ActiveForm.Width - 100;
                }
            }
            catch { }
        }

        private void imgApertusSplash_Resize(object sender, EventArgs e)
        {
            if (imgApertusSplash.Height < 50) { imgApertusSplash.Visible = false; }
            else { if (webBrowser1.DocumentText == "") { imgApertusSplash.Visible = true; } }
        }

        private void cmbSignature_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (cmbSignature.SelectedIndex > 0)
            {
                SignatureLabel = cmbSignature.Text;
                btnExportSignature.Enabled = true;
            }
            else
            {
                SignatureLabel = "";
                btnExportSignature.Enabled = false;
            }
            RefreshSignatureList();
        }

        private void RefreshSignatureList()
        {
            TreeNode node = null;
            string msgData = "";
            string datTime = null;
            List<string> followResults = new List<string>();
            if (cmbSignature.SelectedIndex > 0)
            {
                try
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    var transactions = b.ListTransactions("~~" + cmbSignature.Text, 500, 0);
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
                            followResults.Add(transaction.txid);
                        }
                    }
                    treeView1.Nodes["Signature"].Expand();
                    treeView1.Nodes["Signature"].Nodes[cmbSignature.Text].ExpandAll();
                    followResults.Reverse();
                    Search.DisplayResultsByTransactionID(followResults);
                    var searchURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/follow.htm");
                    webBrowser1.Url = searchURL;


                }
                catch (Exception b)
                {
                    lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                    lblStatusInfo.Text = "Error: " + b.Message;
                    tmrStatusUpdate.Start();
                }

            }
        }


        private void RefreshFollowList()
        {
            TreeNode node = null;
            string msgData = "";
            string datTime = null;
            List<string> followResults = new List<string>();
            if (cmbFollow.SelectedIndex > 0)
            {
                try
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    var transactions = b.ListTransactions("~~~~~~" + cmbFollow.Text, 500, 0, true);
                    if (treeView1.Nodes["Follow"].Nodes.ContainsKey(cmbFollow.Text)) { treeView1.Nodes["Follow"].Nodes.RemoveByKey(cmbFollow.Text); }
                    node = treeView1.Nodes["Follow"].Nodes.Add(cmbFollow.Text);
                    node.Name = cmbFollow.Text;

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
                            followResults.Add(transaction.txid);
                            node.Nodes.Insert(0, datTime.PadRight(20, ' ') + msgData.PadRight(100, ' ').Substring(0, 100)).Tag = transaction.txid;
                        }
                    }
                    treeView1.Nodes["Follow"].Expand();
                    treeView1.Nodes["Follow"].Nodes[cmbFollow.Text].ExpandAll();
                    followResults.Reverse();
                    Search.DisplayResultsByTransactionID(followResults);
                    var searchURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/follow.htm");
                    webBrowser1.Url = searchURL;

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
            
            if (cmbVault.SelectedIndex > 0)
            {
                VaultLabel = cmbVault.Text;
                btnExportVault.Enabled = true;
            }
            else
            {
                VaultLabel = "";
                btnExportVault.Enabled = false;
            }
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
            List<string> followResults = new List<string>();
            if (VaultLabel != "")
            {
                try
                {
                    var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                    var transactions = b.ListTransactions("~~~" + VaultLabel, 500, 0);
                    if (treeView1.Nodes["Vault"].Nodes.ContainsKey(VaultLabel)) { treeView1.Nodes["Vault"].Nodes.RemoveByKey(VaultLabel); }
                    node = treeView1.Nodes["Vault"].Nodes.Add(VaultLabel);
                    node.Name = VaultLabel;

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
                            followResults.Add(transaction.txid);
                        }
                    }
                    treeView1.Nodes["Vault"].Expand();
                    treeView1.Nodes["Vault"].Nodes[VaultLabel].ExpandAll();
                    followResults.Reverse();
                    Search.DisplayResultsByTransactionID(followResults);
                    var searchURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/follow.htm");
                    webBrowser1.Url = searchURL;

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

        private void imgLink_Click(object sender, EventArgs e)
        {
          
                Match match = Regex.Match(TransIDSearch, @"([a-fA-F0-9]{64})");
                string fileName = "";
                if (match.Success && !txtFileName.Text.Contains(match.Value))
                {
                    try
                    {
                        fileName = match.Value;
                        var doc = new HtmlAgilityPack.HtmlDocument();
                        doc.Load("root\\" + fileName + "\\index.htm");
                        var blockchain = doc.GetElementbyId("blockchain").InnerText;
                        if (CoinType != blockchain)
                        { fileName = fileName + "@" + coinShortName[blockchain]; }
                    }
                    catch { }

                    if (txtFileName.Text == "") { txtFileName.Text = fileName; }
                    else { txtFileName.Text = txtFileName.Text + "," + fileName; }
                }
     


            
        }

        private void fileToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            searchByFile();
        }

        //private void cmbTo_KeyDown(object sender, KeyEventArgs e)
        //{
        //    if (cmbTo.Text == "TO:")
        //    { cmbTo.Text = ""; }
        //}

        //private void cmbTo_SelectedIndexChanged(object sender, EventArgs e)
        //{

        //}

        //private void cmbTo_MouseClick(object sender, MouseEventArgs e)
        //{
        //    if (cmbTo.Text == "TO:")
        //    { cmbTo.Text = ""; }
        //}

        private void hashToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string hash = "";
            if (User.InputBox("Apertus", "Enter Hash to search.", ref hash) == DialogResult.OK)
            {
                byte[] payLoadBytes = new byte[21];
                payLoadBytes[0] = coinVersion[CoinType];
                byte[] hashBytes = Encoding.UTF8.GetBytes(hash.Substring(0, 20));
                hashBytes.CopyTo(payLoadBytes, 1);
                string strProofAddress = Base58.EncodeWithCheckSum(payLoadBytes);
                performTextSearch(strProofAddress);
            }
        }

        private void imgTip_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(TransIDSearch, @"([a-fA-F0-9]{64})");
             if (match.Success)
             {
                 if (File.Exists("root//" + match.Value + "//PRO"))
            {
                string readFile = System.IO.File.ReadAllText("root//" + match.Value + "//PRO");

                int start = readFile.IndexOf("TIP=") + 4;
                if (start > 3)
                {
                    int length = readFile.IndexOf(Environment.NewLine, start);
                    txtMessage.Text = txtMessage.Text + Environment.NewLine + " A Tip @" + readFile.Substring(start, length - start) + ">" + coinTipAmount[CoinType];
                }
            }
             }
        }


        private void txtTransIDSearch_TextChanged(object sender, EventArgs e)
        {
            TransIDSearch = txtTransIDSearch.Text;
        }


        private void imgFriend_Click(object sender, EventArgs e)
        {
            Match match = Regex.Match(TransIDSearch, @"([a-fA-F0-9]{64})");
            if (match.Success)
            {
                if (File.Exists("root//" + match.Value + "//PRO"))
                {

                    var doc = new HtmlAgilityPack.HtmlDocument();
                    doc.Load("root\\" + match.Value + "\\index.htm");
                    var blockchain = doc.GetElementbyId("blockchain").InnerText;
                    var fileName = match.Value + "@" + coinShortName[blockchain];


                    string readFile = System.IO.File.ReadAllText("root//" + match.Value + "//PRO");
                    int start = readFile.IndexOf("NIK=") + 4;
                    int length = readFile.IndexOf(Environment.NewLine, start);
                    string strNickName = readFile.Substring(start, length - start);


                    if (!hashFriendList.Contains(strNickName + "@" + fileName))
                    {
                        hashFriendList.Add(strNickName + "@" + fileName);
                        StreamWriter writeFriendList = new StreamWriter("Friend.txt", true);
                        writeFriendList.WriteLine(strNickName + "@" + fileName);
                        writeFriendList.Close();

                        friendTransID.Add(fileName.Substring(0,fileName.IndexOf('@')), strNickName);
                        cmbTo.DataSource = new BindingSource(friendTransID, null);
                        cmbTo.DisplayMember = "Value";
                        cmbTo.ValueMember = "Key";

                    }
                    //select what was clicked on.
                    cmbTo.SelectedIndex = cmbTo.FindString(strNickName);

                }
            }
        }
        public void AddProfile(string label)
        {
                this.Invoke(new MethodInvoker(delegate() {cmbFolder.Items.Add(label); cmbFolder.SelectedItem = label;}));
        }

        private void btnExportProfile_Click(object sender, EventArgs e)
        {

            try
            {
                var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                var strAddress = b.GetAddressesByAccount("~~~~" + cmbFolder.Text);
                Clipboard.SetText(b.DumpPrivateKey(strAddress.First()));
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "A private Key has been copied to the clipboard!";
                tmrStatusUpdate.Start();
            }
            catch (Exception x)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Error: " + x.Message;
                tmrStatusUpdate.Start();
            }
            
        }

        private void btnExportSignature_Click(object sender, EventArgs e)
        {
            try
            {
                var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                var strAddress = b.GetAddressesByAccount("~~" + cmbSignature.Text);
                Clipboard.SetText(b.DumpPrivateKey(strAddress.First()));
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "A private Key has been copied to the clipboard!";
                tmrStatusUpdate.Start();
            }
            catch (Exception x)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Error: " + x.Message;
                tmrStatusUpdate.Start();
            }
            
        }

        private void btnExportVault_Click(object sender, EventArgs e)
        {
            try
            {
                var b = new CoinRPC(new Uri(GetURL(coinIP[CoinType]) + ":" + coinPort[CoinType]), new NetworkCredential(coinUser[CoinType], coinPassword[CoinType]));
                var strAddress = b.GetAddressesByAccount("~~~" + cmbVault.Text);
                Clipboard.SetText(b.DumpPrivateKey(strAddress.First()));
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "A private Key has been copied to the clipboard!";
                tmrStatusUpdate.Start();
            }
            catch (Exception x)
            {
                lblStatusInfo.ForeColor = System.Drawing.Color.Black;
                lblStatusInfo.Text = "Error: " + x.Message;
                tmrStatusUpdate.Start();
            }
        }

        private void tmrPauseBeforeRefreshingMonitor_Tick(object sender, EventArgs e)
        {
            Search.GetLatestArchives((int)totalResults.Value);
            var monitorURL = new Uri(System.IO.Path.GetDirectoryName(Application.ExecutablePath) + "/monitor.htm");
            webBrowser1.Url = monitorURL;
            tmrPauseBeforeRefreshingMonitor.Stop();
        }

        private void chkCompressImages_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableImageCompression = chkCompressImages.Checked;
            Properties.Settings.Default.Save();
        }

        private void chkEnableTips_CheckedChanged(object sender, EventArgs e)
        {
            Properties.Settings.Default.EnableTips = chkEnableTips.Checked;
            Properties.Settings.Default.Save();

        }

        private void cmbFollow_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshFollowList();
        }

        private void cmbTo_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (cmbTo.SelectedIndex > 0)
            {
                FriendLabel = cmbTo.SelectedValue.ToString();
            }
            else
            { FriendLabel = ""; }
        }

  
        private void btnFriendEncryption_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.DirectMessage == "Public")
            { Properties.Settings.Default.DirectMessage = "Private"; }
            else { Properties.Settings.Default.DirectMessage = "Public"; }
            Properties.Settings.Default.Save();

            btnFriendEncryption.Text = Properties.Settings.Default.DirectMessage;
        }

        private void pictureBox1_Click_1(object sender, EventArgs e)
        {
            imgOptionsOpen.Visible = true;
            imgOptionsClose.Visible = false;
            splitArchiveTools.Panel2Collapsed= true;
            Properties.Settings.Default.HideOptions = true;
            Properties.Settings.Default.Save();
        }

        private void imgOptionsOpen_Click(object sender, EventArgs e)
        {
            imgOptionsClose.Visible = true;
            imgOptionsOpen.Visible = false;
            splitArchiveTools.Panel2Collapsed = false;
            Properties.Settings.Default.HideOptions = false;
            Properties.Settings.Default.Save();
        }

        private void imgOpenInBrowserButton_Click(object sender, EventArgs e)
        {
            if (webBrowser1.Url != null)
            {
                Process.Start(webBrowser1.Url.ToString());
            }
        }
    }

}
