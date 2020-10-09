using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using DevExpress.Xpf.Core;

namespace ThiTracNghiem
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Person person = new Person()
            {
                name = HoTenLabel.Text,
                MaSo = MaSoLabel.Text,
                ViTri=ViTriLabel.Text,
                SoCauHoi=Convert.ToInt32(SoCauLabel.Text)
            };
            if (checkbox.IsChecked==true)
            {
                person.ThoiGian = Convert.ToInt32(ThoiGianLabel.Text);
            }
           
            DXWindow1 dXWindow1 = new DXWindow1();
            dXWindow1.ps = person;
            dXWindow1.Show();
            this.Close();
        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
           
            
                lb1.IsEnabled = !lb1.IsEnabled;
                ThoiGianLabel.IsEnabled = !ThoiGianLabel.IsEnabled;
                lb3.IsEnabled = !lb3.IsEnabled;

        }
    }
}
