using QLQuanCaFe.GUI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLQuanCaFe
{
    public partial class TrangChu : Form
    {
        string connection = @"Data Source=DESKTOP-HBPU190\SV;Initial Catalog=QLCafe;Integrated Security=True";
        List<string> list_detail;
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
            openChildForm(new KhachHangGUI());

        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            //Kiểm tra có quyền mới cho vào
            lb_User.Text = FormLogin.NAME_USER;
            if (checkper("ALL") == true)
            {
                MessageBox.Show("Chào Admin");
                openChildForm(new User_PhanQuyen());
            }
            else
            {
                MessageBox.Show("Bạn không có quyền để truy cập");
            }
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
            list_detail = list_per(id_per(FormLogin.ID_USER));
            label1.Text= FormLogin.NAME_USER;
        }

        private void ban1_Click(object sender, EventArgs e)
        {

        }

        // user permision phân quyền
        //Lấy mã Nhóm Quyền
        private string id_per(string id_user)
        {
            string id = "";
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_per_relationship WHERE id_user_rel ='" + id_user + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            if (dr["suspended"].ToString() == "False")
                            {
                                id = dr["id_per_rel"].ToString();
                            }
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            return id;
        }
        //Danh Sách Quyền
        private List<string> list_per(string id_per)
        {
            List<string> termsList = new List<string>();
            try
            {
                using (SqlConnection con = new SqlConnection(connection))
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM tbl_permision_del WHERE id_per ='" + id_per + "'", con);
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    if (dt != null)
                    {
                        foreach (DataRow dr in dt.Rows)
                        {
                            termsList.Add(dr["code_action"].ToString());
                        }
                    }
                    con.Close();

                }
            }
            catch (Exception)
            {
                MessageBox.Show("Lỗi xảy ra khi truy vấn dữ liệu hoặc kết nối với server thất bại !");
            }
            return termsList;
        }
        //Check Quyền
        private Boolean checkper(string code)
        {
            Boolean check = false;
            foreach (string item in list_detail)
            {
                if (item == code)
                {
                    check = true;
                }
            }
            return check;
        }

        private void TrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Quản Lý Quán Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                this.Close();
            }
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn đăng xuất không không?", "Quản Lý Quán Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                FormLogin f = new FormLogin();
                f.Show();
                this.Hide();
                
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            openChildForm(new DoUong());
        }
    }
}
