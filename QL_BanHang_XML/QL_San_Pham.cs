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

namespace QL_BanHang_XML
{
    public partial class QL_San_Pham : Form
    {
        public QL_San_Pham()
        {
            InitializeComponent();
            DisplayData();
        }

        DataUtil_Sanpham data = new DataUtil_Sanpham();

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Home home = new Home();
            home.Show();
            this.Close();
        }

        private void DisplayData()
        {
            dataGridViewSP.DataSource = data.GetAllProducts();
            dataGridViewSP.Columns[0].Width = 30;
            dataGridViewSP.Columns[1].Width = 100;
            dataGridViewSP.Columns[2].Width = 80;
            dataGridViewSP.Columns[3].Width = 50;
            dataGridViewSP.Columns[4].Width = 100;
            dataGridViewSP.Columns[5].Width = 100;
            dataGridViewSP.Columns[6].Width = 100;
            lblCout.Text = dataGridViewSP.Rows.Count + "";
        }
        private void addspbtn_Click(object sender, EventArgs e)
        {
            if (id.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập id!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }else if (name.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Tên sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (gia.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập giá sản phẩm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (soluong.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập số lượng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (mota.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Mô tả!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (ngaysanxuat.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập ngày sản xuất!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else if (hansudung.Text == "")
            {
                MessageBox.Show("Bạn chưa nhập Hạn sử dụng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Question);
            }
            else
            {
                sanpham sp = new sanpham();
                sp.id = id.Text;
                sp.name = name.Text;
                sp.gia = gia.Text;
                sp.soluong = soluong.Text;
                sp.mota = mota.Text;
                sp.ngaysanxuat = ngaysanxuat.Text;
                sp.hansudung = hansudung.Text;
                if (data.ProductExists(sp.id))
                {
                    MessageBox.Show("Sản phẩm có ID này đã tồn tại!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                data.Addproduct(sp);
                cleartextbox();
                DisplayData();
            }
        }
        private void cleartextbox()
        {
            id.Clear();
            name.Clear();
            gia.Clear();
            soluong.Clear   ();
            mota.Clear();
            ngaysanxuat.Clear ();
            hansudung.Clear ();
            ActiveControl = id;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridViewSP_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            sanpham sp = (sanpham)dataGridViewSP.CurrentRow.DataBoundItem;
            id.Text = sp.id;
            name.Text = sp.name;
            gia.Text = sp.gia;
            soluong.Text = sp.soluong;
            mota.Text = sp.mota;
            ngaysanxuat.Text = sp.ngaysanxuat;
            hansudung.Text = sp.hansudung;
        }

        private void editspbtn_Click(object sender, EventArgs e)
        {
            sanpham sp = new sanpham();
            sp.id = id.Text;
            sp.name = name.Text;
            sp.gia = gia.Text;
            sp.soluong = soluong.Text;
            sp.mota = mota.Text;
            sp.ngaysanxuat = ngaysanxuat.Text;
            sp.hansudung = hansudung.Text;
            bool kt = data.UpdateProduct(sp);
            if (!kt)
            {
                MessageBox.Show("Không chỉnh sửa được sản phẩm id="+sp.id);
                return;
            }
            DisplayData();
        }

        private void clear_Click(object sender, EventArgs e)
        {
            cleartextbox();
            DisplayData();
        }

        private void deletespbtn_Click(object sender, EventArgs e)
        {
            DialogResult d = MessageBox.Show("Bạn có chắn chắn muốn xoá không?","Thông báo",MessageBoxButtons.YesNo,MessageBoxIcon.Error);
            if(d == DialogResult.Yes)
            {
                bool kt = data.DeleteProduct(id.Text);
                if (!kt)
                {
                    MessageBox.Show("Có lỗi khi xoá!","Thông báo");
                    return;
                }
                DisplayData();
                cleartextbox();
            }
        }

        private void searchsp_Click(object sender, EventArgs e)
        {
            string idsp = txtSearch.Text;
            List<sanpham> li = new List<sanpham>();
            sanpham sp = data.FindID(idsp);
            if (sp != null)
            {
                li.Add(sp);
                dataGridViewSP.DataSource = li;
                lblCout.Text = dataGridViewSP.Rows.Count + "";
                id.Text = sp.id;
                name.Text = sp.name;
                gia.Text = sp.gia;
                soluong.Text = sp.soluong;
                mota.Text = sp.mota;
                ngaysanxuat.Text = sp.ngaysanxuat;
                hansudung.Text = sp.hansudung;
            }
            else
            {
                MessageBox.Show("Không có sản phẩm nào có id : " + idsp, "Thông báo",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }
    }
}
