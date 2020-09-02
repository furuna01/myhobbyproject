namespace TetorisGame
{
    partial class TetorisForm
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // TetorisForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(732, 983);
            this.MaximumSize = new System.Drawing.Size(750, 1030);
            this.MinimumSize = new System.Drawing.Size(750, 1030);
            this.Name = "TetorisForm";
            this.Text = "Tetoris";
            this.Load += new System.EventHandler(this.TetorisForm_Load);
            this.Paint += new System.Windows.Forms.PaintEventHandler(this.TetorisForm_Paint);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TetorisForm_KeyDown);
            this.ResumeLayout(false);

        }

        #endregion
    }
}

