using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongATM_UWP.Models;

namespace HeThongATM_UWP.ViewModel
{
    class GiaoDichController
    {
        public bool rutTien(string connectionString, double tien)
        {
            string query = "exec sp_RutTien " + tien.ToString() + ", " + TaiKhoanDangNhap.soTaiKhoan;

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
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
            return true;
        }

        public string loadData(string connectionString)
        {
            const string query = "exec sp_GetInfoAllUser";
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
                            string sothedt;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    sothedt = reader.GetString(0);
                                    if (TaiKhoanDangNhap.soThe == sothedt)
                                    {
                                        return reader.GetDecimal(5).ToString();
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
            return "";
        }

        public bool checkTaiKhoanNhan(string connectionString, string matknhan)
        {
            const string query = "exec sp_GetInfoAllUser";
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
                            string matknhandt;
                            using (SqlDataReader reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    matknhandt = reader.GetString(3);
                                    if (matknhan == matknhandt)
                                    {
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

        public bool GuiTien(string connectionString, string tknhan, string tiengui)
        {
            string query = "exec sp_guiTien " + tiengui + ", " + TaiKhoanDangNhap.soTaiKhoan + ", " + tknhan;

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
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
            return true;
        }

        public bool NapTien(string connectionString, string tien)
        {
            string query = "exec sp_NapTien " + tien + ", " + TaiKhoanDangNhap.soTaiKhoan;

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
                            cmd.ExecuteNonQuery();
                        }
                    }
                    conn.Close();
                }
            }
            catch (Exception e)
            {
                Debug.Write(e.Message);
                return false;
            }
            return true;
        }
    }
}
