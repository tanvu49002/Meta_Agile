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
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }
        bool Login(string username, string pass)
        {
            return AccDAO.Instance.Login(username, pass);
        }
        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string pass = txtPass.Text;
            if (Login(username, pass))
            {
                Account loginAcc = AccDAO.Instance.getAccByUsername(username);

                this.Hide();

                frmQuanLy f = new frmQuanLy(loginAcc);
                
                f.ShowDialog();

                this.Close();
            } 
            else if (username == "" || pass == "")
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không được để trống!");
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng !");
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thực sự muốn thoát khỏi chương trình ?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }

        }
    }
}
