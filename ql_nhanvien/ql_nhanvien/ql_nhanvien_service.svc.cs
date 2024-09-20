using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace ql_nhanvien
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ql_nhanvien_service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ql_nhanvien_service.svc or ql_nhanvien_service.svc.cs at the Solution Explorer and start debugging.
    public class ql_nhanvien_service : Iql_nhanvien_service
    {
        string config = "Server=localhost; Database=ql_nhanvien; UId=root; Pwd=1234; Pooling=false; Character Set=utf8";
        public object nhanviens { get; private set; }
        public void create(int manv, string tennv, string phongban, string gioitinh, int luong, int thuong, int sdt)
        {
            string mes = "";

            MySqlConnection strconn = new MySqlConnection(config);

            try
            {
                strconn.Open();
                Console.WriteLine("Kết nối thành công!");

                string sql_id = "INSERT INTO `nhanvien` (`manv`, `tennv`, `phongban`, `gioitinh`, `luong`, `thuong`, `sdt`) VALUES ('" + manv + "','" + tennv + "', '" + phongban + "', '" + gioitinh + "', '" + luong + "', '" + thuong + "', '" + sdt + "')";
                MySqlCommand cmd_id = new MySqlCommand(sql_id, strconn);
                cmd_id.ExecuteNonQuery();
                mes = "Tạo mới thành công";

            }
            catch (Exception e)
            {
                mes = "Lỗi: " + e.Message;
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }

        public void delete(int manv)
        {
            string mes = "";

            MySqlConnection strconn = new MySqlConnection(config);

            try
            {
                strconn.Open();
                Console.WriteLine("Kết nối thành công!");

                string sql_id = "delete from nhanvien where manv= " + manv + "";
                MySqlCommand cmd_id = new MySqlCommand(sql_id, strconn);
                cmd_id.ExecuteReader();
                mes = "xoá thành công";
            }
            catch (Exception e)
            {
                mes = "Lỗi: " + e.Message;
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }

        public List<Nhanvien> getAll()
        {
            string query = "SELECT id, manv, tennv, phongban, gioitinh, luong, thuong, sdt FROM nhanvien";
            List<Nhanvien> nhanviens = new List<Nhanvien>();

            using (MySqlConnection conn = new MySqlConnection(config))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Nhanvien nhanvien = new Nhanvien()
                        {
                            id = Convert.ToInt32(row["id"]),
                            manv = row["manv"].ToString(),
                            tennv = row["tennv"].ToString(),
                            phongban = row["phongban"].ToString(),
                            gioitinh = row["gioitinh"].ToString(),
                            luong = row["luong"].ToString(),
                            thuong = row["thuong"].ToString(),
                            sdt = row["sdt"].ToString()
                        };
                        nhanviens.Add(nhanvien);
                    }
                }

                /*MySqlCommand cmd = new MySqlCommand(query, conn);

                MySqlDataAdapter da = new MySqlDataAdapter(cmd);
                
                da.Fill(dt);*/
            }

            return nhanviens;
        }

        public List<Nhanvien> search(int manv)
        {
            string query = "SELECT id, manv, tennv, phongban, gioitinh, luong, thuong, sdt FROM nhanvien where manv= " + manv + "";
            List<Nhanvien> nhanviens = new List<Nhanvien>();

            using (MySqlConnection conn = new MySqlConnection(config))
            {
                using (MySqlCommand cmd = new MySqlCommand(query, conn))
                {
                    conn.Open();
                    DataTable dataTable = new DataTable();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        adapter.Fill(dataTable);
                    }

                    foreach (DataRow row in dataTable.Rows)
                    {
                        Nhanvien nhanvien = new Nhanvien()
                        {
                            id = Convert.ToInt32(row["id"]),
                            manv = row["manv"].ToString(),
                            tennv = row["tennv"].ToString(),
                            phongban = row["phongban"].ToString(),
                            gioitinh = row["gioitinh"].ToString(),
                            luong = row["luong"].ToString(),
                            thuong = row["thuong"].ToString(),
                            sdt = row["sdt"].ToString()
                        };
                        nhanviens.Add(nhanvien);
                    }
                }
            }

            return nhanviens;
        }

        public void update(int manv, string tennv, string phongban, string gioitinh, int luong, int thuong, int sdt)
        {
            string mes = "";

            MySqlConnection strconn = new MySqlConnection(config);

            try
            {
                strconn.Open();
                Console.WriteLine("Kết nối thành công!");

                string sql_id = "UPDATE nhanvien SET tennv = '" + tennv + "', phongban = '" + phongban + "', gioitinh = '" + gioitinh + "', luong = '" + luong + "', thuong = '" + thuong + "', sdt = '"+ sdt +"' WHERE manv = '" + manv + "'";
                MySqlCommand cmd_id = new MySqlCommand(sql_id, strconn);
                cmd_id.ExecuteNonQuery();
                mes = "Cập nhật thành công";

            }
            catch (Exception e)
            {
                mes = "Lỗi: " + e.Message;
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }
    }
}
