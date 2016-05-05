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
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBlockList
            // 
            this.txtBlockList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlockList.BackColor = System.Drawing.Color.White;
            this.txtBlockList.Location = new System.Drawing.Point(4, 94);
            this.txtBlockList.Margin = new System.Windows.Forms.Padding(4);
            this.txtBlockList.Multiline = true;
            this.txtBlockList.Name = "txtBlockList";
            this.txtBlockList.ReadOnly = true;
            this.txtBlockList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBlockList.Size = new System.Drawing.Size(492, 257);
            this.txtBlockList.TabIndex = 8;
            this.txtBlockList.WordWrap = false;
            // 
            // txtBlock
            // 
            this.txtBlock.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtBlock.Location = new System.Drawing.Point(4, 52);
            this.txtBlock.Margin = new System.Windows.Forms.Padding(4);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(412, 31);
            this.txtBlock.TabIndex = 16;
            this.txtBlock.WordWrap = false;
            // 
            // btnRemoveBlock
            // 
            this.btnRemoveBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveBlock.Location = new System.Drawing.Point(466, 50);
            this.btnRemoveBlock.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveBlock.Name = "btnRemoveBlock";
            this.btnRemoveBlock.Size = new System.Drawing.Size(32, 37);
            this.btnRemoveBlock.TabIndex = 18;
            this.btnRemoveBlock.Text = "-";
            this.btnRemoveBlock.UseVisualStyleBackColor = true;
            this.btnRemoveBlock.Click += new System.EventHandler(this.btnRemoveBlock_Click);
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddBlock.Location = new System.Drawing.Point(426, 50);
            this.btnAddBlock.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(32, 37);
            this.btnAddBlock.TabIndex = 17;
            this.btnAddBlock.Text = "+";
            this.btnAddBlock.UseVisualStyleBackColor = true;
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // chkBlockUnsignedContent
            // 
            this.chkBlockUnsignedContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBlockUnsignedContent.AutoSize = true;
            this.chkBlockUnsignedContent.Location = new System.Drawing.Point(16, 441);
            this.chkBlockUnsignedContent.Margin = new System.Windows.Forms.Padding(4);
            this.chkBlockUnsignedContent.Name = "chkBlockUnsignedContent";
            this.chkBlockUnsignedContent.Size = new System.Drawing.Size(302, 29);
            this.chkBlockUnsignedContent.TabIndex = 21;
            this.chkBlockUnsignedContent.Text = "Block all unsigned content.";
            this.chkBlockUnsignedContent.UseVisualStyleBackColor = true;
            this.chkBlockUnsignedContent.Click += new System.EventHandler(this.chkBlockUnsignedContent_Click);
            // 
            // chkBlockUntrustedContent
            // 
            this.chkBlockUntrustedContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBlockUntrustedContent.AutoSize = true;
            this.chkBlockUntrustedContent.Location = new System.Drawing.Point(16, 405);
            this.chkBlockUntrustedContent.Margin = new System.Windows.Forms.Padding(4);
            this.chkBlockUntrustedContent.Name = "chkBlockUntrustedContent";
            this.chkBlockUntrustedContent.Size = new System.Drawing.Size(304, 29);
            this.chkBlockUntrustedContent.TabIndex = 20;
            this.chkBlockUntrustedContent.Text = "Block all untrusted content.";
            this.chkBlockUntrustedContent.UseVisualStyleBackColor = true;
            this.chkBlockUntrustedContent.Click += new System.EventHandler(this.chkBlockUntrustedContent_Click);
            // 
            // chkBlockBlockedListContent
            // 
            this.chkBlockBlockedListContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkBlockBlockedListContent.AutoSize = true;
            this.chkBlockBlockedListContent.Location = new System.Drawing.Point(16, 370);
            this.chkBlockBlockedListContent.Margin = new System.Windows.Forms.Padding(4);
            this.chkBlockBlockedListContent.Name = "chkBlockBlockedListContent";
            this.chkBlockBlockedListContent.Size = new System.Drawing.Size(464, 29);
            this.chkBlockBlockedListContent.TabIndex = 17;
            this.chkBlockBlockedListContent.Text = "Block all content from Blocked Address List.";
            this.chkBlockBlockedListContent.UseVisualStyleBackColor = true;
            this.chkBlockBlockedListContent.Click += new System.EventHandler(this.chkBlockBlockedListContent_Click);
            // 
            // btnRemoveTrust
            // 
            this.btnRemoveTrust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRemoveTrust.Location = new System.Drawing.Point(470, 50);
            this.btnRemoveTrust.Margin = new System.Windows.Forms.Padding(4);
            this.btnRemoveTrust.Name = "btnRemoveTrust";
            this.btnRemoveTrust.Size = new System.Drawing.Size(32, 37);
            this.btnRemoveTrust.TabIndex = 24;
            this.btnRemoveTrust.Text = "-";
            this.btnRemoveTrust.UseVisualStyleBackColor = true;
            this.btnRemoveTrust.Click += new System.EventHandler(this.btnRemoveTrust_Click);
            // 
            // btnAddTrust
            // 
            this.btnAddTrust.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnAddTrust.Location = new System.Drawing.Point(430, 50);
            this.btnAddTrust.Margin = new System.Windows.Forms.Padding(4);
            this.btnAddTrust.Name = "btnAddTrust";
            this.btnAddTrust.Size = new System.Drawing.Size(32, 37);
            this.btnAddTrust.TabIndex = 23;
            this.btnAddTrust.Text = "+";
            this.btnAddTrust.UseVisualStyleBackColor = true;
            this.btnAddTrust.Click += new System.EventHandler(this.btnAddTrust_Click);
            // 
            // chkTrustTrustedlistContent
            // 
            this.chkTrustTrustedlistContent.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.chkTrustTrustedlistContent.AutoSize = true;
            this.chkTrustTrustedlistContent.Location = new System.Drawing.Point(12, 370);
            this.chkTrustTrustedlistContent.Margin = new System.Windows.Forms.Padding(4);
            this.chkTrustTrustedlistContent.Name = "chkTrustTrustedlistContent";
            this.chkTrustTrustedlistContent.Size = new System.Drawing.Size(388, 29);
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
            this.txtTrustList.Location = new System.Drawing.Point(4, 94);
            this.txtTrustList.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrustList.Multiline = true;
            this.txtTrustList.Name = "txtTrustList";
            this.txtTrustList.ReadOnly = true;
            this.txtTrustList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrustList.Size = new System.Drawing.Size(496, 257);
            this.txtTrustList.TabIndex = 8;
            this.txtTrustList.WordWrap = false;
            // 
            // txtTrust
            // 
            this.txtTrust.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTrust.Location = new System.Drawing.Point(4, 50);
            this.txtTrust.Margin = new System.Windows.Forms.Padding(4);
            this.txtTrust.Name = "txtTrust";
            this.txtTrust.Size = new System.Drawing.Size(414, 31);
            this.txtTrust.TabIndex = 16;
            this.txtTrust.WordWrap = false;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.txtTrustList);
            this.panel1.Controls.Add(this.chkTrustTrustedlistContent);
            this.panel1.Controls.Add(this.btnAddTrust);
            this.panel1.Controls.Add(this.btnRemoveTrust);
            this.panel1.Controls.Add(this.txtTrust);
            this.panel1.Location = new System.Drawing.Point(35, 22);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(506, 480);
            this.panel1.TabIndex = 27;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(8, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 25);
            this.label1.TabIndex = 25;
            this.label1.Text = "Trusted";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(10, 15);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(89, 25);
            this.label3.TabIndex = 29;
            this.label3.Text = "Blocked";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.label3);
            this.panel2.Controls.Add(this.txtBlockList);
            this.panel2.Controls.Add(this.txtBlock);
            this.panel2.Controls.Add(this.chkBlockBlockedListContent);
            this.panel2.Controls.Add(this.btnAddBlock);
            this.panel2.Controls.Add(this.btnRemoveBlock);
            this.panel2.Controls.Add(this.chkBlockUntrustedContent);
            this.panel2.Controls.Add(this.chkBlockUnsignedContent);
            this.panel2.Location = new System.Drawing.Point(579, 22);
            this.panel2.Margin = new System.Windows.Forms.Padding(4);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(502, 480);
            this.panel2.TabIndex = 30;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // Trust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.ClientSize = new System.Drawing.Size(1111, 527);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(1137, 598);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(1137, 598);
            this.Name = "Trust";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trust Center";
            this.Load += new System.EventHandler(this.Trust_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
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
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel2;

    }
}