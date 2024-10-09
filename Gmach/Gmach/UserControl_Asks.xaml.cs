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
    public sealed partial class UserControl_Asks : UserControl
    {
        public Loan CurrentLoan;
        public UserControl_Asks()
        {
            this.InitializeComponent();
        }
        public UserControl_Asks(Loan l) : this()

        {
            InitializeComponent();
            CurrentLoan = l;
            this.DataContext = CurrentLoan;
        }
        public event EventHandler SaveLoan;


       

        private void OK_Click(object sender, RoutedEventArgs e)
        {
            if (SaveLoan != null)
                SaveLoan(this, null);
        }
    }
}
