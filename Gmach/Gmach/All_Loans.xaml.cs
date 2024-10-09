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
using System.Xml.Linq;
using System.Text.RegularExpressions;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class All_Loans : Page
    {
        public MUser u;
        public All_Loans( MUser user)
        {
            this.InitializeComponent();
            all_Loans(user);
            
        }
        
        public async void all_Loans(MUser user)
        {
            u = user;
            //רשימה מקושרת של הלוואות לפי הלווה מהשרת
            System.Collections.ObjectModel.ObservableCollection<Loan> loanList = await Global.proxy.GetLoanByUserAsync(user);

            //לולאת ,הלוואות שהגיעה מהשרת ויוצרת עבור כל הלוואה יוסרקונטרול
            foreach (Loan l in loanList)
            {
                UserControl_Loan lon = new UserControl_Loan(l);
                lon.Margin = new Thickness(10);
                gr.Items.Add(lon);
                //הןספת אירוע ליוסרקונטרול
                lon.Tapped += Lon_Tapped;

            }
        }

        private void Lon_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Loan l = new Loan();
            l = ((UserControl_Loan)sender).CurrentLoan;
            Content = new LoanPayment(l);         
        }
        






    }
}
