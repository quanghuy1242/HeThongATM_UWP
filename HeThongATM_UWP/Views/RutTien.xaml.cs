﻿using System;
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
using HeThongATM_UWP.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HeThongATM_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class RutTien : Page
    {
        public RutTien()
        {
            this.InitializeComponent();
        }

        GiaoDichController GdC = new GiaoDichController();

        private async void btnRutTien_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtTienRut.Text)> Convert.ToDouble(txtTienDu.Text))
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thất bại",
                        Content = "Giao dịch thật bại do số tiền rút lớn hơn tiền có trong hệ thống",
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                    return;
                }

                if (Convert.ToDouble(txtTienRut.Text) <= 0)
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thất bại",
                        Content = "Giao dịch thật bại do số tiền nhập nhỏ hơn hoặc bằng 0",
                        CloseButtonText = "Ok"
                    };
                    await dialog.ShowAsync();
                    return;
                }

                if (GdC.rutTien((App.Current as App).ConnectionString, Convert.ToDouble(txtTienRut.Text)))
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thành công",
                        Content = "Bạn đã rút thành công " + txtTienRut.Text + " đồng",
                        CloseButtonText = "Ok"
                    };
                    txtTienDu.Text = GdC.loadData((App.Current as App).ConnectionString);
                    txtTienRut.Text = "";
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

        private void txtTienDu_Loaded(object sender, RoutedEventArgs e)
        {
            txtTienDu.Text = GdC.loadData((App.Current as App).ConnectionString);
        }
    }
}
