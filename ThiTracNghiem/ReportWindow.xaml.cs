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

        private void Button_Click(object sender, RoutedEventArgs e)
        //{
        //    var dialog = new SaveFileDialog();

        //    dialog.AddExtension = true;
        //    dialog.DefaultExt = "pdf";
        //    dialog.Filter = "PDF Document (*.pdf)|*.pdf";
        //    dialog.FileName = "xxxReport_" + Utility.FormatDate(DateTime.Now).Replace("/", "_");

        //    if (dialog.ShowDialog() == false)
        //        return;

        //    FixedDocument fixedDoc = new FixedDocument();
        //    PageContent pageContent = new PageContent();
        //    FixedPage fixedPage = new FixedPage();

        //    PrintDialog printDlg = new PrintDialog();
        //    Size pageSize = new Size(printDlg.PrintableAreaWidth, printDlg.PrintableAreaHeight - 100);
        //    _reportBorder.Measure(pageSize);
        //    _reportBorder.Arrange(new Rect(10, 50, pageSize.Width, pageSize.Height));

        //    //Create first page of document
        //    fixedPage.Children.Add(_reportBorder);
        //    ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
        //    fixedDoc.Pages.Add(pageContent);

        //    // write to PDF file
        //    string tempFilename = "temp.xps";
        //    File.Delete(tempFilename);
        //    XpsDocument xpsDoc = new XpsDocument(tempFilename, FileAccess.Write);
        //    XpsDocumentWriter xWriter = XpsDocument.CreateXpsDocumentWriter(xpsDoc);
        //    xWriter.Write(fixedDoc.DocumentPaginator);
        //    xpsDoc.Close();

        //    PdfSharp.Xps.XpsConverter.Convert(tempFilename, path, 0);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            this.Close();

        }
    }
}
