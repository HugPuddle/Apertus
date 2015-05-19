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
            System.Windows.Forms.TreeNode treeNode9 = new System.Windows.Forms.TreeNode("Favorites");
            System.Windows.Forms.TreeNode treeNode10 = new System.Windows.Forms.TreeNode("Monitor");
            System.Windows.Forms.TreeNode treeNode11 = new System.Windows.Forms.TreeNode("Follow");
            System.Windows.Forms.TreeNode treeNode12 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode9,
            treeNode10,
            treeNode11});
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.attachFiles = new System.Windows.Forms.OpenFileDialog();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.blockToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.followToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuMain = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.historyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.rebuildToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notarizeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.proofToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.searchToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
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
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.splitHistoryBrowser = new System.Windows.Forms.SplitContainer();
            this.imgOpenLeft = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imgTrash = new System.Windows.Forms.PictureBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.txtTransIDSearch = new System.Windows.Forms.TextBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.imgNextButton = new System.Windows.Forms.PictureBox();
            this.imgBackButton = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.imgOpenUp = new System.Windows.Forms.PictureBox();
            this.imgOpenRight = new System.Windows.Forms.PictureBox();
            this.txtInfoBox = new System.Windows.Forms.TextBox();
            this.imgApertusSplash = new System.Windows.Forms.PictureBox();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.splitArchiveTools = new System.Windows.Forms.SplitContainer();
            this.btnArchive = new System.Windows.Forms.Button();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.cmbCoinType = new System.Windows.Forms.ComboBox();
            this.cmbWalletLabel = new System.Windows.Forms.ComboBox();
            this.imgEnterMessageHere = new System.Windows.Forms.PictureBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.imgOpenDown = new System.Windows.Forms.PictureBox();
            this.txtAddVault = new System.Windows.Forms.TextBox();
            this.txtAddSignature = new System.Windows.Forms.TextBox();
            this.txtAddProfile = new System.Windows.Forms.TextBox();
            this.btnAddProfile = new System.Windows.Forms.Button();
            this.btnAddVault = new System.Windows.Forms.Button();
            this.cmbVault = new System.Windows.Forms.ComboBox();
            this.btnAddSignature = new System.Windows.Forms.Button();
            this.cmbSignature = new System.Windows.Forms.ComboBox();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCoinTotal = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalArchiveSize = new System.Windows.Forms.Label();
            this.chkMonitorBlockChains = new System.Windows.Forms.CheckBox();
            this.chkFilterUnSafeContent = new System.Windows.Forms.CheckBox();
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.chkWarnArchive = new System.Windows.Forms.CheckBox();
            this.chkSaveOnEnter = new System.Windows.Forms.CheckBox();
            this.chkTrackVault = new System.Windows.Forms.CheckBox();
            this.statusArchiveStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.contextMenuStrip1.SuspendLayout();
            this.menuMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitHistoryBrowser)).BeginInit();
            this.splitHistoryBrowser.Panel1.SuspendLayout();
            this.splitHistoryBrowser.Panel2.SuspendLayout();
            this.splitHistoryBrowser.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackButton)).BeginInit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgApertusSplash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitArchiveTools)).BeginInit();
            this.splitArchiveTools.Panel1.SuspendLayout();
            this.splitArchiveTools.Panel2.SuspendLayout();
            this.splitArchiveTools.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenDown)).BeginInit();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.statusArchiveStatus.SuspendLayout();
            this.SuspendLayout();
            // 
            // attachFiles
            // 
            this.attachFiles.FileName = "openFileDialog1";
            this.attachFiles.Multiselect = true;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.blockToolStripMenuItem,
            this.followToolStripMenuItem});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(121, 52);
            // 
            // blockToolStripMenuItem
            // 
            this.blockToolStripMenuItem.Name = "blockToolStripMenuItem";
            this.blockToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
            this.blockToolStripMenuItem.Text = "block";
            // 
            // followToolStripMenuItem
            // 
            this.followToolStripMenuItem.Name = "followToolStripMenuItem";
            this.followToolStripMenuItem.Size = new System.Drawing.Size(120, 24);
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
            this.menuMain.Size = new System.Drawing.Size(505, 26);
            this.menuMain.TabIndex = 0;
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
            this.newToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.saveToolStripMenuItem.Text = "Save";
            // 
            // historyToolStripMenuItem
            // 
            this.historyToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.rebuildToolStripMenuItem1});
            this.historyToolStripMenuItem.Name = "historyToolStripMenuItem";
            this.historyToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.historyToolStripMenuItem.Text = "Catalog";
            // 
            // rebuildToolStripMenuItem1
            // 
            this.rebuildToolStripMenuItem1.Name = "rebuildToolStripMenuItem1";
            this.rebuildToolStripMenuItem1.Size = new System.Drawing.Size(125, 22);
            this.rebuildToolStripMenuItem1.Text = "Rebuild";
            this.rebuildToolStripMenuItem1.Click += new System.EventHandler(this.rebuildToolStripMenuItem_Click);
            // 
            // notarizeToolStripMenuItem
            // 
            this.notarizeToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.proofToolStripMenuItem,
            this.searchToolStripMenuItem});
            this.notarizeToolStripMenuItem.Enabled = false;
            this.notarizeToolStripMenuItem.Name = "notarizeToolStripMenuItem";
            this.notarizeToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.notarizeToolStripMenuItem.Text = "Proof";
            // 
            // proofToolStripMenuItem
            // 
            this.proofToolStripMenuItem.Name = "proofToolStripMenuItem";
            this.proofToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.proofToolStripMenuItem.Text = "Insert";
            this.proofToolStripMenuItem.Click += new System.EventHandler(this.notarizeToolStripMenuItem_Click);
            // 
            // searchToolStripMenuItem
            // 
            this.searchToolStripMenuItem.Name = "searchToolStripMenuItem";
            this.searchToolStripMenuItem.Size = new System.Drawing.Size(123, 22);
            this.searchToolStripMenuItem.Text = "Search";
            this.searchToolStripMenuItem.Click += new System.EventHandler(this.searchToolStripMenuItem_Click);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(127, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.walletsToolStripMenuItem,
            this.fontToolStripMenuItem,
            this.trustToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(73, 22);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // walletsToolStripMenuItem
            // 
            this.walletsToolStripMenuItem.Name = "walletsToolStripMenuItem";
            this.walletsToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.walletsToolStripMenuItem.Text = "Wallets";
            this.walletsToolStripMenuItem.Click += new System.EventHandler(this.walletsToolStripMenuItem_Click);
            // 
            // fontToolStripMenuItem
            // 
            this.fontToolStripMenuItem.Name = "fontToolStripMenuItem";
            this.fontToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.fontToolStripMenuItem.Text = "Font";
            this.fontToolStripMenuItem.Click += new System.EventHandler(this.fontToolStripMenuItem_Click);
            // 
            // trustToolStripMenuItem
            // 
            this.trustToolStripMenuItem.Name = "trustToolStripMenuItem";
            this.trustToolStripMenuItem.Size = new System.Drawing.Size(158, 22);
            this.trustToolStripMenuItem.Text = "Trust Center";
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
            // splitMain
            // 
            this.splitMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitMain.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitMain.Location = new System.Drawing.Point(0, 29);
            this.splitMain.Name = "splitMain";
            this.splitMain.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.Controls.Add(this.splitHistoryBrowser);
            this.splitMain.Panel1MinSize = 70;
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.Controls.Add(this.splitArchiveTools);
            this.splitMain.Panel2MinSize = 146;
            this.splitMain.Size = new System.Drawing.Size(505, 386);
            this.splitMain.SplitterDistance = 75;
            this.splitMain.TabIndex = 23;
            this.splitMain.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer1_SplitterMoved);
            // 
            // splitHistoryBrowser
            // 
            this.splitHistoryBrowser.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitHistoryBrowser.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitHistoryBrowser.Location = new System.Drawing.Point(0, 0);
            this.splitHistoryBrowser.Name = "splitHistoryBrowser";
            // 
            // splitHistoryBrowser.Panel1
            // 
            this.splitHistoryBrowser.Panel1.BackColor = System.Drawing.Color.White;
            this.splitHistoryBrowser.Panel1.Controls.Add(this.imgOpenLeft);
            this.splitHistoryBrowser.Panel1.Controls.Add(this.treeView1);
            this.splitHistoryBrowser.Panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.splitHistoryBrowser_Panel1_Paint);
            // 
            // splitHistoryBrowser.Panel2
            // 
            this.splitHistoryBrowser.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitHistoryBrowser.Panel2.Controls.Add(this.imgTrash);
            this.splitHistoryBrowser.Panel2.Controls.Add(this.pictureBox4);
            this.splitHistoryBrowser.Panel2.Controls.Add(this.txtTransIDSearch);
            this.splitHistoryBrowser.Panel2.Controls.Add(this.pictureBox3);
            this.splitHistoryBrowser.Panel2.Controls.Add(this.imgNextButton);
            this.splitHistoryBrowser.Panel2.Controls.Add(this.imgBackButton);
            this.splitHistoryBrowser.Panel2.Controls.Add(this.panel1);
            this.splitHistoryBrowser.Size = new System.Drawing.Size(505, 75);
            this.splitHistoryBrowser.SplitterDistance = 165;
            this.splitHistoryBrowser.TabIndex = 29;
            this.splitHistoryBrowser.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer2_SplitterMoved);
            // 
            // imgOpenLeft
            // 
            this.imgOpenLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgOpenLeft.Image = global::ADD.Properties.Resources.OpenLeft;
            this.imgOpenLeft.Location = new System.Drawing.Point(150, 31);
            this.imgOpenLeft.Name = "imgOpenLeft";
            this.imgOpenLeft.Size = new System.Drawing.Size(10, 18);
            this.imgOpenLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenLeft.TabIndex = 2;
            this.imgOpenLeft.TabStop = false;
            this.imgOpenLeft.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode9.Name = "favorites";
            treeNode9.Text = "Favorites";
            treeNode10.Name = "monitor";
            treeNode10.Text = "Monitor";
            treeNode11.Name = "follow";
            treeNode11.Text = "Follow";
            treeNode12.Name = "root";
            treeNode12.Text = "Root";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode12});
            this.treeView1.Size = new System.Drawing.Size(163, 73);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // imgTrash
            // 
            this.imgTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgTrash.Enabled = false;
            this.imgTrash.Image = global::ADD.Properties.Resources.TrashDisabled;
            this.imgTrash.Location = new System.Drawing.Point(307, 3);
            this.imgTrash.Name = "imgTrash";
            this.imgTrash.Size = new System.Drawing.Size(23, 23);
            this.imgTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgTrash.TabIndex = 5;
            this.imgTrash.TabStop = false;
            this.imgTrash.Click += new System.EventHandler(this.imgTrash_Click);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::ADD.Properties.Resources.star;
            this.pictureBox4.Location = new System.Drawing.Point(278, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // txtTransIDSearch
            // 
            this.txtTransIDSearch.AcceptsReturn = true;
            this.txtTransIDSearch.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTransIDSearch.Font = new System.Drawing.Font("Calibri", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTransIDSearch.ForeColor = System.Drawing.Color.LightGray;
            this.txtTransIDSearch.Location = new System.Drawing.Point(65, 3);
            this.txtTransIDSearch.Margin = new System.Windows.Forms.Padding(10, 3, 3, 3);
            this.txtTransIDSearch.Name = "txtTransIDSearch";
            this.txtTransIDSearch.Size = new System.Drawing.Size(178, 23);
            this.txtTransIDSearch.TabIndex = 1;
            this.txtTransIDSearch.TabStop = false;
            this.txtTransIDSearch.Text = "ENTER SEARCH STRING";
            this.txtTransIDSearch.Click += new System.EventHandler(this.txtTransIDSearch_Click);
            this.txtTransIDSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransIDSearch_KeyDown);
            // 
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::ADD.Properties.Resources.home;
            this.pictureBox3.Location = new System.Drawing.Point(249, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
            // 
            // imgNextButton
            // 
            this.imgNextButton.Image = global::ADD.Properties.Resources.OpenRightDisabled;
            this.imgNextButton.Location = new System.Drawing.Point(33, 3);
            this.imgNextButton.Name = "imgNextButton";
            this.imgNextButton.Size = new System.Drawing.Size(23, 23);
            this.imgNextButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgNextButton.TabIndex = 5;
            this.imgNextButton.TabStop = false;
            this.imgNextButton.Click += new System.EventHandler(this.imgNextButton_Click);
            // 
            // imgBackButton
            // 
            this.imgBackButton.Image = global::ADD.Properties.Resources.OpenLeftDisabled;
            this.imgBackButton.Location = new System.Drawing.Point(4, 3);
            this.imgBackButton.Name = "imgBackButton";
            this.imgBackButton.Size = new System.Drawing.Size(23, 23);
            this.imgBackButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgBackButton.TabIndex = 4;
            this.imgBackButton.TabStop = false;
            this.imgBackButton.Click += new System.EventHandler(this.imgBackButton_Click);
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.imgOpenUp);
            this.panel1.Controls.Add(this.imgOpenRight);
            this.panel1.Controls.Add(this.txtInfoBox);
            this.panel1.Controls.Add(this.imgApertusSplash);
            this.panel1.Controls.Add(this.webBrowser1);
            this.panel1.Location = new System.Drawing.Point(4, 35);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(331, 37);
            this.panel1.TabIndex = 5;
            // 
            // imgOpenUp
            // 
            this.imgOpenUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgOpenUp.Image = global::ADD.Properties.Resources.OpenUp;
            this.imgOpenUp.Location = new System.Drawing.Point(5, 26);
            this.imgOpenUp.Name = "imgOpenUp";
            this.imgOpenUp.Size = new System.Drawing.Size(18, 10);
            this.imgOpenUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenUp.TabIndex = 4;
            this.imgOpenUp.TabStop = false;
            this.imgOpenUp.Visible = false;
            this.imgOpenUp.Click += new System.EventHandler(this.imgOpenUp_Click);
            // 
            // imgOpenRight
            // 
            this.imgOpenRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgOpenRight.Image = global::ADD.Properties.Resources.OpenRight;
            this.imgOpenRight.Location = new System.Drawing.Point(-2, 12);
            this.imgOpenRight.Name = "imgOpenRight";
            this.imgOpenRight.Size = new System.Drawing.Size(10, 18);
            this.imgOpenRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenRight.TabIndex = 4;
            this.imgOpenRight.TabStop = false;
            this.imgOpenRight.Visible = false;
            this.imgOpenRight.Click += new System.EventHandler(this.imgOpenRight_Click);
            // 
            // txtInfoBox
            // 
            this.txtInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoBox.BackColor = System.Drawing.Color.White;
            this.txtInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoBox.Location = new System.Drawing.Point(-4, 13);
            this.txtInfoBox.Multiline = true;
            this.txtInfoBox.Name = "txtInfoBox";
            this.txtInfoBox.ReadOnly = true;
            this.txtInfoBox.Size = new System.Drawing.Size(335, 31);
            this.txtInfoBox.TabIndex = 0;
            this.txtInfoBox.TabStop = false;
            this.txtInfoBox.Text = "Click Help Then Info for Assistance.";
            this.txtInfoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgApertusSplash
            // 
            this.imgApertusSplash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.imgApertusSplash.Image = global::ADD.Properties.Resources.About;
            this.imgApertusSplash.Location = new System.Drawing.Point(93, -2);
            this.imgApertusSplash.Name = "imgApertusSplash";
            this.imgApertusSplash.Size = new System.Drawing.Size(143, 13);
            this.imgApertusSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgApertusSplash.TabIndex = 0;
            this.imgApertusSplash.TabStop = false;
            this.imgApertusSplash.Resize += new System.EventHandler(this.imgApertusSplash_Resize);
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(331, 37);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // splitArchiveTools
            // 
            this.splitArchiveTools.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitArchiveTools.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitArchiveTools.Location = new System.Drawing.Point(0, 0);
            this.splitArchiveTools.Name = "splitArchiveTools";
            // 
            // splitArchiveTools.Panel1
            // 
            this.splitArchiveTools.Panel1.Controls.Add(this.btnArchive);
            this.splitArchiveTools.Panel1.Controls.Add(this.btnAttachFile);
            this.splitArchiveTools.Panel1.Controls.Add(this.cmbCoinType);
            this.splitArchiveTools.Panel1.Controls.Add(this.cmbWalletLabel);
            this.splitArchiveTools.Panel1.Controls.Add(this.imgEnterMessageHere);
            this.splitArchiveTools.Panel1.Controls.Add(this.txtFileName);
            this.splitArchiveTools.Panel1.Controls.Add(this.txtMessage);
            // 
            // splitArchiveTools.Panel2
            // 
            this.splitArchiveTools.Panel2.Controls.Add(this.imgOpenDown);
            this.splitArchiveTools.Panel2.Controls.Add(this.txtAddVault);
            this.splitArchiveTools.Panel2.Controls.Add(this.txtAddSignature);
            this.splitArchiveTools.Panel2.Controls.Add(this.txtAddProfile);
            this.splitArchiveTools.Panel2.Controls.Add(this.btnAddProfile);
            this.splitArchiveTools.Panel2.Controls.Add(this.btnAddVault);
            this.splitArchiveTools.Panel2.Controls.Add(this.cmbVault);
            this.splitArchiveTools.Panel2.Controls.Add(this.btnAddSignature);
            this.splitArchiveTools.Panel2.Controls.Add(this.cmbSignature);
            this.splitArchiveTools.Panel2.Controls.Add(this.cmbProfile);
            this.splitArchiveTools.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitArchiveTools.Panel2MinSize = 169;
            this.splitArchiveTools.Size = new System.Drawing.Size(505, 307);
            this.splitArchiveTools.SplitterDistance = 282;
            this.splitArchiveTools.TabIndex = 33;
            this.splitArchiveTools.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer5_SplitterMoved);
            // 
            // btnArchive
            // 
            this.btnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchive.Enabled = false;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.Image = global::ADD.Properties.Resources.Save;
            this.btnArchive.Location = new System.Drawing.Point(208, 275);
            this.btnArchive.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(67, 27);
            this.btnArchive.TabIndex = 3;
            this.btnArchive.Tag = "12345678901234567890";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachFile.Enabled = false;
            this.btnAttachFile.FlatAppearance.BorderSize = 0;
            this.btnAttachFile.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachFile.Image = global::ADD.Properties.Resources.Button2;
            this.btnAttachFile.Location = new System.Drawing.Point(142, 275);
            this.btnAttachFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(61, 27);
            this.btnAttachFile.TabIndex = 6;
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFiles_Click);
            // 
            // cmbCoinType
            // 
            this.cmbCoinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoinType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCoinType.FormattingEnabled = true;
            this.cmbCoinType.ItemHeight = 17;
            this.cmbCoinType.Location = new System.Drawing.Point(4, 5);
            this.cmbCoinType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbCoinType.MaxDropDownItems = 100;
            this.cmbCoinType.MaximumSize = new System.Drawing.Size(571, 0);
            this.cmbCoinType.Name = "cmbCoinType";
            this.cmbCoinType.Size = new System.Drawing.Size(143, 25);
            this.cmbCoinType.TabIndex = 11;
            this.cmbCoinType.SelectedIndexChanged += new System.EventHandler(this.cmbCoinType_SelectedIndexChanged);
            // 
            // cmbWalletLabel
            // 
            this.cmbWalletLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbWalletLabel.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbWalletLabel.Enabled = false;
            this.cmbWalletLabel.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbWalletLabel.FormattingEnabled = true;
            this.cmbWalletLabel.Items.AddRange(new object[] {
            "Select Funding Source"});
            this.cmbWalletLabel.Location = new System.Drawing.Point(155, 5);
            this.cmbWalletLabel.MaxDropDownItems = 100;
            this.cmbWalletLabel.Name = "cmbWalletLabel";
            this.cmbWalletLabel.Size = new System.Drawing.Size(120, 25);
            this.cmbWalletLabel.TabIndex = 21;
            this.cmbWalletLabel.SelectedIndexChanged += new System.EventHandler(this.cmbWalletLabel_SelectedIndexChanged);
            // 
            // imgEnterMessageHere
            // 
            this.imgEnterMessageHere.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.imgEnterMessageHere.BackColor = System.Drawing.Color.White;
            this.imgEnterMessageHere.Image = ((System.Drawing.Image)(resources.GetObject("imgEnterMessageHere.Image")));
            this.imgEnterMessageHere.Location = new System.Drawing.Point(18, 52);
            this.imgEnterMessageHere.Name = "imgEnterMessageHere";
            this.imgEnterMessageHere.Size = new System.Drawing.Size(247, 206);
            this.imgEnterMessageHere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgEnterMessageHere.TabIndex = 29;
            this.imgEnterMessageHere.TabStop = false;
            this.imgEnterMessageHere.Visible = false;
            this.imgEnterMessageHere.Click += new System.EventHandler(this.imgEnterMessageHere_Click);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Enabled = false;
            this.txtFileName.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(4, 275);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(133, 27);
            this.txtFileName.TabIndex = 8;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
            // 
            // txtMessage
            // 
            this.txtMessage.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtMessage.Enabled = false;
            this.txtMessage.Font = new System.Drawing.Font("unifont", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMessage.ImeMode = System.Windows.Forms.ImeMode.On;
            this.txtMessage.Location = new System.Drawing.Point(4, 36);
            this.txtMessage.MaxLength = 1024000000;
            this.txtMessage.Multiline = true;
            this.txtMessage.Name = "txtMessage";
            this.txtMessage.Size = new System.Drawing.Size(273, 235);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            this.txtMessage.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtMessage_KeyDown);
            // 
            // imgOpenDown
            // 
            this.imgOpenDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgOpenDown.Image = global::ADD.Properties.Resources.OpenDown;
            this.imgOpenDown.Location = new System.Drawing.Point(195, 2);
            this.imgOpenDown.Name = "imgOpenDown";
            this.imgOpenDown.Size = new System.Drawing.Size(18, 10);
            this.imgOpenDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenDown.TabIndex = 33;
            this.imgOpenDown.TabStop = false;
            this.imgOpenDown.Click += new System.EventHandler(this.imgOpenDown_Click);
            // 
            // txtAddVault
            // 
            this.txtAddVault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddVault.Location = new System.Drawing.Point(30, 275);
            this.txtAddVault.Name = "txtAddVault";
            this.txtAddVault.Size = new System.Drawing.Size(183, 22);
            this.txtAddVault.TabIndex = 45;
            this.txtAddVault.Visible = false;
            this.txtAddVault.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddVault_KeyDown);
            // 
            // txtAddSignature
            // 
            this.txtAddSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddSignature.Location = new System.Drawing.Point(30, 246);
            this.txtAddSignature.Name = "txtAddSignature";
            this.txtAddSignature.Size = new System.Drawing.Size(183, 22);
            this.txtAddSignature.TabIndex = 44;
            this.txtAddSignature.Visible = false;
            this.txtAddSignature.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddSignature_KeyDown);
            // 
            // txtAddProfile
            // 
            this.txtAddProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtAddProfile.Location = new System.Drawing.Point(30, 214);
            this.txtAddProfile.Name = "txtAddProfile";
            this.txtAddProfile.Size = new System.Drawing.Size(183, 22);
            this.txtAddProfile.TabIndex = 43;
            this.txtAddProfile.Visible = false;
            this.txtAddProfile.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtAddProfile_KeyDown);
            // 
            // btnAddProfile
            // 
            this.btnAddProfile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddProfile.Enabled = false;
            this.btnAddProfile.Location = new System.Drawing.Point(3, 212);
            this.btnAddProfile.Name = "btnAddProfile";
            this.btnAddProfile.Size = new System.Drawing.Size(21, 25);
            this.btnAddProfile.TabIndex = 42;
            this.btnAddProfile.Text = "+";
            this.btnAddProfile.UseVisualStyleBackColor = true;
            this.btnAddProfile.Click += new System.EventHandler(this.btnAddProfile_Click);
            // 
            // btnAddVault
            // 
            this.btnAddVault.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddVault.Enabled = false;
            this.btnAddVault.Location = new System.Drawing.Point(3, 274);
            this.btnAddVault.Name = "btnAddVault";
            this.btnAddVault.Size = new System.Drawing.Size(21, 25);
            this.btnAddVault.TabIndex = 41;
            this.btnAddVault.Text = "+";
            this.btnAddVault.UseVisualStyleBackColor = true;
            this.btnAddVault.Click += new System.EventHandler(this.btnAddVault_Click);
            // 
            // cmbVault
            // 
            this.cmbVault.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbVault.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbVault.Enabled = false;
            this.cmbVault.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbVault.FormattingEnabled = true;
            this.cmbVault.Items.AddRange(new object[] {
            "Select Profile"});
            this.cmbVault.Location = new System.Drawing.Point(30, 274);
            this.cmbVault.MaxDropDownItems = 100;
            this.cmbVault.Name = "cmbVault";
            this.cmbVault.Size = new System.Drawing.Size(183, 25);
            this.cmbVault.TabIndex = 40;
            this.cmbVault.SelectedIndexChanged += new System.EventHandler(this.cmbVault_SelectedIndexChanged);
            // 
            // btnAddSignature
            // 
            this.btnAddSignature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.btnAddSignature.Enabled = false;
            this.btnAddSignature.Location = new System.Drawing.Point(3, 243);
            this.btnAddSignature.Name = "btnAddSignature";
            this.btnAddSignature.Size = new System.Drawing.Size(21, 25);
            this.btnAddSignature.TabIndex = 39;
            this.btnAddSignature.Text = "+";
            this.btnAddSignature.UseVisualStyleBackColor = true;
            this.btnAddSignature.Click += new System.EventHandler(this.btnAddSignature_Click);
            // 
            // cmbSignature
            // 
            this.cmbSignature.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbSignature.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbSignature.Enabled = false;
            this.cmbSignature.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbSignature.FormattingEnabled = true;
            this.cmbSignature.Items.AddRange(new object[] {
            "Select Profile"});
            this.cmbSignature.Location = new System.Drawing.Point(30, 243);
            this.cmbSignature.MaxDropDownItems = 100;
            this.cmbSignature.Name = "cmbSignature";
            this.cmbSignature.Size = new System.Drawing.Size(183, 25);
            this.cmbSignature.TabIndex = 34;
            this.cmbSignature.SelectedIndexChanged += new System.EventHandler(this.cmbSignature_SelectedIndexChanged);
            // 
            // cmbProfile
            // 
            this.cmbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.Enabled = false;
            this.cmbProfile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(30, 212);
            this.cmbProfile.MaxDropDownItems = 100;
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(183, 25);
            this.cmbProfile.TabIndex = 32;
            this.cmbProfile.SelectedIndexChanged += new System.EventHandler(this.cmbProfile_SelectedIndexChanged);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.groupBox2);
            this.flowLayoutPanel1.Controls.Add(this.groupBox3);
            this.flowLayoutPanel1.Controls.Add(this.chkMonitorBlockChains);
            this.flowLayoutPanel1.Controls.Add(this.chkFilterUnSafeContent);
            this.flowLayoutPanel1.Controls.Add(this.chkKeywords);
            this.flowLayoutPanel1.Controls.Add(this.chkWarnArchive);
            this.flowLayoutPanel1.Controls.Add(this.chkSaveOnEnter);
            this.flowLayoutPanel1.Controls.Add(this.chkTrackVault);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(212, 204);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox1.Controls.Add(this.lblEstimatedCost);
            this.groupBox1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(3, 3);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(158, 41);
            this.groupBox1.TabIndex = 18;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Estimated Cost";
            // 
            // lblEstimatedCost
            // 
            this.lblEstimatedCost.AutoSize = true;
            this.lblEstimatedCost.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblEstimatedCost.Location = new System.Drawing.Point(6, 18);
            this.lblEstimatedCost.Name = "lblEstimatedCost";
            this.lblEstimatedCost.Size = new System.Drawing.Size(84, 16);
            this.lblEstimatedCost.TabIndex = 0;
            this.lblEstimatedCost.Text = "0.00000000";
            this.lblEstimatedCost.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox2.Controls.Add(this.lblCoinTotal);
            this.groupBox2.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.Location = new System.Drawing.Point(3, 50);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(158, 41);
            this.groupBox2.TabIndex = 19;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Available Funds";
            // 
            // lblCoinTotal
            // 
            this.lblCoinTotal.AutoSize = true;
            this.lblCoinTotal.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblCoinTotal.Location = new System.Drawing.Point(6, 18);
            this.lblCoinTotal.Name = "lblCoinTotal";
            this.lblCoinTotal.Size = new System.Drawing.Size(84, 16);
            this.lblCoinTotal.TabIndex = 0;
            this.lblCoinTotal.Text = "0.00000000";
            this.lblCoinTotal.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.groupBox3.Controls.Add(this.lblTotalArchiveSize);
            this.groupBox3.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.Location = new System.Drawing.Point(3, 97);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(158, 41);
            this.groupBox3.TabIndex = 20;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Total Archive Size";
            // 
            // lblTotalArchiveSize
            // 
            this.lblTotalArchiveSize.AutoSize = true;
            this.lblTotalArchiveSize.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalArchiveSize.Location = new System.Drawing.Point(6, 18);
            this.lblTotalArchiveSize.Name = "lblTotalArchiveSize";
            this.lblTotalArchiveSize.Size = new System.Drawing.Size(84, 16);
            this.lblTotalArchiveSize.TabIndex = 0;
            this.lblTotalArchiveSize.Text = "0.00000000";
            this.lblTotalArchiveSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // chkMonitorBlockChains
            // 
            this.chkMonitorBlockChains.AutoSize = true;
            this.chkMonitorBlockChains.Location = new System.Drawing.Point(3, 144);
            this.chkMonitorBlockChains.Name = "chkMonitorBlockChains";
            this.chkMonitorBlockChains.Size = new System.Drawing.Size(125, 21);
            this.chkMonitorBlockChains.TabIndex = 2;
            this.chkMonitorBlockChains.TabStop = false;
            this.chkMonitorBlockChains.Text = "Enable Monitor";
            this.chkMonitorBlockChains.UseVisualStyleBackColor = true;
            this.chkMonitorBlockChains.CheckedChanged += new System.EventHandler(this.chkMonitorBlockChains_CheckedChanged);
            // 
            // chkFilterUnSafeContent
            // 
            this.chkFilterUnSafeContent.AutoSize = true;
            this.chkFilterUnSafeContent.Checked = true;
            this.chkFilterUnSafeContent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterUnSafeContent.Location = new System.Drawing.Point(3, 171);
            this.chkFilterUnSafeContent.Name = "chkFilterUnSafeContent";
            this.chkFilterUnSafeContent.Size = new System.Drawing.Size(109, 21);
            this.chkFilterUnSafeContent.TabIndex = 3;
            this.chkFilterUnSafeContent.TabStop = false;
            this.chkFilterUnSafeContent.Text = "Enable Filter";
            this.chkFilterUnSafeContent.UseVisualStyleBackColor = true;
            this.chkFilterUnSafeContent.CheckedChanged += new System.EventHandler(this.chkFilterUnSafeContent_CheckedChanged);
            // 
            // chkKeywords
            // 
            this.chkKeywords.AutoSize = true;
            this.chkKeywords.Checked = true;
            this.chkKeywords.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkKeywords.Location = new System.Drawing.Point(5, 200);
            this.chkKeywords.Margin = new System.Windows.Forms.Padding(5);
            this.chkKeywords.Name = "chkKeywords";
            this.chkKeywords.Size = new System.Drawing.Size(147, 21);
            this.chkKeywords.TabIndex = 0;
            this.chkKeywords.Text = "Enable #Keywords";
            this.chkKeywords.UseVisualStyleBackColor = true;
            // 
            // chkWarnArchive
            // 
            this.chkWarnArchive.AutoSize = true;
            this.chkWarnArchive.Checked = true;
            this.chkWarnArchive.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkWarnArchive.Location = new System.Drawing.Point(3, 229);
            this.chkWarnArchive.Name = "chkWarnArchive";
            this.chkWarnArchive.Size = new System.Drawing.Size(119, 21);
            this.chkWarnArchive.TabIndex = 21;
            this.chkWarnArchive.Text = "Save Warning";
            this.chkWarnArchive.UseVisualStyleBackColor = true;
            // 
            // chkSaveOnEnter
            // 
            this.chkSaveOnEnter.AutoSize = true;
            this.chkSaveOnEnter.Location = new System.Drawing.Point(3, 256);
            this.chkSaveOnEnter.Name = "chkSaveOnEnter";
            this.chkSaveOnEnter.Size = new System.Drawing.Size(112, 21);
            this.chkSaveOnEnter.TabIndex = 22;
            this.chkSaveOnEnter.Text = "Enter = Save";
            this.chkSaveOnEnter.UseVisualStyleBackColor = true;
            // 
            // chkTrackVault
            // 
            this.chkTrackVault.AutoSize = true;
            this.chkTrackVault.Location = new System.Drawing.Point(3, 283);
            this.chkTrackVault.Name = "chkTrackVault";
            this.chkTrackVault.Size = new System.Drawing.Size(102, 21);
            this.chkTrackVault.TabIndex = 23;
            this.chkTrackVault.Text = "Track Vault";
            this.chkTrackVault.UseVisualStyleBackColor = true;
            // 
            // statusArchiveStatus
            // 
            this.statusArchiveStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusArchiveStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusArchiveStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusInfo,
            this.progressBar});
            this.statusArchiveStatus.Location = new System.Drawing.Point(0, 418);
            this.statusArchiveStatus.Name = "statusArchiveStatus";
            this.statusArchiveStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusArchiveStatus.Size = new System.Drawing.Size(505, 25);
            this.statusArchiveStatus.SizingGrip = false;
            this.statusArchiveStatus.TabIndex = 32;
            this.statusArchiveStatus.Text = "statusStrip1";
            // 
            // lblStatusInfo
            // 
            this.lblStatusInfo.AutoSize = false;
            this.lblStatusInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblStatusInfo.Name = "lblStatusInfo";
            this.lblStatusInfo.Size = new System.Drawing.Size(350, 20);
            this.lblStatusInfo.Text = "Select a blockchain to get started.";
            this.lblStatusInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // progressBar
            // 
            this.progressBar.Margin = new System.Windows.Forms.Padding(3);
            this.progressBar.Minimum = 1;
            this.progressBar.Name = "progressBar";
            this.progressBar.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.progressBar.Size = new System.Drawing.Size(120, 19);
            this.progressBar.Step = 1;
            this.progressBar.Value = 1;
            this.progressBar.Visible = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(505, 443);
            this.Controls.Add(this.statusArchiveStatus);
            this.Controls.Add(this.splitMain);
            this.Controls.Add(this.menuMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(18, 422);
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
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.splitHistoryBrowser.Panel1.ResumeLayout(false);
            this.splitHistoryBrowser.Panel2.ResumeLayout(false);
            this.splitHistoryBrowser.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitHistoryBrowser)).EndInit();
            this.splitHistoryBrowser.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackButton)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgApertusSplash)).EndInit();
            this.splitArchiveTools.Panel1.ResumeLayout(false);
            this.splitArchiveTools.Panel1.PerformLayout();
            this.splitArchiveTools.Panel2.ResumeLayout(false);
            this.splitArchiveTools.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitArchiveTools)).EndInit();
            this.splitArchiveTools.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenDown)).EndInit();
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.statusArchiveStatus.ResumeLayout(false);
            this.statusArchiveStatus.PerformLayout();
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
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
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
        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.SplitContainer splitHistoryBrowser;
        private System.Windows.Forms.PictureBox imgOpenLeft;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.PictureBox imgTrash;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.TextBox txtTransIDSearch;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox imgNextButton;
        private System.Windows.Forms.PictureBox imgBackButton;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox imgOpenUp;
        private System.Windows.Forms.PictureBox imgOpenRight;
        private System.Windows.Forms.TextBox txtInfoBox;
        private System.Windows.Forms.PictureBox imgApertusSplash;
        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.SplitContainer splitArchiveTools;
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
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblEstimatedCost;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label lblCoinTotal;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label lblTotalArchiveSize;
        private System.Windows.Forms.CheckBox chkFilterUnSafeContent;
        private System.Windows.Forms.CheckBox chkMonitorBlockChains;
        private System.Windows.Forms.CheckBox chkKeywords;
        private System.Windows.Forms.ComboBox cmbProfile;
        private System.Windows.Forms.StatusStrip statusArchiveStatus;
        private System.Windows.Forms.ToolStripStatusLabel lblStatusInfo;
        private System.Windows.Forms.ToolStripProgressBar progressBar;
        private System.Windows.Forms.Button btnAddProfile;
        private System.Windows.Forms.TextBox txtAddVault;
        private System.Windows.Forms.TextBox txtAddSignature;
        private System.Windows.Forms.TextBox txtAddProfile;
        private System.Windows.Forms.CheckBox chkWarnArchive;
        private System.Windows.Forms.CheckBox chkSaveOnEnter;
        private System.Windows.Forms.PictureBox imgOpenDown;
        private System.Windows.Forms.CheckBox chkTrackVault;
    }
}

