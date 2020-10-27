using System;
using System.Windows;
using System.Windows.Controls;
using DevExpress.Xpf.Core.HandleDecorator;

namespace ThiTracNghiem
{
    /// <summary>
    ///     Interaction logic for ReportWindow.xaml
    /// </summary>
    public partial class ReportWindow : Window
    {
        internal StackPanel ketquaStackPanel;
        internal Person ps;

        internal ReportWindow()
        {
            InitializeComponent();
        }

        private void ReportWindow_OnLoaded(object sender, RoutedEventArgs e)
        {
            AddInfor();
            TaoBaoCao();
        }

        private Test bangTest;

        private void TaoBaoCao()
        {
            bangTest = new Test() {ps = ps, Spanel = ketquaStackPanel};
        }

        private void AddInfor()
        {
            hotenlb.Text = ps.name;
            chucvulb.Text = ps.ViTri;
            masolb.Text = ps.MaSo;
            socaulb.Text = ps.SoCauHoi.ToString();
            thoigianlb.Text = ps.ThoiGian == 0 ? "Không giới hạn" : ps.ThoiGian + " phút";
            thoigianthuchienlb.Text = GetTime();
            DiemSoLb.Content = ps.Score + "/" + ps.SoCauHoi;
            STT.Content = ps.stt.ToString();
            ProjectLabel.Text = ps.monthi;
        }

        private string GetTime()
        {
            var time = ps.TimeUsed;
            var phut = Convert.ToInt32(time / 60);
            var giay = Convert.ToInt32(time % 60);
            var Tstring = "";
            Tstring += phut != 0 ? phut + " phút" : "";
            Tstring += giay != 0 ? giay + " giây" : "";
            return Tstring;
        }


        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
          bangTest.Show();
          
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
        //     try
        //     {
        //         IsEnabled = false;
        //         var printDialog = new PrintDialog();
        //         if (printDialog.ShowDialog() == true)
        //         {
        //             XuatPdfbtn.Visibility = Visibility.Hidden;
        //             exitbtn.Visibility = Visibility.Hidden;
        //             printDialog.PrintVisual(this, "invoice");
        //         }
        //     }
        //     finally
        //     {
        //         XuatPdfbtn.Visibility = Visibility.Visible;
        //         exitbtn.Visibility = Visibility.Visible;
        //         IsEnabled = true;
        //     }
        bangTest.Print("Result of "+ps.name+" "+ps.MaSo);
        }
    }
}