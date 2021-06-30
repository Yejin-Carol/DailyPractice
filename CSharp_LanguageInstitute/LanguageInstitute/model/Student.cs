using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.model
{
    class Student
    {
        private string name;
        private string tel;
        private string birth;
        private string email;

        public Student(string name, string tel, string birth, string email)
        {
            this.name = name;
            this.tel = tel;
            this.birth = birth;
            this.email = email;
        }

        public string Name { get => name; set => name = value; }
        public string Tel { get => tel; set => tel = value; }
        public string Birth { get => birth; set => birth = value; }
        public string Email { get => email; set => email = value; }
    }
}
