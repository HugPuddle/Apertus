using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using BitcoinNET.RPCClient;
using ADD.Tools;
using System.Net;
using System.IO;

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


                foreach (string Account in allAccounts.Keys)
                {

                    if (Account.LastIndexOf('~') == 0) { cmbProfileAddress.Items.Add(Account.Substring(1)); }
                    if (Account.LastIndexOf('~') == 3) { cmbTipAddress.Items.Add(Account.Substring(4)); }

                }

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
                    CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                    string label;
                    if (txtProfileAddress.Text.LastIndexOf('~') > 0)
                    { label = txtProfileAddress.Text; }
                    else { label = "~" + txtProfileAddress.Text; }
                    label = a.GetNewAddress(label);
                    cmbProfileAddress.Items.Add(txtProfileAddress.Text);
                    txtProfileAddress.Visible = false;
                    cmbProfileAddress.Visible = true;
                    cmbProfileAddress.SelectedItem = txtProfileAddress.Text;
                    txtProfileAddress.Text = "";
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
                    CoinRPC a = new CoinRPC(new Uri(GetURL(Main.coinIP[Main.CoinType]) + ":" + Main.coinPort[Main.CoinType]), new NetworkCredential(Main.coinUser[Main.CoinType], Main.coinPassword[Main.CoinType]));
                    string label;
                    if (txtTipAddress.Text.LastIndexOf('~') > 0)
                    { label = txtTipAddress.Text; }
                    else { label = "~~~~" + txtTipAddress.Text; }
                    label = a.GetNewAddress(label);
                    cmbTipAddress.Items.Add(txtTipAddress.Text);
                    txtTipAddress.Visible = false;
                    cmbTipAddress.Visible = true;
                    cmbTipAddress.SelectedItem = txtTipAddress.Text;
                    txtTipAddress.Text = "";
                }
                catch { }
            }
            if (e.KeyValue == 27)
            { txtTipAddress.Text = ""; txtTipAddress.Visible = false; cmbTipAddress.Visible = true; }
        }
    }
}
