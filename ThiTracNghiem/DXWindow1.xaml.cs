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
using DevExpress.Xpf.Core;


namespace ThiTracNghiem
{
    /// <summary>
    /// Interaction logic for DXWindow1.xaml
    /// </summary>
    public partial class DXWindow1 : ThemedWindow
    {
        public DXWindow1()
        {
            InitializeComponent();
        }
        System.Collections.SortedList listQuestion;
        private void ThemedWindow_Loaded(object sender, RoutedEventArgs e)
        {
            listQuestion = new System.Collections.SortedList();
            //CauHoi a = new CauHoi();
            for (int i = 1; i <=30; i++)
            {
                CauHoi control = new CauHoi(i);
                listQuestion.Add(i, control);
                stackpanel.Children.Add(control);
            }
        }

      
    }
}
