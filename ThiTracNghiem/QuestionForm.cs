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
        public string trueQuestion;
        public bool CheckQuestion(string question)
        {
            return question == trueQuestion ? true : false;
        }
    }
}
