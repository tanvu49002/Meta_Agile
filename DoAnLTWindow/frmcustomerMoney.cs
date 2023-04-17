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
    public partial class frmcustomerMoney : Form
    {
        private Account acc;
        private int TableId;
        public frmcustomerMoney(int TableId, Account acc)
        {
            InitializeComponent();
            this.acc = acc;
            this.TableId = TableId;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int money = (int)double.Parse(txtCustomerMoney.Text) * 1000 ;
            FrmReport fReport = new FrmReport(TableId, acc, money);
            this.Hide();
            fReport.ShowDialog();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            txtCustomerMoney.Text += "000";
        }

        private void txtCustomerMoney_TextChanged(object sender, EventArgs e)
        {
            txtCustomerMoney.Text = string.Format("{0:#.00}", Convert.ToDecimal(txtCustomerMoney.Text) / 100);
        }
    }
}
