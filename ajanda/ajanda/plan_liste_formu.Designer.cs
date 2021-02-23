
namespace ajanda
{
    partial class Plan_liste_formu
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Plan_liste_formu));
            this.label_time = new System.Windows.Forms.Label();
            this.label_deger = new System.Windows.Forms.Label();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label_time
            // 
            this.label_time.BackColor = System.Drawing.Color.Transparent;
            this.label_time.Font = new System.Drawing.Font("Microsoft YaHei UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_time.ForeColor = System.Drawing.Color.PaleTurquoise;
            this.label_time.Location = new System.Drawing.Point(5, 2);
            this.label_time.Name = "label_time";
            this.label_time.Size = new System.Drawing.Size(423, 54);
            this.label_time.TabIndex = 0;
            this.label_time.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label_deger
            // 
            this.label_deger.AutoSize = true;
            this.label_deger.Font = new System.Drawing.Font("Microsoft Sans Serif", 30F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label_deger.Location = new System.Drawing.Point(3, 583);
            this.label_deger.Name = "label_deger";
            this.label_deger.Size = new System.Drawing.Size(141, 46);
            this.label_deger.TabIndex = 1;
            this.label_deger.Text = "100,00";
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(145, 593);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(272, 31);
            this.progressBar1.Step = 1;
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Value = 70;
            // 
            // Plan_liste_formu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ajanda.Properties.Resources.plan_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 661);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.label_deger);
            this.Controls.Add(this.label_time);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Plan_liste_formu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Plans";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.plan_liste_formu_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }


        #endregion
        public System.Windows.Forms.Label label_time;
        private System.Windows.Forms.Label label_deger;
        public System.Windows.Forms.ProgressBar progressBar1;
    }
}