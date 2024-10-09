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
    public sealed partial class UserControl_Loan : UserControl
    {
        //הלוואה נוכחית
        public Loan CurrentLoan;
        public MUser CurrentBorrower;
        public UserControl_Loan()
        {
            this.InitializeComponent();
           
        }
        //בונה הלואה נוכחית
        public UserControl_Loan(Loan l) : this()
        {
            CurrentLoan = l;
            this.DataContext = CurrentLoan;
            if (CurrentLoan.Confirmed == false)
                txtmassage.Visibility = Visibility.Visible;

        }
        //בונה הלואה נוכחית לפי לווה
        public UserControl_Loan(MUser p) : this()
        {
            CurrentBorrower = p;
            this.DataContext = CurrentBorrower;
        }
    }
}
