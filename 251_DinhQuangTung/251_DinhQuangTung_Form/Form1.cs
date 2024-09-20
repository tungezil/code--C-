using _251_DinhQuangTung_Form.DinhQuangTung_251_Service;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _251_DinhQuangTung_Form
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
                List<Benxe> BenxeList = new List<Benxe>();
                using (I251_DinhQuangTung_ServiceClient service = new I251_DinhQuangTung_ServiceClient())
                {
                    BenxeList = service.getAll().ToList();
                }
                dataGridView1.DataSource = BenxeList;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi: " + ex.Message);
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            I251_DinhQuangTung_ServiceClient client = new I251_DinhQuangTung_ServiceClient();

            int maxe = int.Parse(textBox1.Text);
            string tenxe = textBox2.Text;
            int soluong = int.Parse(textBox3.Text);
            string loaixe = textBox4.Text;

            try
            {
                client.create(maxe, tenxe, soluong, loaixe);
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
            I251_DinhQuangTung_ServiceClient client = new I251_DinhQuangTung_ServiceClient();

            int maxe = int.Parse(textBox1.Text);
            string tenxe = textBox2.Text;
            int soluong = int.Parse(textBox3.Text);
            string loaixe = textBox4.Text;

            try
            {
                client.update(maxe, tenxe, soluong, loaixe);
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
            I251_DinhQuangTung_ServiceClient client = new I251_DinhQuangTung_ServiceClient();

            string maxe = textBox1.Text;

            try
            {
                client.delete(int.Parse(maxe));
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
            int maxe = int.Parse(textBox1.Text);

            if (maxe == null)
            {
                MessageBox.Show("Nhập mã sinh viên");
            }
            else
            {
                try
                {
                    List<Benxe> BenxeList = new List<Benxe>();
                    using (I251_DinhQuangTung_ServiceClient service = new I251_DinhQuangTung_ServiceClient())
                    {
                        BenxeList = service.search(maxe).ToList();
                    }
                    dataGridView1.DataSource = BenxeList;
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
        }
    }
}
