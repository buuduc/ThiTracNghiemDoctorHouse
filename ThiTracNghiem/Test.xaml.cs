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
        internal SortedList listQuestion;
        public StackPanel Spanel;
        public  CauHoi KCauHoi;
        public Test()
        {
            InitializeComponent();
           
        }

        private void WDLoaded(object sender, RoutedEventArgs e)
        {
            stackpanel.Children.Add(Spanel);
            dcmm();
            
        }
        private void dcmm()
        {
            try
            {
                IsEnabled = false;
                var printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    
                    printDialog.PrintVisual(KetquaGrid, "invoice");
                }
            }
            finally
            {
               
                IsEnabled = true;
            }
        }
    }
}