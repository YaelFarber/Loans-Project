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
using System.Reflection;


// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class All_Borrowers : Page
    {
        public All_Borrowers()
        {
            this.InitializeComponent();
            all_Borrowers();
        }
        public async void all_Borrowers()
        {
            //רשימה מקושרת של לווים מהשרת
            System.Collections.ObjectModel.ObservableCollection<MUser> borrowersList = await Global.proxy.GetUsersAsync();

            //לולאת לווים שהגיעה מהשרת ויוצרת עבור כל לווה יוסרקונטרול
            foreach (MUser b in borrowersList)
            {
                UserControl_Borrowers bor = new UserControl_Borrowers(b);
                bor.Margin = new Thickness(1);
                
                gr.Items.Add(bor);
                //הוספת אירוע ליוסרקונטרול
                bor.Tapped += Bor_Tapped;
            }
        }

         private void Bor_Tapped(object sender, TappedRoutedEventArgs e)
        {
            MUser u = new MUser();
            u=((UserControl_Borrowers)sender).CurrentBorrower;
            this.Frame.Content = new All_Loans(u);
           // frm.Navigate(typeof(All_Loans), new All_Loans(u));
        }


        //private async void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    MUser u =await Global.proxy.GetUserByNameAsync(srch.Text);
        //    if (u != null)
        //    {
        //        UserControl_Borrowers bor = new UserControl_Borrowers(u);
        //        bor.Margin = new Thickness(10);
        //        gr.Items.Clear();
        //        gr.Items.Add(bor);
        //        //הוספת אירוע ליוסרקונטרול
        //        bor.Tapped += Bor_Tapped;
        //    }
        //}

        //private void srch_TextChanged(object sender, TextChangedEventArgs e)
        //{
        //    msg.Visibility = Visibility.Collapsed;
        //}

       

    }
}
