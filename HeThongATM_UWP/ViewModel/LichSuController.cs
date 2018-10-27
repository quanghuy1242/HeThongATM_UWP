using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeThongATM_UWP.Models;

namespace HeThongATM_UWP.ViewModel
{
    class LichSuController
    {
        public ObservableCollection<LichSuModel> GetListLS(string connectionString)
        {
            string query = "exec sp_xemGiaoDich " + TaiKhoanDangNhap.soTaiKhoan;

            var LS = new ObservableCollection<LichSuModel>();
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
                                    var ls = new LichSuModel();
                                    ls.giaoDichID = reader.GetInt32(0);
                                    ls.ngayGD = reader.GetInt32(1);
                                    ls.gioiGD = reader.GetInt32(2);
                                    ls.loaiGD = reader.GetString(3);
                                    ls.soTien = reader.GetDecimal(4);
                                    ls.soDu = reader.GetDecimal(5);
                                    ls.soTaiKhoan = reader.GetString(6);
                                    try
                                    {
                                        ls.soTaiKhoanNhan = reader.GetString(7);
                                    }
                                    catch
                                    {
                                        ls.soTaiKhoanNhan = "";
                                    }
                                    

                                    LS.Add(ls);
                                }
                            }
                        }
                    }
                }
                return LS;
            }
            catch(Exception e)
            {
                Debug.Write(e.Message);
            }
            return null;
        }
    }
}
