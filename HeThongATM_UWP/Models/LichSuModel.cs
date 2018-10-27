using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeThongATM_UWP.Models
{
    class LichSuModel : INotifyPropertyChanged
    {
        public int giaoDichID { get; set; }
        public int ngayGD { get; set; }
        public int gioiGD { get; set; }
        public string loaiGD { get; set; }
        public decimal soTien { get; set; }
        public decimal soDu { get; set; }
        public string soTaiKhoan { get; set; }
        public string soTaiKhoanNhan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
