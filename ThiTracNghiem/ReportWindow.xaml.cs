using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace ThiTracNghiem
{
    /// <summary>
    /// Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        Person ps;
        
        internal ReportWindow(Person ps)
        {
            InitializeComponent();
            this.ps = ps;
            AddInfor();
            
        }
        
        void AddInfor()
        {
            hotenlb.Text = ps.name;
            chucvulb.Text = ps.ViTri;
            masolb.Text = ps.MaSo;
            socaulb.Text = ps.SoCauHoi.ToString();
            thoigianlb.Text = ps.ThoiGian == 0 ? "Không giới hạn" : ps.ThoiGian.ToString() + " phút";
            thoigianthuchienlb.Text = this.GetTime();
            DiemSoLb.Content = ps.Score + "/" + ps.SoCauHoi;

        }
        private string GetTime()
        {
            double time = ps.TimeUsed;
            int phut = Convert.ToInt32(time / 60);
            int giay = Convert.ToInt32(time % 60);
            string Tstring = "";
            Tstring += phut != 0 ? phut.ToString() + " phút" : "";
            Tstring += giay != 0 ? giay.ToString() + " giây" : "";
            return Tstring;

        }

       

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    XuatPdfbtn.Visibility= System.Windows.Visibility.Hidden;
                    exitbtn.Visibility = System.Windows.Visibility.Hidden;
                    printDialog.PrintVisual(this, "invoice");
                }
            }
            finally
            {
                XuatPdfbtn.Visibility = System.Windows.Visibility.Visible;
                exitbtn.Visibility = System.Windows.Visibility.Visible;
                this.IsEnabled = true;
            }
        }
    }
}
