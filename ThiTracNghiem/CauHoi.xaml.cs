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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ThiTracNghiem
{
    /// <summary>
    /// Interaction logic for CauHoi.xaml
    /// </summary>
    public partial class CauHoi : UserControl
    {
        int index;
        int stt;
        QuestionData questiondata;
        internal CauHoi(int index, int stt, QuestionData questiondata)
        {
            InitializeComponent();
            this.index = index;
            this.stt = stt;
            this.questiondata = questiondata;
        }
        private int truequestion;
        private System.Collections.SortedList ListAnswer;
        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {


            var b = questiondata.TakeQuestion(index);
            NoiDungText.Text = "Câu " + stt.ToString() + ": " + b.Content;
            Atext.Content = "A. " + b.A;
            Btext.Content = "B. " + b.B;
            Ctext.Content = "C. " + b.C;
            Dtext.Content = "D. " + b.D;
            truequestion = b.trueQuestion;


        }
        private void test()
        {
            Atext.IsChecked = true;
            Report();


        }
        public bool Check()
        {
            int index = 0;
            foreach (RadioButton item in AnswerPanel.Children)
            {
                index++;
                if (item.IsChecked == true)
                {
                    if (index == truequestion)
                    {
                        return true;
                    }

                }
            }
            return false;
        }

        private void RadioCheck(object sender, RoutedEventArgs e)
        {
            stackPanel.Background = new SolidColorBrush(Colors.White);
        }
        public void Report()
        {
           
            index = 0;
            var bc = new BrushConverter();
            foreach (RadioButton item in AnswerPanel.Children)
            {
                index++;
                if (item.IsChecked == true)
                {
                    item.Foreground = new SolidColorBrush(Colors.Red);

                }
                if (index == truequestion)
                {
                    item.Foreground = new SolidColorBrush(Colors.Green);


                }
            }
        }
    }
}
