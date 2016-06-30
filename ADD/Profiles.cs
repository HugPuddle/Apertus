using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BitcoinNET.RPCClient;
using ADD.Tools;
using System.Net;
using System.IO;
using Secp256k1;
using System.Numerics;
using System.Drawing.Imaging;
using System.Threading;

namespace ADD
{
    public partial class Profiles : Form
    {
        public Profiles()
        {
            InitializeComponent();
        }

        private void RefreshListBoxes()
        {
            try
            {
                CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                var allAccounts = a.ListAccounts(1);
                cmbProfileAddress.Items.Clear();
                cmbTipAddress.Items.Clear();

                cmbProfileAddress.Items.Add("Select Profile");
                cmbTipAddress.Items.Add("Select Tip Address");

                foreach (string Account in allAccounts.Keys)
                {

                    if (Account.LastIndexOf('~') == 3) { cmbProfileAddress.Items.Add(Account.Substring(4)); }
                    if (Account.LastIndexOf('~') == 4) { cmbTipAddress.Items.Add(Account.Substring(5)); }

                }
                cmbProfileAddress.SelectedIndex = 0;
                cmbTipAddress.SelectedIndex = 0;

            }
            catch { }
        }
        private string GetURL(string url)
        {
            if (url.ToUpper().StartsWith("HTTP"))
            {
                return url;
            }

            return "http://" + url;
        }

        private void Profiles_Load(object sender, EventArgs e)
        {
            RefreshListBoxes();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            txtProfileAddress.Visible = true;
            cmbProfileAddress.Visible = false;
        }

