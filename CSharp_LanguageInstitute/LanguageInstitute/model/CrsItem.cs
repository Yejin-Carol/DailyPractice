using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.model
{
    class CrsItem
    {
        private int idx;
        private string crsName;
        private int price;

        public CrsItem(int idx, string crsName, int price)
        {
            this.idx = idx;
            this.crsName = crsName;
            this.price = price;
        }

        public int Idx { get => idx; set => idx = value; }
        public string CrsName { get => crsName; set => crsName = value; }
        public int Price { get => price; set => price = value; }
    }
}
