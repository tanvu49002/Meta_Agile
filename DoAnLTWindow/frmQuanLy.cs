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
           
            loadTable();
            
            loadCategory();
            
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
        
        void showBill(int id)
        {
            lvwBill.Items.Clear();
            List<Menu> listbilldetail = MenuDAO.Instance.getListMenu(id);
            float TotalPrice = 0;
            foreach (Menu item in listbilldetail)
            {
                ListViewItem lvwItem = new ListViewItem(item.FoodName.ToString());
                lvwItem.SubItems.Add(item.Count.ToString());
                lvwItem.SubItems.Add(item.Price.ToString());
                lvwItem.SubItems.Add(item.TotalPrice.ToString());
                TotalPrice += item.TotalPrice;
                lvwBill.Items.Add(lvwItem);
            }
            CultureInfo culture = new CultureInfo("vi-VN");
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
        
        public void loadTable()
        {
            flpTable.Controls.Clear();
            List<Table> tableList = TableDAO.Instance.loadTableList();
            foreach (Table item in tableList)
            {
                Button btn = new Button()
                {
                    Width = TableDAO.TableWidth,
                    Height = TableDAO.TableHeight
                };
                btn.Text = item.Name + Environment.NewLine + "(" + item.Status + ")";
                if (item.Status2 != 0)
                {
                    DataTable pTable = DataProvider.Instance.ExecuteQuery("EXEC GET_ORDERED_TABLE " + item.ID);
                    if (pTable.Rows.Count > 0)
                    {
                        string s = pTable.Rows[0]["ORDER_TIME"].ToString();
                        btn.Text += Environment.NewLine + s;
                    }
                    else
                    {
                        DataProvider.Instance.ExecuteNonQuery("UPDATE BAN_AN SET TRANGTHAI2 = 0 WHERE ID = " + item.ID);
                    }
                }
                btn.Click += btn_Click;
                btn.Tag = item;
                btn.BackColor = Color.SandyBrown;
                btn.FlatAppearance.BorderColor = Color.Red;
                btn.FlatAppearance.BorderSize = 2;
                flpTable.Controls.Add(btn);
                if (curr_idTable == item.ID)
                {
                    btn.FlatStyle = FlatStyle.Flat;
                    oldButton = btn;
                }
            }
        }
        
        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void thôngTinCáNhânToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmAccProfile f = new frmAccProfile(LoginAcc);
            f.ShowDialog();
        }
        
       void btn_Click(object sender, EventArgs e)
       {
           Button pButton = sender as Button;
           if (oldButton != null)
               oldButton.FlatStyle = FlatStyle.Standard;
           oldButton = pButton;
           pButton.FlatStyle = FlatStyle.Flat;
           Table pData = pButton.Tag as Table;
           int tableID = pData.ID;
           if (pData.Status == "Đã Thanh Toán")
               btnThanhToan.Text = "Hoàn Thành";
           if (isAddedFood == true && curr_idTable != tableID && curr_idTable != -1 && isSaved == false)
           {
               int id_bill = BillDAO.Instance.getUncheckBill(curr_idTable);
               DataProvider.Instance.ExecuteNonQuery("EXEC DELETE_BILL_UNSAVED " + id_bill);
               isAddedFood = false;
           }
           isSaved = false;
           isAddedFood = false;
           curr_idTable = tableID;
           lvwBill.Tag = (sender as Button).Tag;
           showBill(tableID);
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
        
        private void btnAddFood_Click(object sender, EventArgs e)
        {
            Table table = lvwBill.Tag as Table;
            oldButton.Tag = table;
            if (table == null)
            {
                MessageBox.Show("Hãy chọn bàn trước khi thêm");
                return;
            }
            int idbill = BillDAO.Instance.getUncheckBill(table.ID);
            int idfood = (cboFood.SelectedItem as Food).ID;
            int count = (int)updFoodCount.Value;

            isAddedFood = true;

            if (idbill == -1)
            {
                BillDAO.Instance.insertBill(table.ID);
                BillDetailDAO.Instance.insertBillDetail(BillDAO.Instance.getMaxIdBill(), idfood, count);
            }
            else
            {
                BillDetailDAO.Instance.insertBillDetail(idbill, idfood, count);
            }
            showBill(table.ID);
            loadTable();
        }
       
        private void btnLuu_Click(object sender, EventArgs e)
        {
            isSaved = true;
            loadTable();
        }
        
    }
}
