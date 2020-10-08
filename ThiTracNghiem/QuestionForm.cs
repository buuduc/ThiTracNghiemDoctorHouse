using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiTracNghiem
{
    class QuestionForm
    {
        public int ID;
        public string Content;
        public string A;
        public string B;
        public string C;
        public string D;
        public int trueQuestion;
        public bool CheckQuestion(int question)
        {
            return question == trueQuestion ? true : false;
        }
    }
}
