using LanguageInstitute.handler;
using LanguageInstitute.model;
using LanguageInstitute.util;
using MaterialSkin.Controls;
using Sunny.UI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageInstitute.ui
{
    partial class NewStudent : MaterialForm
    {
        RegisterAdapter adapter;
        public NewStudent()
        {
            InitializeComponent();
        }

        public NewStudent(RegisterAdapter adapter)
        {
            InitializeComponent();
            this.adapter = adapter;
        }
              

        private void newStuSave_Click(object sender, EventArgs e)
        {
            string name = stuName.Text;
            string telH = stuTelH.SelectedText;
            string telB = stuTelB.Text;
            string year = stuYear.SelectedText;
            string month = stuMonth.SelectedText;
            string day = stuDay.SelectedText;
            string emailId = stuEmailId.Text;
            string emailD = stuEmailD.SelectedText;
            string staff = staffName.SelectedText;
            string crs_name = subject.SelectedText;
            string crs_level = level.SelectedText;
            string semester = period.SelectedText;
                       
           
            string[] arrData = new string[]
            {
                name, telH, telB, year, month, 
                day, emailId, emailD, staff,
                crs_name, crs_level, semester
             };

            //누락시 포커스 정보
            object[] arrObj = new object[]
            {
                stuName, stuTelH, stuTelB, stuYear, stuMonth,
                stuDay, stuEmailId, stuEmailD, staffName,
                subject, level, period
            };

            string[] arrMsg = new string[]
            {
                "이름을 입력하세요",
                "전화번호 앞자리를 선택하세요",
                "전화번호 뒷자리를 선택하세요",
                "년도를 선택하세요",
                "월을 선택하세요",
                "일을 선택하세요",
                "이메일 ID를 선택하세요",
                "이메일 도메인을 선택하세요",
                "담당강사를 선택하세요.",
                "수강과목을 선택하세요.",
                "수강레벨을 선택하세요.",
                "수강학기를 선택하세요."
            };

            Dictionary<object, string> dicInput = new Dictionary<object, string>();
            for(int i=0; i<arrData.Length; i++)
            {
                dicInput.Add(arrObj[i], arrData[i]);
            }

            int cnt = 0;
            foreach(KeyValuePair<object, string> item in dicInput)
            {
                if(item.Value.Equals("") || item.Value.Equals("선택"))
                {
                    setFocus(item.Key as Control, arrMsg[cnt]);
                    return;
                }
                cnt++;
            }

            UICheckBox[] checkBox = new UICheckBox[]
            {
                engB, engI, engA, spaB, spaI, spaA
            };

            int sum = 0;
            List<CrsItem> itemList = new List<CrsItem>();
            for (int i = CourseTable.ENGLISH_ONEBYONE; i < CourseTable.SPANISH_LESSTHANTEN+1; i++)
            {
                if (checkBox[i].Checked)
                {
                    Console.WriteLine("강의형태:" + checkBox[i].Text);
                    Console.WriteLine("수강료: " + CourseTable.fixPrice[i]);
                    itemList.Add(new CrsItem(i, checkBox[i].Text, CourseTable.fixPrice[i]));
                    sum += CourseTable.fixPrice[i];
                }
            }

            if (itemList.Count == 0)//체크 박스 체크 안했으면
            {
                MessageBox.Show("강의 형태를 체크하세요");
                return;//반복문 break
            }

            //한글 입력 체크
            Regex regex =
                    new Regex(@"^[가-힣]{2,4}$"); //Regex 정규표현식(서버 언어 모두 적용가능, 한글이 아니면 공백
            Match m = regex.Match(name);
            if (m.Success == false)
            {
                setFocus(stuName, Properties.Resources.ERR_NAME_WRONG);
                return;
            }

            // 전화번호 체크
            string telAll = telH + telB;
            if (telAll.Length == 10 || telAll.Length == 11)//자리수 체크
            {
                Regex regex2 =
                    new Regex(@"01{1}[016]{1}[0-9]{7,8}");
                Match m2 = regex2.Match(telAll);
                if (m2.Success == false)
                {
                    MessageBox.Show("잘못된 전화번호");
                    return;
                }
            }
            else
            {
                MessageBox.Show("올바른 전화번호 자리수를 입력하세요");
                return;
            }

            adapter.addRegister(new Register(
                new Student(name, telH+telB, year+month+day, emailId+emailD),
                new Course(crs_name, crs_level, semester),
                DateTime.Now.ToString("yyyy년MM월dd일"),
                staff, itemList, sum));

            Close();
        }

        private void setFocus(Control cont, string msg)
        {
            MessageBox.Show(msg);
            ActiveControl = cont;
            ActiveControl.Focus();
            cont.Text = "";

        }

        private void stuClose_Click(object sender, EventArgs e)
        {
            Close();
        }




    }
}
