using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThiTracNghiem
{
    class Person
    {
        public String name;
        public String MaSo;
        public String ViTri;
        public int SoCauHoi;
        public int ThoiGian;
        public System.Collections.SortedList listQuestion=new SortedList();
        public List<bool> ListResult = new List<bool>();
        public Person ()
        {
            
        }
        private List<int> RandomQuestion(int Max)
        {
            var list = Enumerable.Range(1, Max).ToList();
            list = list.OrderBy(a => Guid.NewGuid()).ToList();
            var STTCauHoi = list.GetRange(0, SoCauHoi);
            return STTCauHoi;
        }
        public void NapData()
        {
            
            ThiTracNghiem.VanPhongDataSet vanPhongDataSet = new ThiTracNghiem.VanPhongDataSet();
            ThiTracNghiem.VanPhongDataSetTableAdapters.DatabaseTableAdapter vanPhongDataSetDatabaseTableAdapter = new ThiTracNghiem.VanPhongDataSetTableAdapters.DatabaseTableAdapter();
            vanPhongDataSetDatabaseTableAdapter.Fill(vanPhongDataSet.Database);
            int i = 1;
            foreach (var item in RandomQuestion(vanPhongDataSet.Database.Count))
            {
                QuestionData qsdt = new QuestionData(vanPhongDataSet);
                CauHoi control = new CauHoi(item, i, qsdt);
                this.listQuestion.Add(i++, control); //day la usercontrol
                
            }
            
        }
        public int Score
        {
            get
            {
                return ListResult.Where(x => x.Equals(true)).Count();
            }
        }
              
    }
}
