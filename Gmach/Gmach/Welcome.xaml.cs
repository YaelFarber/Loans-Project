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

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Welcome : Page
    {
        public Welcome()
        {
            this.InitializeComponent();
        }

        private void btnM_Click(object sender, RoutedEventArgs e)
        {
            wellcome.Visibility = Visibility.Visible;
            if (enter.Text == "1234")
            {
                stkP.Visibility = Visibility.Collapsed;
                wellcome.Text = "ברוך הבא!";
                Global.IsManager = true;
            }
            else
            {
               
                stkP.Visibility = Visibility.Collapsed;
                btnOK.Visibility = Visibility.Visible;
                wellcome.Text = "הסיסמה שגויה.נסה שוב.";

            }
                

        }


        private void btnOK_Click(object sender, RoutedEventArgs e)
        {
            btnOK.Visibility = Visibility.Collapsed;
            wellcome.Visibility = Visibility.Collapsed;
            stkP.Visibility = Visibility.Visible;
        }


 

       

        private void enter_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                wellcome.Visibility = Visibility.Visible;
                if (enter.Text == "1234")
                {
                    stkP.Visibility = Visibility.Collapsed;
                    wellcome.Text = "ברוך הבא!";
                    Global.IsManager = true;
                }
                else
                {

                    stkP.Visibility = Visibility.Collapsed;
                    btnOK.Visibility = Visibility.Visible;
                    wellcome.Text = "הסיסמה שגויה.נסה שוב.";

                }
            }
                
        }
    }
}
