using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.model
{
    class RegVO
    {
        private string indate;
        private int totalPrice;
        private string stuName;
        private string crsItem;
        private string staffName;

        public RegVO(string indate, int totalPrice, string stuName, string crsItem, string staffName)
        {
            this.indate = indate;
            this.totalPrice = totalPrice;
            this.stuName = stuName;
            this.crsItem = crsItem;
            this.staffName = staffName;
        }

        public string Indate { get => indate; set => indate = value; }
        public int TotalPrice { get => totalPrice; set => totalPrice = value; }
        public string StuName { get => stuName; set => stuName = value; }
        public string CrsItem { get => crsItem; set => crsItem = value; }
        public string StaffName { get => staffName; set => staffName = value; }
    }
}
