using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.model
{
    class Course
    {
        private string crs_name; //수강 과목
        private string crs_level; //레벨
        private string semester; //수강 학기

        public Course(string crs_name, string crs_level, string semester)
        {
            this.crs_name = crs_name;
            this.crs_level = crs_level;
            this.semester = semester;
        }

        public string Crs_name { get => crs_name; set => crs_name = value; }
        public string Crs_level { get => crs_level; set => crs_level = value; }
        public string Semester { get => semester; set => semester = value; }
    }
}
