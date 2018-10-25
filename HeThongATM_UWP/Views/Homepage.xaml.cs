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
    public sealed partial class Homepage : Page
    {
        public Homepage()
        {
            this.InitializeComponent();
        }

        private void GridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            Grid tb = e.ClickedItem as Grid;
            Frame contentF = Window.Current.Content as Frame;
            HomePageNav homePageNav = contentF.Content as HomePageNav;
            switch (tb.Tag)
            {
                case "N_home":
                    foreach (NavigationViewItemBase item in homePageNav.nvTopNav.MenuItems)
                    {
                        if (item is NavigationViewItem && item.Tag.ToString() == "Home")
                        {
                            homePageNav.nvTopNav.SelectedItem = item;
                            break;
                        }
                    }
                    homePageNav.contentFrame.Navigate(typeof(Homepage));
                    break;
                    
                    

                case "N_guitien":
                    foreach (NavigationViewItemBase item in homePageNav.nvTopNav.MenuItems)
                    {
                        if (item is NavigationViewItem && item.Tag.ToString() == "SendMoney")
                        {
                            homePageNav.nvTopNav.SelectedItem = item;
                            break;
                        }
                    }
                    homePageNav.contentFrame.Navigate(typeof(GuiTien));
                    break;

                case "N_ruttien":
                    foreach (NavigationViewItemBase item in homePageNav.nvTopNav.MenuItems)
                    {
                        if (item is NavigationViewItem && item.Tag.ToString() == "RutMoney")
                        {
                            homePageNav.nvTopNav.SelectedItem = item;
                            break;
                        }
                    }
                    homePageNav.contentFrame.Navigate(typeof(RutTien));
                    break;

                case "N_naptien":
                    foreach (NavigationViewItemBase item in homePageNav.nvTopNav.MenuItems)
                    {
                        if (item is NavigationViewItem && item.Tag.ToString() == "NapMoney")
                        {
                            homePageNav.nvTopNav.SelectedItem = item;
                            break;
                        }
                    }
                    homePageNav.contentFrame.Navigate(typeof(NapTien));
                    break;

                case "N_capnhat":
                    foreach (NavigationViewItemBase item in homePageNav.nvTopNav.MenuItems)
                    {
                        if (item is NavigationViewItem && item.Tag.ToString() == "UpdateInfo")
                        {
                            homePageNav.nvTopNav.SelectedItem = item;
                            break;
                        }
                    }
                    homePageNav.contentFrame.Navigate(typeof(UpdateInfo));
                    break;

                case "N_listsu":
                    foreach (NavigationViewItemBase item in homePageNav.nvTopNav.MenuItems)
                    {
                        if (item is NavigationViewItem && item.Tag.ToString() == "History")
                        {
                            homePageNav.nvTopNav.SelectedItem = item;
                            break;
                        }
                    }
                    homePageNav.contentFrame.Navigate(typeof(HistoryView));
                    break;
            }
        }
    }
}
