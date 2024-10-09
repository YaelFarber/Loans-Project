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
using Windows.System;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace Gmach
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class All_Archive : Page
    {
        public All_Archive()
        {
            this.InitializeComponent();
            all_archive();
        }
        public async void all_archive()
        {
            //רשימה מקושרת של הלוואות שהוחזרו במלואן
            System.Collections.ObjectModel.ObservableCollection<Loan> loanList = await Global.proxy.ArchivedLoansAsync();

            //לולאת ,הלוואות שהגיעה מהשרת ויוצרת עבור כל הלוואה יוסרקונטרול
            foreach (Loan l in loanList)
            {
                UserControl_Loan lon = new UserControl_Loan(l);
                lon.Margin = new Thickness(10);
                gr.Items.Add(lon);       
            }
        }

   
    }
}
