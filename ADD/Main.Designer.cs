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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Profile");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("Signature");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Vault");
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Favorites");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Follow");
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.attachFiles = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notarizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proofToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fileToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.hashToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.profilesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.walletsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.fontToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.trustToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rPCToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tmrStatusUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmrProgressBar = new System.Windows.Forms.Timer(this.components);
            this.tmrGetNewTransactions = new System.Windows.Forms.Timer(this.components);
            this.openDigestFile = new System.Windows.Forms.OpenFileDialog();
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.tmrProcessBatch = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdateInfoText = new System.Windows.Forms.Timer(this.components);
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.cmbCoinType = new System.Windows.Forms.ComboBox();
            this.cmbFollow = new System.Windows.Forms.ComboBox();
            this.imgEnterMessageHere = new System.Windows.Forms.PictureBox();
            this.cmbWalletLabel = new System.Windows.Forms.ComboBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.cmbTo = new System.Windows.Forms.ComboBox();
            this.btnArchive = new System.Windows.Forms.Button();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.btnFriendEncryption = new System.Windows.Forms.Button();
            this.txtAddVault = new System.Windows.Forms.TextBox();
            this.txtAddSignature = new System.Windows.Forms.TextBox();
            this.cmbFolder = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCoinTotal = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalArchiveSize = new System.Windows.Forms.Label();
            this.chkMonitorBlockChains = new System.Windows.Forms.CheckBox();
            this.chkFilterUnSafeContent = new System.Windows.Forms.CheckBox();
            this.chkEnableRecipients = new System.Windows.Forms.CheckBox();
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.chkEnableTips = new System.Windows.Forms.CheckBox();
            this.chkWarnArchive = new System.Windows.Forms.CheckBox();
            this.chkSaveOnEnter = new System.Windows.Forms.CheckBox();
            this.chkNoMessage = new System.Windows.Forms.CheckBox();
            this.chkTrackVault = new System.Windows.Forms.CheckBox();
            this.btnExportVault = new System.Windows.Forms.Button();
            this.cmbSignature = new System.Windows.Forms.ComboBox();
            this.btnExportSignature = new System.Windows.Forms.Button();
            this.btnAddSignature = new System.Windows.Forms.Button();
            this.btnExportProfile = new System.Windows.Forms.Button();
            this.cmbVault = new System.Windows.Forms.ComboBox();
            this.btnAddVault = new System.Windows.Forms.Button();
            this.btnAddFolder = new System.Windows.Forms.Button();
            this.imgOpenInBrowserButton = new System.Windows.Forms.PictureBox();
            this.totalResults = new System.Windows.Forms.NumericUpDown();
            this.imgTip = new System.Windows.Forms.PictureBox();
            this.imgLink = new System.Windows.Forms.PictureBox();
            this.imgFriend = new System.Windows.Forms.PictureBox();
            this.imgTrash = new System.Windows.Forms.PictureBox();
            this.imgFavorite = new System.Windows.Forms.PictureBox();
            this.txtTransIDSearch = new System.Windows.Forms.TextBox();
            this.imgCatalog = new System.Windows.Forms.PictureBox();
            this.imgNextButton = new System.Windows.Forms.PictureBox();
            this.imgBackButton = new System.Windows.Forms.PictureBox();
            this.statusArchiveStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.tmrPauseBeforeRefreshingMonitor = new System.Windows.Forms.Timer(this.components);
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.imgApertusSplash = new System.Windows.Forms.PictureBox();
            this.txtInfoBox = new System.Windows.Forms.TextBox();
            this.chkBackLinks = new System.Windows.Forms.CheckBox();
            this.contextMenuStrip1.SuspendLayout();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenInBrowserButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalResults)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTip)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLink)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFriend)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavorite)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCatalog)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackButton)).BeginInit();
            this.statusArchiveStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgApertusSplash)).BeginInit();
            this.SuspendLayout();
            // 
            // attachFiles
            // 
            this.attachFiles.Multiselect = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blockToolStripMenuItem,
            this.followToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(156, 76);
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(155, 36);
            this.blockToolStripMenuItem.Text = "block";
            // 
            // followToolStripMenuItem
            // 
            this.followToolStripMenuItem.Name = "followToolStripMenuItem";
            this.followToolStripMenuItem.Size = new System.Drawing.Size(155, 36);
            this.followToolStripMenuItem.Text = "follow";
            // 
            // menuMain
            // 
            this.menuMain.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.menuMain.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.settingsToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuMain.Location = new System.Drawing.Point(0, 0);
            this.menuMain.Name = "menuMain";
            this.menuMain.Padding = new System.Windows.Forms.Padding(7, 2, 0, 2);
            this.menuMain.Size = new System.Drawing.Size(1217, 37);
            this.menuMain.TabIndex = 0;
            this.menuMain.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.historyToolStripMenuItem,
            this.notarizeToolStripMenuItem,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(66, 33);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(193, 38);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rebuildToolStripMenuItem1});
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(193, 38);
            this.historyToolStripMenuItem.Text = "Catalog";
            // 
            // rebuildToolStripMenuItem1
            // 
            this.rebuildToolStripMenuItem1.Name = "rebuildToolStripMenuItem1";
            this.rebuildToolStripMenuItem1.Size = new System.Drawing.Size(194, 38);
            this.rebuildToolStripMenuItem1.Text = "Rebuild";
            this.rebuildToolStripMenuItem1.Click += new System.EventHandler(this.rebuildToolStripMenuItem_Click);
            // 
            // notarizeToolStripMenuItem
            // 
            this.notarizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proofToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.notarizeToolStripMenuItem.Name = "notarizeToolStripMenuItem";
            this.notarizeToolStripMenuItem.Size = new System.Drawing.Size(193, 38);
            this.notarizeToolStripMenuItem.Text = "Proof";
            // 
            // proofToolStripMenuItem
            // 
            this.proofToolStripMenuItem.Enabled = false;
            this.proofToolStripMenuItem.Name = "proofToolStripMenuItem";
            this.proofToolStripMenuItem.Size = new System.Drawing.Size(186, 38);
            this.proofToolStripMenuItem.Text = "Insert";
            this.proofToolStripMenuItem.Click += new System.EventHandler(this.notarizeToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem1,
            this.hashToolStripMenuItem});
            this.searchToolStripMenuItem.Enabled = false;
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(186, 38);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // fileToolStripMenuItem1
            // 
            this.fileToolStripMenuItem1.Name = "fileToolStripMenuItem1";
            this.fileToolStripMenuItem1.Size = new System.Drawing.Size(165, 38);
            this.fileToolStripMenuItem1.Text = "File";
            this.fileToolStripMenuItem1.Click += new System.EventHandler(this.fileToolStripMenuItem1_Click);
            // 
            // hashToolStripMenuItem
            // 
            this.hashToolStripMenuItem.Name = "hashToolStripMenuItem";
            this.hashToolStripMenuItem.Size = new System.Drawing.Size(165, 38);
            this.hashToolStripMenuItem.Text = "Hash";
            this.hashToolStripMenuItem.Click += new System.EventHandler(this.hashToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(193, 38);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.profilesToolStripMenuItem,
            this.walletsToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.trustToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(112, 33);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // profilesToolStripMenuItem
            // 
            this.profilesToolStripMenuItem.Enabled = false;
            this.profilesToolStripMenuItem.Name = "profilesToolStripMenuItem";
            this.profilesToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.profilesToolStripMenuItem.Text = "Profiles";
            this.profilesToolStripMenuItem.Click += new System.EventHandler(this.profilesToolStripMenuItem_Click);
            // 
            // walletsToolStripMenuItem
            // 
            this.walletsToolStripMenuItem.Name = "walletsToolStripMenuItem";
            this.walletsToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.walletsToolStripMenuItem.Text = "Wallets";
            this.walletsToolStripMenuItem.Click += new System.EventHandler(this.walletsToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // trustToolStripMenuItem
            // 
            this.trustToolStripMenuItem.Name = "trustToolStripMenuItem";
            this.trustToolStripMenuItem.Size = new System.Drawing.Size(243, 38);
            this.trustToolStripMenuItem.Text = "Trust Center";
            this.trustToolStripMenuItem.Click += new System.EventHandler(this.trustToolStripMenuItem_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem,
            this.rPCToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(76, 33);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(172, 38);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // rPCToolStripMenuItem
            // 
            this.rPCToolStripMenuItem.Name = "rPCToolStripMenuItem";
            this.rPCToolStripMenuItem.Size = new System.Drawing.Size(172, 38);
            this.rPCToolStripMenuItem.Text = "Info";
            this.rPCToolStripMenuItem.Click += new System.EventHandler(this.rPCToolStripMenuItem_Click);
            // 
            // tmrStatusUpdate
            // 
            this.tmrStatusUpdate.Interval = 5000;
            this.tmrStatusUpdate.Tick += new System.EventHandler(this.tmrStatusUpdate_Tick);
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
            // tmrProcessBatch
            // 
            this.tmrProcessBatch.Enabled = true;
            this.tmrProcessBatch.Interval = 300000;
            this.tmrProcessBatch.Tick += new System.EventHandler(this.tmrProcessBatch_Tick);
            // 
            // tmrUpdateInfoText
            // 
            this.tmrUpdateInfoText.Enabled = true;
            this.tmrUpdateInfoText.Interval = 10000;
            this.tmrUpdateInfoText.Tick += new System.EventHandler(this.tmrUpdateInfoText_Tick);
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.treeView1.Font = new System.Drawing.Font("Arial", 10.875F);
            this.treeView1.Location = new System.Drawing.Point(12, 198);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "profile";
            treeNode1.Text = "Profile";
            treeNode2.Name = "signature";
            treeNode2.Text = "Signature";
            treeNode3.Name = "vault";
            treeNode3.Text = "Vault";
            treeNode4.Name = "favorites";
            treeNode4.Text = "Favorites";
            treeNode5.Name = "follow";
            treeNode5.Text = "Follow";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode2,
            treeNode3,
            treeNode4,
            treeNode5});
            this.treeView1.Size = new System.Drawing.Size(515, 102);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // cmbCoinType
            // 
            this.cmbCoinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoinType.Font = new System.Drawing.Font("Arial", 10.875F);
            this.cmbCoinType.FormattingEnabled = true;
            this.cmbCoinType.ItemHeight = 33;
            this.cmbCoinType.Location = new System.Drawing.Point(12, 52);
            this.cmbCoinType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbCoinType.MaxDropDownItems = 100;
            this.cmbCoinType.Name = "cmbCoinType";
            this.cmbCoinType.Size = new System.Drawing.Size(515, 41);
            this.cmbCoinType.TabIndex = 11;
            this.cmbCoinType.SelectedIndexChanged += new System.EventHandler(this.cmbCoinType_SelectedIndexChanged);
            // 
            // cmbFollow
            // 
            this.cmbFollow.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFollow.Enabled = false;
            this.cmbFollow.Font = new System.Drawing.Font("Arial", 10.875F);
            this.cmbFollow.FormattingEnabled = true;
            this.cmbFollow.Location = new System.Drawing.Point(12, 151);
            this.cmbFollow.MaxDropDownItems = 100;
            this.cmbFollow.Name = "cmbFollow";
            this.cmbFollow.Size = new System.Drawing.Size(515, 41);
            this.cmbFollow.TabIndex = 50;
            this.cmbFollow.SelectedIndexChanged += new System.EventHandler(this.cmbFollow_SelectedIndexChanged);
            // 
            // imgEnterMessageHere
            // 
            this.imgEnterMessageHere.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgEnterMessageHere.BackColor = System.Drawing.Color.White;
            this.imgEnterMessageHere.Image = ((System.Drawing.Image)(resources.GetObject("imgEnterMessageHere.Image")));
            this.imgEnterMessageHere.Location = new System.Drawing.Point(25, 386);
            this.imgEnterMessageHere.Name = "imgEnterMessageHere";
            this.imgEnterMessageHere.Size = new System.Drawing.Size(481, 203);
            this.imgEnterMessageHere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgEnterMessageHere.TabIndex = 29;
            this.imgEnterMessageHere.TabStop = false;
            this.imgEnterMessageHere.Visible = false;
            this.imgEnterMessageHere.Click += new System.EventHandler(this.imgEnterMessageHere_Click);
            // 
            // cmbWalletLabel
            // 
            this.cmbWalletLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWalletLabel.Enabled = false;
            this.cmbWalletLabel.Font = new System.Drawing.Font("Arial", 10.875F);
            this.cmbWalletLabel.FormattingEnabled = true;
            this.cmbWalletLabel.ItemHeight = 33;
            this.cmbWalletLabel.Items.AddRange(new object[] {
            "Select Funding Source"});
            this.cmbWalletLabel.Location = new System.Drawing.Point(12, 100);
            this.cmbWalletLabel.MaxDropDownItems = 100;
            this.cmbWalletLabel.Name = "cmbWalletLabel";
            this.cmbWalletLabel.Size = new System.Drawing.Size(515, 41);
            this.cmbWalletLabel.TabIndex = 21;
            this.cmbWalletLabel.SelectedIndexChanged += new System.EventHandler(this.cmbWalletLabel_SelectedIndexChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMessage.Location = new System.Drawing.Point(12, 353);
            this.txtMessage.MaxLength = 1024000000;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(515, 268);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAttachFile.Enabled = false;
            this.btnAttachFile.FlatAppearance.BorderSize = 0;
            this.btnAttachFile.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachFile.Location = new System.Drawing.Point(12, 627);
            this.btnAttachFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(86, 41);
            this.btnAttachFile.TabIndex = 6;
            this.btnAttachFile.Text = "Attach";
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFiles_Click);
            // 
            // cmbTo
            // 
            this.cmbTo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbTo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTo.Enabled = false;
            this.cmbTo.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.cmbTo.Font = new System.Drawing.Font("Arial", 10.875F);
            this.cmbTo.FormattingEnabled = true;
            this.cmbTo.Location = new System.Drawing.Point(124, 306);
            this.cmbTo.MaxDropDownItems = 100;
            this.cmbTo.Name = "cmbTo";
            this.cmbTo.Size = new System.Drawing.Size(403, 41);
            this.cmbTo.TabIndex = 49;
            this.cmbTo.SelectedIndexChanged += new System.EventHandler(this.cmbTo_SelectedIndexChanged_1);
            // 
            // btnArchive
            // 
            this.btnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnArchive.Enabled = false;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.Location = new System.Drawing.Point(389, 823);
            this.btnArchive.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(138, 56);
            this.btnArchive.TabIndex = 3;
            this.btnArchive.Tag = "12345678901234567890";
            this.btnArchive.Text = "Etch";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtFileName.Enabled = false;
            this.txtFileName.Font = new System.Drawing.Font("Arial", 10.875F);
            this.txtFileName.Location = new System.Drawing.Point(103, 627);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(424, 41);
            this.txtFileName.TabIndex = 8;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // btnFriendEncryption
            // 
            this.btnFriendEncryption.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnFriendEncryption.Enabled = false;
            this.btnFriendEncryption.Location = new System.Drawing.Point(12, 306);
            this.btnFriendEncryption.Name = "btnFriendEncryption";
            this.btnFriendEncryption.Size = new System.Drawing.Size(98, 41);
            this.btnFriendEncryption.TabIndex = 50;
            this.btnFriendEncryption.Text = "Public";
            this.btnFriendEncryption.UseVisualStyleBackColor = true;
            this.btnFriendEncryption.Click += new System.EventHandler(this.btnFriendEncryption_Click);
            // 
            // txtAddVault
            // 
            this.txtAddVault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAddVault.Location = new System.Drawing.Point(103, 777);
            this.txtAddVault.Name = "txtAddVault";
            this.txtAddVault.Size = new System.Drawing.Size(399, 31);
            this.txtAddVault.TabIndex = 45;
            this.txtAddVault.Visible = false;
            this.txtAddVault.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddVault_KeyDown);
            // 
            // txtAddSignature
            // 
            this.txtAddSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.txtAddSignature.Location = new System.Drawing.Point(103, 729);
            this.txtAddSignature.Name = "txtAddSignature";
            this.txtAddSignature.Size = new System.Drawing.Size(399, 31);
            this.txtAddSignature.TabIndex = 44;
            this.txtAddSignature.Visible = false;
            this.txtAddSignature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddSignature_KeyDown);
            // 
            // cmbFolder
            // 
            this.cmbFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbFolder.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbFolder.Enabled = false;
            this.cmbFolder.Font = new System.Drawing.Font("Arial", 10.875F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbFolder.FormattingEnabled = true;
            this.cmbFolder.Location = new System.Drawing.Point(103, 675);
            this.cmbFolder.MaxDropDownItems = 100;
            this.cmbFolder.Name = "cmbFolder";
            this.cmbFolder.Size = new System.Drawing.Size(424, 41);
            this.cmbFolder.TabIndex = 32;
            this.cmbFolder.SelectedIndexChanged += new System.EventHandler(this.cmbFolder_SelectedIndexChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox1.Controls.Add(this.lblEstimatedCost);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(766, 823);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(218, 60);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estimated Cost";
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedCost.Location = new System.Drawing.Point(6, 32);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(124, 24);
            this.lblEstimatedCost.TabIndex = 0;
            this.lblEstimatedCost.Text = "0.00000000";
            this.lblEstimatedCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox2.Controls.Add(this.lblCoinTotal);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(999, 823);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(218, 60);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Funds";
            // 
            // lblCoinTotal
            // 
            this.lblCoinTotal.AutoSize = true;
            this.lblCoinTotal.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinTotal.Location = new System.Drawing.Point(6, 32);
            this.lblCoinTotal.Name = "lblCoinTotal";
            this.lblCoinTotal.Size = new System.Drawing.Size(124, 24);
            this.lblCoinTotal.TabIndex = 0;
            this.lblCoinTotal.Text = "0.00000000";
            this.lblCoinTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.groupBox3.Controls.Add(this.lblTotalArchiveSize);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(542, 823);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(218, 60);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total Archive Size";
            // 
            // lblTotalArchiveSize
            // 
            this.lblTotalArchiveSize.AutoSize = true;
            this.lblTotalArchiveSize.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArchiveSize.Location = new System.Drawing.Point(6, 32);
            this.lblTotalArchiveSize.Name = "lblTotalArchiveSize";
            this.lblTotalArchiveSize.Size = new System.Drawing.Size(124, 24);
            this.lblTotalArchiveSize.TabIndex = 0;
            this.lblTotalArchiveSize.Text = "0.00000000";
            this.lblTotalArchiveSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkMonitorBlockChains
            // 
            this.chkMonitorBlockChains.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkMonitorBlockChains.AutoSize = true;
            this.chkMonitorBlockChains.Location = new System.Drawing.Point(189, 855);
            this.chkMonitorBlockChains.Name = "chkMonitorBlockChains";
            this.chkMonitorBlockChains.Size = new System.Drawing.Size(116, 29);
            this.chkMonitorBlockChains.TabIndex = 2;
            this.chkMonitorBlockChains.TabStop = false;
            this.chkMonitorBlockChains.Text = "Monitor";
            this.chkMonitorBlockChains.UseVisualStyleBackColor = true;
            this.chkMonitorBlockChains.CheckedChanged += new System.EventHandler(this.chkMonitorBlockChains_CheckedChanged);
            // 
            // chkFilterUnSafeContent
            // 
            this.chkFilterUnSafeContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFilterUnSafeContent.AutoSize = true;
            this.chkFilterUnSafeContent.Checked = true;
            this.chkFilterUnSafeContent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterUnSafeContent.Location = new System.Drawing.Point(189, 817);
            this.chkFilterUnSafeContent.Name = "chkFilterUnSafeContent";
            this.chkFilterUnSafeContent.Size = new System.Drawing.Size(92, 29);
            this.chkFilterUnSafeContent.TabIndex = 3;
            this.chkFilterUnSafeContent.TabStop = false;
            this.chkFilterUnSafeContent.Text = "Filter";
            this.chkFilterUnSafeContent.UseVisualStyleBackColor = true;
            this.chkFilterUnSafeContent.CheckedChanged += new System.EventHandler(this.chkFilterUnSafeContent_CheckedChanged);
            // 
            // chkEnableRecipients
            // 
            this.chkEnableRecipients.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnableRecipients.AutoSize = true;
            this.chkEnableRecipients.Checked = true;
            this.chkEnableRecipients.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkEnableRecipients.Location = new System.Drawing.Point(1225, 823);
            this.chkEnableRecipients.Margin = new System.Windows.Forms.Padding(5);
            this.chkEnableRecipients.Name = "chkEnableRecipients";
            this.chkEnableRecipients.Size = new System.Drawing.Size(166, 29);
            this.chkEnableRecipients.TabIndex = 24;
            this.chkEnableRecipients.Text = "@Recipients";
            this.chkEnableRecipients.UseVisualStyleBackColor = true;
            this.chkEnableRecipients.CheckedChanged += new System.EventHandler(this.chkEnableRecipients_CheckedChanged);
            // 
            // chkKeywords
            // 
            this.chkKeywords.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkKeywords.AutoSize = true;
            this.chkKeywords.Checked = true;
            this.chkKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeywords.Location = new System.Drawing.Point(1225, 855);
            this.chkKeywords.Margin = new System.Windows.Forms.Padding(5);
            this.chkKeywords.Name = "chkKeywords";
            this.chkKeywords.Size = new System.Drawing.Size(150, 29);
            this.chkKeywords.TabIndex = 0;
            this.chkKeywords.Text = "#Keywords";
            this.chkKeywords.UseVisualStyleBackColor = true;
            this.chkKeywords.CheckedChanged += new System.EventHandler(this.chkKeywords_CheckedChanged);
            // 
            // chkEnableTips
            // 
            this.chkEnableTips.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkEnableTips.AutoSize = true;
            this.chkEnableTips.Location = new System.Drawing.Point(1399, 854);
            this.chkEnableTips.Name = "chkEnableTips";
            this.chkEnableTips.Size = new System.Drawing.Size(97, 29);
            this.chkEnableTips.TabIndex = 26;
            this.chkEnableTips.Text = ">Tips";
            this.chkEnableTips.UseVisualStyleBackColor = true;
            this.chkEnableTips.CheckedChanged += new System.EventHandler(this.chkEnableTips_CheckedChanged);
            // 
            // chkWarnArchive
            // 
            this.chkWarnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkWarnArchive.AutoSize = true;
            this.chkWarnArchive.Checked = true;
            this.chkWarnArchive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWarnArchive.Location = new System.Drawing.Point(1399, 823);
            this.chkWarnArchive.Name = "chkWarnArchive";
            this.chkWarnArchive.Size = new System.Drawing.Size(179, 29);
            this.chkWarnArchive.TabIndex = 21;
            this.chkWarnArchive.Text = "Save Warning";
            this.chkWarnArchive.UseVisualStyleBackColor = true;
            this.chkWarnArchive.CheckedChanged += new System.EventHandler(this.chkWarnArchive_CheckedChanged);
            // 
            // chkSaveOnEnter
            // 
            this.chkSaveOnEnter.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkSaveOnEnter.AutoSize = true;
            this.chkSaveOnEnter.Location = new System.Drawing.Point(1584, 858);
            this.chkSaveOnEnter.Name = "chkSaveOnEnter";
            this.chkSaveOnEnter.Size = new System.Drawing.Size(168, 29);
            this.chkSaveOnEnter.TabIndex = 22;
            this.chkSaveOnEnter.Text = "Enter = Save";
            this.chkSaveOnEnter.UseVisualStyleBackColor = true;
            this.chkSaveOnEnter.CheckedChanged += new System.EventHandler(this.chkSaveOnEnter_CheckedChanged);
            // 
            // chkNoMessage
            // 
            this.chkNoMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkNoMessage.AutoSize = true;
            this.chkNoMessage.Location = new System.Drawing.Point(12, 850);
            this.chkNoMessage.Name = "chkNoMessage";
            this.chkNoMessage.Size = new System.Drawing.Size(118, 29);
            this.chkNoMessage.TabIndex = 27;
            this.chkNoMessage.Text = "No Msg";
            this.chkNoMessage.UseVisualStyleBackColor = true;
            // 
            // chkTrackVault
            // 
            this.chkTrackVault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTrackVault.AutoSize = true;
            this.chkTrackVault.Checked = true;
            this.chkTrackVault.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkTrackVault.Location = new System.Drawing.Point(1584, 823);
            this.chkTrackVault.Name = "chkTrackVault";
            this.chkTrackVault.Size = new System.Drawing.Size(153, 29);
            this.chkTrackVault.TabIndex = 23;
            this.chkTrackVault.Text = "Track Vault";
            this.chkTrackVault.UseVisualStyleBackColor = true;
            this.chkTrackVault.CheckedChanged += new System.EventHandler(this.chkTrackVault_CheckedChanged);
            // 
            // btnExportVault
            // 
            this.btnExportVault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportVault.Enabled = false;
            this.btnExportVault.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportVault.Location = new System.Drawing.Point(66, 772);
            this.btnExportVault.Name = "btnExportVault";
            this.btnExportVault.Size = new System.Drawing.Size(32, 41);
            this.btnExportVault.TabIndex = 48;
            this.btnExportVault.Text = "↯";
            this.btnExportVault.UseVisualStyleBackColor = true;
            this.btnExportVault.Click += new System.EventHandler(this.btnExportVault_Click);
            // 
            // cmbSignature
            // 
            this.cmbSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSignature.Enabled = false;
            this.cmbSignature.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSignature.FormattingEnabled = true;
            this.cmbSignature.Items.AddRange(new object[] {
            "Select Folder"});
            this.cmbSignature.Location = new System.Drawing.Point(103, 723);
            this.cmbSignature.MaxDropDownItems = 100;
            this.cmbSignature.Name = "cmbSignature";
            this.cmbSignature.Size = new System.Drawing.Size(424, 40);
            this.cmbSignature.TabIndex = 34;
            this.cmbSignature.SelectedIndexChanged += new System.EventHandler(this.cmbSignature_SelectedIndexChanged);
            // 
            // btnExportSignature
            // 
            this.btnExportSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportSignature.Enabled = false;
            this.btnExportSignature.Font = new System.Drawing.Font("Arial", 10.2F);
            this.btnExportSignature.Location = new System.Drawing.Point(65, 724);
            this.btnExportSignature.Name = "btnExportSignature";
            this.btnExportSignature.Size = new System.Drawing.Size(32, 41);
            this.btnExportSignature.TabIndex = 47;
            this.btnExportSignature.Text = "↯";
            this.btnExportSignature.UseVisualStyleBackColor = true;
            this.btnExportSignature.Click += new System.EventHandler(this.btnExportSignature_Click);
            // 
            // btnAddSignature
            // 
            this.btnAddSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSignature.Enabled = false;
            this.btnAddSignature.Location = new System.Drawing.Point(12, 724);
            this.btnAddSignature.Name = "btnAddSignature";
            this.btnAddSignature.Size = new System.Drawing.Size(47, 41);
            this.btnAddSignature.TabIndex = 39;
            this.btnAddSignature.Text = "+";
            this.btnAddSignature.UseVisualStyleBackColor = true;
            this.btnAddSignature.Click += new System.EventHandler(this.btnAddSignature_Click);
            // 
            // btnExportProfile
            // 
            this.btnExportProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnExportProfile.Enabled = false;
            this.btnExportProfile.Font = new System.Drawing.Font("Arial", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportProfile.Location = new System.Drawing.Point(65, 675);
            this.btnExportProfile.Name = "btnExportProfile";
            this.btnExportProfile.Size = new System.Drawing.Size(32, 41);
            this.btnExportProfile.TabIndex = 46;
            this.btnExportProfile.Text = "↯";
            this.btnExportProfile.UseVisualStyleBackColor = true;
            this.btnExportProfile.Click += new System.EventHandler(this.btnExportProfile_Click);
            // 
            // cmbVault
            // 
            this.cmbVault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbVault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVault.Enabled = false;
            this.cmbVault.Font = new System.Drawing.Font("Arial", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVault.FormattingEnabled = true;
            this.cmbVault.Items.AddRange(new object[] {
            "Select Folder"});
            this.cmbVault.Location = new System.Drawing.Point(103, 771);
            this.cmbVault.MaxDropDownItems = 100;
            this.cmbVault.Name = "cmbVault";
            this.cmbVault.Size = new System.Drawing.Size(424, 40);
            this.cmbVault.TabIndex = 40;
            this.cmbVault.SelectedIndexChanged += new System.EventHandler(this.cmbVault_SelectedIndexChanged);
            // 
            // btnAddVault
            // 
            this.btnAddVault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddVault.Enabled = false;
            this.btnAddVault.Location = new System.Drawing.Point(12, 772);
            this.btnAddVault.Name = "btnAddVault";
            this.btnAddVault.Size = new System.Drawing.Size(47, 41);
            this.btnAddVault.TabIndex = 41;
            this.btnAddVault.Text = "+";
            this.btnAddVault.UseVisualStyleBackColor = true;
            this.btnAddVault.Click += new System.EventHandler(this.btnAddVault_Click);
            // 
            // btnAddFolder
            // 
            this.btnAddFolder.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddFolder.Enabled = false;
            this.btnAddFolder.Location = new System.Drawing.Point(12, 675);
            this.btnAddFolder.Name = "btnAddFolder";
            this.btnAddFolder.Size = new System.Drawing.Size(47, 41);
            this.btnAddFolder.TabIndex = 42;
            this.btnAddFolder.Text = "+";
            this.btnAddFolder.UseVisualStyleBackColor = true;
            this.btnAddFolder.Click += new System.EventHandler(this.btnAddFolder_Click);
            // 
            // imgOpenInBrowserButton
            // 
            this.imgOpenInBrowserButton.Image = global::ADD.Properties.Resources.OpenInWeb;
            this.imgOpenInBrowserButton.Location = new System.Drawing.Point(535, 40);
            this.imgOpenInBrowserButton.Name = "imgOpenInBrowserButton";
            this.imgOpenInBrowserButton.Size = new System.Drawing.Size(40, 40);
            this.imgOpenInBrowserButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenInBrowserButton.TabIndex = 12;
            this.imgOpenInBrowserButton.TabStop = false;
            this.imgOpenInBrowserButton.Click += new System.EventHandler(this.imgOpenInBrowserButton_Click);
            // 
            // totalResults
            // 
            this.totalResults.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.totalResults.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalResults.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
            this.totalResults.Location = new System.Drawing.Point(829, 40);
            this.totalResults.Maximum = new decimal(new int[] {
            10000,
            0,
            0,
            0});
            this.totalResults.MaximumSize = new System.Drawing.Size(145, 0);
            this.totalResults.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.totalResults.Name = "totalResults";
            this.totalResults.Size = new System.Drawing.Size(108, 40);
            this.totalResults.TabIndex = 11;
            this.totalResults.Value = new decimal(new int[] {
            50,
            0,
            0,
            0});
            // 
            // imgTip
            // 
            this.imgTip.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgTip.Enabled = false;
            this.imgTip.Image = global::ADD.Properties.Resources.TipDisabled;
            this.imgTip.Location = new System.Drawing.Point(1081, 40);
            this.imgTip.Name = "imgTip";
            this.imgTip.Size = new System.Drawing.Size(40, 40);
            this.imgTip.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgTip.TabIndex = 10;
            this.imgTip.TabStop = false;
            this.imgTip.Click += new System.EventHandler(this.imgTip_Click);
            // 
            // imgLink
            // 
            this.imgLink.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgLink.Enabled = false;
            this.imgLink.Image = global::ADD.Properties.Resources.LinkDisabled;
            this.imgLink.Location = new System.Drawing.Point(1127, 40);
            this.imgLink.Name = "imgLink";
            this.imgLink.Size = new System.Drawing.Size(40, 40);
            this.imgLink.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgLink.TabIndex = 9;
            this.imgLink.TabStop = false;
            this.imgLink.Click += new System.EventHandler(this.imgLink_Click);
            // 
            // imgFriend
            // 
            this.imgFriend.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgFriend.Image = global::ADD.Properties.Resources.FriendDisabled;
            this.imgFriend.Location = new System.Drawing.Point(1035, 40);
            this.imgFriend.Name = "imgFriend";
            this.imgFriend.Size = new System.Drawing.Size(40, 40);
            this.imgFriend.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgFriend.TabIndex = 8;
            this.imgFriend.TabStop = false;
            this.imgFriend.Click += new System.EventHandler(this.imgFriend_Click);
            // 
            // imgTrash
            // 
            this.imgTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgTrash.Enabled = false;
            this.imgTrash.Image = global::ADD.Properties.Resources.TrashDisabled;
            this.imgTrash.Location = new System.Drawing.Point(1173, 40);
            this.imgTrash.Name = "imgTrash";
            this.imgTrash.Size = new System.Drawing.Size(40, 40);
            this.imgTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgTrash.TabIndex = 5;
            this.imgTrash.TabStop = false;
            this.imgTrash.Click += new System.EventHandler(this.imgTrash_Click);
            // 
            // imgFavorite
            // 
            this.imgFavorite.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgFavorite.Image = global::ADD.Properties.Resources.star;
            this.imgFavorite.Location = new System.Drawing.Point(989, 40);
            this.imgFavorite.Name = "imgFavorite";
            this.imgFavorite.Size = new System.Drawing.Size(40, 40);
            this.imgFavorite.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgFavorite.TabIndex = 7;
            this.imgFavorite.TabStop = false;
            this.imgFavorite.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // txtTransIDSearch
            // 
            this.txtTransIDSearch.AcceptsReturn = true;
            this.txtTransIDSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransIDSearch.Font = new System.Drawing.Font("Calibri", 10.125F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransIDSearch.ForeColor = System.Drawing.Color.LightGray;
            this.txtTransIDSearch.Location = new System.Drawing.Point(654, 40);
            this.txtTransIDSearch.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtTransIDSearch.Name = "txtTransIDSearch";
            this.txtTransIDSearch.Size = new System.Drawing.Size(169, 40);
            this.txtTransIDSearch.TabIndex = 1;
            this.txtTransIDSearch.TabStop = false;
            this.txtTransIDSearch.Text = "ENTER SEARCH STRING";
            this.txtTransIDSearch.Click += new System.EventHandler(this.txtTransIDSearch_Click);
            this.txtTransIDSearch.TextChanged += new System.EventHandler(this.txtTransIDSearch_TextChanged);
            this.txtTransIDSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransIDSearch_KeyDown);
            // 
            // imgCatalog
            // 
            this.imgCatalog.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgCatalog.Image = global::ADD.Properties.Resources.home;
            this.imgCatalog.Location = new System.Drawing.Point(943, 40);
            this.imgCatalog.Name = "imgCatalog";
            this.imgCatalog.Size = new System.Drawing.Size(40, 40);
            this.imgCatalog.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgCatalog.TabIndex = 6;
            this.imgCatalog.TabStop = false;
            this.imgCatalog.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // imgNextButton
            // 
            this.imgNextButton.Image = global::ADD.Properties.Resources.OpenRightDisabled;
            this.imgNextButton.Location = new System.Drawing.Point(612, 40);
            this.imgNextButton.Name = "imgNextButton";
            this.imgNextButton.Size = new System.Drawing.Size(40, 40);
            this.imgNextButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgNextButton.TabIndex = 5;
            this.imgNextButton.TabStop = false;
            this.imgNextButton.Click += new System.EventHandler(this.imgNextButton_Click);
            // 
            // imgBackButton
            // 
            this.imgBackButton.Image = global::ADD.Properties.Resources.OpenLeftDisabled;
            this.imgBackButton.Location = new System.Drawing.Point(575, 40);
            this.imgBackButton.Name = "imgBackButton";
            this.imgBackButton.Size = new System.Drawing.Size(40, 40);
            this.imgBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackButton.TabIndex = 4;
            this.imgBackButton.TabStop = false;
            this.imgBackButton.Click += new System.EventHandler(this.imgBackButton_Click);
            // 
            // statusArchiveStatus
            // 
            this.statusArchiveStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusArchiveStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusArchiveStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusInfo});
            this.statusArchiveStatus.Location = new System.Drawing.Point(0, 886);
            this.statusArchiveStatus.Name = "statusArchiveStatus";
            this.statusArchiveStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusArchiveStatus.Size = new System.Drawing.Size(1217, 30);
            this.statusArchiveStatus.SizingGrip = false;
            this.statusArchiveStatus.TabIndex = 32;
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(1200, 25);
            this.lblStatusInfo.Spring = true;
            this.lblStatusInfo.Text = "Select a blockchain to get started.";
            this.lblStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // tmrPauseBeforeRefreshingMonitor
            // 
            this.tmrPauseBeforeRefreshingMonitor.Interval = 2000;
            this.tmrPauseBeforeRefreshingMonitor.Tick += new System.EventHandler(this.tmrPauseBeforeRefreshingMonitor_Tick);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.webBrowser1.Location = new System.Drawing.Point(535, 83);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.ScriptErrorsSuppressed = true;
            this.webBrowser1.Size = new System.Drawing.Size(682, 725);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // imgApertusSplash
            // 
            this.imgApertusSplash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.imgApertusSplash.Image = global::ADD.Properties.Resources.About;
            this.imgApertusSplash.Location = new System.Drawing.Point(621, 266);
            this.imgApertusSplash.Name = "imgApertusSplash";
            this.imgApertusSplash.Size = new System.Drawing.Size(499, 323);
            this.imgApertusSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgApertusSplash.TabIndex = 0;
            this.imgApertusSplash.TabStop = false;
            this.imgApertusSplash.Resize += new System.EventHandler(this.imgApertusSplash_Resize);
            // 
            // txtInfoBox
            // 
            this.txtInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoBox.Location = new System.Drawing.Point(570, 161);
            this.txtInfoBox.Name = "txtInfoBox";
            this.txtInfoBox.Size = new System.Drawing.Size(597, 24);
            this.txtInfoBox.TabIndex = 51;
            this.txtInfoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // chkBackLinks
            // 
            this.chkBackLinks.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBackLinks.AutoSize = true;
            this.chkBackLinks.Location = new System.Drawing.Point(12, 819);
            this.chkBackLinks.Name = "chkBackLinks";
            this.chkBackLinks.Size = new System.Drawing.Size(149, 29);
            this.chkBackLinks.TabIndex = 52;
            this.chkBackLinks.TabStop = false;
            this.chkBackLinks.Text = "Back Links";
            this.chkBackLinks.UseVisualStyleBackColor = true;
            this.chkBackLinks.CheckedChanged += new System.EventHandler(this.chkBackLinks_CheckedChanged);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(1217, 916);
            this.Controls.Add(this.chkBackLinks);
            this.Controls.Add(this.cmbFollow);
            this.Controls.Add(this.chkTrackVault);
            this.Controls.Add(this.chkNoMessage);
            this.Controls.Add(this.chkSaveOnEnter);
            this.Controls.Add(this.chkWarnArchive);
            this.Controls.Add(this.chkEnableTips);
            this.Controls.Add(this.chkEnableRecipients);
            this.Controls.Add(this.chkFilterUnSafeContent);
            this.Controls.Add(this.chkMonitorBlockChains);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txtInfoBox);
            this.Controls.Add(this.imgApertusSplash);
            this.Controls.Add(this.txtAddVault);
            this.Controls.Add(this.chkKeywords);
            this.Controls.Add(this.imgEnterMessageHere);
            this.Controls.Add(this.btnAddFolder);
            this.Controls.Add(this.btnAddVault);
            this.Controls.Add(this.txtFileName);
            this.Controls.Add(this.txtAddSignature);
            this.Controls.Add(this.btnAttachFile);
            this.Controls.Add(this.cmbVault);
            this.Controls.Add(this.imgOpenInBrowserButton);
            this.Controls.Add(this.btnExportProfile);
            this.Controls.Add(this.statusArchiveStatus);
            this.Controls.Add(this.cmbFolder);
            this.Controls.Add(this.btnAddSignature);
            this.Controls.Add(this.menuMain);
            this.Controls.Add(this.btnExportSignature);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.btnExportVault);
            this.Controls.Add(this.cmbTo);
            this.Controls.Add(this.cmbSignature);
            this.Controls.Add(this.cmbWalletLabel);
            this.Controls.Add(this.imgTrash);
            this.Controls.Add(this.btnFriendEncryption);
            this.Controls.Add(this.imgBackButton);
            this.Controls.Add(this.imgNextButton);
            this.Controls.Add(this.imgCatalog);
            this.Controls.Add(this.btnArchive);
            this.Controls.Add(this.txtMessage);
            this.Controls.Add(this.txtTransIDSearch);
            this.Controls.Add(this.imgFavorite);
            this.Controls.Add(this.imgFriend);
            this.Controls.Add(this.imgLink);
            this.Controls.Add(this.imgTip);
            this.Controls.Add(this.totalResults);
            this.Controls.Add(this.cmbCoinType);
            this.Controls.Add(this.webBrowser1);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(1243, 987);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Apertus";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Shown += new System.EventHandler(this.Main_Shown);
            this.LocationChanged += new System.EventHandler(this.Main_LocationChanged);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenInBrowserButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.totalResults)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTip)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgLink)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFriend)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgFavorite)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgCatalog)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackButton)).EndInit();
            this.statusArchiveStatus.ResumeLayout(false);
            this.statusArchiveStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgApertusSplash)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog attachFiles;
        private System.Windows.Forms.MenuStrip menuMain;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.Timer tmrStatusUpdate;
        private System.Windows.Forms.Timer tmrProgressBar;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem walletsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.Timer tmrGetNewTransactions;
        private System.Windows.Forms.ToolStripMenuItem fontToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem historyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem rPCToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notarizeToolStripMenuItem;
        private System.Windows.Forms.OpenFileDialog openDigestFile;
        private System.Windows.Forms.ToolStripMenuItem proofToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.ToolStripMenuItem trustToolStripMenuItem;
        private System.Windows.Forms.Timer tmrProcessBatch;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem blockToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem followToolStripMenuItem;
        private System.Windows.Forms.Timer tmrUpdateInfoText;
        private System.Windows.Forms.ToolStripMenuItem rebuildToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem searchToolStripMenuItem;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox imgTrash;
        private System.Windows.Forms.PictureBox imgFavorite;
        private System.Windows.Forms.TextBox txtTransIDSearch;
        private System.Windows.Forms.PictureBox imgCatalog;
        private System.Windows.Forms.PictureBox imgNextButton;
        private System.Windows.Forms.PictureBox imgBackButton;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.ComboBox cmbCoinType;
        private System.Windows.Forms.ComboBox cmbWalletLabel;
        private System.Windows.Forms.PictureBox imgEnterMessageHere;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.Button btnAddVault;
        private System.Windows.Forms.ComboBox cmbVault;
        private System.Windows.Forms.Button btnAddSignature;
        private System.Windows.Forms.ComboBox cmbSignature;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCoinTotal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalArchiveSize;
        private System.Windows.Forms.CheckBox chkFilterUnSafeContent;
        private System.Windows.Forms.CheckBox chkMonitorBlockChains;
        private System.Windows.Forms.CheckBox chkKeywords;
        private System.Windows.Forms.ComboBox cmbFolder;
        private System.Windows.Forms.StatusStrip statusArchiveStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
        private System.Windows.Forms.Button btnAddFolder;
        private System.Windows.Forms.TextBox txtAddVault;
        private System.Windows.Forms.TextBox txtAddSignature;
        private System.Windows.Forms.CheckBox chkWarnArchive;
        private System.Windows.Forms.CheckBox chkSaveOnEnter;
        private System.Windows.Forms.CheckBox chkTrackVault;
        private System.Windows.Forms.CheckBox chkEnableRecipients;
        private System.Windows.Forms.ToolStripMenuItem profilesToolStripMenuItem;
        private System.Windows.Forms.PictureBox imgFriend;
        private System.Windows.Forms.PictureBox imgLink;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem hashToolStripMenuItem;
        private System.Windows.Forms.PictureBox imgTip;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Button btnExportVault;
        private System.Windows.Forms.Button btnExportSignature;
        private System.Windows.Forms.Button btnExportProfile;
        private System.Windows.Forms.ComboBox cmbTo;
        private System.Windows.Forms.Timer tmrPauseBeforeRefreshingMonitor;
        private System.Windows.Forms.CheckBox chkEnableTips;
        private System.Windows.Forms.ComboBox cmbFollow;
        private System.Windows.Forms.Button btnFriendEncryption;
        private System.Windows.Forms.CheckBox chkNoMessage;
        private System.Windows.Forms.NumericUpDown totalResults;
        private System.Windows.Forms.PictureBox imgOpenInBrowserButton;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.PictureBox imgApertusSplash;
        private System.Windows.Forms.TextBox txtInfoBox;
        private System.Windows.Forms.CheckBox chkBackLinks;
    }
}

