using LanguageInstitute.common;
using LanguageInstitute.handler;
using LanguageInstitute.ui;
using MaterialSkin.Controls;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LanguageInstitute
{
    public partial class MainForm : MaterialForm
    {
        OraHandler ora;
        RegisterAdapter adapter;
        

        public MainForm()
        {
            InitializeComponent();
            CommUtil.initTheme(this);
            ora = new OraHandler();
            adapter = new RegisterAdapter(ora);
        }
    
        private void stu_RegisterInfo_Click(object sender, EventArgs e)
        {
            new NewStudent(adapter).ShowDialog();
            adapter.addRegisterDb();
           /* ora.insertDb();*/
        }

     /*   
        private void regView_Click(object sender, EventArgs e)
        {
            new RegisterView(adapter).ShowDialog();
        }
*/

        private void mainMin_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }
        private void mainExitbt_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void studyResources_Click(object sender, EventArgs e)
        {
            StudyResources youtube = new StudyResources();
            youtube.ShowDialog();
        }

        private void btnAdmin_Click(object sender, EventArgs e)
        {
            Login loginForm = new Login();
            loginForm.ShowDialog();
        }
    }
}
