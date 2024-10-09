using Gmach.MyProjectService;
using Microsoft.Toolkit.Uwp.UI.Controls;
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
    public sealed partial class The_Table : Page
    {
        DateTime startDate = DateTime.Now;
        //לווה נוכחי
        public MUser CurrentBorrower;
        public The_Table()
        {
            this.InitializeComponent();
            DataGrid dataGrid1 = new DataGrid();
            
            all_Borrowers();
            
        }
        public async void all_Borrowers()
        {
            //רשימה מקושרת של לווים מהשרת
            System.Collections.ObjectModel.ObservableCollection<MUser> borrowersList = await Global.proxy.GetUsersAsync();
           
            
        }
    }
}
