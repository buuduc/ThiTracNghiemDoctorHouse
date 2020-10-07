using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiTracNghiem
{
    class QuestionData
    {
        ThiTracNghiem.VanPhongDataSet vanPhongDataSet;
        public QuestionData()
        {

            vanPhongDataSet = new ThiTracNghiem.VanPhongDataSet();
            ThiTracNghiem.VanPhongDataSetTableAdapters.DatabaseTableAdapter vanPhongDataSetDatabaseTableAdapter = new ThiTracNghiem.VanPhongDataSetTableAdapters.DatabaseTableAdapter();
            vanPhongDataSetDatabaseTableAdapter.Fill(vanPhongDataSet.Database);
            



        }
        public QuestionForm TakeQuestion(int ID)
        {
            var data = vanPhongDataSet.Database.Rows.Find(ID);
            QuestionForm question = new QuestionForm()
            {
                Content = ((ThiTracNghiem.VanPhongDataSet.DatabaseRow)data).NoiDung,
                A = ((ThiTracNghiem.VanPhongDataSet.DatabaseRow)data).TraLoi1,
                B = ((ThiTracNghiem.VanPhongDataSet.DatabaseRow)data).TraLoi2,
                C = ((ThiTracNghiem.VanPhongDataSet.DatabaseRow)data).TraLoi3,
                D = ((ThiTracNghiem.VanPhongDataSet.DatabaseRow)data).TraLoi4,
                trueQuestion = ((ThiTracNghiem.VanPhongDataSet.DatabaseRow)data).DapAnDung

            };
            
            return question;
        }
    }
}
