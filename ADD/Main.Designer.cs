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
            System.Windows.Forms.TreeNode treeNode1 = new System.Windows.Forms.TreeNode("Inbox");
            System.Windows.Forms.TreeNode treeNode2 = new System.Windows.Forms.TreeNode("adb0d57fb8e43ff41f2a63902bd456377132b096b8081144cdfbe118a312eaf0\r\n");
            System.Windows.Forms.TreeNode treeNode3 = new System.Windows.Forms.TreeNode("Archives", new System.Windows.Forms.TreeNode[] {
            treeNode2});
            System.Windows.Forms.TreeNode treeNode4 = new System.Windows.Forms.TreeNode("Favorites");
            System.Windows.Forms.TreeNode treeNode5 = new System.Windows.Forms.TreeNode("Monitor");
            System.Windows.Forms.TreeNode treeNode6 = new System.Windows.Forms.TreeNode("Root", new System.Windows.Forms.TreeNode[] {
            treeNode1,
            treeNode3,
            treeNode4,
            treeNode5});
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
            this.tabProfile = new System.Windows.Forms.TabPage();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.button1 = new System.Windows.Forms.Button();
            this.textBox9 = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.comboBox4 = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.comboBox3 = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button6 = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.button8 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.textBox3 = new System.Windows.Forms.TextBox();
            this.textBox4 = new System.Windows.Forms.TextBox();
            this.tabExplore = new System.Windows.Forms.TabPage();
            this.statusArchiveStatus = new System.Windows.Forms.StatusStrip();
            this.lblStatusInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.progressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.lblMonitorInfo = new System.Windows.Forms.ToolStripStatusLabel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.splitContainer5 = new System.Windows.Forms.SplitContainer();
            this.cmbProfile = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.chkKeywords = new System.Windows.Forms.CheckBox();
            this.chkMonitorBlockChains = new System.Windows.Forms.CheckBox();
            this.chkFilterUnSafeContent = new System.Windows.Forms.CheckBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lblTotalArchiveSize = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lblCoinTotal = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblEstimatedCost = new System.Windows.Forms.Label();
            this.cmbSignature = new System.Windows.Forms.ComboBox();
            this.button9 = new System.Windows.Forms.Button();
            this.cmbVault = new System.Windows.Forms.ComboBox();
            this.button10 = new System.Windows.Forms.Button();
            this.imgOpenDown = new System.Windows.Forms.PictureBox();
            this.txtMessage = new System.Windows.Forms.TextBox();
            this.txtFileName = new System.Windows.Forms.TextBox();
            this.imgEnterMessageHere = new System.Windows.Forms.PictureBox();
            this.cmbWalletLabel = new System.Windows.Forms.ComboBox();
            this.cmbCoinType = new System.Windows.Forms.ComboBox();
            this.btnAttachFile = new System.Windows.Forms.Button();
            this.btnArchive = new System.Windows.Forms.Button();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1 = new System.Windows.Forms.Panel();
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.imgApertusSplash = new System.Windows.Forms.PictureBox();
            this.txtInfoBox = new System.Windows.Forms.TextBox();
            this.imgOpenRight = new System.Windows.Forms.PictureBox();
            this.imgOpenUp = new System.Windows.Forms.PictureBox();
            this.imgBackButton = new System.Windows.Forms.PictureBox();
            this.imgNextButton = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.txtTransIDSearch = new System.Windows.Forms.TextBox();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.imgTrash = new System.Windows.Forms.PictureBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.imgOpenLeft = new System.Windows.Forms.PictureBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.textBox6 = new System.Windows.Forms.TextBox();
            this.textBox7 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox8 = new System.Windows.Forms.TextBox();
            this.textBox10 = new System.Windows.Forms.TextBox();
            this.textBox11 = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textBox5 = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.contextMenuStrip1.SuspendLayout();
            this.menuMain.SuspendLayout();
            this.tabProfile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.tabExplore.SuspendLayout();
            this.statusArchiveStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).BeginInit();
            this.splitContainer5.Panel1.SuspendLayout();
            this.splitContainer5.Panel2.SuspendLayout();
            this.splitContainer5.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenDown)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgApertusSplash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextButton)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrash)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenLeft)).BeginInit();
            this.tabControl1.SuspendLayout();
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
            this.menuMain.Size = new System.Drawing.Size(495, 26);
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
            // tabProfile
            // 
            this.tabProfile.Controls.Add(this.textBox5);
            this.tabProfile.Controls.Add(this.label7);
            this.tabProfile.Controls.Add(this.textBox8);
            this.tabProfile.Controls.Add(this.textBox10);
            this.tabProfile.Controls.Add(this.textBox11);
            this.tabProfile.Controls.Add(this.label8);
            this.tabProfile.Controls.Add(this.label11);
            this.tabProfile.Controls.Add(this.label12);
            this.tabProfile.Controls.Add(this.textBox6);
            this.tabProfile.Controls.Add(this.textBox7);
            this.tabProfile.Controls.Add(this.label4);
            this.tabProfile.Controls.Add(this.label5);
            this.tabProfile.Controls.Add(this.textBox4);
            this.tabProfile.Controls.Add(this.textBox3);
            this.tabProfile.Controls.Add(this.textBox2);
            this.tabProfile.Controls.Add(this.textBox1);
            this.tabProfile.Controls.Add(this.textBox9);
            this.tabProfile.Controls.Add(this.label2);
            this.tabProfile.Controls.Add(this.button8);
            this.tabProfile.Controls.Add(this.label10);
            this.tabProfile.Controls.Add(this.label3);
            this.tabProfile.Controls.Add(this.button6);
            this.tabProfile.Controls.Add(this.label1);
            this.tabProfile.Controls.Add(this.comboBox3);
            this.tabProfile.Controls.Add(this.comboBox2);
            this.tabProfile.Controls.Add(this.button2);
            this.tabProfile.Controls.Add(this.comboBox4);
            this.tabProfile.Controls.Add(this.label6);
            this.tabProfile.Controls.Add(this.label9);
            this.tabProfile.Controls.Add(this.button1);
            this.tabProfile.Controls.Add(this.pictureBox2);
            this.tabProfile.Location = new System.Drawing.Point(4, 25);
            this.tabProfile.Name = "tabProfile";
            this.tabProfile.Size = new System.Drawing.Size(683, 402);
            this.tabProfile.TabIndex = 2;
            this.tabProfile.Text = "Profiles";
            this.tabProfile.UseVisualStyleBackColor = true;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::ADD.Properties.Resources.Profile;
            this.pictureBox2.Location = new System.Drawing.Point(19, 52);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(90, 90);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 67;
            this.pictureBox2.TabStop = false;
            // 
            // button1
            // 
            this.button1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.button1.Enabled = false;
            this.button1.FlatAppearance.BorderSize = 0;
            this.button1.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Image = global::ADD.Properties.Resources.Save;
            this.button1.Location = new System.Drawing.Point(1128, 6);
            this.button1.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(68, 27);
            this.button1.TabIndex = 33;
            this.button1.Tag = "12345678901234567890";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // textBox9
            // 
            this.textBox9.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox9.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F);
            this.textBox9.Location = new System.Drawing.Point(8, 376);
            this.textBox9.MaximumSize = new System.Drawing.Size(547, 19);
            this.textBox9.Name = "textBox9";
            this.textBox9.ReadOnly = true;
            this.textBox9.Size = new System.Drawing.Size(547, 19);
            this.textBox9.TabIndex = 73;
            // 
            // label9
            // 
            this.label9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(14, 318);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(84, 17);
            this.label9.TabIndex = 74;
            this.label9.Text = "Tip Address";
            this.label9.Click += new System.EventHandler(this.label9_Click);
            // 
            // label6
            // 
            this.label6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(8, 345);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(90, 17);
            this.label6.TabIndex = 72;
            this.label6.Text = "Msg Address";
            // 
            // comboBox4
            // 
            this.comboBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox4.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox4.Enabled = false;
            this.comboBox4.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox4.FormattingEnabled = true;
            this.comboBox4.Items.AddRange(new object[] {
            "Select Funding Source"});
            this.comboBox4.Location = new System.Drawing.Point(35, 8);
            this.comboBox4.MaximumSize = new System.Drawing.Size(520, 0);
            this.comboBox4.Name = "comboBox4";
            this.comboBox4.Size = new System.Drawing.Size(520, 25);
            this.comboBox4.TabIndex = 25;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(8, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(21, 25);
            this.button2.TabIndex = 31;
            this.button2.Text = "+";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // comboBox2
            // 
            this.comboBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox2.Enabled = false;
            this.comboBox2.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Items.AddRange(new object[] {
            "Select Funding Source"});
            this.comboBox2.Location = new System.Drawing.Point(131, 314);
            this.comboBox2.MaximumSize = new System.Drawing.Size(424, 0);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(424, 25);
            this.comboBox2.TabIndex = 78;
            // 
            // comboBox3
            // 
            this.comboBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.comboBox3.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox3.Enabled = false;
            this.comboBox3.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboBox3.FormattingEnabled = true;
            this.comboBox3.Items.AddRange(new object[] {
            "Select Funding Source"});
            this.comboBox3.Location = new System.Drawing.Point(131, 345);
            this.comboBox3.MaximumSize = new System.Drawing.Size(424, 0);
            this.comboBox3.Name = "comboBox3";
            this.comboBox3.Size = new System.Drawing.Size(424, 25);
            this.comboBox3.TabIndex = 79;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(140, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(76, 17);
            this.label1.TabIndex = 69;
            this.label1.Text = "Nick Name";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // button6
            // 
            this.button6.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button6.Location = new System.Drawing.Point(104, 345);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(21, 25);
            this.button6.TabIndex = 81;
            this.button6.Text = "+";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(222, 39);
            this.textBox1.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox1.MaxLength = 20;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(333, 22);
            this.textBox1.TabIndex = 68;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(126, 123);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 17);
            this.label3.TabIndex = 71;
            this.label3.Text = "Middle Name";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(140, 96);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(76, 17);
            this.label10.TabIndex = 75;
            this.label10.Text = "First Name";
            // 
            // button8
            // 
            this.button8.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button8.Location = new System.Drawing.Point(104, 313);
            this.button8.Name = "button8";
            this.button8.Size = new System.Drawing.Size(21, 27);
            this.button8.TabIndex = 82;
            this.button8.Text = "+";
            this.button8.UseVisualStyleBackColor = true;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(173, 69);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 70;
            this.label2.Text = "Prefix";
            // 
            // textBox2
            // 
            this.textBox2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox2.Location = new System.Drawing.Point(222, 66);
            this.textBox2.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox2.MaxLength = 20;
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(333, 22);
            this.textBox2.TabIndex = 83;
            // 
            // textBox3
            // 
            this.textBox3.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox3.Location = new System.Drawing.Point(222, 93);
            this.textBox3.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox3.MaxLength = 20;
            this.textBox3.Name = "textBox3";
            this.textBox3.Size = new System.Drawing.Size(333, 22);
            this.textBox3.TabIndex = 84;
            // 
            // textBox4
            // 
            this.textBox4.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox4.Location = new System.Drawing.Point(222, 120);
            this.textBox4.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox4.MaxLength = 20;
            this.textBox4.Name = "textBox4";
            this.textBox4.Size = new System.Drawing.Size(333, 22);
            this.textBox4.TabIndex = 85;
            // 
            // tabExplore
            // 
            this.tabExplore.BackColor = System.Drawing.SystemColors.Control;
            this.tabExplore.Controls.Add(this.splitContainer1);
            this.tabExplore.Controls.Add(this.statusArchiveStatus);
            this.tabExplore.Location = new System.Drawing.Point(4, 25);
            this.tabExplore.Name = "tabExplore";
            this.tabExplore.Padding = new System.Windows.Forms.Padding(3);
            this.tabExplore.Size = new System.Drawing.Size(487, 402);
            this.tabExplore.TabIndex = 0;
            this.tabExplore.Text = "Explore";
            // 
            // statusArchiveStatus
            // 
            this.statusArchiveStatus.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.statusArchiveStatus.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusArchiveStatus.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.lblStatusInfo,
            this.progressBar,
            this.lblMonitorInfo});
            this.statusArchiveStatus.Location = new System.Drawing.Point(3, 374);
            this.statusArchiveStatus.Name = "statusArchiveStatus";
            this.statusArchiveStatus.Padding = new System.Windows.Forms.Padding(1, 0, 16, 0);
            this.statusArchiveStatus.Size = new System.Drawing.Size(481, 25);
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
            this.lblStatusInfo.Text = "Status: Select a blockchain to get started.";
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
            // lblMonitorInfo
            // 
            this.lblMonitorInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMonitorInfo.Name = "lblMonitorInfo";
            this.lblMonitorInfo.Size = new System.Drawing.Size(83, 20);
            this.lblMonitorInfo.Text = "Monitor: 0/0";
            this.lblMonitorInfo.Visible = false;
            // 
            // splitContainer1
            // 
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(3, 3);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.splitContainer2);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.splitContainer5);
            this.splitContainer1.Panel2MinSize = 125;
            this.splitContainer1.Size = new System.Drawing.Size(481, 371);
            this.splitContainer1.SplitterDistance = 169;
            this.splitContainer1.TabIndex = 23;
            // 
            // splitContainer5
            // 
            this.splitContainer5.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer5.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer5.Location = new System.Drawing.Point(0, 0);
            this.splitContainer5.Name = "splitContainer5";
            // 
            // splitContainer5.Panel1
            // 
            this.splitContainer5.Panel1.Controls.Add(this.btnArchive);
            this.splitContainer5.Panel1.Controls.Add(this.btnAttachFile);
            this.splitContainer5.Panel1.Controls.Add(this.cmbCoinType);
            this.splitContainer5.Panel1.Controls.Add(this.cmbWalletLabel);
            this.splitContainer5.Panel1.Controls.Add(this.imgEnterMessageHere);
            this.splitContainer5.Panel1.Controls.Add(this.txtFileName);
            this.splitContainer5.Panel1.Controls.Add(this.txtMessage);
            // 
            // splitContainer5.Panel2
            // 
            this.splitContainer5.Panel2.Controls.Add(this.imgOpenDown);
            this.splitContainer5.Panel2.Controls.Add(this.button10);
            this.splitContainer5.Panel2.Controls.Add(this.cmbVault);
            this.splitContainer5.Panel2.Controls.Add(this.button9);
            this.splitContainer5.Panel2.Controls.Add(this.cmbSignature);
            this.splitContainer5.Panel2.Controls.Add(this.flowLayoutPanel1);
            this.splitContainer5.Panel2.Controls.Add(this.cmbProfile);
            this.splitContainer5.Size = new System.Drawing.Size(481, 198);
            this.splitContainer5.SplitterDistance = 306;
            this.splitContainer5.TabIndex = 33;
            this.splitContainer5.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitContainer5_SplitterMoved);
            // 
            // cmbProfile
            // 
            this.cmbProfile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.cmbProfile.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbProfile.Enabled = false;
            this.cmbProfile.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbProfile.FormattingEnabled = true;
            this.cmbProfile.Location = new System.Drawing.Point(3, 103);
            this.cmbProfile.MaxDropDownItems = 100;
            this.cmbProfile.Name = "cmbProfile";
            this.cmbProfile.Size = new System.Drawing.Size(162, 25);
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
            this.flowLayoutPanel1.Controls.Add(this.chkFilterUnSafeContent);
            this.flowLayoutPanel1.Controls.Add(this.chkMonitorBlockChains);
            this.flowLayoutPanel1.Controls.Add(this.chkKeywords);
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 4);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(164, 95);
            this.flowLayoutPanel1.TabIndex = 33;
            // 
            // chkKeywords
            // 
            this.chkKeywords.Anchor = System.Windows.Forms.AnchorStyles.None;
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
            // chkMonitorBlockChains
            // 
            this.chkMonitorBlockChains.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkMonitorBlockChains.AutoSize = true;
            this.chkMonitorBlockChains.Location = new System.Drawing.Point(3, 171);
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
            this.chkFilterUnSafeContent.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.chkFilterUnSafeContent.AutoSize = true;
            this.chkFilterUnSafeContent.Checked = true;
            this.chkFilterUnSafeContent.CheckState = System.Windows.Forms.CheckState.Checked;
            this.chkFilterUnSafeContent.Location = new System.Drawing.Point(3, 144);
            this.chkFilterUnSafeContent.Name = "chkFilterUnSafeContent";
            this.chkFilterUnSafeContent.Size = new System.Drawing.Size(109, 21);
            this.chkFilterUnSafeContent.TabIndex = 3;
            this.chkFilterUnSafeContent.TabStop = false;
            this.chkFilterUnSafeContent.Text = "Enable Filter";
            this.chkFilterUnSafeContent.UseVisualStyleBackColor = true;
            this.chkFilterUnSafeContent.CheckedChanged += new System.EventHandler(this.chkFilterUnSafeContent_CheckedChanged);
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
            this.cmbSignature.Location = new System.Drawing.Point(30, 134);
            this.cmbSignature.MaxDropDownItems = 100;
            this.cmbSignature.Name = "cmbSignature";
            this.cmbSignature.Size = new System.Drawing.Size(135, 25);
            this.cmbSignature.TabIndex = 34;
            // 
            // button9
            // 
            this.button9.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button9.Location = new System.Drawing.Point(3, 134);
            this.button9.Name = "button9";
            this.button9.Size = new System.Drawing.Size(21, 25);
            this.button9.TabIndex = 39;
            this.button9.Text = "+";
            this.button9.UseVisualStyleBackColor = true;
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
            this.cmbVault.Location = new System.Drawing.Point(30, 165);
            this.cmbVault.MaxDropDownItems = 100;
            this.cmbVault.Name = "cmbVault";
            this.cmbVault.Size = new System.Drawing.Size(135, 25);
            this.cmbVault.TabIndex = 40;
            // 
            // button10
            // 
            this.button10.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.button10.Location = new System.Drawing.Point(3, 165);
            this.button10.Name = "button10";
            this.button10.Size = new System.Drawing.Size(21, 25);
            this.button10.TabIndex = 41;
            this.button10.Text = "+";
            this.button10.UseVisualStyleBackColor = true;
            // 
            // imgOpenDown
            // 
            this.imgOpenDown.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgOpenDown.Image = global::ADD.Properties.Resources.OpenDown;
            this.imgOpenDown.Location = new System.Drawing.Point(152, -1);
            this.imgOpenDown.Name = "imgOpenDown";
            this.imgOpenDown.Size = new System.Drawing.Size(18, 10);
            this.imgOpenDown.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenDown.TabIndex = 5;
            this.imgOpenDown.TabStop = false;
            this.imgOpenDown.Click += new System.EventHandler(this.imgOpenDown_Click);
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
            this.txtMessage.Size = new System.Drawing.Size(297, 126);
            this.txtMessage.TabIndex = 5;
            this.txtMessage.TextChanged += new System.EventHandler(this.txtMessage_TextChanged);
            // 
            // txtFileName
            // 
            this.txtFileName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFileName.Enabled = false;
            this.txtFileName.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtFileName.Location = new System.Drawing.Point(6, 4);
            this.txtFileName.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.txtFileName.Multiline = true;
            this.txtFileName.Name = "txtFileName";
            this.txtFileName.Size = new System.Drawing.Size(157, 27);
            this.txtFileName.TabIndex = 8;
            this.txtFileName.TextChanged += new System.EventHandler(this.txtFileName_TextChanged);
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
            this.imgEnterMessageHere.Size = new System.Drawing.Size(271, 97);
            this.imgEnterMessageHere.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgEnterMessageHere.TabIndex = 29;
            this.imgEnterMessageHere.TabStop = false;
            this.imgEnterMessageHere.Visible = false;
            this.imgEnterMessageHere.Click += new System.EventHandler(this.imgEnterMessageHere_Click);
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
            "Select Funding Source"});
            this.cmbWalletLabel.Location = new System.Drawing.Point(160, 165);
            this.cmbWalletLabel.MaxDropDownItems = 100;
            this.cmbWalletLabel.Name = "cmbWalletLabel";
            this.cmbWalletLabel.Size = new System.Drawing.Size(141, 25);
            this.cmbWalletLabel.TabIndex = 21;
            this.cmbWalletLabel.SelectedIndexChanged += new System.EventHandler(this.cmbWalletLabel_SelectedIndexChanged);
            // 
            // cmbCoinType
            // 
            this.cmbCoinType.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.cmbCoinType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCoinType.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbCoinType.FormattingEnabled = true;
            this.cmbCoinType.ItemHeight = 17;
            this.cmbCoinType.Location = new System.Drawing.Point(4, 165);
            this.cmbCoinType.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.cmbCoinType.MaxDropDownItems = 100;
            this.cmbCoinType.MaximumSize = new System.Drawing.Size(571, 0);
            this.cmbCoinType.Name = "cmbCoinType";
            this.cmbCoinType.Size = new System.Drawing.Size(148, 25);
            this.cmbCoinType.TabIndex = 11;
            this.cmbCoinType.SelectedIndexChanged += new System.EventHandler(this.cmbCoinType_SelectedIndexChanged);
            // 
            // btnAttachFile
            // 
            this.btnAttachFile.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAttachFile.Enabled = false;
            this.btnAttachFile.FlatAppearance.BorderSize = 0;
            this.btnAttachFile.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAttachFile.Image = global::ADD.Properties.Resources.Button2;
            this.btnAttachFile.Location = new System.Drawing.Point(168, 4);
            this.btnAttachFile.Margin = new System.Windows.Forms.Padding(0);
            this.btnAttachFile.Name = "btnAttachFile";
            this.btnAttachFile.Size = new System.Drawing.Size(61, 27);
            this.btnAttachFile.TabIndex = 6;
            this.btnAttachFile.UseVisualStyleBackColor = true;
            this.btnAttachFile.Click += new System.EventHandler(this.btnAttachFiles_Click);
            // 
            // btnArchive
            // 
            this.btnArchive.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnArchive.Enabled = false;
            this.btnArchive.FlatAppearance.BorderSize = 0;
            this.btnArchive.Font = new System.Drawing.Font("Arial", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnArchive.Image = global::ADD.Properties.Resources.Save;
            this.btnArchive.Location = new System.Drawing.Point(234, 4);
            this.btnArchive.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.btnArchive.Name = "btnArchive";
            this.btnArchive.Size = new System.Drawing.Size(67, 27);
            this.btnArchive.TabIndex = 3;
            this.btnArchive.Tag = "12345678901234567890";
            this.btnArchive.UseVisualStyleBackColor = true;
            this.btnArchive.Click += new System.EventHandler(this.btnArchive_Click);
            // 
            // splitContainer2
            // 
            this.splitContainer2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer2.Location = new System.Drawing.Point(0, 0);
            this.splitContainer2.Name = "splitContainer2";
            // 
            // splitContainer2.Panel1
            // 
            this.splitContainer2.Panel1.BackColor = System.Drawing.Color.White;
            this.splitContainer2.Panel1.Controls.Add(this.imgOpenLeft);
            this.splitContainer2.Panel1.Controls.Add(this.treeView1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.BackColor = System.Drawing.SystemColors.Window;
            this.splitContainer2.Panel2.Controls.Add(this.imgTrash);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox4);
            this.splitContainer2.Panel2.Controls.Add(this.txtTransIDSearch);
            this.splitContainer2.Panel2.Controls.Add(this.pictureBox3);
            this.splitContainer2.Panel2.Controls.Add(this.imgNextButton);
            this.splitContainer2.Panel2.Controls.Add(this.imgBackButton);
            this.splitContainer2.Panel2.Controls.Add(this.panel1);
            this.splitContainer2.Size = new System.Drawing.Size(481, 169);
            this.splitContainer2.SplitterDistance = 145;
            this.splitContainer2.TabIndex = 29;
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
            this.panel1.Size = new System.Drawing.Size(327, 131);
            this.panel1.TabIndex = 5;
            // 
            // webBrowser1
            // 
            this.webBrowser1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowser1.Location = new System.Drawing.Point(0, 0);
            this.webBrowser1.Margin = new System.Windows.Forms.Padding(0);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(327, 131);
            this.webBrowser1.TabIndex = 1;
            this.webBrowser1.TabStop = false;
            this.webBrowser1.Navigated += new System.Windows.Forms.WebBrowserNavigatedEventHandler(this.webBrowser1_Navigated);
            // 
            // imgApertusSplash
            // 
            this.imgApertusSplash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)));
            this.imgApertusSplash.Image = global::ADD.Properties.Resources.About;
            this.imgApertusSplash.Location = new System.Drawing.Point(86, 0);
            this.imgApertusSplash.Name = "imgApertusSplash";
            this.imgApertusSplash.Size = new System.Drawing.Size(143, 94);
            this.imgApertusSplash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgApertusSplash.TabIndex = 0;
            this.imgApertusSplash.TabStop = false;
            // 
            // txtInfoBox
            // 
            this.txtInfoBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtInfoBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtInfoBox.Location = new System.Drawing.Point(0, 102);
            this.txtInfoBox.Multiline = true;
            this.txtInfoBox.Name = "txtInfoBox";
            this.txtInfoBox.Size = new System.Drawing.Size(323, 31);
            this.txtInfoBox.TabIndex = 5;
            this.txtInfoBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // imgOpenRight
            // 
            this.imgOpenRight.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgOpenRight.Image = global::ADD.Properties.Resources.OpenRight;
            this.imgOpenRight.Location = new System.Drawing.Point(-1, 103);
            this.imgOpenRight.Name = "imgOpenRight";
            this.imgOpenRight.Size = new System.Drawing.Size(10, 18);
            this.imgOpenRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenRight.TabIndex = 4;
            this.imgOpenRight.TabStop = false;
            this.imgOpenRight.Visible = false;
            this.imgOpenRight.Click += new System.EventHandler(this.imgOpenRight_Click);
            // 
            // imgOpenUp
            // 
            this.imgOpenUp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.imgOpenUp.Image = global::ADD.Properties.Resources.OpenUp;
            this.imgOpenUp.Location = new System.Drawing.Point(9, 121);
            this.imgOpenUp.Name = "imgOpenUp";
            this.imgOpenUp.Size = new System.Drawing.Size(18, 10);
            this.imgOpenUp.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenUp.TabIndex = 4;
            this.imgOpenUp.TabStop = false;
            this.imgOpenUp.Visible = false;
            this.imgOpenUp.Click += new System.EventHandler(this.imgOpenUp_Click);
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
            // pictureBox3
            // 
            this.pictureBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox3.Image = global::ADD.Properties.Resources.home;
            this.pictureBox3.Location = new System.Drawing.Point(245, 3);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(23, 23);
            this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox3.TabIndex = 6;
            this.pictureBox3.TabStop = false;
            this.pictureBox3.Click += new System.EventHandler(this.pictureBox3_Click);
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
            this.txtTransIDSearch.Size = new System.Drawing.Size(174, 23);
            this.txtTransIDSearch.TabIndex = 1;
            this.txtTransIDSearch.TabStop = false;
            this.txtTransIDSearch.Text = "ENTER SEARCH STRING";
            this.txtTransIDSearch.Click += new System.EventHandler(this.txtTransIDSearch_Click);
            this.txtTransIDSearch.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtTransIDSearch_KeyDown);
            // 
            // pictureBox4
            // 
            this.pictureBox4.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox4.Image = global::ADD.Properties.Resources.star;
            this.pictureBox4.Location = new System.Drawing.Point(274, 2);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(23, 23);
            this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox4.TabIndex = 7;
            this.pictureBox4.TabStop = false;
            this.pictureBox4.Click += new System.EventHandler(this.pictureBox4_Click);
            // 
            // imgTrash
            // 
            this.imgTrash.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.imgTrash.Enabled = false;
            this.imgTrash.Image = global::ADD.Properties.Resources.TrashDisabled;
            this.imgTrash.Location = new System.Drawing.Point(303, 3);
            this.imgTrash.Name = "imgTrash";
            this.imgTrash.Size = new System.Drawing.Size(23, 23);
            this.imgTrash.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.imgTrash.TabIndex = 5;
            this.imgTrash.TabStop = false;
            this.imgTrash.Click += new System.EventHandler(this.imgTrash_Click);
            // 
            // treeView1
            // 
            this.treeView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.treeView1.Location = new System.Drawing.Point(0, 0);
            this.treeView1.Name = "treeView1";
            treeNode1.Name = "inbox";
            treeNode1.Text = "Inbox";
            treeNode2.Name = "Node4";
            treeNode2.Text = "adb0d57fb8e43ff41f2a63902bd456377132b096b8081144cdfbe118a312eaf0\r\n";
            treeNode3.Name = "archives";
            treeNode3.Text = "Archives";
            treeNode4.Name = "favorites";
            treeNode4.Text = "Favorites";
            treeNode5.Name = "monitor";
            treeNode5.Text = "Monitor";
            treeNode6.Name = "root";
            treeNode6.Text = "Root";
            this.treeView1.Nodes.AddRange(new System.Windows.Forms.TreeNode[] {
            treeNode6});
            this.treeView1.Size = new System.Drawing.Size(143, 167);
            this.treeView1.TabIndex = 5;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            this.treeView1.DoubleClick += new System.EventHandler(this.treeView1_DoubleClick);
            // 
            // imgOpenLeft
            // 
            this.imgOpenLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.imgOpenLeft.Image = global::ADD.Properties.Resources.OpenLeft;
            this.imgOpenLeft.Location = new System.Drawing.Point(130, 125);
            this.imgOpenLeft.Name = "imgOpenLeft";
            this.imgOpenLeft.Size = new System.Drawing.Size(10, 18);
            this.imgOpenLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.imgOpenLeft.TabIndex = 2;
            this.imgOpenLeft.TabStop = false;
            this.imgOpenLeft.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabExplore);
            this.tabControl1.Controls.Add(this.tabProfile);
            this.tabControl1.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabControl1.Location = new System.Drawing.Point(0, 29);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(495, 431);
            this.tabControl1.TabIndex = 0;
            this.tabControl1.TabStop = false;
            // 
            // textBox6
            // 
            this.textBox6.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox6.Location = new System.Drawing.Point(222, 175);
            this.textBox6.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox6.MaxLength = 20;
            this.textBox6.Name = "textBox6";
            this.textBox6.Size = new System.Drawing.Size(333, 22);
            this.textBox6.TabIndex = 90;
            // 
            // textBox7
            // 
            this.textBox7.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox7.Location = new System.Drawing.Point(222, 148);
            this.textBox7.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox7.MaxLength = 20;
            this.textBox7.Name = "textBox7";
            this.textBox7.Size = new System.Drawing.Size(333, 22);
            this.textBox7.TabIndex = 89;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(140, 153);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 86;
            this.label4.Text = "Last Name";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(174, 178);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 17);
            this.label5.TabIndex = 88;
            this.label5.Text = "Suffix";
            // 
            // textBox8
            // 
            this.textBox8.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox8.Location = new System.Drawing.Point(222, 257);
            this.textBox8.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox8.MaxLength = 20;
            this.textBox8.Name = "textBox8";
            this.textBox8.Size = new System.Drawing.Size(333, 22);
            this.textBox8.TabIndex = 97;
            // 
            // textBox10
            // 
            this.textBox10.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox10.Location = new System.Drawing.Point(222, 230);
            this.textBox10.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox10.MaxLength = 20;
            this.textBox10.Name = "textBox10";
            this.textBox10.Size = new System.Drawing.Size(333, 22);
            this.textBox10.TabIndex = 96;
            // 
            // textBox11
            // 
            this.textBox11.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox11.Location = new System.Drawing.Point(222, 203);
            this.textBox11.MaximumSize = new System.Drawing.Size(333, 22);
            this.textBox11.MaxLength = 20;
            this.textBox11.Name = "textBox11";
            this.textBox11.Size = new System.Drawing.Size(333, 22);
            this.textBox11.TabIndex = 95;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(144, 208);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(72, 17);
            this.label8.TabIndex = 92;
            this.label8.Text = "Address 1";
            this.label8.Click += new System.EventHandler(this.label8_Click);
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(144, 233);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(72, 17);
            this.label11.TabIndex = 94;
            this.label11.Text = "Address 2";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(144, 260);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(72, 17);
            this.label12.TabIndex = 93;
            this.label12.Text = "Address 3";
            // 
            // textBox5
            // 
            this.textBox5.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox5.Location = new System.Drawing.Point(8, 285);
            this.textBox5.MaxLength = 20;
            this.textBox5.Multiline = true;
            this.textBox5.Name = "textBox5";
            this.textBox5.Size = new System.Drawing.Size(667, 21);
            this.textBox5.TabIndex = 99;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(8, 262);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(28, 17);
            this.label7.TabIndex = 98;
            this.label7.Text = "Bio";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(495, 462);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.menuMain);
            this.DoubleBuffered = true;
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.MinimumSize = new System.Drawing.Size(508, 422);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Apertus";
            this.TransparencyKey = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(128)))));
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Form1_Resize);
            this.contextMenuStrip1.ResumeLayout(false);
            this.menuMain.ResumeLayout(false);
            this.menuMain.PerformLayout();
            this.tabProfile.ResumeLayout(false);
            this.tabProfile.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.tabExplore.ResumeLayout(false);
            this.tabExplore.PerformLayout();
            this.statusArchiveStatus.ResumeLayout(false);
            this.statusArchiveStatus.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.splitContainer5.Panel1.ResumeLayout(false);
            this.splitContainer5.Panel1.PerformLayout();
            this.splitContainer5.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer5)).EndInit();
            this.splitContainer5.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenDown)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgEnterMessageHere)).EndInit();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            this.splitContainer2.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.imgApertusSplash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgBackButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgNextButton)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgTrash)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.imgOpenLeft)).EndInit();
            this.tabControl1.ResumeLayout(false);
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
        private System.Windows.Forms.TabPage tabProfile;
        private System.Windows.Forms.TextBox textBox6;
        private System.Windows.Forms.TextBox textBox7;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox4;
        private System.Windows.Forms.TextBox textBox3;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.TextBox textBox9;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox3;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.ComboBox comboBox4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.TabPage tabExplore;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.SplitContainer splitContainer2;
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
        private System.Windows.Forms.SplitContainer splitContainer5;
        private System.Windows.Forms.Button btnArchive;
        private System.Windows.Forms.Button btnAttachFile;
        private System.Windows.Forms.ComboBox cmbCoinType;
        private System.Windows.Forms.ComboBox cmbWalletLabel;
        private System.Windows.Forms.PictureBox imgEnterMessageHere;
        private System.Windows.Forms.TextBox txtFileName;
        private System.Windows.Forms.TextBox txtMessage;
        private System.Windows.Forms.PictureBox imgOpenDown;
        private System.Windows.Forms.Button button10;
        private System.Windows.Forms.ComboBox cmbVault;
        private System.Windows.Forms.Button button9;
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
        private System.Windows.Forms.ToolStripStatusLabel lblMonitorInfo;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TextBox textBox8;
        private System.Windows.Forms.TextBox textBox10;
        private System.Windows.Forms.TextBox textBox11;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textBox5;
        private System.Windows.Forms.Label label7;
    }
}

