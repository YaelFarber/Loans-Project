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
    public sealed partial class LoanPayment : Page
    {
        public LoanPayment()
        {
            this.InitializeComponent();
        }
        public  LoanPayment(Loan l)
        {
            this.InitializeComponent();   
            loanPayment(l);
           
        }

        public async void loanPayment(Loan l)
        {
            int i = 1;
            //רשימה מקושרת של תשלומים מהשרת           
            System.Collections.ObjectModel.ObservableCollection<Payment> paymentsList = await Global.proxy.GetPaymentByLoanAsync(l);
            //לולאת תשלומים שהגיעה מהשרת ויוצרת עבור כל תשלום יוסרקונטרול
            foreach (Payment p in paymentsList)
            {
                UserControl_Payment pay = new UserControl_Payment(p, i++);
                pay.Margin = new Thickness(10);
                gr.Items.Add(pay);


            }
        }
        private void btnDone_Click(object sender, RoutedEventArgs e)
        {
            Loan l = ((UserControl_Loan)sender).CurrentLoan;
            l.AllLoanReturned = true;
            Global.proxy.UpdateLoanAsync(l);
            this.Frame.Navigate(typeof(All_Archive));
        }
    }
}
