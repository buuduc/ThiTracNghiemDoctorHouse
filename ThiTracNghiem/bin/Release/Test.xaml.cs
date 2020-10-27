using System;
using System.Collections;
using System.Windows;
using System.Windows.Controls;

namespace ThiTracNghiem
{
    /// <summary>
    ///     Interaction logic for Test.xaml
    /// </summary>
    public partial class Test : Window
    {
        public CauHoi KCauHoi;
        internal SortedList listQuestion;
        internal Person ps;
        public StackPanel Spanel;

        public Test()
        {
            InitializeComponent();
        }

        private void WDLoaded(object sender, RoutedEventArgs e)
        {
            AddKetqua();
            AddInfor();
            
        }

        private void AddKetqua()
        {
            if (Properties.Settings.Default.XemDapAn)
            {
                 stackpanel.Children.Add(Spanel);
                 stackpanel.Visibility = Visibility.Visible;
            }
               
            else
            {
                stackpanel.Visibility = Visibility.Hidden;
            }

        }

        private void AddInfor()
        {
            hotenlb.Text = ps.name;
            chucvulb.Text = ps.ViTri;
            masolb.Text = ps.MaSo;
            socaulb.Text = ps.SoCauHoi.ToString() + "câu hỏi";
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
        public void Print(string descrition)
        {
            try
            {
                IsEnabled = false;
                var printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true) printDialog.PrintVisual(KetquaGrid, descrition);
            }
            finally
            {
                IsEnabled = true;
            }
        }
    }
}