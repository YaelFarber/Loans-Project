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
    public sealed partial class UserControl_Donor : UserControl
    {
        public Donation CurrentDonor;
        public UserControl_Donor()
        {
            this.InitializeComponent();
        }
        //בונה תורם נוכחי
        public UserControl_Donor(Donation d) : this()
        {
            CurrentDonor = d;
            this.DataContext = CurrentDonor;
        }
    }
}
