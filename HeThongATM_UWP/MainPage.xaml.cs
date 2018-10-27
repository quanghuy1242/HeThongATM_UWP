using HeThongATM_UWP.Models;
using HeThongATM_UWP.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Data.SqlClient;
using System.Diagnostics;
using System.Data;
using Windows.UI.Popups;
using HeThongATM_UWP.ViewModel;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace HeThongATM_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    /// 
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        DangNhap dnC = new DangNhap();

        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (dnC.checkDangNhap((App.Current as App).ConnectionString, txtMaSo.Text, txtPass.Password.ToString()))
                {
                    this.Frame.Navigate(typeof(HomePageNav));
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thành công",
                        Content = "Xin chào! " + TaiKhoanDangNhap.hoVaTen,
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                }
                else
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Error",
                        Content = "Đã xảy ra lỗi",
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                }
            }
            catch
            {
                ContentDialog dialog = new ContentDialog()
                {
                    Title = "Error",
                    Content = "Đã xảy ra lỗi",
                    CloseButtonText = "Ok"
                };
                await dialog.ShowAsync();
            }
        }
    }
}
