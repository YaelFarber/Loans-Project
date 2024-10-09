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
    public sealed partial class New_Loan : Page
    {
        public  New_Loan()
        {
            this.InitializeComponent();
           
            Global.proxy = new MyProjectService.ServiceClient();
      
        }
        public event EventHandler SaveLoan;

        private async void btn_OK_Click(object sender, RoutedEventArgs e)
        {

            if (cmbArev1.Text.ToString() == cmbArev2.Text.ToString())
                cmbArev2.Text = "על מנת לקבל אישור עליך להביא 2 ערבים שונים!";
            else
            {
                MyProjectService.Loan askloan = new MyProjectService.Loan();

                if (cmbSum.SelectionBoxItem.ToString() == "10000")
                    askloan.LSum = 10000;
                else
                {
                    if (cmbSum.SelectionBoxItem.ToString() == "15000")
                        askloan.LSum = 15000;
                    else
                    {
                        if (cmbSum.SelectionBoxItem.ToString() == "20000")
                            askloan.LSum = 20000;
                        else
                        {
                            if (cmbSum.SelectionBoxItem.ToString() == "25000")
                                askloan.LSum = 25000;
                            else
                            {
                                if (cmbSum.SelectionBoxItem.ToString() == "30000")
                                    askloan.LSum = 30000;
                                else
                                    askloan.LSum = 35000;
                            }
                        }
                    }

                }
                askloan.VerbalSum = txtbVerbalSum.Text.ToString();
                //מוסיף את ההלוואה בהכרח למי שנרשם אחרון
                askloan.Borrower = await Global.proxy.GetUserByNameAsync(txtid.Text.ToString());
                askloan.AskDate = Currentdate.SelectedDate.Value.DateTime;
                askloan.FirstPayment = FirstPaymentDate.SelectedDate.Value.DateTime;
                askloan.PaymentsType = cmbTyp.SelectionBoxItem.ToString();
                askloan.PaymentsNum = Convert.ToInt32(NumofPayments.Text.ToString());                
                askloan.Neeman = (Neeman)cmbNeeman.SelectionBoxItem;
                askloan.RequestedDate = Getdate.SelectedDate.Value.DateTime;
                askloan.Arev1 = cmbArev1.Text.ToString();
                askloan.Arev2 = cmbArev2.Text.ToString();
                askloan.Confirmed = false;
                askloan.AllLoanReturned = false;
                await Global.proxy.AddLoanAsync(askloan);
                this. Content = new Asks();
            }

        }

        private async void Page_Loaded(object sender, RoutedEventArgs e)
        {
            cmbNeeman.ItemsSource = await Global.proxy.GetNeemanAsync();
        }

        private void ComboBoxItem_Tapped(object sender, TappedRoutedEventArgs e)
        {
            txtbVerbalSum.Text = "עשר אלף שח";
        }

        private void ComboBoxItem_Tapped_1(object sender, TappedRoutedEventArgs e)
        {
            txtbVerbalSum.Text = "חמישה עשר אלף שח";
        }

        private void ComboBoxItem_Tapped_2(object sender, TappedRoutedEventArgs e)
        {
            txtbVerbalSum.Text = "עשרים אלף שח";
        }

        private void ComboBoxItem_Tapped_3(object sender, TappedRoutedEventArgs e)
        {
            
            txtbVerbalSum.Text = "עשרים וחמישה אלף שח";
        }

        private void ComboBoxItem_Tapped_4(object sender, TappedRoutedEventArgs e)
        {
            txtbVerbalSum.Text = "שלושים אלף שח";
        }

        private void ComboBoxItem_Tapped_5(object sender, TappedRoutedEventArgs e)
        {
            txtbVerbalSum.Text = "שלושים וחמישה אלף שח";
        }
    }
}
