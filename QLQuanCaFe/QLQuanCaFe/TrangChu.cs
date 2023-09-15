using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCaFe
{
    public partial class TrangChu : Form
    {
        
        public TrangChu()
        {
            InitializeComponent();
        }
        private Form currentFormChild;
        private void openChildForm(Form childForm)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();

            }
            currentFormChild = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pn_main.Controls.Add(childForm);
            pn_main.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void btn_TaiBan_Click(object sender, EventArgs e)
        {
            openChildForm(new TaiBan());
        }

        private void btn_TaiQuay_Click(object sender, EventArgs e)
        {
            openChildForm(new TaiQuay());
        }

        private void btn_BaoCao_Click(object sender, EventArgs e)
        {
            openChildForm(new BaoCao());
        }

        private void btn_KhachHang_Click(object sender, EventArgs e)
        {
            openChildForm(new KhachHang());
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            openChildForm(new Them());
        }

        private void ptb_TrangChu_Click(object sender, EventArgs e)
        {
            if (currentFormChild != null)
            {
                currentFormChild.Close();

            }
        }

        private void TrangChu_Load(object sender, EventArgs e)
        {
            openChildForm(new TaiBan());
        }
    }
}
