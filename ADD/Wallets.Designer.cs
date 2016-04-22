namespace ADD
{
    partial class Wallets
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Wallets));
            this.cmbWallets = new System.Windows.Forms.ComboBox();
            this.btnAdd = new System.Windows.Forms.Button();
            this.txtVersion = new System.Windows.Forms.TextBox();
            this.txtPayload = new System.Windows.Forms.TextBox();
            this.txtTransactionFee = new System.Windows.Forms.TextBox();
            this.txtMinTransaction = new System.Windows.Forms.TextBox();
            this.txtTransactionSize = new System.Windows.Forms.TextBox();
            this.txtRPCPort = new System.Windows.Forms.TextBox();
            this.txtRPCIP = new System.Windows.Forms.TextBox();
            this.txtRPCUser = new System.Windows.Forms.TextBox();
            this.txtRPCPassword = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtName = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label15 = new System.Windows.Forms.Label();
            this.label16 = new System.Windows.Forms.Label();
            this.label17 = new System.Windows.Forms.Label();
            this.btnDelete = new System.Windows.Forms.Button();
            this.chkGetRawSupport = new System.Windows.Forms.CheckBox();
            this.chkFeePerAddress = new System.Windows.Forms.CheckBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.chkEnabled = new System.Windows.Forms.CheckBox();
            this.label19 = new System.Windows.Forms.Label();
            this.txtShortName = new System.Windows.Forms.TextBox();
            this.label20 = new System.Windows.Forms.Label();
            this.label21 = new System.Windows.Forms.Label();
            this.txtHelperUrl = new System.Windows.Forms.TextBox();
            this.txtTipAmount = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.label18 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cmbWallets
            // 
            this.cmbWallets.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWallets.FormattingEnabled = true;
            this.cmbWallets.Location = new System.Drawing.Point(18, 33);
            this.cmbWallets.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.cmbWallets.Name = "cmbWallets";
            this.cmbWallets.Size = new System.Drawing.Size(398, 39);
            this.cmbWallets.TabIndex = 0;
            this.cmbWallets.SelectedIndexChanged += new System.EventHandler(this.cmbWallets_SelectedIndexChanged);
            // 
            // btnAdd
            // 
            this.btnAdd.Enabled = false;
            this.btnAdd.Location = new System.Drawing.Point(435, 33);
            this.btnAdd.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnAdd.Name = "btnAdd";
            this.btnAdd.Size = new System.Drawing.Size(104, 48);
            this.btnAdd.TabIndex = 1;
            this.btnAdd.Text = "Copy";
            this.btnAdd.UseVisualStyleBackColor = true;
            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
            // 
            // txtVersion
            // 
            this.txtVersion.Enabled = false;
            this.txtVersion.Location = new System.Drawing.Point(194, 192);
            this.txtVersion.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtVersion.Name = "txtVersion";
            this.txtVersion.Size = new System.Drawing.Size(148, 31);
            this.txtVersion.TabIndex = 2;
            // 
            // txtPayload
            // 
            this.txtPayload.Enabled = false;
            this.txtPayload.Location = new System.Drawing.Point(194, 236);
            this.txtPayload.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtPayload.Name = "txtPayload";
            this.txtPayload.Size = new System.Drawing.Size(148, 31);
            this.txtPayload.TabIndex = 3;
            // 
            // txtTransactionFee
            // 
            this.txtTransactionFee.Enabled = false;
            this.txtTransactionFee.Location = new System.Drawing.Point(194, 323);
            this.txtTransactionFee.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransactionFee.Name = "txtTransactionFee";
            this.txtTransactionFee.Size = new System.Drawing.Size(148, 31);
            this.txtTransactionFee.TabIndex = 4;
            // 
            // txtMinTransaction
            // 
            this.txtMinTransaction.Enabled = false;
            this.txtMinTransaction.Location = new System.Drawing.Point(194, 412);
            this.txtMinTransaction.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtMinTransaction.Name = "txtMinTransaction";
            this.txtMinTransaction.Size = new System.Drawing.Size(148, 31);
            this.txtMinTransaction.TabIndex = 5;
            // 
            // txtTransactionSize
            // 
            this.txtTransactionSize.Enabled = false;
            this.txtTransactionSize.Location = new System.Drawing.Point(194, 280);
            this.txtTransactionSize.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTransactionSize.Name = "txtTransactionSize";
            this.txtTransactionSize.Size = new System.Drawing.Size(148, 31);
            this.txtTransactionSize.TabIndex = 6;
            // 
            // txtRPCPort
            // 
            this.txtRPCPort.Enabled = false;
            this.txtRPCPort.Location = new System.Drawing.Point(194, 456);
            this.txtRPCPort.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRPCPort.Name = "txtRPCPort";
            this.txtRPCPort.Size = new System.Drawing.Size(148, 31);
            this.txtRPCPort.TabIndex = 7;
            // 
            // txtRPCIP
            // 
            this.txtRPCIP.Enabled = false;
            this.txtRPCIP.Location = new System.Drawing.Point(194, 500);
            this.txtRPCIP.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRPCIP.Name = "txtRPCIP";
            this.txtRPCIP.Size = new System.Drawing.Size(148, 31);
            this.txtRPCIP.TabIndex = 8;
            // 
            // txtRPCUser
            // 
            this.txtRPCUser.Enabled = false;
            this.txtRPCUser.Location = new System.Drawing.Point(194, 544);
            this.txtRPCUser.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRPCUser.Name = "txtRPCUser";
            this.txtRPCUser.Size = new System.Drawing.Size(565, 31);
            this.txtRPCUser.TabIndex = 9;
            // 
            // txtRPCPassword
            // 
            this.txtRPCPassword.Enabled = false;
            this.txtRPCPassword.Location = new System.Drawing.Point(194, 588);
            this.txtRPCPassword.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtRPCPassword.Name = "txtRPCPassword";
            this.txtRPCPassword.Size = new System.Drawing.Size(565, 31);
            this.txtRPCPassword.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(54, 197);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(134, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "Version Byte";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(51, 241);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(138, 25);
            this.label2.TabIndex = 12;
            this.label2.Text = "Payload Size";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(34, 327);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(156, 25);
            this.label3.TabIndex = 13;
            this.label3.Text = "Min  Miner Fee";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 417);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(166, 25);
            this.label4.TabIndex = 14;
            this.label4.Text = "Min Transaction";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 284);
            this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 25);
            this.label5.TabIndex = 15;
            this.label5.Text = "Transaction Size";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(87, 461);
            this.label6.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(101, 25);
            this.label6.TabIndex = 16;
            this.label6.Text = "RPC Port";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(108, 505);
            this.label7.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 25);
            this.label7.TabIndex = 17;
            this.label7.Text = "RPC IP";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(81, 548);
            this.label8.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(107, 25);
            this.label8.TabIndex = 18;
            this.label8.Text = "RPC User";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(34, 592);
            this.label9.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(156, 25);
            this.label9.TabIndex = 19;
            this.label9.Text = "RPC Password";
            // 
            // txtName
            // 
            this.txtName.Enabled = false;
            this.txtName.Location = new System.Drawing.Point(194, 100);
            this.txtName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtName.Name = "txtName";
            this.txtName.Size = new System.Drawing.Size(565, 31);
            this.txtName.TabIndex = 21;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(54, 105);
            this.label10.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(134, 25);
            this.label10.TabIndex = 22;
            this.label10.Text = "Wallet Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(351, 192);
            this.label11.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(216, 25);
            this.label11.TabIndex = 24;
            this.label11.Text = "( BTC = 0, LTC = 48 )";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(351, 236);
            this.label12.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(228, 25);
            this.label12.TabIndex = 25;
            this.label12.Text = "( BTC = 20, LTC = 20 )";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(351, 280);
            this.label13.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(252, 25);
            this.label13.TabIndex = 26;
            this.label13.Text = "( BTC = 330, LTC = 330 )";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(351, 412);
            this.label15.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(384, 25);
            this.label15.TabIndex = 28;
            this.label15.Text = "( BTC = .00000548, LTC = .00000001 )";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Location = new System.Drawing.Point(351, 461);
            this.label16.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(270, 25);
            this.label16.TabIndex = 29;
            this.label16.Text = "( BTC = 8332, LTC = 9332)";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(351, 505);
            this.label17.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(227, 25);
            this.label17.TabIndex = 30;
            this.label17.Text = "( 127.0.0.1, HTTPS:// )";
            // 
            // btnDelete
            // 
            this.btnDelete.Enabled = false;
            this.btnDelete.Location = new System.Drawing.Point(552, 33);
            this.btnDelete.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(104, 48);
            this.btnDelete.TabIndex = 31;
            this.btnDelete.Text = "Delete";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // chkGetRawSupport
            // 
            this.chkGetRawSupport.AutoSize = true;
            this.chkGetRawSupport.Enabled = false;
            this.chkGetRawSupport.Location = new System.Drawing.Point(150, 711);
            this.chkGetRawSupport.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkGetRawSupport.Name = "chkGetRawSupport";
            this.chkGetRawSupport.Size = new System.Drawing.Size(116, 29);
            this.chkGetRawSupport.TabIndex = 32;
            this.chkGetRawSupport.Text = "Monitor";
            this.chkGetRawSupport.UseVisualStyleBackColor = true;
            // 
            // chkFeePerAddress
            // 
            this.chkFeePerAddress.AutoSize = true;
            this.chkFeePerAddress.Enabled = false;
            this.chkFeePerAddress.Location = new System.Drawing.Point(357, 325);
            this.chkFeePerAddress.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkFeePerAddress.Name = "chkFeePerAddress";
            this.chkFeePerAddress.Size = new System.Drawing.Size(294, 29);
            this.chkFeePerAddress.TabIndex = 33;
            this.chkFeePerAddress.Text = "Estimate Fee Per Address";
            this.chkFeePerAddress.UseVisualStyleBackColor = true;
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(670, 33);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(104, 48);
            this.btnSave.TabIndex = 23;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // chkEnabled
            // 
            this.chkEnabled.AutoSize = true;
            this.chkEnabled.Location = new System.Drawing.Point(18, 711);
            this.chkEnabled.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.chkEnabled.Name = "chkEnabled";
            this.chkEnabled.Size = new System.Drawing.Size(123, 29);
            this.chkEnabled.TabIndex = 34;
            this.chkEnabled.Text = "Enabled";
            this.chkEnabled.UseVisualStyleBackColor = true;
            // 
            // label19
            // 
            this.label19.AutoSize = true;
            this.label19.Location = new System.Drawing.Point(62, 148);
            this.label19.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label19.Name = "label19";
            this.label19.Size = new System.Drawing.Size(125, 25);
            this.label19.TabIndex = 44;
            this.label19.Text = "Short Name";
            // 
            // txtShortName
            // 
            this.txtShortName.Enabled = false;
            this.txtShortName.Location = new System.Drawing.Point(194, 144);
            this.txtShortName.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtShortName.MaxLength = 20;
            this.txtShortName.Name = "txtShortName";
            this.txtShortName.Size = new System.Drawing.Size(148, 31);
            this.txtShortName.TabIndex = 43;
            // 
            // label20
            // 
            this.label20.AutoSize = true;
            this.label20.Location = new System.Drawing.Point(352, 148);
            this.label20.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label20.Name = "label20";
            this.label20.Size = new System.Drawing.Size(281, 25);
            this.label20.TabIndex = 45;
            this.label20.Text = "( BTC, LTC, DOGE, MZC... )";
            // 
            // label21
            // 
            this.label21.AutoSize = true;
            this.label21.Location = new System.Drawing.Point(28, 638);
            this.label21.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label21.Name = "label21";
            this.label21.Size = new System.Drawing.Size(158, 25);
            this.label21.TabIndex = 47;
            this.label21.Text = "Helper Url (%s)";
            // 
            // txtHelperUrl
            // 
            this.txtHelperUrl.Enabled = false;
            this.txtHelperUrl.Location = new System.Drawing.Point(194, 633);
            this.txtHelperUrl.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtHelperUrl.Name = "txtHelperUrl";
            this.txtHelperUrl.Size = new System.Drawing.Size(565, 31);
            this.txtHelperUrl.TabIndex = 46;
            // 
            // txtTipAmount
            // 
            this.txtTipAmount.Enabled = false;
            this.txtTipAmount.Location = new System.Drawing.Point(194, 367);
            this.txtTipAmount.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.txtTipAmount.Name = "txtTipAmount";
            this.txtTipAmount.Size = new System.Drawing.Size(148, 31);
            this.txtTipAmount.TabIndex = 48;
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(66, 372);
            this.label14.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(121, 25);
            this.label14.TabIndex = 49;
            this.label14.Text = "Tip Amount";
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(351, 372);
            this.label18.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(80, 25);
            this.label18.TabIndex = 50;
            this.label18.Text = "( .001 )";
            // 
            // Wallets
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 762);
            this.Controls.Add(this.label18);
            this.Controls.Add(this.txtTipAmount);
            this.Controls.Add(this.label14);
            this.Controls.Add(this.label21);
            this.Controls.Add(this.txtHelperUrl);
            this.Controls.Add(this.label20);
            this.Controls.Add(this.label19);
            this.Controls.Add(this.txtShortName);
            this.Controls.Add(this.chkEnabled);
            this.Controls.Add(this.chkFeePerAddress);
            this.Controls.Add(this.chkGetRawSupport);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.label17);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.label15);
            this.Controls.Add(this.label13);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.txtTransactionFee);
            this.Controls.Add(this.txtMinTransaction);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txtName);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtRPCPassword);
            this.Controls.Add(this.txtRPCUser);
            this.Controls.Add(this.txtRPCIP);
            this.Controls.Add(this.txtRPCPort);
            this.Controls.Add(this.txtTransactionSize);
            this.Controls.Add(this.txtPayload);
            this.Controls.Add(this.txtVersion);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.cmbWallets);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Wallets";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "  Wallet Settings";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Wallets_FormClosed);
            this.Load += new System.EventHandler(this.Wallets_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmbWallets;
        private System.Windows.Forms.Button btnAdd;
        private System.Windows.Forms.TextBox txtVersion;
        private System.Windows.Forms.TextBox txtPayload;
        private System.Windows.Forms.TextBox txtTransactionFee;
        private System.Windows.Forms.TextBox txtMinTransaction;
        private System.Windows.Forms.TextBox txtTransactionSize;
        private System.Windows.Forms.TextBox txtRPCPort;
        private System.Windows.Forms.TextBox txtRPCIP;
        private System.Windows.Forms.TextBox txtRPCUser;
        private System.Windows.Forms.TextBox txtRPCPassword;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.CheckBox chkGetRawSupport;
        private System.Windows.Forms.CheckBox chkFeePerAddress;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.CheckBox chkEnabled;
        private System.Windows.Forms.Label label19;
        private System.Windows.Forms.TextBox txtShortName;
        private System.Windows.Forms.Label label20;
        private System.Windows.Forms.Label label21;
        private System.Windows.Forms.TextBox txtHelperUrl;
        private System.Windows.Forms.TextBox txtTipAmount;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label18;
    }
}