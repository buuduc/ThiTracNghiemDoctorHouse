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
        public CauHoi(int index)
        {
            InitializeComponent();
            this.index = index;
        }

        private void UserControl_Loaded(object sender, RoutedEventArgs e)
        {
            QuestionData a = new QuestionData();
            var b =a.TakeQuestion(index);
            NoiDungText.Text = b.Content;
            Atext.Content = "A. "+  b.A;
            Btext.Content = "B. " + b.B;
            Ctext.Content = "C. " + b.C;
            Dtext.Content = "D. " + b.D;
        }
        public bool Check()
        {
            foreach (RadioButton item in stackPanel.Controls)
            {

            }
            return false;
        }
    }
}
