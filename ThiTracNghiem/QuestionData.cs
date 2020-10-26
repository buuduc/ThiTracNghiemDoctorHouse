using System;

namespace ThiTracNghiem
{
    internal class QuestionData
    {
        private  VanPhongDataSet dataSet;

        public QuestionData(VanPhongDataSet dataSet)
        {
            this.dataSet = dataSet;
        }

        public QuestionForm TakeQuestion(int ID)
        {
            var data = dataSet.Database.Rows.Find(ID);
            var question = new QuestionForm
            {
                Content = ((VanPhongDataSet.DatabaseRow) data).NoiDung,
                A = ((VanPhongDataSet.DatabaseRow) data).TraLoi1,
                B = ((VanPhongDataSet.DatabaseRow) data).TraLoi2,
                C = ((VanPhongDataSet.DatabaseRow) data).TraLoi3,
                D = ((VanPhongDataSet.DatabaseRow) data).TraLoi4,
                trueQuestion = Convert.ToInt32(((VanPhongDataSet.DatabaseRow) data).DapAnDung)
            };

            return question;
        }
    }
}