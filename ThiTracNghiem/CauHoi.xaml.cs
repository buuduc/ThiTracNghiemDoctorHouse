using System.Collections;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace ThiTracNghiem
{
    /// <summary>
    ///     Interaction logic for CauHoi.xaml
    /// </summary>
    public partial class CauHoi : UserControl
    {
        internal int indexData;
        internal SortedList ListAnswer;
        internal QuestionData questiondata;
        internal int stt;
        internal int truequestion;

        public CauHoi CloneCauHoi()
        {
            CauHoi cloneCauHoi = new CauHoi(indexData,stt,questiondata);
            cloneCauHoi.indexAnswer = indexAnswer;
            return cloneCauHoi;
        }
        internal CauHoi(int indexData, int stt, QuestionData questiondata)
        {
            InitializeComponent();
            this.indexData = indexData;
            this.stt = stt;
            this.questiondata = questiondata;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            var b = questiondata.TakeQuestion(indexData);
            NoiDungText.Text = "Câu " + stt + ": " + b.Content;
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

        private int indexAnswer = 0;
        public bool Check()
        {
            var index = 0;
            foreach (RadioButton item in AnswerPanel.Children)
            {
                index++;
                if (item.IsChecked == true)
                    if (index == truequestion)
                        return true;
            }

            indexAnswer = index;
            return false;
        }

        public void AddAnswer()
        {
            var index = 0;
            foreach (RadioButton item in AnswerPanel.Children)
            {
                index++;
                if (index ==indexAnswer)
                {
                    item.IsChecked = true;
                }
            }
        }



        private void RadioCheck(object sender, RoutedEventArgs e)
        {
            stackPanel.Background = new SolidColorBrush(Colors.White);
        }

        public void Report()
        {
           int  index = 0;
            var bc = new BrushConverter();
            foreach (RadioButton item in AnswerPanel.Children)
            {
                index++;
                if (item.IsChecked == true) item.Foreground = new SolidColorBrush(Colors.Red);
                if (index == truequestion) item.Foreground = new SolidColorBrush(Colors.Green);
            }
        }
    }
}