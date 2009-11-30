namespace GistBoard
{
    partial class ConfigForm
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
            this.m_buttonCancel = new System.Windows.Forms.Button();
            this.m_buttonSave = new System.Windows.Forms.Button();
            this.m_labelUser = new System.Windows.Forms.Label();
            this.m_labelToken = new System.Windows.Forms.Label();
            this.m_textUser = new System.Windows.Forms.TextBox();
            this.m_textToken = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // m_buttonCancel
            // 
            this.m_buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonCancel.Location = new System.Drawing.Point(150, 69);
            this.m_buttonCancel.Name = "m_buttonCancel";
            this.m_buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.m_buttonCancel.TabIndex = 0;
            this.m_buttonCancel.Text = "Cancel";
            this.m_buttonCancel.UseVisualStyleBackColor = true;
            // 
            // m_buttonSave
            // 
            this.m_buttonSave.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.m_buttonSave.Location = new System.Drawing.Point(231, 69);
            this.m_buttonSave.Name = "m_buttonSave";
            this.m_buttonSave.Size = new System.Drawing.Size(75, 23);
            this.m_buttonSave.TabIndex = 1;
            this.m_buttonSave.Text = "Save";
            this.m_buttonSave.UseVisualStyleBackColor = true;
            this.m_buttonSave.Click += new System.EventHandler(this.m_buttonSave_Click);
            // 
            // m_labelUser
            // 
            this.m_labelUser.AutoSize = true;
            this.m_labelUser.Location = new System.Drawing.Point(21, 15);
            this.m_labelUser.Name = "m_labelUser";
            this.m_labelUser.Size = new System.Drawing.Size(32, 13);
            this.m_labelUser.TabIndex = 2;
            this.m_labelUser.Text = "User:";
            // 
            // m_labelToken
            // 
            this.m_labelToken.AutoSize = true;
            this.m_labelToken.Location = new System.Drawing.Point(12, 41);
            this.m_labelToken.Name = "m_labelToken";
            this.m_labelToken.Size = new System.Drawing.Size(41, 13);
            this.m_labelToken.TabIndex = 3;
            this.m_labelToken.Text = "Token:";
            // 
            // m_textUser
            // 
            this.m_textUser.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textUser.Location = new System.Drawing.Point(59, 12);
            this.m_textUser.Name = "m_textUser";
            this.m_textUser.Size = new System.Drawing.Size(247, 20);
            this.m_textUser.TabIndex = 4;
            // 
            // m_textToken
            // 
            this.m_textToken.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.m_textToken.Location = new System.Drawing.Point(59, 38);
            this.m_textToken.Name = "m_textToken";
            this.m_textToken.Size = new System.Drawing.Size(247, 20);
            this.m_textToken.TabIndex = 5;
            // 
            // ConfigForm
            // 
            this.AcceptButton = this.m_buttonSave;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.m_buttonCancel;
            this.ClientSize = new System.Drawing.Size(318, 104);
            this.Controls.Add(this.m_textToken);
            this.Controls.Add(this.m_textUser);
            this.Controls.Add(this.m_labelToken);
            this.Controls.Add(this.m_labelUser);
            this.Controls.Add(this.m_buttonSave);
            this.Controls.Add(this.m_buttonCancel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.SizableToolWindow;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ConfigForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "GistBoard Configuration";
            this.TopMost = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button m_buttonCancel;
        private System.Windows.Forms.Button m_buttonSave;
        private System.Windows.Forms.Label m_labelUser;
        private System.Windows.Forms.Label m_labelToken;
        private System.Windows.Forms.TextBox m_textUser;
        private System.Windows.Forms.TextBox m_textToken;
    }
}