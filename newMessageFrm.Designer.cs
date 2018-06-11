namespace OpenMessage
{
    partial class newMessageFrm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(newMessageFrm));
            this.newMessageWindow = new MonoFlat.MonoFlat_ThemeContainer();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.sendBtn = new MonoFlat.MonoFlat_Button();
            this.monoFlat_ControlBox1 = new MonoFlat.MonoFlat_ControlBox();
            this.newMessageWindow.SuspendLayout();
            this.SuspendLayout();
            // 
            // newMessageWindow
            // 
            this.newMessageWindow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(32)))), ((int)(((byte)(41)))), ((int)(((byte)(50)))));
            this.newMessageWindow.Controls.Add(this.richTextBox1);
            this.newMessageWindow.Controls.Add(this.textBox1);
            this.newMessageWindow.Controls.Add(this.sendBtn);
            this.newMessageWindow.Controls.Add(this.monoFlat_ControlBox1);
            this.newMessageWindow.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newMessageWindow.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.newMessageWindow.Location = new System.Drawing.Point(0, 0);
            this.newMessageWindow.Name = "newMessageWindow";
            this.newMessageWindow.Padding = new System.Windows.Forms.Padding(10, 70, 10, 9);
            this.newMessageWindow.RoundCorners = true;
            this.newMessageWindow.Sizable = true;
            this.newMessageWindow.Size = new System.Drawing.Size(797, 370);
            this.newMessageWindow.SmartBounds = true;
            this.newMessageWindow.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.newMessageWindow.TabIndex = 0;
            this.newMessageWindow.Text = "Chat with: -jid-";
            this.newMessageWindow.Click += new System.EventHandler(this.newMessageWindow_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(66)))), ((int)(((byte)(76)))), ((int)(((byte)(85)))));
            this.richTextBox1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.richTextBox1.ForeColor = System.Drawing.SystemColors.Window;
            this.richTextBox1.Location = new System.Drawing.Point(14, 73);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.ReadOnly = true;
            this.richTextBox1.Size = new System.Drawing.Size(771, 237);
            this.richTextBox1.TabIndex = 4;
            this.richTextBox1.Text = "";
            // 
            // textBox1
            // 
            this.textBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBox1.Location = new System.Drawing.Point(14, 322);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(688, 23);
            this.textBox1.TabIndex = 3;
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // sendBtn
            // 
            this.sendBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.sendBtn.BackColor = System.Drawing.Color.Transparent;
            this.sendBtn.Font = new System.Drawing.Font("Segoe UI", 12F);
            this.sendBtn.Image = null;
            this.sendBtn.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.sendBtn.Location = new System.Drawing.Point(708, 316);
            this.sendBtn.Name = "sendBtn";
            this.sendBtn.Size = new System.Drawing.Size(77, 33);
            this.sendBtn.TabIndex = 2;
            this.sendBtn.Text = "Send";
            this.sendBtn.TextAlignment = System.Drawing.StringAlignment.Center;
            this.sendBtn.Click += new System.EventHandler(this.sendBtn_Click);
            // 
            // monoFlat_ControlBox1
            // 
            this.monoFlat_ControlBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.monoFlat_ControlBox1.EnableHoverHighlight = false;
            this.monoFlat_ControlBox1.EnableMaximizeButton = true;
            this.monoFlat_ControlBox1.EnableMinimizeButton = true;
            this.monoFlat_ControlBox1.Location = new System.Drawing.Point(685, 15);
            this.monoFlat_ControlBox1.Name = "monoFlat_ControlBox1";
            this.monoFlat_ControlBox1.Size = new System.Drawing.Size(100, 25);
            this.monoFlat_ControlBox1.TabIndex = 0;
            this.monoFlat_ControlBox1.Text = "monoFlat_ControlBox1";
            // 
            // newMessageFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(797, 370);
            this.Controls.Add(this.newMessageWindow);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "newMessageFrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chat with: -jid-";
            this.TransparencyKey = System.Drawing.Color.Fuchsia;
            this.newMessageWindow.ResumeLayout(false);
            this.newMessageWindow.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private MonoFlat.MonoFlat_ThemeContainer newMessageWindow;
        private MonoFlat.MonoFlat_Button sendBtn;
        private MonoFlat.MonoFlat_ControlBox monoFlat_ControlBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}