using HeThongATM_UWP.ViewModel;
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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HeThongATM_UWP.Views
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class NapTien : Page
    {
        public NapTien()
        {
            this.InitializeComponent();
        }

        GiaoDichController GdC = new GiaoDichController();

        private void txtTienDu_Loaded(object sender, RoutedEventArgs e)
        {
            txtTienDu.Text = GdC.loadData((App.Current as App).ConnectionString);
        }

        private async void btnNapTien_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (Convert.ToDouble(txtTienNap.Text) <= 0)
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

                if (GdC.NapTien((App.Current as App).ConnectionString, txtTienNap.Text))
                {
                    ContentDialog dialog = new ContentDialog()
                    {
                        Title = "Thành công",
                        Content = "Bạn đã nạp thành công " + txtTienNap.Text + " đồng",
                        CloseButtonText = "Ok"
                    };
                    txtTienDu.Text = GdC.loadData((App.Current as App).ConnectionString);
                    txtTienNap.Text = "";
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
