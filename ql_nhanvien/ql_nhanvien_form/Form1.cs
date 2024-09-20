using ql_nhanvien_form.ql_nhanvien_service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ql_nhanvien_form
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private void showData()
        {
            try
            {
                List<Nhanvien> NhanvienList = new List<Nhanvien>();
                using (Iql_nhanvien_serviceClient service = new Iql_nhanvien_serviceClient())
                {
                    NhanvienList = service.getAll().ToList();
                }
                dataGridView1.DataSource = NhanvienList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            Iql_nhanvien_serviceClient client = new Iql_nhanvien_serviceClient();

            int manv = int.Parse(textBox1.Text);
            string tennv = textBox2.Text;
            string phongban = textBox3.Text;
            string gioitinh = textBox4.Text;
            int luong = int.Parse(textBox5.Text);
            int thuong = int.Parse(textBox6.Text);
            int sdt = int.Parse(textBox7.Text);

            try
            {
                client.create(manv, tennv, phongban, gioitinh, luong, thuong, sdt);
                showData();
                MessageBox.Show("Tạo thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Tạo lỗi: " + ex.Message + "");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Iql_nhanvien_serviceClient client = new Iql_nhanvien_serviceClient();

            int manv = int.Parse(textBox1.Text);
            string tennv = textBox2.Text;
            string phongban = textBox3.Text;
            string gioitinh = textBox4.Text;
            int luong = int.Parse(textBox5.Text);
            int thuong = int.Parse(textBox6.Text);
            int sdt = int.Parse(textBox7.Text);

            try
            {
                client.update(manv, tennv, phongban, gioitinh, luong, thuong, sdt);
                showData();
                MessageBox.Show("Sửa thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Sửa lỗi: " + ex.Message + "");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Iql_nhanvien_serviceClient client = new Iql_nhanvien_serviceClient();

            string manv = textBox1.Text;

            try
            {
                client.delete(int.Parse(manv));
                showData();
                MessageBox.Show("Xóa thành công.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Xóa lỗi: " + ex.Message + "");
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            int manv = int.Parse(textBox8.Text);

            if (manv == null)
            {
                MessageBox.Show("Nhập id nhân viên");
            }
            else
            {
                try
                {
                    List<Nhanvien> NhanvienList = new List<Nhanvien>();
                    using (Iql_nhanvien_serviceClient service = new Iql_nhanvien_serviceClient())
                    {
                        NhanvienList = service.search(manv).ToList();
                    }
                    dataGridView1.DataSource = NhanvienList;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            showData();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";
            textBox5.Text = "";
            textBox6.Text = "";
            textBox7.Text = "";
        }
    }
}
