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
using ADD.Bitcoin;
using ADD.RPCClient;
using ADD.Tools;
using Microsoft.Security.Application;


namespace ADD
{
    public partial class Main : Form
    {

        public static Dictionary<string, byte> coinVersion;
        public static Dictionary<string, int> coinPayloadByteSize;
        public static Dictionary<string, string> coinPort;
        public static Dictionary<string, string> coinIP;
        public static Dictionary<string, string> coinUser;
        public static Dictionary<string, string> coinPassword;
        public static Dictionary<string, decimal> coinTransactionFee;
        public static Dictionary<string, decimal> coinMinTransaction;
        public static Dictionary<string, int> coinTransactionSize;
        public static Dictionary<string, Boolean> coinGetRawSupport;
        public static Dictionary<string, Boolean> coinFeePerAddress;
        public static Dictionary<string, Boolean> coinEnabled;
        IDictionary<string, decimal> allAccounts;
        Dictionary<string, IEnumerable<string>> coinLastMemoryDump;

        Decimal fileSize;
        int transactionsSearched = 0;
        int transactionsFound = 0;
        int msgId = 0;




        public Main()
        {
            InitializeComponent();

        }

        private char GetRandomDivider()
        {
            char[] chars = "\\/:*?\"><|".ToCharArray();
            Random r = new Random((int)DateTime.Now.Ticks & 0x0000FFFF);
            int i = r.Next(chars.Length);
            System.Threading.Thread.Sleep(100);

            return chars[i];
        }