        private void txtProfileAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    Match match = Regex.Match(txtProfileAddress.Text, @"([a-zA-Z0-9]{51,})");
                    if (match.Success)
                    {
                        string label = "";
                        if (User.InputBox("Apertus", "Enter label to import key.", ref label) == DialogResult.OK)
                        {
                            CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                            var result = a.ImportPrivateKey(txtProfileAddress.Text, "~~~~" + label, true);
                            cmbProfileAddress.Items.Add(label);
                            txtProfileAddress.Text = "";
                            txtProfileAddress.Visible = false;
                            cmbProfileAddress.Visible = true;
                            cmbProfileAddress.SelectedItem = label;

                        }
                    }
                    else
                    {

                        CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                        string label;
                        if (txtProfileAddress.Text.LastIndexOf('~') > 0)
                        { label = txtProfileAddress.Text; }
                        else { label = "~~~~" + txtProfileAddress.Text; }
                        label = a.GetNewAddress(label);
                        cmbProfileAddress.Items.Add(txtProfileAddress.Text);
                        txtProfileAddress.Visible = false;
                        cmbProfileAddress.Visible = true;
                        cmbProfileAddress.SelectedItem = txtProfileAddress.Text;
                        txtProfileAddress.Text = "";
                        StreamWriter writeTrustList = new StreamWriter("trust.txt", true);
                        writeTrustList.WriteLine(label);
                        writeTrustList.Close();
                        var mainForm = Application.OpenForms.OfType<Main>().Single();
                        mainForm.RefreshHashCache();
                    }
                }
                catch { }
            }
            if (e.KeyValue == 27)
            { txtProfileAddress.Text = ""; txtProfileAddress.Visible = false; cmbProfileAddress.Visible = true; }

        }

        private void button8_Click(object sender, EventArgs e)
        {
            txtTipAddress.Visible = true;
            cmbTipAddress.Visible = false;
        }

        private void txtTipAddress_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13)
            {
                try
                {
                    Match match = Regex.Match(txtTipAddress.Text, @"([a-zA-Z0-9]{51,})");
                    if (match.Success)
                    {
                        string label = "";
                        if (User.InputBox("Apertus", "Enter label to import key.", ref label) == DialogResult.OK)
                        {
                            CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                            var result = a.ImportPrivateKey(txtTipAddress.Text, "~~~~~" + label, true);
                            cmbTipAddress.Items.Add(label);
                            txtTipAddress.Text = "";
                            txtTipAddress.Visible = false;
                            cmbTipAddress.Visible = true;
                            cmbTipAddress.SelectedItem = label;

                        }
                    }
                    else
                    {
                        CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                        string label;
                        if (txtTipAddress.Text.LastIndexOf('~') > 0)
                        { label = txtTipAddress.Text; }
                        else { label = "~~~~~" + txtTipAddress.Text; }
                        label = a.GetNewAddress(label);
                        cmbTipAddress.Items.Add(txtTipAddress.Text);
                        txtTipAddress.Visible = false;
                        cmbTipAddress.Visible = true;
                        cmbTipAddress.SelectedItem = txtTipAddress.Text;
                        txtTipAddress.Text = "";
                    }
                }
                catch { }
            }
            if (e.KeyValue == 27)
            { txtTipAddress.Text = ""; txtTipAddress.Visible = false; cmbTipAddress.Visible = true; }
        }

        private void cmbProfileAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            BuildSelectedProfile();

        }

        private void BuildSelectedProfile()
        {
            if (cmbProfileAddress.SelectedIndex > 0)
            {
                txtNickName.Enabled = true;
                txtPrefix.Enabled = true;
                txtFirstName.Enabled = true;
                txtMiddleName.Enabled = true;
                txtLastName.Enabled = true;
                txtSuffix.Enabled = true;
                txtAddress1.Enabled = true;
                txtAddress2.Enabled = true;
                txtAddress3.Enabled = true;
                txtTransID.Enabled = true;
                cmbTipAddress.Enabled = true;
                btnArchive.Enabled = true;
                btnTipAddress.Enabled = true;
                imgProfilePhoto.Enabled = true;

                txtNickName.Text = "";
                txtPrefix.Text = "";
                txtFirstName.Text = "";
                txtMiddleName.Text = "";
                txtLastName.Text = "";
                txtSuffix.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                txtTransID.Text = "";
                imgProfilePhoto.Image = Properties.Resources.Profile;
                cmbTipAddress.SelectedIndex = 0;
                btnArchive.Enabled = true;
                btnTipAddress.Enabled = true;

                var b = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                var transactions = b.ListTransactions("~~~~" + cmbProfileAddress.Text, 10000, 0);

                foreach (var transaction in transactions.Reverse())
                {
                    if (transaction.category == "receive")
                    {
                       
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
                                        txtTransID.Text = transaction.txid;
                                        string readFile = System.IO.File.ReadAllText("root//" + transaction.txid + "//PRO");
                                        int start = readFile.IndexOf("NIK=") + 4;
                                        int length = readFile.IndexOf(Environment.NewLine, start);
                                        txtNickName.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("PRE=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtPrefix.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("FNM=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtFirstName.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("MNM=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtMiddleName.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("LNM=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtLastName.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("SUF=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtSuffix.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("AD1=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtAddress1.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("AD2=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtAddress2.Text = readFile.Substring(start, length - start);
                                        start = readFile.IndexOf("AD3=") + 4;
                                        length = readFile.IndexOf(Environment.NewLine, start);
                                        txtAddress3.Text = readFile.Substring(start, length - start);

                                        try
                                        {
                                            start = readFile.IndexOf("TIP=") + 4;
                                            length = readFile.IndexOf(Environment.NewLine, start);
                                            var addData = b.ValidateAddress(readFile.Substring(start, length - start));
                                            string accData = addData.account.Substring(5);
                                            cmbTipAddress.Text = accData;

                                        }
                                        catch { }



                                        try
                                        {
                                            start = readFile.IndexOf("IMG=") + 4;
                                            length = readFile.IndexOf(Environment.NewLine, start);
                                            string strProfileImage = readFile.Substring(start, length - start);

                                            imgProfilePhoto.Image = Image.FromFile(Application.StartupPath + "//root//" + strProfileImage.Substring(3).Replace('/', '\\'));
                                            openFileDialog1.FileName = Application.StartupPath + "//root//" + strProfileImage.Substring(3).Replace('/', '\\');

                                        }
                                        catch { }
                                        break;
                                    }
                                }

                            }


                        }
                    }
                }


            }
            else
            {
                txtNickName.Enabled = false;
                txtPrefix.Enabled = false;
                txtFirstName.Enabled = false;
                txtMiddleName.Enabled = false;
                txtLastName.Enabled = false;
                txtSuffix.Enabled = false;
                txtAddress1.Enabled = false;
                txtAddress2.Enabled = false;
                txtAddress3.Enabled = false;
                txtTransID.Enabled = false;
                cmbTipAddress.Enabled = false;
                btnArchive.Enabled = false;
                btnTipAddress.Enabled = false;
                txtNickName.Text = "";
                txtPrefix.Text = "";
                txtFirstName.Text = "";
                txtMiddleName.Text = "";
                txtLastName.Text = "";
                txtSuffix.Text = "";
                txtAddress1.Text = "";
                txtAddress2.Text = "";
                txtAddress3.Text = "";
                txtTransID.Text = "";
                imgProfilePhoto.Image = Properties.Resources.Profile;

            }
        }

        private void imgProfilePhoto_Click(object sender, EventArgs e)
        {

            DialogResult result = STAShowDialog(openFileDialog1); // Show the dialog.
            if (result == DialogResult.OK) // Test result.
            {
                string fileName = openFileDialog1.FileName;
                string processID = "";
                try
                {

                    Bitmap bmp1 = new Bitmap(fileName);
                    if (processID == "") { processID = Guid.NewGuid().ToString(); }
                    Directory.CreateDirectory("process//" + processID);
                    ImageCodecInfo jgpEncoder = GetEncoder(ImageFormat.Jpeg);
                    System.Drawing.Imaging.Encoder myEncoder = System.Drawing.Imaging.Encoder.Quality;
                    EncoderParameters myEncoderParameters = new EncoderParameters(1);
                    EncoderParameter myEncoderParameter = new EncoderParameter(myEncoder, 70L);
                    myEncoderParameters.Param[0] = myEncoderParameter;

                    fileName = Path.GetDirectoryName(Application.ExecutablePath) + @"\process\" + processID + @"\" + Path.GetFileNameWithoutExtension(openFileDialog1.FileName) + ".jpg";
                    bmp1.Save(fileName, jgpEncoder, myEncoderParameters);
                    FileInfo f1 = new FileInfo(openFileDialog1.FileName);
                    FileInfo f2 = new FileInfo(fileName);

                    //Files aren't always smaller especially when converting png files
                    if (f2.Length < f1.Length) {openFileDialog1.FileName = fileName; }

                    imgProfilePhoto.Image = Image.FromFile(openFileDialog1.FileName);
                }
                catch { }


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

        private DialogResult STAShowDialog(FileDialog dialog)
        {

            DialogState state = new DialogState();

            state.dialog = dialog;

            System.Threading.Thread t = new System.Threading.Thread(state.ThreadProcShowDialog);

            t.SetApartmentState(System.Threading.ApartmentState.STA);

            t.Start();

            t.Join();

            return state.result;

        }

        private void btnArchive_Click(object sender, EventArgs e)
        {

            DialogResult prompt = MessageBox.Show("You are about to permanently etch a profile onto " + Main.CoinType + "." + Environment.NewLine + "            !!! Apertus may lock up during this process !!!" + Environment.NewLine + "       Please be patient.  We will thread it better next time.", "Confirmation", MessageBoxButtons.YesNoCancel);
            if (prompt == DialogResult.Yes)
            {
                Main.ProfileID = "";
                Main.ProfileLabel = "";
                var mainForm = Application.OpenForms.OfType<Main>().Single();
                string tempSignature = Main.SignatureLabel;
                Main.SignatureLabel = "~~" + cmbProfileAddress.Text;
                Match match = Regex.Match(openFileDialog1.FileName, @"([a-fA-F0-9]{64})");
                string profileImagePath = "";
                if (openFileDialog1.FileName != "openFileDialog1" && !match.Success)

                {
                    mainForm.PerformArchive(Main.CoinType, openFileDialog1.FileName, "");
                    var b = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                    var transactions = b.ListTransactions("~~~~" + cmbProfileAddress.Text, 100, 0);

                    foreach (var transaction in transactions.Reverse())
                    {
                        if (transaction.category == "receive")
                        {

                            if (mainForm.CreateArchive(transaction.txid, Main.CoinType, false, true, null, null, false))
                            {
                                if (System.IO.File.Exists("root//" + transaction.txid + "//" + Path.GetFileName(openFileDialog1.FileName)))
                                {
                                    profileImagePath = "../" + transaction.txid + "/" + Path.GetFileName(openFileDialog1.FileName);
                                    break;
                                }
                            }

                        }
                    }
                }
                
                if (match.Success) {  profileImagePath = "../" + match.Value + "/" + Path.GetFileName(openFileDialog1.FileName);}
            

                String processId = Guid.NewGuid().ToString();
                System.IO.Directory.CreateDirectory("process//" + processId);
                System.IO.StreamWriter proFile = new System.IO.StreamWriter("process//" + processId + "//PRO");
                proFile.WriteLine("IMG=" + profileImagePath);
                proFile.WriteLine("NIK=" + txtNickName.Text);
                proFile.WriteLine("PRE=" + txtPrefix.Text);
                proFile.WriteLine("FNM=" + txtFirstName.Text);
                proFile.WriteLine("MNM=" + txtMiddleName.Text);
                proFile.WriteLine("LNM=" + txtLastName.Text);
                proFile.WriteLine("SUF=" + txtSuffix.Text);
                proFile.WriteLine("AD1=" + txtAddress1.Text);
                proFile.WriteLine("AD2=" + txtAddress2.Text);
                proFile.WriteLine("AD3=" + txtAddress3.Text);
                CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                IEnumerable<string> Address = null;
                if (cmbTipAddress.SelectedIndex > 0)
                {
                    Address = a.GetAddressesByAccount("~~~~~" + cmbTipAddress.Text);
                    proFile.WriteLine("TIP=" + Address.First());

                }
                Address = a.GetAddressesByAccount("~~~~" + cmbProfileAddress.Text);
                var privKeyHex = BitConverter.ToString(Base58.Decode(a.DumpPrivateKey(Address.First()))).Replace("-", "");
                privKeyHex = privKeyHex.Substring(2, 64);
                BigInteger privateKey = Hex.HexToBigInteger(privKeyHex);
                ECPoint publicKey = Secp256k1.Secp256k1.G.Multiply(privateKey);

                proFile.WriteLine("MSG=" + Address.First());
                proFile.WriteLine("PKX=" + publicKey.X.ToHex());
                proFile.WriteLine("PKY=" + publicKey.Y.ToHex());
                proFile.Close();

                mainForm.PerformArchive(Main.CoinType, Application.StartupPath + "//process//" + processId + "//PRO", "");
                Main.SignatureLabel = tempSignature;
                BuildSelectedProfile();
                Main.ProfileID = txtTransID.Text;
                Main.ProfileLabel = cmbProfileAddress.Text;
                mainForm.AddProfile(cmbProfileAddress.Text);

            }
        }

        private void btnExportVault_Click(object sender, EventArgs e)
        {
            try
            {

                CoinRPC b = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                var strAddress = b.GetAddressesByAccount("~~~~~" + cmbTipAddress.Text);
                Thread thread = new Thread(() => Clipboard.SetText(b.DumpPrivateKey(strAddress.First())));
                thread.SetApartmentState(ApartmentState.STA); //Set the thread to STA
                thread.Start();
                thread.Join(); //Wait for the thread to end



            }
            catch { }
        }

        private void cmbTipAddress_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbTipAddress.SelectedIndex > 0) { btnExportTip.Enabled = true; } else { btnExportTip.Enabled = false; }
        }
    }
      
    
}
public class DialogState

    {

        public DialogResult result;

        public FileDialog dialog;

 

        public void ThreadProcShowDialog()

        {

            result = dialog.ShowDialog();

        }

    }

    