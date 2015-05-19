using System;
using System.IO;
using System.Windows.Forms;

namespace ADD
{
    public partial class Trust : Form
    {
        public Trust()
        {
            InitializeComponent();
        }

        private void Trust_Load(object sender, EventArgs e)
        {
            RefreshTrustList();
            RefreshBlockList();
            RefreshFollowList();
            RefreshSettings();
            
        }

        private void btnAddTrust_Click(object sender, EventArgs e)
        {
            StreamWriter writeTrustList = new StreamWriter("trust.txt", true);
            writeTrustList.WriteLine(txtTrust.Text);
            writeTrustList.Close();
            RefreshTrustList();
        }

        private void RefreshSettings()
        {
            System.IO.StreamReader readTrustConf = new System.IO.StreamReader("trust.conf");

                try
                {
                    var trustSettings = readTrustConf.ReadLine().Split(' ');
                    chkTrustTrustedlistContent.Checked = Convert.ToBoolean(trustSettings[0]);
                    chkBlockBlockedListContent.Checked = Convert.ToBoolean(trustSettings[1]);
                    chkBlockUnsignedContent.Checked = Convert.ToBoolean(trustSettings[2]);
                    chkBlockUntrustedContent.Checked = Convert.ToBoolean(trustSettings[3]);
                }
                catch { }
            
            readTrustConf.Close();
        }

        private void SaveSettings()
        {
            System.IO.StreamWriter writeTrustConf = new StreamWriter("trust.conf", false);
            writeTrustConf.WriteLine(chkTrustTrustedlistContent.Checked + " " +  chkBlockBlockedListContent.Checked + " " +  chkBlockUnsignedContent.Checked + " " + chkBlockUntrustedContent.Checked);
            writeTrustConf.Close();
        }

        private void RefreshTrustList()
        {
            var trustLine = "";
            txtTrustList.Text = "";
            if (System.IO.File.Exists("trust.txt"))
            {
                System.IO.StreamReader readTrust = new System.IO.StreamReader("trust.txt");
                while ((trustLine = readTrust.ReadLine()) != null)
                {
                    txtTrustList.Text = txtTrustList.Text + trustLine + Environment.NewLine;
                }
                readTrust.Close();
            }
        }

        private void RefreshBlockList()
        {
            var blockLine = "";
            txtBlockList.Text = "";

            if (System.IO.File.Exists("block.txt"))
            {
                System.IO.StreamReader readBlock = new System.IO.StreamReader("block.txt");
                while ((blockLine = readBlock.ReadLine()) != null)
                {
                    txtBlockList.Text = txtBlockList.Text + blockLine + Environment.NewLine;
                }
                readBlock.Close();
            }
        }

        private void RefreshFollowList()
        {
            var FollowLine = "";
            txtFollowList.Text = "";

            if (System.IO.File.Exists("Follow.txt"))
            {
                System.IO.StreamReader readFollow = new System.IO.StreamReader("Follow.txt");
                while ((FollowLine = readFollow.ReadLine()) != null)
                {
                    txtFollowList.Text = txtFollowList.Text + FollowLine + Environment.NewLine;
                }
                readFollow.Close();
            }
        }

        private void btnRemoveTrust_Click(object sender, EventArgs e)
        {
            txtTrustList.Text = "";
            System.IO.StreamReader readTrust = new System.IO.StreamReader("trust.txt");
            while (!readTrust.EndOfStream)
            {
                String trustLine = readTrust.ReadLine();

                if (trustLine != txtTrust.Text)
                {
                    txtTrustList.Text = txtTrustList.Text + trustLine + Environment.NewLine;
                }
            }
            readTrust.Close();

            StreamWriter writeTrustList = new StreamWriter("trust.txt");
            writeTrustList.Write(txtTrustList.Text);
            writeTrustList.Close();
        }

        private void btnAddBlock_Click(object sender, EventArgs e)
        {
            StreamWriter writeBlockList = new StreamWriter("block.txt", true);
            writeBlockList.WriteLine(txtBlock.Text);
            writeBlockList.Close();
            RefreshBlockList();
        }

        private void btnRemoveBlock_Click(object sender, EventArgs e)
        {
            
            txtBlockList.Text = "";
            System.IO.StreamReader readBlock = new System.IO.StreamReader("block.txt");
            while (!readBlock.EndOfStream)
            {
                String blockLine = readBlock.ReadLine();

                if (blockLine != txtBlock.Text)
                {
                    txtBlockList.Text = txtBlockList.Text + blockLine + Environment.NewLine;
                }
            }
            readBlock.Close();

            StreamWriter writeBlockList = new StreamWriter("block.txt");
            writeBlockList.Write(txtBlockList.Text);
            writeBlockList.Close();



        }



        private void chkTrustTrustedlistContent_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void chkBlockBlockedListContent_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void chkBlockUntrustedContent_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void chkBlockUnsignedContent_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }


        private void btnAddFollow_Click(object sender, EventArgs e)
        {
            StreamWriter writeFollowList = new StreamWriter("Follow.txt", true);
            writeFollowList.WriteLine(txtFollow.Text);
            writeFollowList.Close();
            RefreshFollowList();
        }

        private void btnRemoveFollow_Click(object sender, EventArgs e)
        {
            txtFollowList.Text = "";
            System.IO.StreamReader readFollow = new System.IO.StreamReader("Follow.txt");
            while (!readFollow.EndOfStream)
            {
                String FollowLine = readFollow.ReadLine();

                if (FollowLine != txtFollow.Text)
                {
                    txtFollowList.Text = txtFollowList.Text + FollowLine + Environment.NewLine;
                }
            }
            readFollow.Close();

            StreamWriter writeFollowList = new StreamWriter("Follow.txt");
            writeFollowList.Write(txtFollowList.Text);
            writeFollowList.Close();
        }


    }
}