        private string GetRandomBuffer(int BufferLength)
        {
            const string allowedChars = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz0123456789";
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
                CreateArchive(TransId, cmbCoinType.Text);
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
            string line;
            int tranCount = 1;
            int ledgerCount = 0;
            string transactionId = "";




            try
            {
                if (!FilePath.ToUpper().EndsWith(".ADD"))
                {


                    if (FilePath.Length > 0)
                    {


                        var mergeFiles = FilePath.Split(',');

                        foreach (var f in mergeFiles)
                        {
                            var intCurrentSize = 0;
                            var readFileBytes = System.IO.File.ReadAllBytes(f);
                            if (fileBytes != null) { intCurrentSize = fileBytes.Length; }

                            if (ledgerId != null)
                            {
                                cglText = ledgerId + GetRandomDivider() + readFileBytes.Length.ToString() + GetRandomDivider();
                            }
                            else
                            {
                                cglText = Path.GetFileName(f) + GetRandomDivider() + readFileBytes.Length.ToString() + GetRandomDivider();
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
                        lblStatusInfo.Text = "Status: Converting primary data to wallet addresses.";

                    }

                    if (TextMessage.Length > 0)
                    {
                        msgBytes = Encoding.UTF8.GetBytes(TextMessage);
                        cglText = GetRandomDivider() + msgBytes.Length.ToString() + GetRandomDivider();
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


                    System.IO.StreamWriter arcFile = new System.IO.StreamWriter("process\\" + processId + ".ADD", true);

                    for (int arcBytePosition = 0; arcBytePosition < fileBytes.Length; arcBytePosition++)
                    {

                        if (payloadBytePosition > PayloadByteSize)
                        {
                            arcFile.WriteLine(Base58Encoding.EncodeWithCheckSum(arcPayloadBytes));
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

                    arcFile.WriteLine(Base58Encoding.EncodeWithCheckSum(arcPayloadBytes));
                    arcFile.Close();
                    lblStatusInfo.Text = "Status: Saving " + fileBytes.Length.ToString() + " bytes of primary data to the blockchain.";
                    progressBar.Value = 1;
                    progressBar.Maximum = (fileBytes.Length + PayloadByteSize) / PayloadByteSize;
                    progressBar.PerformStep();


                }
                else
                {
                    processId = FilePath.ToUpper().Remove(0, FilePath.Length - 40).Replace(".ADD", "");
                }

                CoinRPC b = new CoinRPC(new Uri("http://" + WalletRPCIP + ":" + WalletRPCPort), new NetworkCredential(WalletRPCUser, WalletRPCPassword));
                b.SetTXFee(coinTransactionFee[cmbCoinType.Text]);
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
                        transactionId = b.SendMany(WalletLabel, toMany, 1, "");
                        arcLedger.WriteLine(transactionId);
                        toMany.Clear();
                        toMany.Add(line, CoinMinTransaction);
                        progressBar.PerformStep();
                        tranCount = 0;
                        GetTransactionResponse transLookup = b.GetTransaction(transactionId);
                        //Wait for the wallet to catch up.
                        while (transLookup.confirmations < 1 && ledgerCount > (coinTransactionSize[cmbCoinType.Text] / 2))
                        {
                            System.Threading.Thread.Sleep(1000);
                            transLookup = b.GetTransaction(transactionId);

                        }
                        if (transLookup.confirmations > 0) { ledgerCount = 0; }


                    }


                    if (tranCount == coinTransactionSize[cmbCoinType.Text])
                    {
                        //Breaking transaction file into size specified in wallet settings
                        transactionId = b.SendMany(WalletLabel, toMany, 1, "");
                        arcLedger.WriteLine(transactionId);
                        toMany.Clear();
                        tranCount = 0;

                        GetTransactionResponse transLookup = b.GetTransaction(transactionId);
                        //Wait for the wallet to catch up.
                        while (transLookup.confirmations < 1 && ledgerCount > (coinTransactionSize[cmbCoinType.Text] * 25))
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
                    transactionId = b.SendMany(WalletLabel, toMany, 1, "");
                    arcLedger.WriteLine(transactionId);
                    toMany.Clear();
                    tranCount = 0;
                    GetTransactionResponse transLookup = b.GetTransaction(transactionId);
                    //Wait for the wallet to catch up.
                    while (transLookup.confirmations < 1 && ledgerCount > (coinTransactionSize[cmbCoinType.Text] * 25))
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
                lblStatusInfo.Text = "Error: " + e.Message;
                tmrStatusUpdate.Start();
                tmrProgressBar.Start();
                return;
            }
            lblStatusInfo.Text = "Status: Saved " + (progressBar.Maximum * PayloadByteSize) + " bytes of address data to the blockChain.";
            tmrStatusUpdate.Start();
            tmrProgressBar.Start();


        }

        private void btnArchive_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("The estimated cost is based on your current wallet settings and does not include ledger archiving costs for files over " + (coinPayloadByteSize[cmbCoinType.Text] * coinTransactionSize[cmbCoinType.Text]).ToString() + " bytes.", "Confirm Saving", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                CreateLedgerFile(coinPayloadByteSize[cmbCoinType.Text], GetRandomBuffer(coinPayloadByteSize[cmbCoinType.Text]), coinIP[cmbCoinType.Text], coinPort[cmbCoinType.Text], coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text], cmbWalletLabel.Text, coinVersion[cmbCoinType.Text], coinMinTransaction[cmbCoinType.Text], txtFileName.Text, null, txtMessage.Text);
            }
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
                    var fileBytes = System.IO.File.ReadAllBytes(f);
                    fileSize = fileSize + (decimal)fileBytes.Length;
                }

                updateEstimatedCost();

            }

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Directory.CreateDirectory("root");
            Directory.CreateDirectory("process");
            RefreshCoinTypes();
            tmrStatusUpdate.Start();
        }

        public void RefreshCoinTypes()
        {
            try
            {
                coinVersion = new Dictionary<string, byte>();
                coinPayloadByteSize = new Dictionary<string, int>();
                coinTransactionFee = new Dictionary<string, decimal>();
                coinMinTransaction = new Dictionary<string, decimal>();
                coinTransactionSize = new Dictionary<string, int>();
                coinPort = new Dictionary<string, string>();
                coinIP = new Dictionary<string, string>();
                coinUser = new Dictionary<string, string>();
                coinPassword = new Dictionary<string, string>();
                coinGetRawSupport = new Dictionary<string, bool>();
                coinFeePerAddress = new Dictionary<string, bool>();
                coinEnabled = new Dictionary<string, bool>();
                coinLastMemoryDump = new Dictionary<string, IEnumerable<string>>();
                string confLine;

                if (!System.IO.File.Exists("coin.conf"))
                {
                    System.IO.StreamWriter writeCoinConf = new StreamWriter("coin.conf");
                    writeCoinConf.WriteLine("Bitcoin 0 20 .0001 .00001 164 8332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True False False");
                    writeCoinConf.WriteLine("Litecoin 48 20 .001 .00000001 164 9332 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False");
                    writeCoinConf.WriteLine("Anoncoin 23 20 .01 .00000001 164 9376 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False");
                    writeCoinConf.WriteLine("Devcoin 0 20 1 .00000001 328 6333 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME False True False");
                    writeCoinConf.WriteLine("Dogecoin 30 20 1 0.00000001 164 22555 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False");
                    //SHA3 Required
                    //writeCoinConf.WriteLine("Maxcoin 110 20 1 0.01 164 8669 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False");
                    writeCoinConf.WriteLine("Mazacoin 50 20 .0001 .000055 164 12832 127.0.0.1 RPC_USER_CHANGE_ME RPC_PASSWORD_CHANGE_ME True True False");

                    writeCoinConf.Close();
                }


                if (!System.IO.Directory.Exists("root\\includes"))
                {
                    System.IO.Directory.CreateDirectory("root\\includes");

                    System.IO.StreamWriter writeIncludes = new StreamWriter("root\\includes\\meta.ssi");
                    writeIncludes.WriteLine("");
                    writeIncludes.Close();

                    writeIncludes = new StreamWriter("root\\includes\\header.ssi");
                    writeIncludes.WriteLine("<center>");
                    writeIncludes.Close();

                    writeIncludes = new StreamWriter("root\\includes\\css.ssi");
                    writeIncludes.WriteLine("");
                    writeIncludes.Close();

                    writeIncludes = new StreamWriter("root\\includes\\footer.ssi");
                    writeIncludes.WriteLine("</center>");
                    writeIncludes.Close();
                }

                System.IO.StreamReader readCoinConf = new System.IO.StreamReader("coin.conf");
                while ((confLine = readCoinConf.ReadLine()) != null)
                {
                    string[] coins = confLine.Split(' ');
                    coinVersion.Add(coins[0], byte.Parse(coins[1]));
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
                    if (coins[10].ToUpper() == "TRUE") { coinGetRawSupport.Add(coins[0], true); } else { coinGetRawSupport.Add(coins[0], false); }
                    if (coins[11].ToUpper() == "TRUE") { coinFeePerAddress.Add(coins[0], true); } else { coinFeePerAddress.Add(coins[0], false); }
                    if (coins[12].ToUpper() == "TRUE") { coinEnabled.Add(coins[0], true); } else { coinEnabled.Add(coins[0], false); }
                    coinLastMemoryDump.Add(coins[0], null);

                }
                readCoinConf.Close();

                cmbCoinType.Items.Add("Select Wallet");
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
                lblStatusInfo.Text = "Error: " + coinTypeException.Message + " check coin.conf file.";
                cmbCoinType.SelectedIndex = 0;
                cmbWalletLabel.SelectedIndex = 0;
                cmbWalletLabel.Enabled = false;
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
                    totalTransactionCost = Math.Round(totalSize / coinPayloadByteSize[cmbCoinType.Text], 0) * coinMinTransaction[cmbCoinType.Text];
                    if (coinFeePerAddress[cmbCoinType.Text]) { totalTransactionCost = totalTransactionCost + ((Math.Round(totalSize / coinPayloadByteSize[cmbCoinType.Text], 0)) * coinTransactionFee[cmbCoinType.Text]); }
                    totalFeeCost = Math.Round((Math.Round(totalSize / coinPayloadByteSize[cmbCoinType.Text], 0) / coinTransactionSize[cmbCoinType.Text]), 0) * coinTransactionFee[cmbCoinType.Text];
                    estTotalCost = totalTransactionCost + totalFeeCost + coinTransactionFee[cmbCoinType.Text] + coinMinTransaction[cmbCoinType.Text];
                    lblEstimatedCost.Text = estTotalCost.ToString();
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

            if (fileSize > 0 || txtMessage.TextLength > 0)
            {
                updateEstimatedCost();
            }
            lblCoinTotal.Text = "0.00000000";
            cmbWalletLabel.Items.Clear();
            cmbWalletLabel.Items.Add("Select Account");
            cmbWalletLabel.SelectedIndex = 0;
            if (cmbCoinType.SelectedIndex > 0)
            {
                try
                {
                    CoinRPC a = new CoinRPC(new Uri("http://" + coinIP[cmbCoinType.Text] + ":" + coinPort[cmbCoinType.Text]), new NetworkCredential(coinUser[cmbCoinType.Text], coinPassword[cmbCoinType.Text]));
                    allAccounts = a.ListAccounts(1);
                    tmrStatusUpdate.Start();

                    try
                    {
                        foreach (string Account in allAccounts.Keys)
                        {
                            cmbWalletLabel.Items.Add(Account);

                            totalValue = totalValue + allAccounts[Account];

                        }
                        lblCoinTotal.Text = totalValue.ToString();

                        var itemCountString = "";
                        if ((cmbWalletLabel.Items.Count - 1) > 1) { itemCountString = "s"; }
                        lblStatusInfo.Text = "Status: Wallet connected " + (cmbWalletLabel.Items.Count - 1).ToString() + " suitable account" + itemCountString + " Found";

                        cmbWalletLabel.Enabled = true;
                    }
                    catch
                    {
                        lblStatusInfo.Text = "Status: No accounts found.  Check wallet settings.";
                        cmbCoinType.SelectedIndex = 0;
                        cmbWalletLabel.SelectedIndex = 0;
                        cmbWalletLabel.Enabled = false;
                        tmrStatusUpdate.Start();
                    }

                }
                catch (Exception walletException)
                {
                    lblStatusInfo.Text = "Error: " + walletException.Message + " check wallet settings.";
                    cmbCoinType.SelectedIndex = 0;
                    cmbWalletLabel.SelectedIndex = 0;
                    cmbWalletLabel.Enabled = false;
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
                notarizeToolStripMenuItem.Enabled = true;
                pictureBox1.Visible = false;
                if (txtMessage.TextLength < 1) { imgEnterMessageHere.Visible = true; }

            }
            else
            {
                txtMessage.Enabled = false;
                txtFileName.Enabled = false;
                btnAttachFile.Enabled = false;
                notarizeToolStripMenuItem.Enabled = false;
                imgEnterMessageHere.Visible = false;
                if (txtMessage.TextLength < 1) { pictureBox1.Visible = true; }



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
                { lblEstimatedCost.ForeColor = System.Drawing.Color.Green; btnArchive.Enabled = true; }

            }
            if (txtFileName.TextLength == 0 && txtMessage.TextLength == 0) { btnArchive.Enabled = false; }
            if (lblEstimatedCost.ForeColor != System.Drawing.Color.Green && lblCoinTotal.Text != "0.00000000")
            {
                lblStatusInfo.Text = "Status: Deposit more coins to ensure a succesfull archive.";
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
                arcPayloadBytes = Base58Encoding.DecodeWithCheckSum(line);
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
                                    try
                                    {
                                        var b = new CoinRPC(new Uri("http://" + coinIP[WalletKey] + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));
                                        if (coinGetRawSupport[WalletKey])
                                        {
                                            var transaction = b.GetRawTransaction(headerArray[0], 1);
                                        }
                                        else
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

        private Boolean ConvertAddressArrayToFile(string[] AddressArray, string TransID, string WalletKey)
        {
            try
            {
                int intFileByteCount = 0;
                int intPayLoadSize = 0;
                byte[] rawBytes = null;


                // Converting Addresses to RawBytes
                foreach (string address in AddressArray)
                {
                    var arcPayloadBytes = Base58Encoding.DecodeWithCheckSum(address);

                    //Supporting different Payload Byte Sizes
                    if (rawBytes == null)
                    {
                        intPayLoadSize = arcPayloadBytes.Count() - 1;
                        rawBytes = new byte[(AddressArray.Count() * intPayLoadSize)];
                    }
                    //Building rawbytes
                    ArrayHelpers.SubArray(arcPayloadBytes, 1).CopyTo(rawBytes, intFileByteCount);
                    intFileByteCount = intFileByteCount + intPayLoadSize;
                }

                string strHeaderBuilder = "";
                string[] header = new string[2];
                int intHeaderPosition = 0;
                int intFilePosition = 0;
                int intFileSize = 0;
                string strFileName = "";
                byte[] buildingFile = null;
                Boolean containsData = false;


                for (int i = 0; i < rawBytes.Length; i++)
                {
                    if (buildingFile == null)
                    {
                        if (UTF8Encoding.UTF8.GetString(rawBytes, i, 1).IndexOfAny("\\/:*?\"><|".ToCharArray()) > -1)
                        {
                            header[intHeaderPosition] = strHeaderBuilder;
                            strHeaderBuilder = "";
                            intHeaderPosition++;
                        }
                        else { strHeaderBuilder = strHeaderBuilder + UTF8Encoding.UTF8.GetString(rawBytes, i, 1); }

                        //Has Found enough Special Characters for a simple file Check
                        if (intHeaderPosition == 2)
                        {
                            var containsFileSize = int.TryParse(header[1], out intFileSize);
                            if (!containsFileSize || ((rawBytes.Length - i) < intFileSize) || header[0].Count() > 255 || header[0].IndexOfAny(Path.GetInvalidFileNameChars()) > -1) { return false; }
                            intHeaderPosition = 0;
                            intFilePosition = 0;
                            strFileName = header[0];
                            buildingFile = new byte[intFileSize];

                            if (!containsData)
                            {
                                Directory.CreateDirectory("root\\" + TransID);
                                FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Create);
                                fileStream.Write(UTF8Encoding.UTF8.GetBytes("<html><head><meta charset=\"UTF-8\" /><title>" + WalletKey + " - " + TransID + "</title><meta name=\"description\" content=\"The following content was archived to the " + WalletKey + " blockchain.\" /><!--#include file=\"..\\includes\\meta.ssi\" --></head><!--#include file=\"..\\includes\\css.ssi\" --><body><!--#include file=\"..\\includes\\header.ssi\" -->"), 0, 292 + (WalletKey.Length * 2) + TransID.Length);
                                fileStream.Close();

                            }
                            containsData = true;
                            transactionsFound++;
                        }
                    }
                    else
                    {

                        if (intFilePosition < intFileSize)
                        {
                            buildingFile[intFilePosition] = rawBytes[i];
                            intFilePosition++;
                        }
                        else
                        {

                            if (header[0] != "" && chkFilterUnSafeContent.Checked)
                            {
                                string unSafeExtensions = ".ADE.ADP.BAS.BAT.CHM.CMD.COM.CPL.CRT.DLL.DOC.DOCX.EXE.HLP.HTA.INF.INS.ISP.JS.JSE.LNK.MDB.MDE.MSC.MSI.MSP.MST.OCX.PCD.PIF.POT.PPT.REG.SCR.SCT.SHB.SHS.SYS.URL.VB.VBE.VBS.WSC.WSF.WSH.XLS.XLSX";
                                if (Path.GetExtension(header[0]).Length > 1 && unSafeExtensions.IndexOf(Path.GetExtension(header[0]).ToUpper()) > -1)
                                {
                                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                                    fileStream.Write(UTF8Encoding.UTF8.GetBytes("<div class=\"arc\">[ " + header[0] + " ]</div><p>&nbsp;</p>"), 0, header[0].Length + 40);
                                    fileStream.Close();

                                }
                                else
                                {
                                    ParseData(buildingFile, TransID, header[0]);
                                }
                            }
                            else
                            {
                                ParseData(buildingFile, TransID, header[0]);
                            }

                            i = i - 1;
                            buildingFile = null;

                        }

                    }

                }

                if (intFilePosition == intFileSize && buildingFile != null)
                {
                    ParseData(buildingFile, TransID, header[0]);
                }

                if (containsData)
                {
                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);

                    if (coinGetRawSupport[WalletKey])
                    {
                        var b = new CoinRPC(new Uri("http://" + coinIP[WalletKey] + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));
                        var transaction = b.GetRawTransaction(TransID, 1);
                        System.DateTime dateTime = new System.DateTime(1970, 1, 1, 0, 0, 0, 0);
                        dateTime = dateTime.AddSeconds(transaction.blocktime);
                        string printDate = dateTime.ToShortDateString() + " " + dateTime.ToShortTimeString();
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<div class=\"item\"><div class=\"content\"><table>"), 0, 46);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>TRANSACTION ID</td><td>" + transaction.txid + "</td></tr>"), 0, 41 + transaction.txid.Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>ARCHIVE DATE</td><td>" + printDate + "</td></tr>"), 0, 39 + printDate.Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>VERSION</td><td>" + transaction.version + "</td></tr>"), 0, 34 + transaction.version.ToString().Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>BLOCKCHAIN</td><td>" + WalletKey + "</td></tr>"), 0, 37 + WalletKey.Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td>ADDRESS FILE</td><td><a href=\"address.dat\">address.dat</a></td></tr>"), 0, 76);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("<tr><td colspan=2 align=right><a href=\"..\\abuse.aspx?TransID=" + transaction.txid + "\">report abuse</a></td></tr>"), 0, 89 + transaction.txid.Length);
                        fileStream.Write(UTF8Encoding.UTF8.GetBytes("</table></div></div>"), 0, 20);
                    }
                    FileStream dataFileStream = new FileStream("root\\" + TransID + "\\address.dat", FileMode.Create);

