using System.Data.SqlClient;
using System.Data;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DoAnLTWindow.DAO;
using System;
using DoAnLTWindow.DTO;
using System.Drawing;

namespace DoAnLTWindow
{
    public partial class frmAdmin : Form
    {

    }
}
    /*
        #region Food
        List<Food> searchFood(string name)
        {
            List<Food> listFood = FoodDAO.Instance.searchFoodByName(name);
            return listFood;
        }
        void loadListFood()
        {
            List<Food> pList = FoodDAO.Instance.showFood();
            dtgvFood.DataSource = pList;
            dtgvFood.Columns["IdCategory"].Visible = false;
        }
        void addFoodBinding()
        {
            txtFoodName.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "NAME", true, DataSourceUpdateMode.Never));
            txtFoodID.DataBindings.Add(new Binding("Text", dtgvFood.DataSource, "ID", true, DataSourceUpdateMode.Never));
            updFoodPrice.DataBindings.Add(new Binding("Value", dtgvFood.DataSource, "PRICE", true, DataSourceUpdateMode.Never));
        }    
        void loadFoodCategoryToComboBox(ComboBox cb)
        {
            cb.DataSource = CategoryDAO.Instance.getListCategory();
            cb.DisplayMember = "NAME";
        }
        private void btnShowFood_Click(object sender, EventArgs e)
        {
            loadListFood();
        }               
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int categoryID = (cboFoodCategory.SelectedItem as Category).ID;
            float price = (float)updFoodPrice.Value;
            int tmp = FoodDAO.Instance.insertFood(name, categoryID, price);
            if (tmp == 1)
            {
           
                MessageBox.Show("Đã thêm món ăn");
                loadListFood();
                if (insertFood != null)
                {
                    insertFood(this, new EventArgs());
                }
            }
            else if(tmp == 0)
            {
                MessageBox.Show("Món Ăn Đã Tồn Tại!!");
            }
            else
            {
                MessageBox.Show("Lỗi ! Vui lòng thử lại");
            }
  
        }
        private void btnEditFood_Click(object sender, EventArgs e)
        {
            string name = txtFoodName.Text;
            int categoryID = (cboFoodCategory.SelectedItem as Category).ID;
            float price = (float)updFoodPrice.Value;
            int id = Convert.ToInt32(txtFoodID.Text);
            if (FoodDAO.Instance.updateFood(id, name, categoryID, price))
            {
                MessageBox.Show("Đã sửa món ăn");
                loadListFood();
                if (updateFood != null)
                {
                    updateFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Lỗi ! Vui lòng thử lại");
            }
        }
        private void btnDeleteFood_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtFoodID.Text);
            if (FoodDAO.Instance.deleteFood(id))
            {
                MessageBox.Show("Đã xóa món ăn");
                loadListFood();
                if (deleteFood != null)
                {
                    deleteFood(this, new EventArgs());
                }
            }
            else
            {
                MessageBox.Show("Lỗi ! Vui lòng thử lại");
            }
        }
        private event EventHandler insertFood;
        public event EventHandler InsertFood
        {
            add
            {
                insertFood += value;
            }
            remove
            {
                insertFood -= value;
            }
        }
        private event EventHandler deleteFood;
        public event EventHandler DeleteFood
        {
            add
            {
                deleteFood += value;
            }
            remove
            {
                deleteFood -= value;
            }
        }
        private event EventHandler updateFood;
        public event EventHandler UpdateFood
        {
            add
            {
                updateFood += value;
            }
            remove
            {
                updateFood -= value;
            }
        }
        private void btnSearghFood_Click(object sender, EventArgs e)
        {
            List<Food> pData = searchFood(txtSearchFoodName.Text);
            if (pData.Count > 0)
                dtgvFood.DataSource = pData;
            else
                MessageBox.Show("Không Tìm Thấy Món!");

        }        
        private void txtFoodID_TextChanged(object sender, EventArgs e)
        {
            try
            {
                dtgvFood.TabIndex = 0;
                if (dtgvFood.SelectedCells.Count > 0)
                {
                    int id = (int)dtgvFood.SelectedCells[0].OwningRow.Cells["IdCategory"].Value;
                    Category category = CategoryDAO.Instance.getCategoryByID(id);
                    cboFoodCategory.SelectedItem = category;
                    int index = -1;
                    int i = 0;
                    foreach (Category item in cboFoodCategory.Items)
                    {
                        if (item.ID == category.ID)
                        {
                            index = i;
                            break;
                        }
                        i++;
                    }
                    cboFoodCategory.SelectedIndex = index;
                }
                }
            catch
            {
                return;
            }
            
           
        }
        #endregion
        #region Account
        void addAccBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "USERNAME", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DISPLAYNAME", true, DataSourceUpdateMode.Never));
            updAccType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "TYPE", true, DataSourceUpdateMode.Never));
        }
        void loadAcc()
        {
            AccountList.DataSource = AccDAO.Instance.getListAcc();
        }
        void addAcc(string username, string displayname, int type)
        {
            if(AccDAO.Instance.insertAcc(username, displayname, type))
            {
                MessageBox.Show("Thêm thành công");
            }
            else
            {
                MessageBox.Show("Lỗi ! Vui lòng thử lại");
            }
            loadAcc();
            
        }
        void editAcc(string username, string displayname, int type)
        {
            if (AccDAO.Instance.updateAcc(username, displayname, type))
            {
                MessageBox.Show("Sửa thành công");
            }
            else
            {
                MessageBox.Show("Lỗi ! Vui lòng thử lại");
            }
            loadAcc();

        }
        void deleteAccount(string username)
        {
            if (LoginAccount.Username.Equals(username))
            {
                MessageBox.Show("Tài khoản đang được sử dụng");
                return;
            }
            if (AccDAO.Instance.deleteAcc(username))
            {
                MessageBox.Show("Xóa thành công");
            }
            else
            {
                MessageBox.Show("Lỗi ! Vui lòng thử lại");
            }
            loadAcc();

        }
        void resetPassword(string username)
        {
            if (AccDAO.Instance.resetPass(username))
            {
                MessageBox.Show("Đặt lại mật khẩu thành công");
            }
            else
            {
                MessageBox.Show("Lỗi ! Vui lòng thử lại");
            }
            
        }
        private void btnShowAccount_Click(object sender, EventArgs e)
        {
            loadAcc();
        }
        private void btnAddAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = updAccType.Text == "ADMIN" ? 1 : 0;
            addAcc(username, displayname, type);
        }
        private void btnDeleteAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            deleteAccount(username);
        }
        private void btnEditAccount_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            string displayname = txtDisplayName.Text;
            int type = updAccType.Text == "ADMIN" ? 1 : 0;
            editAcc(username, displayname, type);
        }
        private void btnResetPass_Click(object sender, EventArgs e)
        {
            string username = txtUserName.Text;
            resetPassword(username);
        }
        #endregion        
        #region Bill
        private void btnViewBill_Click(object sender, System.EventArgs e)
        {
            loadBillList(dtpFromDate.Value, dtpToDate.Value);
        }
        void loadDateTimePickerBill()
        {
            DateTime today = DateTime.Now;
            dtpFromDate.Value = new DateTime(today.Year, today.Month, 1);
            dtpToDate.Value = dtpFromDate.Value.AddMonths(1).AddDays(-1);
        }
        void loadBillList (DateTime checkin, DateTime checkout)
        {
            dtgvBill.DataSource = BillDAO.Instance.getBillListByDate(checkin, checkout);
        }
        #endregion
        #region Table
        // Table
        void loadListTable()
        {
            List<Table> pTable  = TableDAO.Instance.loadTableList();
            TableList.DataSource = pTable;
            dtgvTable.Columns["Status2"].Visible = false;
        }
        void CBBTableData()
        {
            cbbTableStatus.Items.Add("Có Người");
            cbbTableStatus.Items.Add("Trống");
            cbbTableStatus.Items.Add("Đã Được Đặt");
            cbbTableStatus.Items.Add("Đã Thanh Toán");
        }
        void addTableBinding()
        {
            txtTableId.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "ID", true, DataSourceUpdateMode.Never));
            txtTableName.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Name", true, DataSourceUpdateMode.Never));
            cbbTableStatus.DataBindings.Add(new Binding("Text", dtgvTable.DataSource, "Status", true, DataSourceUpdateMode.Never));
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC INSERTTABLE_NONAME");
            loadListTable();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC DELETETABLE " + txtTableId.Text);
            loadListTable();
        }

        private void btnChange_Click(object sender, EventArgs e)
        {
            DataProvider.Instance.ExecuteNonQuery("EXEC UPDATETABLE @table_id , @table_name , @table_status", new object[] {txtTableId.Text, txtTableName.Text, cbbTableStatus.Text});
            loadListTable();
        }

        private void btnAddMany_Click(object sender, EventArgs e)
        {
            if (txtTableCount.Text.Length != 0)
            {
                DataProvider.Instance.ExecuteNonQuery("EXEC INSERTTABLE_MANY " + txtTableCount.Text);
            }
            loadListTable();
        }
        private void frmAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {
            pQL.loadTable();
            pQL.Show();
        }
    }
}
   
#endregion */
