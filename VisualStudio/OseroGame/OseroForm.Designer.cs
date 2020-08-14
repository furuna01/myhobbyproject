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
            this.SenteBtn = new System.Windows.Forms.Button();
            this.KouteBtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // SenteBtn
            // 
            this.SenteBtn.Location = new System.Drawing.Point(636, 12);
            this.SenteBtn.Name = "SenteBtn";
            this.SenteBtn.Size = new System.Drawing.Size(87, 32);
            this.SenteBtn.TabIndex = 0;
            this.SenteBtn.Text = "先手";
            this.SenteBtn.UseVisualStyleBackColor = true;
            this.SenteBtn.Click += new System.EventHandler(this.SenteBtn_Click);
            // 
            // KouteBtn
            // 
            this.KouteBtn.Location = new System.Drawing.Point(636, 59);
            this.KouteBtn.Name = "KouteBtn";
            this.KouteBtn.Size = new System.Drawing.Size(87, 32);
            this.KouteBtn.TabIndex = 1;
            this.KouteBtn.Text = "後手";
            this.KouteBtn.UseVisualStyleBackColor = true;
            this.KouteBtn.Click += new System.EventHandler(this.KouteBtn_Click);
            // 
            // OseroForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoScroll = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(984, 870);
            this.Controls.Add(this.KouteBtn);
            this.Controls.Add(this.SenteBtn);
            this.Name = "OseroForm";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.OseroForm_Load);
            this.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OseroForm_MouseClick);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button SenteBtn;
        private System.Windows.Forms.Button KouteBtn;
    }
}

