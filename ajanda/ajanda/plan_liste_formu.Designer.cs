﻿
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
            this.label_time = new System.Windows.Forms.Label();
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
            // Plan_liste_formu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImage = global::ajanda.Properties.Resources.plan_background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(434, 661);
            this.Controls.Add(this.label_time);
            this.ForeColor = System.Drawing.Color.Silver;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Plan_liste_formu";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Ekle";
            this.TopMost = true;
            this.Load += new System.EventHandler(this.plan_liste_formu_Load);
            this.ResumeLayout(false);

        }


        #endregion
        public System.Windows.Forms.Label label_time;
    }
}