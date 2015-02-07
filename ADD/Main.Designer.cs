namespace ADD
{
    partial class Main
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.attachFiles = new System.Windows.Forms.OpenFileDialog();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.cmbCoinType = new System.Windows.Forms.ComboBox();
            this.txtTransIDSearch = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.statusArchiveStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.imgEnterMessageHere = new System.Windows.Forms.PictureBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCoinTotal = new System.Windows.Forms.Label();
            this.btnArchive = new System.Windows.Forms.Button();
            this.cmbWalletLabel = new System.Windows.Forms.ComboBox();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.chkFilterUnSafeContent = new System.Windows.Forms.CheckBox();
            this.statusExploreStatus = new System.Windows.Forms.StatusStrip();
            this.lblExploreStatus = new System.Windows.Forms.ToolStripStatusLabel();
            this.lblMonitorInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.searchResults = new System.Windows.Forms.RichTextBox();
            this.chkMonitorBlockChains = new System.Windows.Forms.CheckBox();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notarizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proofToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.indexToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmrProgressBar = new System.Windows.Forms.Timer(this.components);
            this.tmrGetNewTransactions = new System.Windows.Forms.Timer(this.components);
            this.openDigestFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.groupBox1.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.statusArchiveStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusExploreStatus.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachFiles
            // 
            this.attachFiles.FileName = "openFileDialog1";
            this.attachFiles.Multiselect = true;
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Enabled = false;
            this.txtFileName.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(94, 228);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(566, 25);
            this.txtFileName.TabIndex = 8;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // cmbCoinType
            // 
            this.cmbCoinType.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbCoinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoinType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCoinType.FormattingEnabled = true;
            this.cmbCoinType.ItemHeight = 17;
            this.cmbCoinType.Location = new System.Drawing.Point(10, 262);
            this.cmbCoinType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbCoinType.MaximumSize = new System.Drawing.Size(571, 0);
            this.cmbCoinType.Name = "cmbCoinType";
            this.cmbCoinType.Size = new System.Drawing.Size(158, 25);
            this.cmbCoinType.TabIndex = 11;
            this.cmbCoinType.SelectedIndexChanged += new System.EventHandler(this.cmbCoinType_SelectedIndexChanged);
            // 
            // txtTransIDSearch
            // 
            this.txtTransIDSearch.AcceptsReturn = true;
            this.txtTransIDSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransIDSearch.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransIDSearch.Location = new System.Drawing.Point(3, 7);
            this.txtTransIDSearch.Name = "txtTransIDSearch";
            this.txtTransIDSearch.Size = new System.Drawing.Size(662, 23);
            this.txtTransIDSearch.TabIndex = 14;
            this.txtTransIDSearch.Text = "ENTER TRANSACTION ID";
            this.txtTransIDSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtTransIDSearch.Click += new System.EventHandler(this.txtTransIDSearch_Click);
            this.txtTransIDSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransIDSearch_KeyDown);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("unifont", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMessage.Location = new System.Drawing.Point(9, 6);
            this.txtMessage.MaxLength = 1024000000;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(651, 216);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblEstimatedCost);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(367, 265);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(181, 64);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estimated Cost";
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedCost.Location = new System.Drawing.Point(10, 26);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(84, 16);
            this.lblEstimatedCost.TabIndex = 0;
            this.lblEstimatedCost.Text = "0.00000000";
            this.lblEstimatedCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 28);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(679, 391);
            this.tabControl1.TabIndex = 21;
            // 
            // tabPage1
            // 
            this.tabPage1.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage1.Controls.Add(this.pictureBox1);
            this.tabPage1.Controls.Add(this.statusArchiveStatus);
            this.tabPage1.Controls.Add(this.imgEnterMessageHere);
            this.tabPage1.Controls.Add(this.groupBox2);
            this.tabPage1.Controls.Add(this.btnArchive);
            this.tabPage1.Controls.Add(this.cmbWalletLabel);
            this.tabPage1.Controls.Add(this.txtMessage);
            this.tabPage1.Controls.Add(this.btnAttachFile);
            this.tabPage1.Controls.Add(this.groupBox1);
            this.tabPage1.Controls.Add(this.txtFileName);
            this.tabPage1.Controls.Add(this.cmbCoinType);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(671, 362);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Archive";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox1.Image = global::ADD.Properties.Resources.Main;
            this.pictureBox1.Location = new System.Drawing.Point(45, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(555, 191);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 28;
            this.pictureBox1.TabStop = false;
            // 
            // statusArchiveStatus
            // 
            this.statusArchiveStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusArchiveStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusInfo,
            this.progressBar});
            this.statusArchiveStatus.Location = new System.Drawing.Point(3, 334);
            this.statusArchiveStatus.Name = "statusArchiveStatus";
            this.statusArchiveStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusArchiveStatus.Size = new System.Drawing.Size(665, 25);
            this.statusArchiveStatus.SizingGrip = false;
            this.statusArchiveStatus.TabIndex = 31;
            this.statusArchiveStatus.Text = "statusStrip1";
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.AutoSize = false;
            this.lblStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(372, 20);
            this.lblStatusInfo.Text = "Status: Select a wallet to get started.";
            this.lblStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Minimum = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(229, 19);
            this.progressBar.Step = 1;
            this.progressBar.Value = 1;
            this.progressBar.Visible = false;
            // 
            // imgEnterMessageHere
            // 
            this.imgEnterMessageHere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgEnterMessageHere.BackColor = System.Drawing.Color.White;
            this.imgEnterMessageHere.Image = ((System.Drawing.Image)(resources.GetObject("imgEnterMessageHere.Image")));
            this.imgEnterMessageHere.Location = new System.Drawing.Point(55, 18);
            this.imgEnterMessageHere.MinimumSize = new System.Drawing.Size(240, 18);
            this.imgEnterMessageHere.Name = "imgEnterMessageHere";
            this.imgEnterMessageHere.Size = new System.Drawing.Size(534, 191);
            this.imgEnterMessageHere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgEnterMessageHere.TabIndex = 29;
            this.imgEnterMessageHere.TabStop = false;
            this.imgEnterMessageHere.Visible = false;
            this.imgEnterMessageHere.Click += new System.EventHandler(this.imgEnterMessageHere_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.lblCoinTotal);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(177, 265);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(181, 64);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Funds";
            // 
            // lblCoinTotal
            // 
            this.lblCoinTotal.AutoSize = true;
            this.lblCoinTotal.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinTotal.Location = new System.Drawing.Point(10, 27);
            this.lblCoinTotal.Name = "lblCoinTotal";
            this.lblCoinTotal.Size = new System.Drawing.Size(84, 16);
            this.lblCoinTotal.TabIndex = 0;
            this.lblCoinTotal.Text = "0.00000000";
            this.lblCoinTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnArchive
            // 
            this.btnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchive.Enabled = false;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.Image = global::ADD.Properties.Resources.Save;
            this.btnArchive.Location = new System.Drawing.Point(568, 271);
            this.btnArchive.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(92, 58);
            this.btnArchive.TabIndex = 3;
            this.btnArchive.Tag = "12345678901234567890";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // cmbWalletLabel
            // 
            this.cmbWalletLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWalletLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWalletLabel.Enabled = false;
            this.cmbWalletLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWalletLabel.FormattingEnabled = true;
            this.cmbWalletLabel.Items.AddRange(new object[] {
            "Select Wallet From List"});
            this.cmbWalletLabel.Location = new System.Drawing.Point(10, 302);
            this.cmbWalletLabel.MaximumSize = new System.Drawing.Size(571, 0);
            this.cmbWalletLabel.Name = "cmbWalletLabel";
            this.cmbWalletLabel.Size = new System.Drawing.Size(158, 25);
            this.cmbWalletLabel.TabIndex = 21;
            this.cmbWalletLabel.SelectedIndexChanged += new System.EventHandler(this.cmbWalletLabel_SelectedIndexChanged);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAttachFile.Enabled = false;
            this.btnAttachFile.FlatAppearance.BorderSize = 0;
            this.btnAttachFile.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachFile.Image = global::ADD.Properties.Resources.Button2;
            this.btnAttachFile.Location = new System.Drawing.Point(9, 226);
            this.btnAttachFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(80, 28);
            this.btnAttachFile.TabIndex = 6;
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFiles_Click);
            // 
            // tabPage2
            // 
            this.tabPage2.BackColor = System.Drawing.SystemColors.Control;
            this.tabPage2.Controls.Add(this.chkFilterUnSafeContent);
            this.tabPage2.Controls.Add(this.statusExploreStatus);
            this.tabPage2.Controls.Add(this.searchResults);
            this.tabPage2.Controls.Add(this.chkMonitorBlockChains);
            this.tabPage2.Controls.Add(this.txtTransIDSearch);
            this.tabPage2.Location = new System.Drawing.Point(4, 25);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(671, 362);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Explore";
            // 
            // chkFilterUnSafeContent
            // 
            this.chkFilterUnSafeContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.chkFilterUnSafeContent.AutoSize = true;
            this.chkFilterUnSafeContent.Checked = true;
            this.chkFilterUnSafeContent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterUnSafeContent.Location = new System.Drawing.Point(498, 303);
            this.chkFilterUnSafeContent.Name = "chkFilterUnSafeContent";
            this.chkFilterUnSafeContent.Size = new System.Drawing.Size(163, 21);
            this.chkFilterUnSafeContent.TabIndex = 41;
            this.chkFilterUnSafeContent.Text = "Filter Unsafe Content";
            this.chkFilterUnSafeContent.UseVisualStyleBackColor = true;
            // 
            // statusExploreStatus
            // 
            this.statusExploreStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblExploreStatus,
            this.lblMonitorInfo});
            this.statusExploreStatus.Location = new System.Drawing.Point(3, 334);
            this.statusExploreStatus.Name = "statusExploreStatus";
            this.statusExploreStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusExploreStatus.Size = new System.Drawing.Size(665, 25);
            this.statusExploreStatus.SizingGrip = false;
            this.statusExploreStatus.TabIndex = 40;
            this.statusExploreStatus.Text = "statusStrip2";
            // 
            // lblExploreStatus
            // 
            this.lblExploreStatus.AutoSize = false;
            this.lblExploreStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblExploreStatus.Name = "lblExploreStatus";
            this.lblExploreStatus.Size = new System.Drawing.Size(372, 20);
            this.lblExploreStatus.Text = "Status: ";
            this.lblExploreStatus.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblMonitorInfo
            // 
            this.lblMonitorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitorInfo.Name = "lblMonitorInfo";
            this.lblMonitorInfo.Size = new System.Drawing.Size(83, 20);
            this.lblMonitorInfo.Text = "Monitor: 0/0";
            this.lblMonitorInfo.Visible = false;
            // 
            // searchResults
            // 
            this.searchResults.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResults.BackColor = System.Drawing.Color.White;
            this.searchResults.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.searchResults.Location = new System.Drawing.Point(10, 40);
            this.searchResults.Name = "searchResults";
            this.searchResults.Size = new System.Drawing.Size(650, 258);
            this.searchResults.TabIndex = 39;
            this.searchResults.Text = "";
            this.searchResults.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.searchResults_LinkClicked);
            // 
            // chkMonitorBlockChains
            // 
            this.chkMonitorBlockChains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMonitorBlockChains.AutoSize = true;
            this.chkMonitorBlockChains.Location = new System.Drawing.Point(10, 303);
            this.chkMonitorBlockChains.Name = "chkMonitorBlockChains";
            this.chkMonitorBlockChains.Size = new System.Drawing.Size(162, 21);
            this.chkMonitorBlockChains.TabIndex = 38;
            this.chkMonitorBlockChains.Text = "Monitor Block Chains";
            this.chkMonitorBlockChains.UseVisualStyleBackColor = true;
            this.chkMonitorBlockChains.CheckedChanged += new System.EventHandler(this.chkMonitorBlockChains_CheckedChanged);
            // 
            // menuMain
            // 
            this.menuMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(679, 26);
            this.menuMain.TabIndex = 22;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.notarizeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(43, 22);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.historyToolStripMenuItem.Text = "History";
            this.historyToolStripMenuItem.Click += new System.EventHandler(this.historyToolStripMenuItem_Click);
            // 
            // notarizeToolStripMenuItem
            // 
            this.notarizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proofToolStripMenuItem});
            this.notarizeToolStripMenuItem.Enabled = false;
            this.notarizeToolStripMenuItem.Name = "notarizeToolStripMenuItem";
            this.notarizeToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.notarizeToolStripMenuItem.Text = "Insert";
            // 
            // proofToolStripMenuItem
            // 
            this.proofToolStripMenuItem.Name = "proofToolStripMenuItem";
            this.proofToolStripMenuItem.Size = new System.Drawing.Size(113, 22);
            this.proofToolStripMenuItem.Text = "Proof";
            this.proofToolStripMenuItem.Click += new System.EventHandler(this.notarizeToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.walletsToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.indexToolStripMenuItem,
            this.trustToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // walletsToolStripMenuItem
            // 
            this.walletsToolStripMenuItem.Name = "walletsToolStripMenuItem";
            this.walletsToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.walletsToolStripMenuItem.Text = "Wallets";
            this.walletsToolStripMenuItem.Click += new System.EventHandler(this.walletsToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // indexToolStripMenuItem
            // 
            this.indexToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rebuildToolStripMenuItem});
            this.indexToolStripMenuItem.Name = "indexToolStripMenuItem";
            this.indexToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.indexToolStripMenuItem.Text = "Index";
            // 
            // rebuildToolStripMenuItem
            // 
            this.rebuildToolStripMenuItem.Name = "rebuildToolStripMenuItem";
            this.rebuildToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.rebuildToolStripMenuItem.Text = "Rebuild";
            this.rebuildToolStripMenuItem.Click += new System.EventHandler(this.rebuildToolStripMenuItem_Click);
            // 
            // trustToolStripMenuItem
            // 
            this.trustToolStripMenuItem.Name = "trustToolStripMenuItem";
            this.trustToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
            this.trustToolStripMenuItem.Text = "Trust";
            this.trustToolStripMenuItem.Click += new System.EventHandler(this.trustToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.rPCToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(50, 22);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rPCToolStripMenuItem
            // 
            this.rPCToolStripMenuItem.Name = "rPCToolStripMenuItem";
            this.rPCToolStripMenuItem.Size = new System.Drawing.Size(114, 22);
            this.rPCToolStripMenuItem.Text = "Info";
            this.rPCToolStripMenuItem.Click += new System.EventHandler(this.rPCToolStripMenuItem_Click);
            // 
            // tmrStatusUpdate
            // 
            this.tmrStatusUpdate.Interval = 5000;
            this.tmrStatusUpdate.Tick += new System.EventHandler(this.tmrStatusUpdate_Tick);
            // 
            // tmrProgressBar
            // 
            this.tmrProgressBar.Interval = 5000;
            this.tmrProgressBar.Tick += new System.EventHandler(this.tmrProgressBar_Tick);
            // 
            // tmrGetNewTransactions
            // 
            this.tmrGetNewTransactions.Interval = 1000;
            this.tmrGetNewTransactions.Tick += new System.EventHandler(this.tmrGetNewTransactions_Tick);
            // 
            // openDigestFile
            // 
            this.openDigestFile.FileName = "openFileDialog1";
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(146, 17);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(679, 419);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(529, 408);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertus - Disk Drive";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.statusArchiveStatus.ResumeLayout(false);
            this.statusArchiveStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.statusExploreStatus.ResumeLayout(false);
            this.statusExploreStatus.PerformLayout();
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog attachFiles;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.ComboBox cmbCoinType;
        private System.Windows.Forms.TextBox txtTransIDSearch;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.ComboBox cmbWalletLabel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCoinTotal;
        private System.Windows.Forms.PictureBox imgEnterMessageHere;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusArchiveStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Timer tmrStatusUpdate;
        private System.Windows.Forms.Timer tmrProgressBar;
        private System.Windows.Forms.CheckBox chkMonitorBlockChains;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walletsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer tmrGetNewTransactions;
        private System.Windows.Forms.RichTextBox searchResults;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.StatusStrip statusExploreStatus;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblExploreStatus;
        private System.Windows.Forms.CheckBox chkFilterUnSafeContent;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel lblMonitorInfo;
        private System.Windows.Forms.ToolStripMenuItem rPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notarizeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDigestFile;
        private System.Windows.Forms.ToolStripMenuItem proofToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem indexToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rebuildToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem trustToolStripMenuItem;
    }
}

