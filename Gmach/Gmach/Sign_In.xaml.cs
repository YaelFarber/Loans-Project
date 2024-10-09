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
    public sealed partial class Sign_In : Page
    {
        public Sign_In()
        {
            this.InitializeComponent();
        }
        //הוספת משתמש חדש
        private void btnAddUser_Click(object sender, RoutedEventArgs e)
        {
            MyProjectService.MUser user = new MyProjectService.MUser();
            Neeman neeman = new Neeman();
            user.UserID = txtID.Text;
            user.FirstLastName = txtFLName.Text;
           
            user.Phone1 = txtPHone1.Text;
            user.Phone2 = txtPHone2.Text;
            user.uAddress = txtAdress.Text;
            user.uMail = txtMail.Text;
            if (txtNeeman.IsChecked == true)
            {
                user.IsNeeman = true;
                neeman.nFirstLastName = txtFLName.Text;
                neeman.nPhone1 = txtPHone1.Text;
                neeman.nPhone2 = txtPHone2.Text;
                neeman.nCommunity = txtAdress.Text;
                Global.proxy.AddNeemanAsync(neeman);
            }
            Global.proxy.AddUserAsync(user);
            Global.LastUser = user;
            txtMassage.Visibility = Visibility.Visible;
            txtMassage.Text = "נוספת בהצלחה! תודה רבה!";
        }
        //מעבר להלוואה
        private void btnAddLoan_Click(object sender, RoutedEventArgs e)
        {
            this.Content = new New_Loan();
        }
    }
}
