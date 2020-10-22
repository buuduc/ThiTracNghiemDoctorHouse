using System;
using System.Collections.Generic;
using System.IO;
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
using OfficeOpenXml;

namespace ThiTracNghiem
{
    /// <summary>
    /// Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class DXWindow1 : System.Windows.Window
    {
        internal Person ps;
        private TimeSpan Time;
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
            ps.NapData("buuduc123");
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
        DispatcherTimer timer = new DispatcherTimer();
        void TimeCooldown()
        {
            if (ps.ThoiGian != 0)
            {
                Time = new TimeSpan(0, ps.ThoiGian,0);
                
                timer.Interval = TimeSpan.FromSeconds(1);
                timer.Tick += timer_Tick;
                timer.Start();

            }
            else
            {
                TimeLabel.FontSize = 30;
                TimeLabel.Content = "KHÔNG ĐẾM GIỜ";
            }
        }
        void timer_Tick(object sender, EventArgs e)
        {
            Time=Time.Subtract(new TimeSpan(0, 0, 1));
            TimeLabel.Content = Time.ToString(@"mm\:ss");
            if (Time.TotalSeconds <= 0)
            {
                MessageBox.Show("Đã hết thời gian làm bài", "THÔNG BÁO!", MessageBoxButton.OK, MessageBoxImage.Information);
                Submit();
                
            }
        }
        private void Submit()
        {
            timer.Stop();
            foreach (CauHoi item in listQuestion.Values)
            {
                item.Report();
            }
            ps.TimeUsed = Math.Round((double)(ps.ThoiGian * 60 - Time.TotalSeconds),0);
            int diem = 0;
            foreach (CauHoi item in listQuestion.Values)
            {
                if (item.Check())
                {
                    diem += 1;
                    ps.ListResult.Add(true);
                }
                else
                    ps.ListResult.Add(false);
            }
            //this.RemoveVisualChild(this.stackpanel);
            //this.RemoveLogicalChild(this.stackpanel);
            ReportWindow report = new ReportWindow(ps);
            NopBaibtn.IsEnabled = false;
            
            this.IsEnabled = false;
            report.Show();
            this.IsEnabled = true;

            //MessageBox.Show(ps.Score.ToString());
        }
        private void SetData()
        {
            ExcelWorksheet workSheet;

            using (ExcelPackage MaNS = new ExcelPackage(new FileInfo(Properties.Settings.Default.PathOfReportExcel)))
            //using (ExcelPackage MaNS = new ExcelPackage(new FileInfo(@"D:\TEMP\Score.xlsx")))
            {
                // lấy ra sheet đầu tiên để thao tác
                workSheet = MaNS.Workbook.Worksheets[0];
                int start = workSheet.Dimension.Start.Row;
                int end = workSheet.Dimension.End.Row;
                int row = end + 1;
                int col = 1;
                workSheet.Cells[row, col++].Value = end-start+1;
                workSheet.Cells[row, col++].Value = ps.MaSo;
                workSheet.Cells[row, col++].Value = ps.name;
                workSheet.Cells[row, col++].Value = ps.ViTri;
                workSheet.Cells[row, col++].Value = ps.Score.ToString() + "/"+ ps.SoCauHoi.ToString();
                workSheet.Cells[row, col++].Value = ps.ThoiGian;
                workSheet.Cells[row, col++].Value = ps.TimeUsed;
                workSheet.Cells[row, col++].Value = ps.SoCauHoi;
                MaNS.Save();


            }
        }
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
            var answer = MessageBox.Show(" Bạn có chắc chắn muốn nộp bài ! \n Hành động này không thể hoàn tác !", "THÔNG BÁO", MessageBoxButton.YesNo,MessageBoxImage.Question);
            if (answer == MessageBoxResult.Yes)

            {
                try
                {
                    Submit();
                    SetData();
                }
                catch (Exception exe)
                {
                    MessageBox.Show(exe.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    throw;
                }
                
            }
            
        }
    }
}
