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
            this.labelFile = new System.Windows.Forms.Label();
            this.labelContent = new System.Windows.Forms.Label();
            this.textFile = new System.Windows.Forms.TextBox();
            this.textContent = new System.Windows.Forms.TextBox();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.buttonPost = new System.Windows.Forms.Button();
            this.checkPrivate = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // labelFile
            // 
            this.labelFile.AutoSize = true;
            this.labelFile.Location = new System.Drawing.Point(12, 15);
            this.labelFile.Name = "labelFile";
            this.labelFile.Size = new System.Drawing.Size(52, 13);
            this.labelFile.TabIndex = 0;
            this.labelFile.Text = "Filename:";
            // 
            // labelContent
            // 
            this.labelContent.AutoSize = true;
            this.labelContent.Location = new System.Drawing.Point(17, 41);
            this.labelContent.Name = "labelContent";
            this.labelContent.Size = new System.Drawing.Size(47, 13);
            this.labelContent.TabIndex = 1;
            this.labelContent.Text = "Content:";
            // 
            // textFile
            // 
            this.textFile.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textFile.Location = new System.Drawing.Point(70, 12);
            this.textFile.Name = "textFile";
            this.textFile.Size = new System.Drawing.Size(359, 20);
            this.textFile.TabIndex = 2;
            // 
            // textContent
            // 
            this.textContent.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textContent.Location = new System.Drawing.Point(70, 38);
            this.textContent.Multiline = true;
            this.textContent.Name = "textContent";
            this.textContent.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textContent.Size = new System.Drawing.Size(359, 217);
            this.textContent.TabIndex = 3;
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(273, 261);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 4;
            this.buttonCancel.Text = "Cancel";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // buttonPost
            // 
            this.buttonPost.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonPost.Location = new System.Drawing.Point(354, 261);
            this.buttonPost.Name = "buttonPost";
            this.buttonPost.Size = new System.Drawing.Size(75, 23);
            this.buttonPost.TabIndex = 5;
            this.buttonPost.Text = "Post";
            this.buttonPost.UseVisualStyleBackColor = true;
            this.buttonPost.Click += new System.EventHandler(this.ButtonPost_Click);
            // 
            // checkPrivate
            // 
            this.checkPrivate.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.checkPrivate.AutoSize = true;
            this.checkPrivate.Location = new System.Drawing.Point(70, 265);
            this.checkPrivate.Name = "checkPrivate";
            this.checkPrivate.Size = new System.Drawing.Size(88, 17);
            this.checkPrivate.TabIndex = 6;
            this.checkPrivate.Text = "Make private";
            this.checkPrivate.UseVisualStyleBackColor = true;
            // 
            // PostForm
            // 
            this.AcceptButton = this.buttonPost;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(441, 296);
            this.Controls.Add(this.checkPrivate);
            this.Controls.Add(this.buttonPost);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.textContent);
            this.Controls.Add(this.textFile);
            this.Controls.Add(this.labelContent);
            this.Controls.Add(this.labelFile);
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

        private System.Windows.Forms.Label labelFile;
        private System.Windows.Forms.Label labelContent;
        private System.Windows.Forms.TextBox textFile;
        private System.Windows.Forms.TextBox textContent;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Button buttonPost;
        private System.Windows.Forms.CheckBox checkPrivate;
    }
}