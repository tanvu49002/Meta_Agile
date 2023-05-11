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
            loadPaidBills();
            loadListFood();
            loadAcc();

        }
        #region Food
        void loadListFood()
        {
            List<Food> pList = FoodDAO.Instance.showFood();
            dtgvFood.DataSource = pList;
            dtgvFood.Columns["IdCategory"].Visible = false;
        }

        #endregion
        #region Account
        void loadAcc()
        {
            dtgvAccount.DataSource = AccDAO.Instance.getListAcc();
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
    
      
        
