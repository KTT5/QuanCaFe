using DAL_BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        }

        private void grbban_Enter(object sender, EventArgs e)
        {

        }

        private void DoUong_Load(object sender, EventArgs e)
        {
            List<SanPham> sp = du.GetSanPhams();
            pbdouong.Controls.Clear();
            sp.ForEach(x =>
            {
                Button btn = new Button();
                btn.Text = x.TenSanPham;
                btn.Tag = x.MaSanPham;
                btn.Width = 100;
                btn.Height = 40;
                pbdouong.Controls.Add(btn);
            });
        }
    }
}
