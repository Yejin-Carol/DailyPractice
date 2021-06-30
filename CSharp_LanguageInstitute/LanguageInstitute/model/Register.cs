using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.model
{
    class Register
    {
        private Student stu;
        private Course crs;
        //Register Date = New Student
        private string inDate;
        private string staffName;
        //List for variable size
        private List<CrsItem> itemList;
        private int totalPrice;

        public Register(Student stu, Course crs, string inDate, string staffName, List<CrsItem> itemList, int totalPrice)
        {
            this.stu = stu;
            this.crs = crs;
            this.inDate = inDate;
            this.staffName = staffName;
            this.itemList = itemList;
            this.totalPrice = totalPrice;
        }

        public string InDate { get => inDate; set => inDate = value; }
        public string StaffName { get => staffName; set => staffName = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        internal Student Stu { get => stu; set => stu = value; }
        internal Course Crs { get => crs; set => crs = value; }
        internal List<CrsItem> ItemList { get => itemList; set => itemList = value; }
    }
}
