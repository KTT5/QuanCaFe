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
        ToppingDAL_BLL to= new ToppingDAL_BLL();
        decimal tongTien = 0;
        private SanPham sanPham;
        ComboBox cbbTopping;

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
            sanPham = du.Get1SanPhamsTheoMa(maSanPham);

            Panel existingCard = flpDSDoUong.Controls.OfType<Panel>().FirstOrDefault(card => (int)card.Tag == maSanPham);

            if (existingCard != null && cbbTopping.SelectedIndex == 0)
            {
                // Đã tồn tại, tăng giá trị của NumericUpDown lên 1
                NumericUpDown num1 = existingCard.Controls.OfType<NumericUpDown>().FirstOrDefault();
                Label lb = existingCard.Controls.OfType<Label>().FirstOrDefault();
                if (num1 != null)
                {
                    num1.Value++;
                    lb.Text = sanPham.TenSanPham + "       " + sanPham.GiaTien*num1.Value;
                    tongTien += (decimal)sanPham.GiaTien;
                    // Cập nhật lbTongTien
                    //lbTongTien.Text = tongTien.ToString(); // Format tiền tệ
                }
            }
            else if(existingCard != null && cbbTopping.SelectedIndex != 0)
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
                lb.TextChanged += Lb_TextChanged;


                NumericUpDown num = new NumericUpDown();
                num.Width = 30;
                num.Location = new Point(300, 0);
                num.Font = new Font(Font.FontFamily, 10);
                num.Value = 1;
                num.ValueChanged += (s, ev) =>
                {
                    int numValue = (int)num.Value;
                    if (numValue == 0)
                    {
                        // Loại bỏ Panel nếu num = 0
                        flpDSDoUong.Controls.Remove(card);
                    }
                    else
                    {
                        lb.Text = sanPham.TenSanPham + "       " + sanPham.GiaTien * numValue;
                        tongTien += (decimal)sanPham.GiaTien * numValue;
                    }
                };

                

                List<Topping> topping = to.getToppping();
                cbbTopping = new ComboBox();
                cbbTopping.DataSource = topping;
                cbbTopping.DisplayMember = "Ten";
                cbbTopping.ValueMember = "MaTopping";
                cbbTopping.Width = 150;
                cbbTopping.Location = new Point(0, lb.Bottom + 25);
                cbbTopping.Font = new Font(Font.FontFamily, 10);
                cbbTopping.SelectedIndexChanged += CbbTopping_SelectedIndexChanged;

                if (sanPham.MaTheLoai == 3 || sanPham.MaTheLoai == 4 || sanPham.MaTheLoai == 5)
                {
                    cbbTopping.Enabled = false;
                }

                Button bt1 = new Button();
                bt1.Text = "Hoàn thành";
                bt1.Font=new Font(Font.FontFamily, 10);
                bt1.Location= new Point(300,60);
                bt1.Width = 100;
                bt1.Click += Bt1_Click;

                
                card.Controls.Add(lb);
                card.Controls.Add(cbbTopping);
                card.Controls.Add(num);
                card.Controls.Add(bt1);

                tongTien += (decimal)sanPham.GiaTien;


                flpDSDoUong.Controls.Add(card);
                //flpDSDoUong.Controls.Add(cbbTopping);
                //flpDSDoUong.Controls.Add(num);
                Label lineBreakLabel = new Label();
                lineBreakLabel.Text = Environment.NewLine;
                flpDSDoUong.Controls.Add(lineBreakLabel);
                pbdouong.Enabled = false;
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
                lb.TextChanged += Lb_TextChanged;

                NumericUpDown num = new NumericUpDown();
                num.Width = 30;
                num.Location = new Point(300, 0);
                num.Font = new Font(Font.FontFamily, 10);
                num.Value = 1;
                num.ValueChanged += (s, ev) =>
                {
                    int numValue = (int)num.Value;
                    if (numValue == 0)
                    {
                        // Loại bỏ Panel nếu num = 0
                        flpDSDoUong.Controls.Remove(card);
                    }
                    else
                    {
                        lb.Text = sanPham.TenSanPham + "       " + sanPham.GiaTien * numValue;
                        tongTien += (decimal)sanPham.GiaTien * numValue;
                    }
                };



                List<Topping> topping = to.getToppping();
                cbbTopping = new ComboBox();
                cbbTopping.DataSource = topping;
                cbbTopping.DisplayMember = "Ten";
                cbbTopping.ValueMember = "MaTopping";
                cbbTopping.Width = 150;
                cbbTopping.Location = new Point(0, lb.Bottom + 25);
                cbbTopping.Font = new Font(Font.FontFamily, 10);
                cbbTopping.SelectedIndexChanged += CbbTopping_SelectedIndexChanged;

                if (sanPham.MaTheLoai == 3 || sanPham.MaTheLoai == 4 || sanPham.MaTheLoai == 5)
                {
                    cbbTopping.Enabled = false;
                }

                Button bt = new Button();
                bt.Text = "Hoàn thành";
                bt.Font = new Font(Font.FontFamily, 10);
                bt.Location = new Point(300, 60);
                bt.Width= 100;
                bt.Click += Bt_Click;

                card.Controls.Add(lb);
                card.Controls.Add(cbbTopping);
                card.Controls.Add(num);
                card.Controls.Add(bt);

                tongTien += (decimal)sanPham.GiaTien;
                // Cập nhật lbTongTien
                //lbTongTien.Text = tongTien.ToString();

                flpDSDoUong.Controls.Add(card);
                //flpDSDoUong.Controls.Add(cbbTopping);
                //flpDSDoUong.Controls.Add(num);
                Label lineBreakLabel = new Label();
                lineBreakLabel.Text = Environment.NewLine;
                flpDSDoUong.Controls.Add(lineBreakLabel);
                pbdouong.Enabled = false;
            }

            
        }

        private void Bt1_Click(object sender, EventArgs e)
        {
            pbdouong.Enabled = true;
        }

        private void Bt_Click(object sender, EventArgs e)
        {
            pbdouong.Enabled=true;
        }

        private void Lb_TextChanged(object sender, EventArgs e)
        {
            //decimal tongGiaTien = TinhTongGiaTienCacSanPham();
            //lbTongTien.Text =tongGiaTien.ToString(); // Format tiền tệ
        }


        private void CbbTopping_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox cbbTopping = (ComboBox)sender;
            Topping selectedTopping = (Topping)cbbTopping.SelectedItem;

            if (selectedTopping != null)
            {
                Panel parentPanel = (Panel)cbbTopping.Parent;

                if (parentPanel != null)
                {
                    NumericUpDown num = parentPanel.Controls.OfType<NumericUpDown>().FirstOrDefault();
                    Label lb = parentPanel.Controls.OfType<Label>().FirstOrDefault();

                    if (num != null && lb != null)
                    {
                        decimal sanPhamGia = (decimal)sanPham.GiaTien;
                        decimal giaTienTopping = (decimal)selectedTopping.Gia;
                        int soLuong = (int)num.Value;

                        // Tính giá tiền của sản phẩm bao gồm topping
                        decimal giaTienSanPham = sanPhamGia * soLuong;
                        decimal giaTienTong = giaTienSanPham + giaTienTopping;

                        // Cập nhật label để hiển thị giá tiền mới
                        lb.Text = sanPham.TenSanPham + "       " + giaTienTong;

                        // Cập nhật tổng tiền
                        tongTien += giaTienTong;

                        // Cập nhật lbTongTien
                        //lbTongTien.Text = tongTien.ToString("c"); // Format tiền tệ
                    }
                }
            }
        }

        private void lbDouong_Click(object sender, EventArgs e)
        {
            pbdouong.Enabled = true;
        }
    }
}
