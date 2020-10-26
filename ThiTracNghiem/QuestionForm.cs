namespace ThiTracNghiem
{
    internal class QuestionForm
    {
        public string A;
        public string B;
        public string C;
        public string Content;
        public string D;
        public int ID;
        public int trueQuestion;

        public bool CheckQuestion(int question)
        {
            return question == trueQuestion ? true : false;
        }
    }
}