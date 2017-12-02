using StockSummarizer.lib;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using static StockSummarizer.lib.StockRecordOperation;
using StockSummarizer.model;

namespace StockSummarizer
{
    public partial class Main : Form
    {
        private StockRecordOperation operation = new StockRecordOperation();
        private DataTable table = new DataTable();

        public Main()
        {
            InitializeComponent();

            initializeView();

            action.DataSource = Enum.GetValues(typeof(RecordType));

            operation.initializeDatabase();

            operation.updateView(table, stockTime.Value);
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

        private void click_add_button(object sender, EventArgs e)
        {
            if (symbol.Text.Length < 1)
            {
                MessageBox.Show("必須輸入股票代碼。");
                return;
            }

            RecordType actionType;
            Enum.TryParse<RecordType>(action.SelectedValue.ToString(), out actionType);

            Nullable<Guid> resultId = operation.recordTransaction(stockTime.Value, symbol.Text, price.Value, amount.Value, actionType);
            
            if (resultId.HasValue)
            {
                switch (actionType)
                {
                    case RecordType.買進:
                        break;
                    case RecordType.賣出:
                        TransactionMappingForm form = new TransactionMappingForm(resultId.Value);
                        form.ShowDialog();
                        break;
                    case RecordType.內部借券:
                    case RecordType.回補:
                        break;
                }

                MessageBox.Show("新增成功！");
            }

            operation.updateView(table, stockTime.Value);
        }

        private void clear_when_enter(object senderObj, EventArgs e)
        {
            Control sender = (Control)senderObj;
            sender.Text = String.Empty;
        }

        private void monthSelector_ValueChanged(object sender, EventArgs e)
        {
            operation.updateView(table, monthSelector.Value);
        }
    }
}