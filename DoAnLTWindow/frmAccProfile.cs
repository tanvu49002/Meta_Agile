using DoAnLTWindow.DAO;
using DoAnLTWindow.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTWindow
{
    public partial class frmAccProfile : Form
    {
        /* Phần thay đổi
        private Account loginAcc;
        public Account LoginAcc
        {
            get
            {
                return loginAcc;
            }
            set
            {
                loginAcc = value;
                typeAcc(loginAcc);
            }
        }
        public frmAccProfile(Account acc)
        {
            InitializeComponent();
            LoginAcc = acc;
        }
        void typeAcc(Account acc)
        {
            txtUsername.Text = LoginAcc.Username;
            txtDisplayName.Text = LoginAcc.Displayname;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }*/
    }
}
