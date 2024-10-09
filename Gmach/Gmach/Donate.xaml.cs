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
    public sealed partial class Donate : Page
    {
        public Donate()
        {
            this.InitializeComponent();
        }

        private async void btnAddDonation_Click(object sender, RoutedEventArgs e)
        {
            Donation d = new Donation();
            d.dSum = Convert.ToInt32(txtSum.Text);
            d.Donor = txtID.Text;
            d.BankNum = txtBnkNum.Text;
            d.BankName = txtBnkNme.Text;
            d.dDate = txtDate.SelectedDate.Value.DateTime;
           await Global.proxy.AddDonationAsync(d);
            txtMassage.Text = "התרומה נוספה לרשימה בהצלחה!";
            stkp.Visibility = Visibility.Visible;
      
        }
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //מעבר מיידי חזרה לדף בו מוצגות התרומות        
            this.Frame.Navigate(typeof(All_Donors));
        }
    }
}
