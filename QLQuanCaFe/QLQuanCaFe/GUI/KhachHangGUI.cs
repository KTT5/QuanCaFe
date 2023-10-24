using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL_BLL;

namespace QLQuanCaFe
{
    public partial class KhachHangGUI : Form
    {
        KhachHangDAL_BLL kh = new KhachHangDAL_BLL();
        public KhachHangGUI()
        {
            InitializeComponent();
        }

        private void dgvKhachhang_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
             DataGridViewRow row = dgvKhachhang.Rows[e.RowIndex];
            int masv =  int.Parse(row.Cells[0].Value.ToString());
            List<KhachHang> khs = new List<KhachHang>();
            khs = kh.getKhachHangTheoMa(masv);
            if (khs.Count > 0)
            {
                KhachHang khachHang = khs[0];
                txtMaKH.Text=khachHang.MaKhachHang.ToString();
                txtTenKH.Text = khachHang.TenKhachHang;
                txtDiaChi.Text = khachHang.DiaChi;
                txtSoDT.Text = khachHang.SoDienThoai;
            }
            
        }
        

        private void KhachHang_Load(object sender, EventArgs e)
        {
            List<KhachHang> khs = kh.getKhachHang();
            dgvKhachhang.DataSource = khs;
        }
    }
}
