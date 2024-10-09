using Gmach.MyProjectService;
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
    public sealed partial class New_Neeman : Page
    {
        public New_Neeman()
        {
            this.InitializeComponent();
        }

        private async void btnAddNeeman_Click(object sender, RoutedEventArgs e)
        {
            Neeman d = new Neeman();
            d.nFirstLastName =txtName.Text;
            d.nPhone1 = txt1.Text;
            d.nPhone2 = txt2.Text;
            d.nCommunity = txt3.Text;
            await Global.proxy.AddNeemanAsync(d);
            txtMassage.Text = "הנאמן נוספה לרשימה בהצלחה!";
            stkp.Visibility = Visibility.Visible;
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            //מעבר מיידי חזרה לדף בו מוצגות התרומות        
            this.Frame.Navigate(typeof(All_Neeman));
        }
    }
}
