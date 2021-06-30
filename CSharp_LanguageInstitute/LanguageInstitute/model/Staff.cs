using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.model
{
    class Staff
    {
        private string name;
        private string tel;
        private string address;
        private string birth;
        private string rank;
        private string workType;
        private string salary;

        public Staff(string name, string tel, string address, string birth, string rank, string workType, string salary)
        {
            this.name = name;
            this.tel = tel;
            this.address = address;
            this.birth = birth;
            this.rank = rank;
            this.workType = workType;
            this.salary = salary;
        }

        public string Name { get => name; set => name = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Address { get => address; set => address = value; }
        public string Birth { get => birth; set => birth = value; }
        public string Rank { get => rank; set => rank = value; }
        public string WorkType { get => workType; set => workType = value; }
        public string Salary { get => salary; set => salary = value; }
    }
}
