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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.chkBlockUnsignedContent = new System.Windows.Forms.CheckBox();
            this.chkBlockUntrustedContent = new System.Windows.Forms.CheckBox();
            this.chkBlockBlockedListContent = new System.Windows.Forms.CheckBox();
            this.btnRemoveTrust = new System.Windows.Forms.Button();
            this.btnAddTrust = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.chkTrustTrustedlistContent = new System.Windows.Forms.CheckBox();
            this.txtTrustList = new System.Windows.Forms.TextBox();
            this.txtTrust = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtBlockList
            // 
            this.txtBlockList.BackColor = System.Drawing.Color.White;
            this.txtBlockList.Location = new System.Drawing.Point(24, 74);
            this.txtBlockList.Multiline = true;
            this.txtBlockList.Name = "txtBlockList";
            this.txtBlockList.ReadOnly = true;
            this.txtBlockList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtBlockList.Size = new System.Drawing.Size(360, 225);
            this.txtBlockList.TabIndex = 8;
            this.txtBlockList.WordWrap = false;
            this.txtBlockList.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // txtBlock
            // 
            this.txtBlock.Location = new System.Drawing.Point(24, 44);
            this.txtBlock.Name = "txtBlock";
            this.txtBlock.Size = new System.Drawing.Size(307, 22);
            this.txtBlock.TabIndex = 16;
            // 
            // btnRemoveBlock
            // 
            this.btnRemoveBlock.Location = new System.Drawing.Point(791, 52);
            this.btnRemoveBlock.Name = "btnRemoveBlock";
            this.btnRemoveBlock.Size = new System.Drawing.Size(21, 23);
            this.btnRemoveBlock.TabIndex = 18;
            this.btnRemoveBlock.Text = "-";
            this.btnRemoveBlock.UseVisualStyleBackColor = true;
            this.btnRemoveBlock.Click += new System.EventHandler(this.btnRemoveBlock_Click);
            // 
            // btnAddBlock
            // 
            this.btnAddBlock.Location = new System.Drawing.Point(765, 51);
            this.btnAddBlock.Name = "btnAddBlock";
            this.btnAddBlock.Size = new System.Drawing.Size(21, 23);
            this.btnAddBlock.TabIndex = 17;
            this.btnAddBlock.Text = "+";
            this.btnAddBlock.UseVisualStyleBackColor = true;
            this.btnAddBlock.Click += new System.EventHandler(this.btnAddBlock_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.chkBlockUnsignedContent);
            this.groupBox1.Controls.Add(this.chkBlockUntrustedContent);
            this.groupBox1.Controls.Add(this.chkBlockBlockedListContent);
            this.groupBox1.Controls.Add(this.txtBlockList);
            this.groupBox1.Controls.Add(this.txtBlock);
            this.groupBox1.Location = new System.Drawing.Point(427, 8);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(406, 402);
            this.groupBox1.TabIndex = 22;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Blocked Address List";
            // 
            // chkBlockUnsignedContent
            // 
            this.chkBlockUnsignedContent.AutoSize = true;
            this.chkBlockUnsignedContent.Location = new System.Drawing.Point(24, 359);
            this.chkBlockUnsignedContent.Name = "chkBlockUnsignedContent";
            this.chkBlockUnsignedContent.Size = new System.Drawing.Size(199, 21);
            this.chkBlockUnsignedContent.TabIndex = 21;
            this.chkBlockUnsignedContent.Text = "Block all unsigned content.";
            this.chkBlockUnsignedContent.UseVisualStyleBackColor = true;
            this.chkBlockUnsignedContent.Click += new System.EventHandler(this.chkBlockUnsignedContent_Click);
            // 
            // chkBlockUntrustedContent
            // 
            this.chkBlockUntrustedContent.AutoSize = true;
            this.chkBlockUntrustedContent.Location = new System.Drawing.Point(24, 332);
            this.chkBlockUntrustedContent.Name = "chkBlockUntrustedContent";
            this.chkBlockUntrustedContent.Size = new System.Drawing.Size(201, 21);
            this.chkBlockUntrustedContent.TabIndex = 20;
            this.chkBlockUntrustedContent.Text = "Block all untrusted content.";
            this.chkBlockUntrustedContent.UseVisualStyleBackColor = true;
            this.chkBlockUntrustedContent.Click += new System.EventHandler(this.chkBlockUntrustedContent_Click);
            // 
            // chkBlockBlockedListContent
            // 
            this.chkBlockBlockedListContent.AutoSize = true;
            this.chkBlockBlockedListContent.Location = new System.Drawing.Point(24, 305);
            this.chkBlockBlockedListContent.Name = "chkBlockBlockedListContent";
            this.chkBlockBlockedListContent.Size = new System.Drawing.Size(305, 21);
            this.chkBlockBlockedListContent.TabIndex = 17;
            this.chkBlockBlockedListContent.Text = "Block all content from Blocked Address List.";
            this.chkBlockBlockedListContent.UseVisualStyleBackColor = true;
            this.chkBlockBlockedListContent.Click += new System.EventHandler(this.chkBlockBlockedListContent_Click);
            // 
            // btnRemoveTrust
            // 
            this.btnRemoveTrust.Location = new System.Drawing.Point(375, 52);
            this.btnRemoveTrust.Name = "btnRemoveTrust";
            this.btnRemoveTrust.Size = new System.Drawing.Size(21, 23);
            this.btnRemoveTrust.TabIndex = 24;
            this.btnRemoveTrust.Text = "-";
            this.btnRemoveTrust.UseVisualStyleBackColor = true;
            this.btnRemoveTrust.Click += new System.EventHandler(this.btnRemoveTrust_Click);
            // 
            // btnAddTrust
            // 
            this.btnAddTrust.Location = new System.Drawing.Point(349, 51);
            this.btnAddTrust.Name = "btnAddTrust";
            this.btnAddTrust.Size = new System.Drawing.Size(21, 23);
            this.btnAddTrust.TabIndex = 23;
            this.btnAddTrust.Text = "+";
            this.btnAddTrust.UseVisualStyleBackColor = true;
            this.btnAddTrust.Click += new System.EventHandler(this.btnAddTrust_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.chkTrustTrustedlistContent);
            this.groupBox2.Controls.Add(this.txtTrustList);
            this.groupBox2.Controls.Add(this.txtTrust);
            this.groupBox2.Location = new System.Drawing.Point(11, 8);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(406, 402);
            this.groupBox2.TabIndex = 25;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Trusted Address List";
            // 
            // chkTrustTrustedlistContent
            // 
            this.chkTrustTrustedlistContent.AutoSize = true;
            this.chkTrustTrustedlistContent.Location = new System.Drawing.Point(24, 305);
            this.chkTrustTrustedlistContent.Name = "chkTrustTrustedlistContent";
            this.chkTrustTrustedlistContent.Size = new System.Drawing.Size(313, 21);
            this.chkTrustTrustedlistContent.TabIndex = 19;
            this.chkTrustTrustedlistContent.Text = "Accept all content from Trusted Address List.";
            this.chkTrustTrustedlistContent.UseVisualStyleBackColor = true;
            this.chkTrustTrustedlistContent.Click += new System.EventHandler(this.chkTrustTrustedlistContent_Click);
            // 
            // txtTrustList
            // 
            this.txtTrustList.BackColor = System.Drawing.Color.White;
            this.txtTrustList.Location = new System.Drawing.Point(24, 74);
            this.txtTrustList.Multiline = true;
            this.txtTrustList.Name = "txtTrustList";
            this.txtTrustList.ReadOnly = true;
            this.txtTrustList.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.txtTrustList.Size = new System.Drawing.Size(360, 225);
            this.txtTrustList.TabIndex = 8;
            this.txtTrustList.WordWrap = false;
            // 
            // txtTrust
            // 
            this.txtTrust.Location = new System.Drawing.Point(24, 44);
            this.txtTrust.Name = "txtTrust";
            this.txtTrust.Size = new System.Drawing.Size(307, 22);
            this.txtTrust.TabIndex = 16;
            // 
            // Trust
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(844, 422);
            this.Controls.Add(this.btnRemoveTrust);
            this.Controls.Add(this.btnAddTrust);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.btnRemoveBlock);
            this.Controls.Add(this.btnAddBlock);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(862, 467);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(862, 467);
            this.Name = "Trust";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Trust Center";
            this.Load += new System.EventHandler(this.Trust_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TextBox txtBlockList;
        private System.Windows.Forms.TextBox txtBlock;
        private System.Windows.Forms.Button btnRemoveBlock;
        private System.Windows.Forms.Button btnAddBlock;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnRemoveTrust;
        private System.Windows.Forms.Button btnAddTrust;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox txtTrustList;
        private System.Windows.Forms.TextBox txtTrust;
        private System.Windows.Forms.CheckBox chkBlockBlockedListContent;
        private System.Windows.Forms.CheckBox chkTrustTrustedlistContent;
        private System.Windows.Forms.CheckBox chkBlockUnsignedContent;
        private System.Windows.Forms.CheckBox chkBlockUntrustedContent;

    }
}