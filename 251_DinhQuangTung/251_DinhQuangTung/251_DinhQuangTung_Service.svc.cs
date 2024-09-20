using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace _251_DinhQuangTung
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "_251_DinhQuangTung_Service" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select 251_DinhQuangTung_Service.svc or 251_DinhQuangTung_Service.svc.cs at the Solution Explorer and start debugging.
    public class _251_DinhQuangTung_Service : I251_DinhQuangTung_Service
    {
        string config = "Server=localhost; Database=ql_benxe; UId=root; Pwd=1234; Pooling=false; Character Set=utf8";
        public object benxes { get; private set; }
        public void create(int maxe, string tenxe, int soluong, string loaixe)
        {
            string mes = "";
            MySqlConnection strconn = new MySqlConnection(config);

            try
            {
                strconn.Open();
                Console.WriteLine("Kết nối thành công!");

                string sql_id = "INSERT INTO `t_xe` (`maxe`, `tenxe`, `soluong`, `loaixe`) VALUES ('" + maxe + "', '" + tenxe + "', '" + soluong + "', '" + loaixe + "')";
                MySqlCommand cmd_id = new MySqlCommand(sql_id, strconn);
                cmd_id.ExecuteNonQuery();
                mes = "Tạo mới xe thành công";

            }
            catch (Exception e)
            {
                mes = "Lỗi: " + e.Message;
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }

        public void delete(int maxe)
        {
            string mes = "";
            MySqlConnection strconn = new MySqlConnection(config);

            try
            {
                strconn.Open();
                Console.WriteLine("Kết nối thành công!");

                string sql_id = "delete from t_xe where maxe = " + maxe + "";
                MySqlCommand cmd_id = new MySqlCommand(sql_id, strconn);
                cmd_id.ExecuteReader();
                mes = "xoá xe thành công";
            }
            catch (Exception e)
            {
                mes = "Lỗi: " + e.Message;
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }

        public List<Benxe> getAll()
        {
            string query = "SELECT id, maxe, tenxe, soluong ,loaixe FROM t_xe";
            List<Benxe> benxes = new List<Benxe>();

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
                        Benxe benxe = new Benxe()
                        {
                            id = Convert.ToInt32(row["id"]),
                            maxe = row["maxe"].ToString(),
                            tenxe = row["tenxe"].ToString(),
                            soluong = row["soluong"].ToString(),
                            loaixe = row["loaixe"].ToString()
                        };
                        benxes.Add(benxe);
                    }
                }
            }

            return benxes;
        }

        public List<Benxe> search(int maxe)
        {
            string query = "SELECT id, maxe, tenxe, soluong ,loaixe FROM t_xe where maxe = " + maxe + "";
            List<Benxe> benxes = new List<Benxe>();

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
                        Benxe benxe = new Benxe()
                        {
                            id = Convert.ToInt32(row["id"]),
                            maxe = row["maxe"].ToString(),
                            tenxe = row["tenxe"].ToString(),
                            soluong = row["soluong"].ToString(),
                            loaixe = row["loaixe"].ToString()
                        };
                        benxes.Add(benxe);
                    }
                }
            }

            return benxes;
        }

        public void update(int maxe, string tenxe, int soluong, string loaixe)
        {
            string mes = "";
            MySqlConnection strconn = new MySqlConnection(config);

            try
            {
                strconn.Open();
                Console.WriteLine("Kết nối thành công!");

                string sql_id = "UPDATE t_xe SET tenxe = '" + tenxe + "', soluong = '" + soluong + "', loaixe = '" + loaixe + "' WHERE maxe = '" + maxe + "'";
                MySqlCommand cmd_id = new MySqlCommand(sql_id, strconn);
                cmd_id.ExecuteNonQuery();
                mes = "Cập nhật xe thành công";

            }
            catch (Exception e)
            {
                mes = "Lỗi: " + e.Message;
                Console.WriteLine("Lỗi: " + e.Message);
            }
        }

        public void user(string tenuser)
        {
            throw new NotImplementedException();
        }
    }
}
