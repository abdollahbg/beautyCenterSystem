namespace beautyCenterSystem
{
    partial class SplashForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            progressBar1 = new ProgressBar();
            lblTitle = new Label();
            lblLoading = new Label();
            SuspendLayout();
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(50, 220);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(400, 10);
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.TabIndex = 0;
            // 
            // lblTitle
            // 
            lblTitle.AutoSize = true;
            lblTitle.Font = new Font("Segoe UI", 16F, FontStyle.Bold);
            lblTitle.ForeColor = Color.MediumSlateBlue;
            lblTitle.Location = new Point(90, 114);
            lblTitle.Name = "lblTitle";
            lblTitle.Size = new Size(324, 30);
            lblTitle.TabIndex = 1;
            lblTitle.Text = "‰Ÿ«„ «·’‰Ê«‰ ··≈œ«—… „—«ﬂ“ «· Ã„Ì·";
            // 
            // lblLoading
            // 
            lblLoading.AutoSize = true;
            lblLoading.Font = new Font("Segoe UI", 10F);
            lblLoading.ForeColor = Color.Gray;
            lblLoading.Location = new Point(200, 190);
            lblLoading.Name = "lblLoading";
            lblLoading.Size = new Size(67, 19);
            lblLoading.TabIndex = 2;
            lblLoading.Text = "Loading...";
            // 
            // SplashForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            ClientSize = new Size(500, 300);
            Controls.Add(lblLoading);
            Controls.Add(lblTitle);
            Controls.Add(progressBar1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SplashForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SplashForm";
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblLoading;
    }
}
