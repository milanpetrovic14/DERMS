using DermsUI.Model;
using DermsUI.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using DermsUI.Model;
using DermsUI.ViewModel;
using MahApps.Metro.Controls;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using GMap.NET;
using GMap.NET.WindowsForms;
using GMap.NET.WindowsForms.Markers;
using GMap.NET.ObjectModel;
using GMap.NET.WindowsForms.ToolTips;

namespace DermsUI.View
{
    /// <summary>
    /// Interaction logic for HomeWindow.xaml
    /// </summary>
    public partial class HomeWindow : MetroWindow
    {
        public HomeWindow()
        {
            InitializeComponent();

            GMapp.MapProvider = GMap.NET.MapProviders.GoogleMapProvider.Instance;
            GMap.NET.GMaps.Instance.Mode = GMap.NET.AccessMode.ServerOnly;
            GMapp.ShowCenter = true;

            GMapp.DragButton = System.Windows.Input.MouseButton.Left;
            GMapp.Position = new PointLatLng(45.2516700, 19.8369400);
        }

        private void RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri));
            e.Handled = true;
        }

        private void UIElement_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            var sample = (SampleVm)((Border)sender).DataContext;
            var hvm = (HomeViewModel)DataContext;
            hvm.Content = (UserControl)Activator.CreateInstance(sample.Content);
            hvm.IsMenuOpen = false;
        }

        private void UIElement_OnMouseDown2(object sender, MouseButtonEventArgs e)
        {
            var sample = (SampleVm)((Border)sender).DataContext;
            var hvm = (HomeViewModel)DataContext;
            hvm.Content2 = (UserControl)Activator.CreateInstance(sample.Content);
            hvm.IsMenuOpen2 = false;
        }

        private void UIElement_OnMouseDown3(object sender, MouseButtonEventArgs e)
        {
            var sample = (SampleVm)((Border)sender).DataContext;
            var hvm = (HomeViewModel)DataContext;
            hvm.Content3 = (UserControl)Activator.CreateInstance(sample.Content);
            hvm.IsMenuOpen3 = false;
        }

        private void UIElement_OnMouseDown4(object sender, MouseButtonEventArgs e)
        {
            var sample = (SampleVm)((Border)sender).DataContext;
            var hvm = (HomeViewModel)DataContext;
            hvm.Content4 = (UserControl)Activator.CreateInstance(sample.Content);
            hvm.IsMenuOpen4 = false;
        }
    }
}
