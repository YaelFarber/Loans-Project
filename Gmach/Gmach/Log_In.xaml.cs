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
using Windows.UI.Xaml.Documents;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Log_In : Page
    {
        MyProjectService.ServiceClient proxy;
        public Log_In()
        {
            this.InitializeComponent();
            proxy = new ServiceClient();
        }
        //כניסת משתמש
        private async void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            Global.CurrentUser =   await proxy. GetUserByIDAsync(txtenterID.Text);
            if (Global.CurrentUser != null)
            {
                if (Global.CurrentUser.UserID == "326770468" || Global.CurrentUser.UserID == "060164415" || Global.CurrentUser.UserID == "028985380")
                {
                    txtMassege.Text = Global.CurrentUser.FirstName + "  " + Global.CurrentUser.LastName+ "\nברוך הבא !" + " \n    ";
                    
                }
                else
                {
                    txtMassege.Text = "     רק למנהלים יש אפשרות כניסה\nייתכן ויש לך טעות הקלדה, אנא נסה שנית";
                }
            }
            else
            {
                txtMassege.Text = " רק למנהלים יש אפשרות כניסה\nייתכן ויש לך טעות הקלדה, אנא נסה שנית";
            }
        }
    }
}
