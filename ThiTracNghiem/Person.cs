using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using ThiTracNghiem.VanPhongDataSetTableAdapters;

namespace ThiTracNghiem
{
    internal class Person
    {
        public SortedList listQuestion = new SortedList();
        public List<bool> ListResult = new List<bool>();
        public string MaSo;
        public string name;
        public int SoCauHoi;
        public int ThoiGian;
        public double TimeUsed;
        public string ViTri;

        public int Score
        {
            get { return ListResult.Where(x => x.Equals(true)).Count(); }
        }

        private List<int> RandomQuestion(int Max)
        {
            var list = Enumerable.Range(1, Max).ToList();
            list = list.OrderBy(a => Guid.NewGuid()).ToList();
            var STTCauHoi = list.GetRange(0, SoCauHoi);
            return STTCauHoi;
        }

        public void NapData(string password)
        {
            var vanPhongDataSet = new VanPhongDataSet();
            var vanPhongDataSetDatabaseTableAdapter = new DatabaseTableAdapter();
            vanPhongDataSetDatabaseTableAdapter.Connection.ConnectionString +=
                ";Jet OLEDB:Database Password=" + password;
            vanPhongDataSetDatabaseTableAdapter.Fill(vanPhongDataSet.Database);
            var i = 1;
            foreach (var item in RandomQuestion(vanPhongDataSet.Database.Count))
            {
                var qsdt = new QuestionData(vanPhongDataSet);
                var control = new CauHoi(item, i, qsdt);
                listQuestion.Add(i++, control); //day la usercontrol
            }
        }
    }
}