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
            this.flpDSDoUong = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnThanhtoan = new System.Windows.Forms.Button();
            this.lbTongTien = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.lbDouong = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.txtKhachhang = new System.Windows.Forms.TextBox();
            this.date = new System.Windows.Forms.DateTimePicker();
            this.lbMaKH = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.grbban.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // grbban
            // 
            this.grbban.Controls.Add(this.pbdouong);
            this.grbban.Location = new System.Drawing.Point(1, 22);
            this.grbban.Name = "grbban";
            this.grbban.Size = new System.Drawing.Size(438, 481);
            this.grbban.TabIndex = 0;
            this.grbban.TabStop = false;
            this.grbban.Enter += new System.EventHandler(this.grbban_Enter);
            // 
            // pbdouong
            // 
            this.pbdouong.Location = new System.Drawing.Point(6, 19);
            this.pbdouong.Name = "pbdouong";
            this.pbdouong.Size = new System.Drawing.Size(427, 455);
            this.pbdouong.TabIndex = 0;
            // 
            // flpDSDoUong
            // 
            this.flpDSDoUong.Location = new System.Drawing.Point(674, 41);
            this.flpDSDoUong.Name = "flpDSDoUong";
            this.flpDSDoUong.Padding = new System.Windows.Forms.Padding(7);
            this.flpDSDoUong.Size = new System.Drawing.Size(343, 322);
            this.flpDSDoUong.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnThanhtoan);
            this.panel1.Controls.Add(this.lbTongTien);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(568, 385);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(449, 162);
            this.panel1.TabIndex = 1;
            // 
            // btnThanhtoan
            // 
            this.btnThanhtoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThanhtoan.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnThanhtoan.Location = new System.Drawing.Point(147, 88);
            this.btnThanhtoan.Name = "btnThanhtoan";
            this.btnThanhtoan.Size = new System.Drawing.Size(135, 45);
            this.btnThanhtoan.TabIndex = 2;
            this.btnThanhtoan.Text = "Thanh Toán";
            this.btnThanhtoan.UseVisualStyleBackColor = true;
            this.btnThanhtoan.Click += new System.EventHandler(this.btnThanhtoan_Click);
            // 
            // lbTongTien
            // 
            this.lbTongTien.AutoSize = true;
            this.lbTongTien.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbTongTien.Location = new System.Drawing.Point(291, 34);
            this.lbTongTien.Name = "lbTongTien";
            this.lbTongTien.Size = new System.Drawing.Size(0, 20);
            this.lbTongTien.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(24, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tổng Tiền";
            // 
            // lbDouong
            // 
            this.lbDouong.AutoSize = true;
            this.lbDouong.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbDouong.Location = new System.Drawing.Point(23, 9);
            this.lbDouong.Name = "lbDouong";
            this.lbDouong.Size = new System.Drawing.Size(57, 16);
            this.lbDouong.TabIndex = 2;
            this.lbDouong.Text = "Đồ uống";
            this.lbDouong.Click += new System.EventHandler(this.lbDouong_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(445, 41);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(223, 303);
            this.dataGridView1.TabIndex = 3;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // txtKhachhang
            // 
            this.txtKhachhang.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtKhachhang.Location = new System.Drawing.Point(828, 12);
            this.txtKhachhang.Name = "txtKhachhang";
            this.txtKhachhang.Size = new System.Drawing.Size(189, 22);
            this.txtKhachhang.TabIndex = 4;
            this.txtKhachhang.Click += new System.EventHandler(this.txtKhachhang_Click);
            // 
            // date
            // 
            this.date.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.date.Location = new System.Drawing.Point(456, 350);
            this.date.Name = "date";
            this.date.Size = new System.Drawing.Size(100, 20);
            this.date.TabIndex = 5;
            this.date.Visible = false;
            // 
            // lbMaKH
            // 
            this.lbMaKH.AutoSize = true;
            this.lbMaKH.Location = new System.Drawing.Point(574, 356);
            this.lbMaKH.Name = "lbMaKH";
            this.lbMaKH.Size = new System.Drawing.Size(35, 13);
            this.lbMaKH.TabIndex = 6;
            this.lbMaKH.Text = "label2";
            this.lbMaKH.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(742, 15);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 16);
            this.label2.TabIndex = 7;
            this.label2.Text = "Khách hàng:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(453, 9);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(119, 16);
            this.label3.TabIndex = 8;
            this.label3.Text = "Danh sách topping";
            // 
            // DoUong
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1029, 556);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lbMaKH);
            this.Controls.Add(this.date);
            this.Controls.Add(this.txtKhachhang);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.lbDouong);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.flpDSDoUong);
            this.Controls.Add(this.grbban);
            this.Name = "DoUong";
            this.Text = "DoUong";
            this.Load += new System.EventHandler(this.DoUong_Load);
            this.grbban.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox grbban;
        private System.Windows.Forms.FlowLayoutPanel pbdouong;
        private System.Windows.Forms.FlowLayoutPanel flpDSDoUong;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label lbTongTien;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnThanhtoan;
        private System.Windows.Forms.Label lbDouong;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtKhachhang;
        private System.Windows.Forms.DateTimePicker date;
        private System.Windows.Forms.Label lbMaKH;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
    }
}