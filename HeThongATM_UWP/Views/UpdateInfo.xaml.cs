using HeThongATM_UWP.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using HeThongATM_UWP.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HeThongATM_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class UpdateInfo : Page
    {
        public UpdateInfo()
        {
            this.InitializeComponent();
        }

        UpdateInfoController upInC = new UpdateInfoController();

        private async void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (txtoldPass.Text != TaiKhoanDangNhap.maPIN)
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thất bại",
                        Content = "Mã PIN cũ sai!",
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                    return;
                }

                if(txtnewPass.Text.Length != 6)
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thất bại",
                        Content = "Mã PIN mới phải đủ 6 ký tự!",
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                    return;
                }

                if(txtnewPass.Text != txtrePass.Text)
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thất bại",
                        Content = "Mã PIN nhập không trùng khớp!",
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                    return;
                }

                if (upInC.changePass((App.Current as App).ConnectionString, txtnewPass.Text))
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thành công",
                        Content = "Giao dịch thành công!",
                        CloseButtonText = "Ok"
                    };

                    txtnewPass.Text = "";
                    txtoldPass.Text = "";
                    txtrePass.Text = "";

                    await dialog.ShowAsync();
                }
                else
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thất bại",
                        Content = "Giao dịch thật bại!",
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                }
            }
            catch
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Thất bại",
                    Content = "Giao dịch thật bại do bạn đã bỏ trống trường nào đó!",
                    CloseButtonText = "Ok"
                };
                await dialog.ShowAsync();
            }
        }
    }
}
