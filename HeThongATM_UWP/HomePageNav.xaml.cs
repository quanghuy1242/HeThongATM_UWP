using HeThongATM_UWP.Views;
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
using HeThongATM_UWP.Models;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace HeThongATM_UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class HomePageNav : Page
    {
        public HomePageNav()
        {
            this.InitializeComponent();
            this.DataContext = new DangNhapModel() { hoVaTen = TaiKhoanDangNhap.hoVaTen };
        }
        #region NavigationView event handlers
        private void nvTopNav_Loaded(object sender, RoutedEventArgs e)
        {
            foreach (NavigationViewItemBase item in nvTopNav.MenuItems)
            {
                if (item is NavigationViewItem && item.Tag.ToString() == "Home")
                {
                    nvTopNav.SelectedItem = item;
                    break;
                }
            }
            contentFrame.Navigate(typeof(Homepage));
        }

        internal void nvTopNav_ItemInvoked(Homepage homepage, NavigationViewItemInvokedEventArgs navigationViewItemInvokedEventArgs)
        {
            throw new NotImplementedException();
        }

        private void nvTopNav_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                TextBlock itemContent = args.SelectedItem as TextBlock;
                if (itemContent != null)
                {
                    switch (itemContent.Tag)
                    {
                        case "nav_Home":
                            contentFrame.Navigate(typeof(Homepage));
                            break;

                        case "nav_SendMoney":
                            contentFrame.Navigate(typeof(GuiTien));
                            break;

                        case "nav_RutMoney":
                            contentFrame.Navigate(typeof(RutTien));
                            break;

                        case "nav_NapMoney":
                            contentFrame.Navigate(typeof(NapTien));
                            break;

                        case "nav_UpdateInfo":
                            contentFrame.Navigate(typeof(UpdateInfo));
                            break;

                        case "nav_History":
                            contentFrame.Navigate(typeof(HistoryView));
                            break;
                    }
                }
            }
        }

        public void nvTopNav_ItemInvoked(NavigationView sender, NavigationViewItemInvokedEventArgs args)
        {
            if (args.IsSettingsInvoked)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                TextBlock itemContent = args.InvokedItem as TextBlock;
                if (itemContent != null)
                {
                    switch (itemContent.Tag)
                    {
                        case "nav_Home":
                            contentFrame.Navigate(typeof(Homepage));
                            break;

                        case "nav_SendMoney":
                            contentFrame.Navigate(typeof(GuiTien));
                            break;

                        case "nav_RutMoney":
                            contentFrame.Navigate(typeof(RutTien));
                            break;

                        case "nav_NapMoney":
                            contentFrame.Navigate(typeof(NapTien));
                            break;

                        case "nav_UpdateInfo":
                            contentFrame.Navigate(typeof(UpdateInfo));
                            break;

                        case "nav_History":
                            contentFrame.Navigate(typeof(HistoryView));
                            break;
                    }
                }
            }
        }
        #endregion
    }
}
