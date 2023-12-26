using QL_BanHang_XML.Data;
using QL_BanHang_XML.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QL_BanHang_XML
{
    public partial class QL_Khach_Hang : Form
    {
        public QL_Khach_Hang()
        {
            InitializeComponent();
            DisplayData();
        }
        DataUtil_Khachhang  data = new DataUtil_Khachhang();
        private void btnBack_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        private void DisplayData()
        {
            dataGridViewkh.DataSource = data.GetAllMember();
            dataGridViewkh.Columns[0].Width = 30;
            dataGridViewkh.Columns[1].Width = 120;
            dataGridViewkh.Columns[2].Width = 30;
            dataGridViewkh.Columns[3].Width = 140;
            dataGridViewkh.Columns[4].Width = 80;
            dataGridViewkh.Columns[5].Width = 160;
            txtSearchkh.Text = dataGridViewkh.Rows.Count + "";
        }
        private void btnAddkh_Click(object sender, EventArgs e)
        {
            if (txtIdkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Id!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }else if (txtNamekh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên khách hàng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (txtGioitinh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Giới tính!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (txtEmailkh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Email!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (txtPhonekh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Số điện thoại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (txtDiachikh.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Địa chỉ!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                khachhang kh = new khachhang();
                kh.txtIdkh = txtIdkh.Text;
                kh.txtNamekh = txtNamekh.Text;
                kh.txtEmailkh = txtEmailkh.Text;
                kh.txtGioitinh = txtGioitinh.Text;
                kh.txtPhonekh = txtPhonekh.Text;
                kh.txtDiachikh = txtDiachikh.Text;
                data.AddMember(kh);
                cleartextbox();
                DisplayData();
            }

        }
        private void cleartextbox()
        {
            txtIdkh.Clear();
            txtNamekh.Clear();
            txtGioitinh.Clear();
            txtEmailkh.Clear();
            txtPhonekh.Clear();
            txtDiachikh.Clear();
            ActiveControl = txtIdkh;
        }

        private void dataGridViewkh_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void dataGridViewkh_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            khachhang kh = (khachhang)dataGridViewkh.CurrentRow.DataBoundItem;
            txtIdkh.Text = kh.txtIdkh;
            txtNamekh.Text = kh.txtNamekh;
            txtGioitinh.Text = kh.txtGioitinh;
            txtEmailkh.Text = kh.txtEmailkh;
            txtPhonekh.Text = kh.txtPhonekh;
            txtDiachikh.Text = kh.txtDiachikh;
        }

        private void btnSuakh_Click(object sender, EventArgs e)
        {
            khachhang kh = new khachhang();
            kh.txtIdkh = txtIdkh.Text;
            kh.txtNamekh = txtNamekh.Text;
            kh.txtGioitinh = txtGioitinh.Text;
            kh.txtEmailkh = txtEmailkh.Text;
            kh.txtPhonekh = txtPhonekh.Text;
            kh.txtDiachikh = txtDiachikh.Text;
            bool ktkh = data.UpdateMember(kh);
            if (!ktkh)
            {
                MessageBox.Show("Không chỉnh sửa được sản phẩm id=" + kh.txtIdkh);
                return;
            }
            DisplayData();
        }

        private void btnXoakh_Click(object sender, EventArgs e)
        {
            DialogResult dkh = MessageBox.Show("Bạn có chắn chắn muốn xoá không?", "Thông báo", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            if (dkh == DialogResult.Yes)
            {
                bool ktkh = data.DeleteMember(txtIdkh.Text);
                if (!ktkh)
                {
                    MessageBox.Show("Có lỗi khi xoá!", "Thông báo");
                    return;
                }
                DisplayData();
                cleartextbox();
            }
        }

        private void btnSearchkh_Click(object sender, EventArgs e)
        {
            string idsp = txtSearchkh.Text;
            List<khachhang> likh = new List<khachhang>();
            khachhang kh = data.FindID(idsp);
            if (kh != null)
            {
                likh.Add(kh);
                dataGridViewkh.DataSource = likh;
                txtSearchkh.Text = dataGridViewkh.Rows.Count + "";
                txtIdkh.Text = kh.txtIdkh;
                txtNamekh.Text = kh.txtNamekh;
                txtGioitinh.Text = kh.txtGioitinh;
                txtEmailkh.Text = kh.txtEmailkh;
                txtPhonekh.Text = kh.txtPhonekh;
                txtDiachikh.Text = kh.txtDiachikh;
            }
            else
            {
                MessageBox.Show("Không có khach hang nào có id : " + txtIdkh, "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
