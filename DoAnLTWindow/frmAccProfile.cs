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
        }
       /* Phần thay đổi
        void updateAccount()
        {
            string displayname = txtDisplayName.Text;

            string pass = txtPass.Text;
            string newpass = txtNewPass.Text.Replace(" ", "");
            string reenterpass = txtReEnterPass.Text;
            string username = txtUsername.Text;
            if (newpass.Length == 0)
            {
                MessageBox.Show("Mật khẩu mới không hợp lệ !");
            }
            else if (newpass != reenterpass)
            {
                MessageBox.Show("Vui lòng nhập lại mật khẩu khớp với mật khẩu mới !");
            }
            else if (newpass == pass)
            {
                MessageBox.Show("Mật khẩu mới trùng với mật khẩu cũ !");
            }
            else
            {
                if (AccDAO.Instance.updateAccountInfo(username, displayname, pass, newpass))
                {
                    MessageBox.Show("Cập nhật thành công !");
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đúng mật khẩu !");
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            updateAccount();
        }*/
    }
}
