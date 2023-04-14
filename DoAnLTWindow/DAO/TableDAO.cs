using DoAnLTWindow.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnLTWindow.DAO
{
    public class TableDAO
    {
        private static TableDAO instance;
        public static TableDAO Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new TableDAO();
                }
                return TableDAO.instance;
            }
            private set
            {
                TableDAO.instance = value;
            }
        }
        public static int TableWidth = 94;
        public static int TableHeight = 70;
        private TableDAO() { }
        //form QuanLy
        public List<Table> loadTableList()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BAN_AN");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);

                tableList.Add(table);
            }
            return tableList;
        }

        public List<Table> loadTableList2()
        {
            List<Table> tableList = new List<Table>();
            DataTable data = DataProvider.Instance.ExecuteQuery("SELECT * FROM BAN_AN WHERE TRANGTHAI = N'Trống'");
            foreach (DataRow item in data.Rows)
            {
                Table table = new Table(item);

                tableList.Add(table);
            }
            return tableList;
        }
    }
}
