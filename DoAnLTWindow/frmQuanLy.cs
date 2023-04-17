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
            this.LoginAcc = acc;
            loadCategory();
        }
        #region METHODS
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
        void loadCategory()
        {
            List<Category> listCategory = CategoryDAO.Instance.getListCategory();
            cboCategory.DataSource = listCategory;
            cboCategory.DisplayMember = "NAME";
        }
        void loadFoodByCategory(int id)
        {
            List<Food> listFood = FoodDAO.Instance.getFoodList(id);
            cboFood.DataSource = listFood;
            cboFood.DisplayMember = "NAME";
        }
        
        

        #endregion
        #region EVENTS
        
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
            frmLogin f = new frmLogin();
            f.Show();
        }

        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccProfile f = new frmAccProfile(LoginAcc);

            f.ShowDialog();
        }
        
        
        private void cbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = 0;
            ComboBox cbo = sender as ComboBox;
            if (cbo.SelectedItem == null)
            {
                return;
            }
            Category selected = cbo.SelectedItem as Category;
            id = selected.ID;
            loadFoodByCategory(id);
        }
        #endregion

        
        private void frmQuanLy_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
    }

}
