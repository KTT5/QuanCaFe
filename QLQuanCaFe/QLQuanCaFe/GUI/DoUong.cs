using DAL_BLL;
using Dynamic_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCaFe.GUI
{
    public partial class DoUong : Form
    {
        DoUongDAL_BLL du = new DoUongDAL_BLL();
        ToppingDAL_BLL to = new ToppingDAL_BLL();
        decimal tongTien = 0;
        decimal tiendu = 0;
        decimal tientopping = 0;
        decimal thanhtoan = 0;
        private SanPham sanPham;
        Button bt;
        NumericUpDown num;

        public DoUong()
        {
            InitializeComponent();
            flpDSDoUong.FlowDirection = FlowDirection.LeftToRight;
            flpDSDoUong.AutoScroll = true;
        }

        private void grbban_Enter(object sender, EventArgs e)
        {

        }

        private void DoUong_Load(object sender, EventArgs e)
        {
            pbdouong.FlowDirection = FlowDirection.LeftToRight;
            pbdouong.AutoScroll = true;
            pbdouong.Dock = DockStyle.Fill;
            List<SanPham> sp = du.GetSanPhams();
            pbdouong.Controls.Clear();
            sp.ForEach(x =>
            {
                Button btn = new Button();
                btn.Text = x.TenSanPham + "\n" + x.GiaTien;
                btn.Tag = x.MaSanPham;
                if (x.HinhAnh == null)
                {
                    btn.Image = null;
                }
                else
                {
                    byte[] byteArray = x.HinhAnh.ToArray();
                    using (MemoryStream ms = new MemoryStream(byteArray))
                    {
                        Image image = Image.FromStream(ms);
                        btn.Image = image;
                    }
                }
                btn.AutoEllipsis = false;
                btn.ImageAlign = ContentAlignment.TopCenter;
                btn.TextAlign = ContentAlignment.BottomCenter;
                btn.Font = new Font(btn.Font.FontFamily, 10);
                btn.Width = 120;
                btn.Height = 170;




                btn.Click += Btn_Click;
                pbdouong.Controls.Add(btn);
            });
        }

        private void Btn_Click(object sender, EventArgs e)
        {

            // flpDSDoUong.Dock = DockStyle.Fill;
            Button clickedButton = (Button)sender;
            int maSanPham = (int)clickedButton.Tag;
            sanPham = du.Get1SanPhamsTheoMa(maSanPham);

            Panel existingCard = flpDSDoUong.Controls.OfType<Panel>().FirstOrDefault(card => (int)card.Tag == maSanPham);

            if (existingCard != null)
            {
                // Đã tồn tại, tăng giá trị của NumericUpDown lên 1
                NumericUpDown num1 = existingCard.Controls.OfType<NumericUpDown>().FirstOrDefault();
                Label lb = existingCard.Controls.OfType<Label>().FirstOrDefault();
                if (num1 != null)
                {
                    num1.Value++;
                    lb.Text = sanPham.TenSanPham + "       " + sanPham.GiaTien * num1.Value;

                }
            }
            else
            {
                Panel card = new Panel();
                card.BorderStyle = BorderStyle.Fixed3D;
                card.Padding = new Padding(10);
                card.Width = 400;
                card.Tag = maSanPham;

                Label lb = new Label();
                lb.Text = sanPham.TenSanPham + "       " + sanPham.GiaTien;
                lb.MaximumSize = new Size(flpDSDoUong.ClientSize.Width, 0);
                lb.AutoSize = true;
                lb.Font = new Font(Font.FontFamily, 10);


                num = new NumericUpDown();
                
                //num.Enabled = false;
                num.Width = 30;
                num.Location = new Point(300, 0);
                num.Font = new Font(Font.FontFamily, 10);
                num.Value = 1;
                bool canDecrease = true;
                num.Minimum = 1;
                num.ValueChanged += (s, ev) =>
                {
                    int numValue = (int)num.Value;
                    if (numValue == 1 && !canDecrease)
                    {
                        num.Value = 1;
                    }
                    else
                    {
                        lb.Text = sanPham.TenSanPham + "       " + sanPham.GiaTien * num.Value;
                    }
                };

                 bt = new Button();
                bt.Text = "Hoàn thành";
                bt.Font = new Font(Font.FontFamily, 10);
                bt.Location = new Point(300, 60);
                bt.Width = 100;
                bt.Click += Bt_Click;

                card.Controls.Add(lb);

                card.Controls.Add(num);
                card.Controls.Add(bt);

                flpDSDoUong.Controls.Add(card);

                Label lineBreakLabel = new Label();
                lineBreakLabel.Text = Environment.NewLine;
                flpDSDoUong.Controls.Add(lineBreakLabel);
                pbdouong.Enabled = false;
            }

        }



        private void Bt_Click(object sender, EventArgs e)
        {
            tiendu = (decimal)sanPham.GiaTien * num.Value;

            pbdouong.Enabled = true;
            thanhtoan += tiendu;
            lbTongTien.Text = thanhtoan.ToString();
            bt.Enabled = false;
        }

        private void lbDouong_Click(object sender, EventArgs e)
        {
            pbdouong.Enabled = true;
        }

    }
}
