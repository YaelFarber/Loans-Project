using Gmach.MyProjectService;
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
    public sealed partial class All_Neeman : Page
    {
        public All_Neeman()
        {
            this.InitializeComponent();
            all_Neemans();
        }
        private async void all_Neemans()
        {
            //רשימה מקושרת של תורמים מהשרת


            System.Collections.ObjectModel.ObservableCollection<Neeman> neemansList = await Global.proxy.GetNeemanAsync();

            //לולאת ,תורמים שהגיעה מהשרת ויוצרת עבור כל תורם יוסרקונטרול
            foreach (Neeman n in neemansList)
            {
                UserControl_Neeman ne = new UserControl_Neeman(n);
                ne.Margin = new Thickness(10);
                gr.Items.Add(ne);

            }

        }
        private void btnd_Click(object sender, RoutedEventArgs e)
        {

           frm.Navigate(typeof(New_Neeman));
        }
    }
}
