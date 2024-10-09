using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Gmach.MyProjectService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Search_Page : Page
    {
        public Search_Page()
        {
            this.InitializeComponent();
        }
        //חיפוש לפי תעודת זהות
        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            skp1.Visibility = Visibility.Visible;
            skp2.Visibility = Visibility.Visible;
            MUser u =await Global.proxy.GetUserByNameAsync(srch.Text);
            if (u == null)
                srch.Text = "יש לך טעות הקלדה, תקן ונסה שוב";
            else
            {
                tId.Text = u.UserID;
                tuser.Text = u.FirstLastName;    
                taddress.Text = u.uAddress;
                tphone.Text = u.Phone1;
                tphone2.Text = u.Phone2;
                tmail.Text = u.uMail;
                tneeman.IsChecked = u.IsNeeman == true;
            }

        }

        private async void btnd_Click(object sender, RoutedEventArgs e)
        {
            MUser u = await Global.proxy.GetUserByNameAsync(srch.Text);
            this.Content = new All_Loans(u);
        }

        private async void srch_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                skp1.Visibility = Visibility.Visible;
                skp2.Visibility = Visibility.Visible;
                MUser u = await Global.proxy.GetUserByNameAsync(srch.Text);
                if (u == null)
                    srch.Text = "יש לך טעות הקלדה, תקן ונסה שוב";
                else
                {
                    tId.Text = u.UserID;
                    tuser.Text = u.FirstLastName;
                    taddress.Text = u.uAddress;
                    tphone.Text = u.Phone1;
                    tphone2.Text = u.Phone2;
                    tmail.Text = u.uMail;
                    tneeman.IsChecked = u.IsNeeman == true;
                }
            }
        }
    }
}
