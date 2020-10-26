using System;
using System.Collections;
using System.IO;
using System.Windows;
using System.Windows.Threading;
using DevExpress.Xpf.Core;
using OfficeOpenXml;
using ThiTracNghiem.Properties;

namespace ThiTracNghiem
{
    /// <summary>
    ///     Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class DXWindow1 : Window
    {
        private readonly DispatcherTimer timer = new DispatcherTimer();
        internal SortedList listQuestion;
        internal Person ps;
        private TimeSpan Time;

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

        private void QuestionPull()
        {
            ps.NapData("buuduc123");
            listQuestion = ps.listQuestion;
            foreach (CauHoi item in listQuestion.Values) stackpanel.Children.Add(item);
        }

        private void AddInfor()
        {
            hotenlb.Text = ps.name;
            chucvulb.Text = ps.ViTri;
            masolb.Text = ps.MaSo;
            socaulb.Text = ps.SoCauHoi.ToString();
            thoigianlb.Text = ps.ThoiGian == 0 ? "Không giới hạn" : ps.ThoiGian + " phút";
        }

        private void TimeCooldown()
        {
            if (ps.ThoiGian != 0)
            {
                Time = new TimeSpan(0, ps.ThoiGian, 0);

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

        private void timer_Tick(object sender, EventArgs e)
        {
            Time = Time.Subtract(new TimeSpan(0, 0, 1));
            TimeLabel.Content = Time.ToString(@"mm\:ss");
            if (Time.TotalSeconds <= 0)
            {
                MessageBox.Show("Đã hết thời gian làm bài", "THÔNG BÁO!", MessageBoxButton.OK,
                    MessageBoxImage.Information);
                Submit();
            }
        }

        private void Submit()
        {
            timer.Stop();
            foreach (CauHoi item in listQuestion.Values) item.Report();
            ps.TimeUsed = Math.Round(ps.ThoiGian * 60 - Time.TotalSeconds, 0);
            var diem = 0;
            foreach (CauHoi item in listQuestion.Values)
                if (item.Check())
                {
                    diem += 1;
                    ps.ListResult.Add(true);
                }
                else
                {
                    ps.ListResult.Add(false);
                }

            //this.RemoveVisualChild(this.stackpanel);
            //this.RemoveLogicalChild(this.stackpanel);
            var report = new ReportWindow {ps = ps};
            NopBaibtn.IsEnabled = false;

            IsEnabled = false;
            report.Show();
            IsEnabled = true;

            //MessageBox.Show(ps.Score.ToString());
        }

        private void SetData()
        {
            ExcelWorksheet workSheet;
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using (var MaNS = new ExcelPackage(new FileInfo(Settings.Default.PathOfReportExcel)))
                //using (ExcelPackage MaNS = new ExcelPackage(new FileInfo(@"D:\TEMP\Score.xlsx")))
            {
                // lấy ra sheet đầu tiên để thao tác
                workSheet = MaNS.Workbook.Worksheets[0];
                var start = workSheet.Dimension.Start.Row;
                var end = workSheet.Dimension.End.Row;
                var row = end + 1;
                var col = 1;
                workSheet.Cells[row, col++].Value = end - start + 1;
                workSheet.Cells[row, col++].Value = ps.MaSo;
                workSheet.Cells[row, col++].Value = ps.name;
                workSheet.Cells[row, col++].Value = ps.ViTri;
                workSheet.Cells[row, col++].Value = ps.Score + "/" + ps.SoCauHoi;
                workSheet.Cells[row, col++].Value = ps.ThoiGian + " phút";
                workSheet.Cells[row, col++].Value = new TimeSpan(0, 0, (int) ps.TimeUsed).ToString(@"mm\:ss");
                workSheet.Cells[row, col++].Value = ps.SoCauHoi;
                MaNS.Save();
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // var answer = MessageBox.Show(" Bạn có chắc chắn muốn nộp bài ! \n Hành động này không thể hoàn tác !",
            //     "THÔNG BÁO", MessageBoxButton.YesNo, MessageBoxImage.Question);
            // if (answer == MessageBoxResult.Yes)
            //
            //     try
            //     {
            //         Submit();
            //         SetData();
            //     }
            //     catch (Exception exe)
            //     {
            //         MessageBox.Show(exe.ToString(), "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            //         throw;
            //     }


            // StackPanel SPnel = new StackPanel();
            // grid1.Children.Remove(SCviewer);
            // this.RemoveLogicalChild(item);
            // this.RemoveVisualChild(stackpanel);
            // foreach (CauHoi item in listQuestion.Values)
            // {
            //     this.RemoveLogicalChild(stackpanel);
            //
            // }


            Submit();
            stackpanel.RemoveFromVisualTree();

            var a = new Test {Spanel = stackpanel};
            a.Show();
            Close();


            // // stackpanel.RemoveFromVisualTree();
            // StackPanel cStackPanel = new StackPanel();
            //
            // List<CauHoi> ctrls = new List<CauHoi>();
            // // foreach (CauHoi c in stackpanel.Children)
            // // {
            // //
            // //     cStackPanel.Children.Add(c);
            // //    
            // // }
            // //
            // // // this.stackpanel.Children.Clear();
            // //  cStackPanel.Children = stackpanel.Children;
            //
        }
    }
}