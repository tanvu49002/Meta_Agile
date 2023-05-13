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
        public Account LoginAccount;
        frmQuanLy pQL;
        public frmAdmin(frmQuanLy QL)
        {
            pQL = QL;
            InitializeComponent();
            //load data
            loadDateTimePickerBill();
            loadBillList(dtpFromDate.Value, dtpToDate.Value);
            loadListFood();
            loadAcc();
            //binding data
            loadFoodCategoryToComboBox(cboFoodCategory);
            addFoodBinding();
            addAccBinding();

        }
        #region Food
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
        void loadAcc()
        {
            dtgvAccount.DataSource = AccDAO.Instance.getListAcc();
        }
        void addAccBinding()
        {
            txtUserName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "USERNAME", true, DataSourceUpdateMode.Never));
            txtDisplayName.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "DISPLAYNAME", true, DataSourceUpdateMode.Never));
            updAccType.DataBindings.Add(new Binding("Text", dtgvAccount.DataSource, "TYPE", true, DataSourceUpdateMode.Never));
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
        void loadBillList(DateTime checkin, DateTime checkout)
        {
            dtgvBill.DataSource = BillDAO.Instance.getBillListByDate(checkin, checkout);
        }
        void loadPaidBills()
        {
            dtgvBill.DataSource = BillDAO.Instance.loadPaidBills();
        }
        #endregion
    }
}
    
      
        
