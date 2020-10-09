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
using System.Windows.Shapes;
using System.Windows.Threading;
using DevExpress.Xpf.Core;


namespace ThiTracNghiem
{
    /// <summary>
    /// Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class DXWindow1 : System.Windows.Window
    {
        internal Person ps;
        private int Time;
        private System.Collections.SortedList listQuestion;
        public DXWindow1()
        {
            InitializeComponent();
        }
        
        
        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionPull();
            TimeCooldown();
            AddInfor();
        }
        void QuestionPull()
        {
            ps.NapData();
            listQuestion = ps.listQuestion;
            foreach (CauHoi item in listQuestion.Values)
            {

                stackpanel.Children.Add(item);
            }
        }
        void AddInfor()
        {
            hotenlb.Text = ps.name;
            chucvulb.Text = ps.ViTri;
            masolb.Text = ps.MaSo;
            socaulb.Text = ps.SoCauHoi.ToString();
            thoigianlb.Text = ps.ThoiGian == 0 ? "Không giới hạn": ps.ThoiGian.ToString() + " phút";
            

        }
        void TimeCooldown()
        {
            if (ps.ThoiGian != 0)
            {
                Time = ps.ThoiGian * 60;
                var timer = new DispatcherTimer();
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();

            }
            else
                TimeLabel.Content = "Không đếm giờ";
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Time--;
            TimeLabel.Content = string.Format("{0}:{1}", Time / 60, Time % 60);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            int diem = 0;
            foreach (CauHoi item in listQuestion.Values)
            {
                if (item.Check())
                {
                    diem += 1;
                }
                
            }
            MessageBox.Show(diem.ToString());
        }
    }
}
