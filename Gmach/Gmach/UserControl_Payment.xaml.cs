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

// The User Control item template is documented at https://go.microsoft.com/fwlink/?LinkId=234236

namespace Gmach
{
    public sealed partial class UserControl_Payment : UserControl
    {
        public Payment CurrentPayment;
        public Payment payy;
        public MUser CurrentBorrower;
        public UserControl_Payment()
        {
            this.InitializeComponent();
        }
        //בונה תשלום נוכחי לפי תשלום
        public UserControl_Payment(Payment p, int i) : this()
        {
            CurrentPayment = p;
            this.DataContext = CurrentPayment;

            txtNumPay.Text = i.ToString();

        }
        //בונה תשלום נוכחי לפי לווה
        public UserControl_Payment(MUser p) : this()
        {
            CurrentBorrower = p;
            this.DataContext = CurrentPayment;

        }


        //פעולה האומרת האם התשלום הוחזר במלואו או שחזר צ'ק
        private async void CheckBox_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = CurrentPayment;
            if (checkReturned.IsChecked == true)
                paid.IsChecked = false;
          await  Global.proxy.UpdatePaymentAsync(CurrentPayment);


        }

        private async void paid_Click(object sender, RoutedEventArgs e)
        {
            this.DataContext = CurrentPayment;
            if (paid.IsChecked == true)
                checkReturned.IsChecked = false;
            await Global.proxy.UpdatePaymentAsync(CurrentPayment);

        }
    }
}
