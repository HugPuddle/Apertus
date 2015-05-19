namespace ADD
{
    partial class Trust
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Trust));
            this.txtBlockList = new System.Windows.Forms.TextBox();
            this.txtBlock = new System.Windows.Forms.TextBox();
            this.btnRemoveBlock = new System.Windows.Forms.Button();
            this.btnAddBlock = new System.Windows.Forms.Button();
            this.chkBlockUnsignedContent = new System.Windows.Forms.CheckBox();
            this.chkBlockUntrustedContent = new System.Windows.Forms.CheckBox();
            this.chkBlockBlockedListContent = new System.Windows.Forms.CheckBox();
            this.btnRemoveTrust = new System.Windows.Forms.Button();
            this.btnAddTrust = new System.Windows.Forms.Button();
            this.chkTrustTrustedlistContent = new System.Windows.Forms.CheckBox();
            this.txtTrustList = new System.Windows.Forms.TextBox();
            this.txtTrust = new System.Windows.Forms.TextBox();
            this.btnRemoveFollow = new System.Windows.Forms.Button();
            this.btnAddFollow = new System.Windows.Forms.Button();
            this.chkFollowFollowedlistContent = new System.Windows.Forms.CheckBox();
            this.txtFollowList = new System.Windows.Forms.TextBox();
            this.txtFollow = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.splitContainer2 = new System.Windows.Forms.SplitContainer();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).BeginInit();
            this.splitContainer2.Panel1.SuspendLayout();
            this.splitContainer2.Panel2.SuspendLayout();
            this.splitContainer2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBlockList
            // 
            this.txtBlockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlockList.BackColor = System.Drawing.Color.White;
            this.txtBlockList.Location = new System.Drawing.Point(18, 62);
            this.txtBlockList.Multiline = true;
            this.txtBlockList.Name = "txtBlockList";
            this.txtBlockList.ReadOnly = true;
            this.txtBlockList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBlockList.Size = new System.Drawing.Size(342, 0);
            this.txtBlockList.TabIndex = 8;
            this.txtBlockList.WordWrap = false;
            // 
            // txtBlock
            // 
            this.txtBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlock.Location = new System.Drawing.Point(18, 34);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(289, 22);
            this.txtBlock.TabIndex = 16;
            // 
            // btnRemoveBlock
            // 
            this.btnRemoveBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBlock.Location = new System.Drawing.Point(339, 33);
            this.btnRemoveBlock.Name = "btnRemoveBlock";
            this.btnRemoveBlock.Size = new System.Drawing.Size(21, 23);
            this.btnRemoveBlock.TabIndex = 18;
            this.btnRemoveBlock.Text = "-";
            this.btnRemoveBlock.UseVisualStyleBackColor = true;
            this.btnRemoveBlock.Click += new System.EventHandler(this.btnRemoveBlock_Click);
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBlock.Location = new System.Drawing.Point(313, 33);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(21, 23);
            this.btnAddBlock.TabIndex = 17;
            this.btnAddBlock.Text = "+";
            this.btnAddBlock.UseVisualStyleBackColor = true;
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // chkBlockUnsignedContent
            // 
            this.chkBlockUnsignedContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBlockUnsignedContent.AutoSize = true;
            this.chkBlockUnsignedContent.Location = new System.Drawing.Point(18, 118);
            this.chkBlockUnsignedContent.Name = "chkBlockUnsignedContent";
            this.chkBlockUnsignedContent.Size = new System.Drawing.Size(199, 21);
            this.chkBlockUnsignedContent.TabIndex = 21;
            this.chkBlockUnsignedContent.Text = "Block all unsigned content.";
            this.chkBlockUnsignedContent.UseVisualStyleBackColor = true;
            this.chkBlockUnsignedContent.Click += new System.EventHandler(this.chkBlockUnsignedContent_Click);
            // 
            // chkBlockUntrustedContent
            // 
            this.chkBlockUntrustedContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBlockUntrustedContent.AutoSize = true;
            this.chkBlockUntrustedContent.Location = new System.Drawing.Point(18, 91);
            this.chkBlockUntrustedContent.Name = "chkBlockUntrustedContent";
            this.chkBlockUntrustedContent.Size = new System.Drawing.Size(201, 21);
            this.chkBlockUntrustedContent.TabIndex = 20;
            this.chkBlockUntrustedContent.Text = "Block all untrusted content.";
            this.chkBlockUntrustedContent.UseVisualStyleBackColor = true;
            this.chkBlockUntrustedContent.Click += new System.EventHandler(this.chkBlockUntrustedContent_Click);
            // 
            // chkBlockBlockedListContent
            // 
            this.chkBlockBlockedListContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBlockBlockedListContent.AutoSize = true;
            this.chkBlockBlockedListContent.Location = new System.Drawing.Point(18, 64);
            this.chkBlockBlockedListContent.Name = "chkBlockBlockedListContent";
            this.chkBlockBlockedListContent.Size = new System.Drawing.Size(305, 21);
            this.chkBlockBlockedListContent.TabIndex = 17;
            this.chkBlockBlockedListContent.Text = "Block all content from Blocked Address List.";
            this.chkBlockBlockedListContent.UseVisualStyleBackColor = true;
            this.chkBlockBlockedListContent.Click += new System.EventHandler(this.chkBlockBlockedListContent_Click);
            // 
            // btnRemoveTrust
            // 
            this.btnRemoveTrust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTrust.Location = new System.Drawing.Point(339, 26);
            this.btnRemoveTrust.Name = "btnRemoveTrust";
            this.btnRemoveTrust.Size = new System.Drawing.Size(21, 23);
            this.btnRemoveTrust.TabIndex = 24;
            this.btnRemoveTrust.Text = "-";
            this.btnRemoveTrust.UseVisualStyleBackColor = true;
            this.btnRemoveTrust.Click += new System.EventHandler(this.btnRemoveTrust_Click);
            // 
            // btnAddTrust
            // 
            this.btnAddTrust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrust.Location = new System.Drawing.Point(313, 26);
            this.btnAddTrust.Name = "btnAddTrust";
            this.btnAddTrust.Size = new System.Drawing.Size(21, 23);
            this.btnAddTrust.TabIndex = 23;
            this.btnAddTrust.Text = "+";
            this.btnAddTrust.UseVisualStyleBackColor = true;
            this.btnAddTrust.Click += new System.EventHandler(this.btnAddTrust_Click);
            // 
            // chkTrustTrustedlistContent
            // 
            this.chkTrustTrustedlistContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTrustTrustedlistContent.AutoSize = true;
            this.chkTrustTrustedlistContent.Location = new System.Drawing.Point(18, 210);
            this.chkTrustTrustedlistContent.Name = "chkTrustTrustedlistContent";
            this.chkTrustTrustedlistContent.Size = new System.Drawing.Size(257, 21);
            this.chkTrustTrustedlistContent.TabIndex = 19;
            this.chkTrustTrustedlistContent.Text = "Accept all content from Trusted List.";
            this.chkTrustTrustedlistContent.UseVisualStyleBackColor = true;
            this.chkTrustTrustedlistContent.Click += new System.EventHandler(this.chkTrustTrustedlistContent_Click);
            // 
            // txtTrustList
            // 
            this.txtTrustList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrustList.BackColor = System.Drawing.Color.White;
            this.txtTrustList.Location = new System.Drawing.Point(18, 56);
            this.txtTrustList.Multiline = true;
            this.txtTrustList.Name = "txtTrustList";
            this.txtTrustList.ReadOnly = true;
            this.txtTrustList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrustList.Size = new System.Drawing.Size(342, 148);
            this.txtTrustList.TabIndex = 8;
            this.txtTrustList.WordWrap = false;
            // 
            // txtTrust
            // 
            this.txtTrust.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrust.Location = new System.Drawing.Point(18, 26);
            this.txtTrust.Name = "txtTrust";
            this.txtTrust.Size = new System.Drawing.Size(289, 22);
            this.txtTrust.TabIndex = 16;
            // 
            // btnRemoveFollow
            // 
            this.btnRemoveFollow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveFollow.Location = new System.Drawing.Point(371, 26);
            this.btnRemoveFollow.Name = "btnRemoveFollow";
            this.btnRemoveFollow.Size = new System.Drawing.Size(21, 23);
            this.btnRemoveFollow.TabIndex = 28;
            this.btnRemoveFollow.Text = "-";
            this.btnRemoveFollow.UseVisualStyleBackColor = true;
            this.btnRemoveFollow.Click += new System.EventHandler(this.btnRemoveFollow_Click);
            // 
            // btnAddFollow
            // 
            this.btnAddFollow.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddFollow.Location = new System.Drawing.Point(345, 26);
            this.btnAddFollow.Name = "btnAddFollow";
            this.btnAddFollow.Size = new System.Drawing.Size(21, 23);
            this.btnAddFollow.TabIndex = 27;
            this.btnAddFollow.Text = "+";
            this.btnAddFollow.UseVisualStyleBackColor = true;
            this.btnAddFollow.Click += new System.EventHandler(this.btnAddFollow_Click);
            // 
            // chkFollowFollowedlistContent
            // 
            this.chkFollowFollowedlistContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkFollowFollowedlistContent.AutoSize = true;
            this.chkFollowFollowedlistContent.Location = new System.Drawing.Point(18, 368);
            this.chkFollowFollowedlistContent.Name = "chkFollowFollowedlistContent";
            this.chkFollowFollowedlistContent.Size = new System.Drawing.Size(243, 21);
            this.chkFollowFollowedlistContent.TabIndex = 19;
            this.chkFollowFollowedlistContent.Text = "Follow all content from Follow List.";
            this.chkFollowFollowedlistContent.UseVisualStyleBackColor = true;
            // 
            // txtFollowList
            // 
            this.txtFollowList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFollowList.BackColor = System.Drawing.Color.White;
            this.txtFollowList.Location = new System.Drawing.Point(18, 57);
            this.txtFollowList.Multiline = true;
            this.txtFollowList.Name = "txtFollowList";
            this.txtFollowList.ReadOnly = true;
            this.txtFollowList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtFollowList.Size = new System.Drawing.Size(374, 305);
            this.txtFollowList.TabIndex = 8;
            this.txtFollowList.WordWrap = false;
            // 
            // txtFollow
            // 
            this.txtFollow.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFollow.Location = new System.Drawing.Point(18, 28);
            this.txtFollow.Name = "txtFollow";
            this.txtFollow.Size = new System.Drawing.Size(321, 22);
            this.txtFollow.TabIndex = 16;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.Controls.Add(this.splitContainer1);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(379, 396);
            this.panel1.TabIndex = 27;
            // 
            // splitContainer1
            // 
            this.splitContainer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.label1);
            this.splitContainer1.Panel1.Controls.Add(this.txtTrustList);
            this.splitContainer1.Panel1.Controls.Add(this.txtTrust);
            this.splitContainer1.Panel1.Controls.Add(this.chkTrustTrustedlistContent);
            this.splitContainer1.Panel1.Controls.Add(this.btnAddTrust);
            this.splitContainer1.Panel1.Controls.Add(this.btnRemoveTrust);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.txtBlock);
            this.splitContainer1.Panel2.Controls.Add(this.chkBlockUnsignedContent);
            this.splitContainer1.Panel2.Controls.Add(this.chkBlockBlockedListContent);
            this.splitContainer1.Panel2.Controls.Add(this.btnRemoveBlock);
            this.splitContainer1.Panel2.Controls.Add(this.label3);
            this.splitContainer1.Panel2.Controls.Add(this.chkBlockUntrustedContent);
            this.splitContainer1.Panel2.Controls.Add(this.btnAddBlock);
            this.splitContainer1.Panel2.Controls.Add(this.txtBlockList);
            this.splitContainer1.Size = new System.Drawing.Size(379, 396);
            this.splitContainer1.SplitterDistance = 245;
            this.splitContainer1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 6);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(57, 17);
            this.label1.TabIndex = 25;
            this.label1.Text = "Trusted";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 8);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 17);
            this.label2.TabIndex = 26;
            this.label2.Text = "Followed";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 14);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(58, 17);
            this.label3.TabIndex = 29;
            this.label3.Text = "Blocked";
            // 
            // panel2
            // 
            this.panel2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.btnRemoveFollow);
            this.panel2.Controls.Add(this.txtFollowList);
            this.panel2.Controls.Add(this.btnAddFollow);
            this.panel2.Controls.Add(this.txtFollow);
            this.panel2.Controls.Add(this.chkFollowFollowedlistContent);
            this.panel2.Location = new System.Drawing.Point(5, 3);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(402, 396);
            this.panel2.TabIndex = 30;
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
            this.splitContainer2.Panel1.Controls.Add(this.panel1);
            // 
            // splitContainer2.Panel2
            // 
            this.splitContainer2.Panel2.Controls.Add(this.panel2);
            this.splitContainer2.Size = new System.Drawing.Size(805, 406);
            this.splitContainer2.SplitterDistance = 389;
            this.splitContainer2.TabIndex = 31;
            // 
            // Trust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(805, 406);
            this.Controls.Add(this.splitContainer2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Trust";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trust Center";
            this.Load += new System.EventHandler(this.Trust_Load);
            this.panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.splitContainer2.Panel1.ResumeLayout(false);
            this.splitContainer2.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer2)).EndInit();
            this.splitContainer2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBlockList;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Button btnRemoveBlock;
        private System.Windows.Forms.Button btnAddBlock;
        private System.Windows.Forms.Button btnRemoveTrust;
        private System.Windows.Forms.Button btnAddTrust;
        private System.Windows.Forms.TextBox txtTrustList;
        private System.Windows.Forms.TextBox txtTrust;
        private System.Windows.Forms.CheckBox chkBlockBlockedListContent;
        private System.Windows.Forms.CheckBox chkTrustTrustedlistContent;
        private System.Windows.Forms.CheckBox chkBlockUnsignedContent;
        private System.Windows.Forms.CheckBox chkBlockUntrustedContent;
        private System.Windows.Forms.Button btnRemoveFollow;
        private System.Windows.Forms.Button btnAddFollow;
        private System.Windows.Forms.CheckBox chkFollowFollowedlistContent;
        private System.Windows.Forms.TextBox txtFollowList;
        private System.Windows.Forms.TextBox txtFollow;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.SplitContainer splitContainer2;

    }
}