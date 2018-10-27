using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using HeThongATM_UWP.Models;

namespace HeThongATM_UWP.ViewModel
{
    class DangNhap
    {
        public bool checkDangNhap(string connectionString, string mathe, string pass)
        {
            const string query = "exec sp_GetAllUser";
            DataSet ds = new DataSet();
            string sothedt, passworddt, hoten, soTaiKhoan;
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    if (conn.State == System.Data.ConnectionState.Open)
                    {
                        using (SqlCommand cmd = conn.CreateCommand())
                        {
                            cmd.CommandText = query;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    sothedt = reader.GetString(1);
                                    passworddt = reader.GetString(0);
                                    hoten = reader.GetString(2);
                                    soTaiKhoan = reader.GetString(3);
                                    if (mathe == sothedt && pass == passworddt)
                                    {
                                        TaiKhoanDangNhap.hoVaTen = hoten;
                                        TaiKhoanDangNhap.maPIN = passworddt;
                                        TaiKhoanDangNhap.soThe = sothedt;
                                        TaiKhoanDangNhap.soTaiKhoan = soTaiKhoan;
                                        return true;
                                    }
                                }
                            }
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
            }
            return false;
        }
    }
}
