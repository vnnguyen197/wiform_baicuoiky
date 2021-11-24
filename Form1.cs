using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
// Nguyễn Văn Nguyện_CS414H
namespace QLMATHANG
{
    public partial class matHang : Form
    {

        DATA data = new DATA();
        public matHang()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadBang();
            loadCbx();
        }

        private void loadCbx()
        {
            string sql = "select * from NCC";
            cbx_NCC.DataSource = data.loadData(sql);
            cbx_NCC.DisplayMember = "TENNCC";
            cbx_NCC.ValueMember = "MANCC";
        }
        private void clearData()
        {
            txt_MaHang.Text = "";
            txt_TenHang.Text = "";
            txt_Soluong.Text = "";

        }
        private void loadBang()
        {
            string sql = "select * from MATHANG";
            dataGridView1.DataSource = data.loadData(sql);
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            try
            {
                string sql = "insert into MATHANG values(N'" + txt_MaHang.Text + "', N'" + txt_TenHang.Text + "',convert(datetime,'" + dt_NgayNhap.Text + "',103), " + int.Parse(txt_Soluong.Text) + ", " + cbx_NCC.SelectedValue.ToString() + ")";
                int kq = data.ThemXoaSua(sql);
                if (kq >= 1)
                {
                    MessageBox.Show("Thêm thành công");
                }
                else MessageBox.Show("Thêm thất bại");

                loadBang();
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Thêm thất bại");
            }

        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "delete MATHANG where MAHANG = N'" + txt_MaHang.Text + "'";
                int kq = data.ThemXoaSua(sql);
                if (kq >= 1)
                {
                    MessageBox.Show("Xoá thành công");
                }
                else MessageBox.Show("Xoá thất bại");

                loadBang();
                clearData();
            }
            catch (Exception)
            {
                MessageBox.Show("Xoá thất bại");
            }
        }


        private void btn_Sua_Click(object sender, EventArgs e)
        {
            try
            {
                String sql = "update MATHANG set TENHANG = N'" + txt_TenHang.Text + "', NGAYNHAP = convert(datetime, " + dt_NgayNhap.Text + ", 103), SOLUONG = " + int.Parse(txt_Soluong.Text) + " where MAHANG = N'" + txt_MaHang.Text + "'";
                int kq = data.ThemXoaSua(sql);
                if (kq >= 1)
                {
                    MessageBox.Show("Sửa thành công");
                }
                else MessageBox.Show("Sửa thất bại");
                loadBang();
                clearData();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa thất bại");
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txt_MaHang.Text = dataGridView1.CurrentRow.Cells["MAHANG"].Value.ToString();
            txt_TenHang.Text = dataGridView1.CurrentRow.Cells["TENHANG"].Value.ToString();
            cbx_NCC.SelectedValue = dataGridView1.CurrentRow.Cells["MANCC"].Value.ToString();
            dt_NgayNhap.Text = dataGridView1.CurrentRow.Cells["NGAYNHAP"].Value.ToString();
            txt_Soluong.Text = dataGridView1.CurrentRow.Cells["SOLUONG"].Value.ToString();
        }

        private void cbx_NCC_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }
    }
}
