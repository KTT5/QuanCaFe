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
    public partial class user : Form
    {
        //Bảng User
        QLCFDataContext data = new QLCFDataContext();
        public user()
        {
            InitializeComponent();
            loadData();
        }
        void loadData()
        {
            var user = from us in data.tbl_users select us;
            dataGridView1.DataSource = user;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtID.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            txtNameUser.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            txtUserName.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            txtPass.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (txtUserName.Text == "" || txtPass.Text == "" || txtNameUser.Text == "")
            {
                MessageBox.Show("Dữ Liệu Đang Trống");
            }
            try
            {
                tbl_user us = new tbl_user();
                us.id_user = int.Parse(txtID.Text);
                us.name_user = txtNameUser.Text;
                us.user_name = txtUserName.Text;
                us.pass = txtPass.Text;
                data.tbl_users.InsertOnSubmit(us);
                data.SubmitChanges();
                MessageBox.Show("Thêm Thành Công");
                loadData();
            }
            catch (Exception)
            {

                MessageBox.Show("Thêm Thất Bại");
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Không Được Để Trống ID_User");
                return;
            }
            tbl_user _us = data.tbl_users.Where(us => us.id_user == int.Parse(txtID.Text)).FirstOrDefault();
            if (_us != null)
            {
                data.tbl_users.DeleteOnSubmit(_us);
                data.SubmitChanges();
                MessageBox.Show("Xóa Thàng Công");
                loadData();
            }
            else
            {
                MessageBox.Show("Xóa Thất Bại");
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (txtID.Text == "")
            {
                MessageBox.Show("Không Được Để Trống ID_User");
                return;
            }
            tbl_user us = data.tbl_users.Where(t => t.id_user == int.Parse(txtID.Text.ToString())).FirstOrDefault();
            if (us != null)
            {
                us.name_user = txtNameUser.Text;
                us.user_name = txtUserName.Text;
                us.pass = txtPass.Text;
                data.SubmitChanges();
                MessageBox.Show("Sửa Thành Công");
            }
            else
            {
                MessageBox.Show("Sửa Thất Bại");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắc là muốn thoát không?", "Quản Lý Quán Cafe", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
            }
        }
    }
}
