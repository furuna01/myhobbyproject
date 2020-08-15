namespace OseroGame
{
    partial class OseroForm
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
            this.EndGameBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // EndGameBtn
            // 
            this.EndGameBtn.Location = new System.Drawing.Point(721, 13);
            this.EndGameBtn.Name = "EndGameBtn";
            this.EndGameBtn.Size = new System.Drawing.Size(113, 34);
            this.EndGameBtn.TabIndex = 0;
            this.EndGameBtn.Text = "ゲーム終了";
            this.EndGameBtn.UseVisualStyleBackColor = true;
            this.EndGameBtn.Click += new System.EventHandler(this.EndGameBtn_Click);
            // 
            // OseroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 870);
            this.Controls.Add(this.EndGameBtn);
            this.Name = "OseroForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OseroForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OseroForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button EndGameBtn;
    }
}

