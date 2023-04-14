using DoAnLTWindow.DAO;
using DoAnLTWindow.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DoAnLTWindow
{
    public partial class frmQuanLy : Form
    {


        private int curr_idTable;
        private bool isSaved;
        private bool isAddedFood;
        private Button oldButton = null;
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
                typeAcc(loginAcc.Type);
            }
        }
        public frmQuanLy(Account acc)
        {
            InitializeComponent();
            curr_idTable = -1;
            isSaved = false;
            isAddedFood = false;
            this.LoginAcc = acc;
         
        }
        void typeAcc(string type)
        {
            if (type == "ADMIN")
                mnuAdmin.Enabled = true;
            else
            {
                mnuAdmin.Enabled = false;
            }
            mnuTaiKhoan.Text += " (" + LoginAcc.Displayname + ")";
        }
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
