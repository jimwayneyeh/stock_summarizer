using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data;
using System.Data.SQLite;
using System.IO;

using StockSummarizer.lib;

namespace StockSummarizer
{
    public partial class TransactionMappingForm : Form
    {
        BalanceOperation operation;

        DataTable table = new DataTable();

        public TransactionMappingForm(Guid guid)
        {
            InitializeComponent();

            initializeView();

            operation = new BalanceOperation(guid);
            operation.getNotConsumedBuying(table);
        }

        private void initializeView()
        {
            gridView.DataSource = table.DefaultView;

            table.Columns.Add("編號", Type.GetType("System.String"));
            table.Columns.Add("日期", Type.GetType("System.String"));
            table.Columns.Add("股票代碼", Type.GetType("System.String"));
            table.Columns.Add("價格", Type.GetType("System.Decimal"));
            table.Columns.Add("數量", Type.GetType("System.String"));
            table.Columns.Add("類型", Type.GetType("System.String"));
        }
    }
}
