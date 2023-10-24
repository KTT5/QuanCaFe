namespace QLQuanCaFe.GUI
{
    partial class DoUong
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
            this.grbban = new System.Windows.Forms.GroupBox();
            this.pbdouong = new System.Windows.Forms.FlowLayoutPanel();
            this.grbban.SuspendLayout();
            this.SuspendLayout();
            // 
            // grbban
            // 
            this.grbban.Controls.Add(this.pbdouong);
            this.grbban.Location = new System.Drawing.Point(12, 12);
            this.grbban.Name = "grbban";
            this.grbban.Size = new System.Drawing.Size(788, 426);
            this.grbban.TabIndex = 0;
            this.grbban.TabStop = false;
            this.grbban.Text = "Ban";
            this.grbban.Enter += new System.EventHandler(this.grbban_Enter);
            // 
            // pbdouong
            // 
            this.pbdouong.Location = new System.Drawing.Point(40, 10);
            this.pbdouong.Name = "pbdouong";
            this.pbdouong.Size = new System.Drawing.Size(714, 416);
            this.pbdouong.TabIndex = 0;
            // 
            // DoUong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.grbban);
            this.Name = "DoUong";
            this.Text = "DoUong";
            this.Load += new System.EventHandler(this.DoUong_Load);
            this.grbban.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox grbban;
        private System.Windows.Forms.FlowLayoutPanel pbdouong;
    }
}