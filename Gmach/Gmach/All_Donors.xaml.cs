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
using Gmach.MyProjectService;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class All_Donors : Page
    {
        public All_Donors()
        {
            this.InitializeComponent();
            all_Donors();
        }
        private async void all_Donors ()
        {
            //רשימה מקושרת של תורמים מהשרת
     

          System.Collections.ObjectModel.ObservableCollection<Donation> donorsList = await Global.proxy.GetDonationAsync();

            //לולאת ,תורמים שהגיעה מהשרת ויוצרת עבור כל תורם יוסרקונטרול
            foreach (Donation d in donorsList)
            {
                UserControl_Donor don = new UserControl_Donor(d);
                don.Margin = new Thickness(10);
                gr.Items.Add(don);

            }
        }
        private void btnd_Click(object sender, RoutedEventArgs e)
        {
      
            
                frm.Navigate(typeof (Donate));
            
        }
    }
}
