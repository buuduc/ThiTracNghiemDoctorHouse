using System;
using System.Windows;
using DevExpress.Xpf.Core;
using ThiTracNghiem.Properties;

namespace ThiTracNghiem
{
    /// <summary>
    ///     Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : ThemedWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            lb1.IsEnabled = true;
            ThoiGianLabel.IsEnabled = true;
            lb3.IsEnabled = true;
            ProjectLabel.Content = Settings.Default.MonThi;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var person = new Person
                {
                    name = HoTenLabel.Text,
                    MaSo = MaSoLabel.Text,
                    ViTri = ViTriLabel.Text,
                    SoCauHoi = Convert.ToInt32(SoCauLabel.Text),
                    monthi = Settings.Default.MonThi
                };
                if (checkbox.IsChecked == true) person.ThoiGian = Convert.ToInt32(ThoiGianLabel.Text);

                var dXWindow1 = new DXWindow1();
                dXWindow1.ps = person;
                dXWindow1.Show();
                Close();
            }
            catch (Exception exe)
            {
                MessageBox.Show(exe.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                throw;
            }
        }

        private void CheckBoxChanged(object sender, RoutedEventArgs e)
        {
            lb1.IsEnabled = !lb1.IsEnabled;
            ThoiGianLabel.IsEnabled = !ThoiGianLabel.IsEnabled;
            lb3.IsEnabled = !lb3.IsEnabled;
        }
    }
}