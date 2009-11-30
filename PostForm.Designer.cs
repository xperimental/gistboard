namespace GistBoard
{
    partial class PostForm
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
            this.m_labelFile = new System.Windows.Forms.Label();
            this.m_labelContent = new System.Windows.Forms.Label();
            this.m_textFile = new System.Windows.Forms.TextBox();
            this.m_textContent = new System.Windows.Forms.TextBox();
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonPost = new System.Windows.Forms.Button();
            this.m_checkPrivate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // m_labelFile
            // 
            this.m_labelFile.AutoSize = true;
            this.m_labelFile.Location = new System.Drawing.Point(12, 15);
            this.m_labelFile.Name = "m_labelFile";
            this.m_labelFile.Size = new System.Drawing.Size(52, 13);
            this.m_labelFile.TabIndex = 0;
            this.m_labelFile.Text = "Filename:";
            // 
            // m_labelContent
            // 
            this.m_labelContent.AutoSize = true;
            this.m_labelContent.Location = new System.Drawing.Point(17, 41);
            this.m_labelContent.Name = "m_labelContent";
            this.m_labelContent.Size = new System.Drawing.Size(47, 13);
            this.m_labelContent.TabIndex = 1;
            this.m_labelContent.Text = "Content:";
            // 
            // m_textFile
            // 
            this.m_textFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textFile.Location = new System.Drawing.Point(70, 12);
            this.m_textFile.Name = "m_textFile";
            this.m_textFile.Size = new System.Drawing.Size(359, 20);
            this.m_textFile.TabIndex = 2;
            // 
            // m_textContent
            // 
            this.m_textContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textContent.Location = new System.Drawing.Point(70, 38);
            this.m_textContent.Multiline = true;
            this.m_textContent.Name = "m_textContent";
            this.m_textContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.m_textContent.Size = new System.Drawing.Size(359, 217);
            this.m_textContent.TabIndex = 3;
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.m_buttonCancel.Location = new System.Drawing.Point(273, 261);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.m_buttonCancel.TabIndex = 4;
            this.m_buttonCancel.Text = "Cancel";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // m_buttonPost
            // 
            this.m_buttonPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonPost.Location = new System.Drawing.Point(354, 261);
            this.m_buttonPost.Name = "m_buttonPost";
            this.m_buttonPost.Size = new System.Drawing.Size(75, 23);
            this.m_buttonPost.TabIndex = 5;
            this.m_buttonPost.Text = "Post";
            this.m_buttonPost.UseVisualStyleBackColor = true;
            this.m_buttonPost.Click += new System.EventHandler(this.m_buttonPost_Click);
            // 
            // m_checkPrivate
            // 
            this.m_checkPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.m_checkPrivate.AutoSize = true;
            this.m_checkPrivate.Location = new System.Drawing.Point(70, 265);
            this.m_checkPrivate.Name = "m_checkPrivate";
            this.m_checkPrivate.Size = new System.Drawing.Size(88, 17);
            this.m_checkPrivate.TabIndex = 6;
            this.m_checkPrivate.Text = "Make private";
            this.m_checkPrivate.UseVisualStyleBackColor = true;
            // 
            // PostForm
            // 
            this.AcceptButton = this.m_buttonPost;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.ClientSize = new System.Drawing.Size(441, 296);
            this.Controls.Add(this.m_checkPrivate);
            this.Controls.Add(this.m_buttonPost);
            this.Controls.Add(this.m_buttonCancel);
            this.Controls.Add(this.m_textContent);
            this.Controls.Add(this.m_textFile);
            this.Controls.Add(this.m_labelContent);
            this.Controls.Add(this.m_labelFile);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "PostForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Post clipboard...";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label m_labelFile;
        private System.Windows.Forms.Label m_labelContent;
        private System.Windows.Forms.TextBox m_textFile;
        private System.Windows.Forms.TextBox m_textContent;
        private System.Windows.Forms.Button m_buttonCancel;
        private System.Windows.Forms.Button m_buttonPost;
        private System.Windows.Forms.CheckBox m_checkPrivate;
    }
}