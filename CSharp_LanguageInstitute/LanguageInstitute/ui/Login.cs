using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageInstitute.ui
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }

        //PW에 Enter Key가 입력되면 btnLogin_Click 호출
        private void textPW_KeyDown(object sender, KeyEventArgs e)
        {
            btnLogIn_Click(sender, e);
            btnLogIn.Select();
        }

        private void btnLogIn_Click(object sender, EventArgs e)
        {
            string ID = textID.Text;
            string PW = textPW.Text;

            if (EmptyCheck())
            {
               if(ID == "admin" && PW == "1234")
                {
                    //로그인 성공시 DialogResult Ok 후 로그인 창 닫힘
                    this.DialogResult = DialogResult.OK;
                    this.Close();
                }
               else
                {
                   MessageBox.Show("죄송합니다. ID와 비밀번호가 올바르지 않습니다.");
                }
            }
        }
        private bool EmptyCheck()
        {
            if(String.IsNullOrEmpty(textID.Text))
            {
                MessageBox.Show("사용자명을 입력해 주세요");
                textID.Focus();
                return false;
            }
            else if (String.IsNullOrEmpty(textPW.Text))
            {
                MessageBox.Show("비밀번호를 입력해 주세요");
                textPW.Focus();
                return false;
            }
            return true;
        }     
       

    }
}