                    foreach (string address in AddressArray)
                    {
                        dataFileStream.Write(UTF8Encoding.UTF8.GetBytes(address + "\n"), 0, address.Length + 1);
                    }
                    dataFileStream.Close();

                    fileStream.Write(UTF8Encoding.UTF8.GetBytes("<!--#include file=\"..\\includes\\footer.ssi\" --></body></html>"), 0, 60);
                    fileStream.Close();
                    System.IO.File.AppendAllText("root\\sitemap.htm", "<a href=\"" + TransID + "/index.htm\">" + TransID + "</a><br>" + Environment.NewLine);
                    System.IO.File.AppendAllText("root\\sitemap.txt", Properties.Settings.Default.SiteMapUrl + "/" + TransID + Environment.NewLine);

                }
                return containsData;
            }
            catch { return false; }
        }

        private void ParseData(byte[] ByteData, string TransID, string FileName)
        {

            Boolean foundType = false;
            if (FileName != "")
            {
                string embExtensions = ".m2ts.aac.adt.adts.3g2.3gp2.3gp.3gpp.m4a.mov.wmz.wms.ivf.cda.wav.au.snd.aif.aifc.aiff.mid.midi.rmi.mpg.mpeg.m1v.mp2.mp3.mpa.mpe.m3u.avi.wmd.dvr-ms.wpi.wax.wvx.wmx.asf.wma.wmv.wm.swf.pdf";
                string imgExtensions = ".jpg.jpeg.jpe.gif.png.tiff.tif.svg.svgz.xbm.bmp.ico";
                string webExtensions = ".asp.aspx.axd.asx.asmx.ashx.css.cfm.yaws.html.htm.xhtml.jhtml.jsp.jspx.wss.do.js.pl.php.php4.php3.phtml.py.rb.rhtml.xml.rss.svg.cgi";
                string strPrintLine = "";

                if (!foundType && Path.GetExtension(FileName).Length > 1 && embExtensions.IndexOf(Path.GetExtension(FileName).ToLower()) > -1)
                {
                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><embed src=\"" + HttpUtility.UrlPathEncode(FileName) + "\" /><p><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\">" + FileName + "</a></p></div></div>";
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                    fileStream.Close();
                    foundType = true;
                }

                if (!foundType && Path.GetExtension(FileName).Length > 1 && imgExtensions.IndexOf(Path.GetExtension(FileName).ToLower()) > -1)
                {
                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><img src=\"" + HttpUtility.UrlPathEncode(FileName) + "\" /><br><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\">" + FileName + "</a></div></div>";
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                    fileStream.Close();
                    foundType = true;
                }

                if (!foundType)
                {
                    FileStream fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                    strPrintLine = "<div class=\"item\"><div class=\"content\"><a href=\"" + HttpUtility.UrlPathEncode(FileName) + "\">" + HttpUtility.UrlPathEncode(FileName) + "</a></div></div>";
                    fileStream.Write(UTF8Encoding.UTF8.GetBytes(strPrintLine), 0, UTF8Encoding.UTF8.GetBytes(strPrintLine).Length);
                    fileStream.Close();
                    searchResults.DeselectAll();

                }


                //Limited Protection From Injection Hacks
                if (Path.GetExtension(FileName).Length > 1 && webExtensions.IndexOf(Path.GetExtension(FileName).ToLower()) > -1)
                {
                    if (chkFilterUnSafeContent.Checked)
                    {
                        string result = Sanitizer.GetSafeHtmlFragment(System.Text.UTF8Encoding.UTF8.GetString(ByteData));
                        FileStream attachStream = new FileStream("root\\" + TransID + "\\" + FileName, FileMode.Create);
                        attachStream.Write(UTF8Encoding.UTF8.GetBytes(result), 0, UTF8Encoding.UTF8.GetBytes(result).Length);
                        attachStream.Close();
                    }
                    else
                    {
                        FileStream attachStream = new FileStream("root\\" + TransID + "\\" + FileName, FileMode.Create);
                        attachStream.Write(ByteData, 0, ByteData.Length);
                        attachStream.Close();
                    }
                }
                else
                {
                    FileStream attachStream = new FileStream("root\\" + TransID + "\\" + FileName, FileMode.Create);
                    attachStream.Write(ByteData, 0, ByteData.Length);
                    attachStream.Close();
                }


                //Good Enough For Now.
                searchResults.DeselectAll();
                Image image = null;
                try { image = Image.FromFile("root\\" + TransID + "\\" + FileName); }
                catch { image = (Image)ADD.Properties.Resources.icon; }
                Clipboard.SetImage(image);
                searchResults.Paste();
                searchResults.AppendText(Environment.NewLine);
                searchResults.AppendText("file://" + TransID + "/" + FileName);
                searchResults.AppendText(Environment.NewLine);
                searchResults.AppendText(Environment.NewLine);
                searchResults.ScrollToCaret();
                image.Dispose();

            }
            else
            {
                string result = System.Text.UTF8Encoding.UTF8.GetString(ByteData);
                if (chkFilterUnSafeContent.Checked)
                {
                    //Limited Protection From Injection Hacks
                    result = Sanitizer.GetSafeHtmlFragment(result);
                }

                msgId++;
                FileStream fileStream = new FileStream("root\\" + TransID + "\\"+ msgId +".MSG", FileMode.Create);
                fileStream.Write(UTF8Encoding.UTF8.GetBytes(result), 0, UTF8Encoding.UTF8.GetBytes(result).Length);
                fileStream.Close();

                fileStream = new FileStream("root\\" + TransID + "\\index.htm", FileMode.Append);
                fileStream.Write(UTF8Encoding.UTF8.GetBytes("<div class=\"item\"><div class=\"content\">"), 0, 39);
                fileStream.Write(UTF8Encoding.UTF8.GetBytes(result), 0, UTF8Encoding.UTF8.GetBytes(result).Length);
                fileStream.Write(UTF8Encoding.UTF8.GetBytes("<p><a href=\""+msgId+".MSG\">"+msgId+"</a></p></div></div>"), 0, 38 + (msgId.ToString().Length *2));
                fileStream.Close();

                searchResults.DeselectAll();
                searchResults.AppendText(Environment.NewLine);
                searchResults.AppendText(result);
                searchResults.AppendText(Environment.NewLine);
                searchResults.AppendText("file://" + TransID);
                searchResults.AppendText(Environment.NewLine);
                searchResults.AppendText(Environment.NewLine);
                searchResults.ScrollToCaret();
            }


        }

        private void Form1_Resize(object sender, EventArgs e)
        {
            lblStatusInfo.Width = Main.ActiveForm.Width - 240;
            lblExploreStatus.Width = Main.ActiveForm.Width - 240;
        }

        private void tmrStatusUpdate_Tick(object sender, EventArgs e)
        {
            lblStatusInfo.Text = "Status:";
            lblExploreStatus.Text = "Status:";
            tmrStatusUpdate.Stop();
        }

        private void tmrProgressBar_Tick(object sender, EventArgs e)
        {
            progressBar.Visible = false;
            tmrProgressBar.Stop();
        }

        public Boolean CreateArchive(string TransactionID, string WalletKey)
        {

            string[] AddressArray = null;
            string[] LedgerArray = null;
            msgId = 0;
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

                return ConvertAddressArrayToFile(AddressArray, TransactionID, WalletKey);
            }
            catch { return false; }

        }

        private string[] CreateAddressArrayFromTransactionID(string TransactionId, string WalletKey)
        {
            var delimiter = "";
            string addressBuilder = "";

            var b = new CoinRPC(new Uri("http://" + coinIP[WalletKey] + ":" + coinPort[WalletKey]), new NetworkCredential(coinUser[WalletKey], coinPassword[WalletKey]));

            if (coinGetRawSupport[WalletKey])
            {

                var transaction = b.GetRawTransaction(TransactionId, 1);
                var arcValue = (decimal)999999999;

                foreach (ADD.RPCClient.GetRawTransactionResponse.Output detail in transaction.vout)
                {
                    if (arcValue > detail.value)
                    {
                        arcValue = detail.value;
                    }
                }

                foreach (ADD.RPCClient.GetRawTransactionResponse.Output detail in transaction.vout)
                {

                    if (detail.value == arcValue)
                    {
                        addressBuilder = addressBuilder + delimiter + detail.scriptPubKey.addresses[0];
                        delimiter = ",";
                    }
                }

            }
            else
            {
                var transaction = b.GetTransaction(TransactionId);

                foreach (ADD.RPCClient.GetTransactionResponse.Details detail in transaction.details)
                {
                    addressBuilder = addressBuilder + delimiter + detail.address;
                    delimiter = ",";
                }

            }

            return addressBuilder.Split(',');

        }

        private void chkMonitorBlockChains_CheckedChanged(object sender, EventArgs e)
        {
            var coinCount = 0;
            foreach (var i in coinIP)
            {
                if (coinLastMemoryDump[i.Key] == null && coinGetRawSupport[i.Key] && coinEnabled[i.Key])
                {
                    try
                    {
                        var b = new CoinRPC(new Uri("http://" + coinIP[i.Key] + ":" + coinPort[i.Key]), new NetworkCredential(coinUser[i.Key], coinPassword[i.Key]));
                        coinLastMemoryDump[i.Key] = b.GetRawMemPool();
                    }
                    catch (Exception ex)
                    {
                        lblExploreStatus.Text = "Error: " + i.Key + " " + ex.Message;
                        tmrStatusUpdate.Start();
                    }
                    coinCount++;
                }


            }

            if (coinCount == 0)
            {
                lblExploreStatus.Text = "Status: Nothing to Monitor.  Check Wallet Settings";
                tmrStatusUpdate.Start();
                chkMonitorBlockChains.Checked = false;
            }




            if (chkMonitorBlockChains.Checked)
            {
                tmrGetNewTransactions.Start();
                lblMonitorInfo.Visible = true;
            }
            else
            {
                tmrGetNewTransactions.Stop();
                lblMonitorInfo.Visible = false;
            }


        }

        private void tmrGetNewTransactions_Tick(object sender, EventArgs e)
        {
            IEnumerable<string> transaction = null;
            try
            {
                foreach (var i in coinIP)
                {
                    if (coinEnabled[i.Key] && coinGetRawSupport[i.Key])
                    {
                        try
                        {
                            var b = new CoinRPC(new Uri("http://" + coinIP[i.Key] + ":" + coinPort[i.Key]), new NetworkCredential(coinUser[i.Key], coinPassword[i.Key]));
                            transaction = b.GetRawMemPool();

                            IEnumerable<string> differenceQuery =
                            transaction.Except(coinLastMemoryDump[i.Key]);

                            foreach (var s in differenceQuery)
                            {

                                CreateArchive(s, i.Key);
                                transactionsSearched++;
                            }

                            coinLastMemoryDump[i.Key] = transaction;
                            lblMonitorInfo.Text = "Monitor: " + transactionsSearched.ToString() + " / " + transactionsFound.ToString();

                        }
                        catch (Exception ex)
                        {
                            lblExploreStatus.Text = "Error: " + i.Key + " Check Wallet Settings. " + ex.Message;
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
            var isFound = false;
            if (e.KeyValue == 13)
            {
                foreach (string i in cmbCoinType.Items)
                {
                    if (i != "Select Wallet" && isFound == false)
                    {
                        isFound = CreateArchive(txtTransIDSearch.Text, i);
                        if (isFound)
                        {
                            lblExploreStatus.Text = "Status: Found in Blockchain";
                            tmrStatusUpdate.Start();
                            break;
                        }
                    }
                }
                if (!isFound)
                {
                    lblExploreStatus.Text = "Status: Transaction Id not found in linked Bockchains.";
                    tmrStatusUpdate.Start();
                }

            }

            if (e.KeyValue == (int)Keys.Back || e.KeyValue == (int)Keys.Delete)
            {

                txtTransIDSearch.Text = "ENTER TRANSACTION ID";
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

        public static void OpenAboutForm()
        {
            Application.Run(new About());
        }

        public static void OpenRPCForm()
        {
            Application.Run(new RPC());
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenAboutForm));
            t.Start();

        }

        private void txtTransIDSearch_Click(object sender, EventArgs e)
        {
            if (txtTransIDSearch.Text == "ENTER TRANSACTION ID") { txtTransIDSearch.Text = ""; }

        }

        private void searchResults_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("root\\" + e.LinkText.Substring(6).Replace("/", "\\"));
        }

        private void historyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("root\\");
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.rtf";
            saveFile1.Filter = "RTF Files|*.rtf";
            saveFile1.FileName = "Session.rtf";

            // Determine if the user selected a file name from the saveFileDialog. 
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                searchResults.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
            }
        }

        private void rPCToolStripMenuItem_Click(object sender, EventArgs e)
        {

            System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(OpenRPCForm));
            t.Start();
        }


        private void notarizeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = openDigestFile.ShowDialog(); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                FileStream filestream;
                SHA256 mySHA256 = SHA256Managed.Create();
                filestream = new FileStream(openDigestFile.FileName, FileMode.Open);
                filestream.Position = 0;
                byte[] hashValue = mySHA256.ComputeHash(filestream);
                filestream.Close();
                txtMessage.Text = txtMessage.Text + "File Name: " + Path.GetFileName(openDigestFile.FileName) + Environment.NewLine + "File Proof: " + BitConverter.ToString(hashValue).Replace("-", String.Empty) + Environment.NewLine;
            }

        }

        private void imgEnterMessageHere_Click(object sender, EventArgs e)
        {
            txtMessage.Select();
        }

        private void rebuildToolStripMenuItem_Click(object sender, EventArgs e)
        {
            string[] folders = Directory.GetDirectories("root");

            foreach (string f in folders)
            {
                bool isFound = false;

                foreach (string i in cmbCoinType.Items)
                {
                    if (i != "Select Wallet" && isFound == false)
                    {
                        string transID = f.Replace("root\\", "");
                        isFound = CreateArchive(transID, i);
                        if (isFound)
                        {
                            lblExploreStatus.Text = "Status: Found in Blockchain";
                            tmrStatusUpdate.Start();
                            break;
                        }
                    }
                }
                if (!isFound)
                {
                    lblExploreStatus.Text = "Status: Transaction Id not found in linked Bockchains.";
                    tmrStatusUpdate.Start();
                }

            }
        }


    }
}
