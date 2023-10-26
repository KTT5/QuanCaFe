using DAL_BLL;
using Dynamic_Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                btn.Text = x.TenSanPham+"\n"+x.GiaTien;
                btn.Tag = x.MaSanPham;
                if (x.HinhAnh == null)
                {
                    btn.Image= null;
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
            SanPham sanPham = du.Get1SanPhamsTheoMa(maSanPham);
            //MessageBox.Show("Mã sản phẩm: " + sanPham.MaSanPham + "\nTên sản phẩm: " + sanPham.TenSanPham);
            Label lb =new Label();
            //Label lbgia = new Label();
            lb.Text = sanPham.TenSanPham + sanPham.GiaTien;
            lb.MaximumSize = new Size(flpDSDoUong.ClientSize.Width, 0);
            lb.AutoSize = true;

            flpDSDoUong.Controls.Add(lb);
            Label lineBreakLabel = new Label();
            lineBreakLabel.Text = Environment.NewLine;
            flpDSDoUong.Controls.Add(lineBreakLabel);
        }
    }
}
