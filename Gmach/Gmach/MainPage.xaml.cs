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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            frmMenu.Navigate(typeof(Welcome));
        }

        private void nvmenu_BackRequested(NavigationView sender, NavigationViewBackRequestedEventArgs args)
        {
            if (frmMenu.CanGoBack)
                frmMenu.GoBack();
            
            
        }

        private void home_Tapped(object sender, TappedRoutedEventArgs e)
        {

            frmMenu.Navigate(typeof(Welcome));
        }

        private void search_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {

                frmMenu.Navigate(typeof( Welcome));
            }
            else
                frmMenu.Navigate(typeof(Search_Page));
        }

        private void askForLoan_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {

                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(New_Loan));
        }

        private void signIn_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {
;
                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(Sign_In));
        }

        private void confirmLoans_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {

                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(Asks));
        }

        private void borrowers_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {

                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(All_Borrowers));
        }

       

        private void donors_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {

                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(All_Donors));
        }

        //private void donate_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    if (!Global.IsManager)
        //    {

        //        frmMenu.Navigate(typeof(Welcome));
        //    }
        //    else
        //        frmMenu.Navigate(typeof(Donate));

        //}

       

        //private void logOut_Tapped(object sender, TappedRoutedEventArgs e)
        //{
        //    frmMenu.Navigate(typeof(Log_Out));
        //}

        private void AboutUs_Tapped(object sender, TappedRoutedEventArgs e)
        {
            frmMenu.Navigate(typeof(About_Us));
        }

        private void arvhived_Loan_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {
                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(All_Archive));
        }

        private void neemanim_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {
                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(All_Neeman));
        }

        private void table_Tapped(object sender, TappedRoutedEventArgs e)
        {
            if (!Global.IsManager)
            {
                frmMenu.Navigate(typeof(Welcome));
            }
            else
                frmMenu.Navigate(typeof(The_Table));
        }
    }
}

