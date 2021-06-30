using LanguageInstitute.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LanguageInstitute.handler
{
    class RegisterAdapter
    {
        private List<Register> registerList = new List<Register>();
        private OraHandler ora;

        public RegisterAdapter(OraHandler ora)
        {
            this.ora = ora;
        }

        public void addRegister(Register register)
        {
            registerList.Add(register);
        }

        public void addRegisterDb()
        {
            for (int i = 0; i<registerList.Count; i++)
            {
                ora.insertDb(registerList[i]);
            }
            registerList.Clear();
        }

        public void viewRegister()
        {
            for (int i = 0; i<registerList.Count; i++)
            {
                Student stu = registerList[i].Stu;
                Console.WriteLine("학생이름: " + stu.Name);
                Console.WriteLine("전화번호: " + stu.Tel);
                Console.WriteLine("생년월일: " + stu.Birth);
                Console.WriteLine("이메일: " + stu.Email);

                Course crs = registerList[i].Crs;
                Console.WriteLine("수강과목: " + crs.Crs_name);
                Console.WriteLine("수강레벨: " + crs.Crs_level);
                Console.WriteLine("수강학기: " + crs.Semester);

                Console.WriteLine("담당교수: " + registerList[i].StaffName);
                Console.WriteLine("수강등록일: " + registerList[i].InDate);

                List<CrsItem> itemList = registerList[i].ItemList;
                for (int j = 0; j < itemList.Count; j++)
                {
                    Console.WriteLine("과목번호: " + itemList[j].Idx);
                    Console.WriteLine("과목명(레벨): " + itemList[j].CrsName);
                    Console.WriteLine("수강료: " + itemList[j].Price);
                }
            }
        }
        public void viewRegisterDb()
        {
            ora.showDb();
        }
             
    }
}
