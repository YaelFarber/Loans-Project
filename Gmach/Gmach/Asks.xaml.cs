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
    public sealed partial class Asks : Page
    {
        public Asks()
        {
            this.InitializeComponent();
            ShowLoan();
        }
        public async void ShowLoan()
        {
            //רשימה מקושרת של הלוואות המחכות לאישור מהשרת

            System.Collections.ObjectModel.ObservableCollection<Loan> AskingloansList = await Global.proxy.GetLoanForConfirmAsync();
            //לולאת הבקשות שהגיעה מהשרת ויוצרת עבור כל בקשת הלואה לא מאושרת יוסרקונטרול
            foreach (Loan b in AskingloansList)
            {
                UserControl_Asks lon = new UserControl_Asks(b);
                lon.Margin = new Thickness(10);
                lon.SaveLoan += Lon_SaveLoan;
                gr.Items.Add(lon);
            }
        }
        //פעולה השומרת הלואה שאושרה ומעדכנת את היוזר קונטרול להצגה של הלואות שעוד לא אושרו
        private async void Lon_SaveLoan(object sender, EventArgs e)
        {
            
            Loan l = ((UserControl_Asks)sender).CurrentLoan;
            l.Confirmed = true;
            await Global.proxy.UpdateLoanAsync(l);
            gr.Items.Clear();
            ShowLoan();

            //הוספת תשלומים להלואה
            for (int i = 0; i < l.PaymentsNum; i++)
            {
                Payment p = new Payment();
                p.pAsk = l;
                p.pReturnedSum = l.LSum / l.PaymentsNum;
                p.pDate = l.FirstPayment.Date.AddMonths(i);
                if (DateTime.Now.Month == p.pDate.Month)
                {
                    p.Paid = true;
                    Global.pNUM = i++;
                    p.ReturnedCheck = false;
                }

                else
                {
                    p.Paid = false;
                    p.ReturnedCheck = false;
                }

                await Global.proxy.AddPaymentAsync(p);
                Global.pSUM = i;
            }
            
        }
    }
}
