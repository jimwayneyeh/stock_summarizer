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
        private StockRecordOperation recordsOpt = new StockRecordOperation();

        private DataTable recordsTable = new DataTable();
        private DataTable balanceTable = new DataTable();

        private int balancePage = 1;
        private int numberPerPage = 20;

        public Main()
        {
            InitializeComponent();

            initializeView();

            action.DataSource = Enum.GetValues(typeof(RecordType));

            tabControl1_SelectedIndexChanged(null, null);
        }

        private void initializeView()
        {
            // Views in sumary tab.
            mappingGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            mappingGrid.DataSource = balanceTable.DefaultView;

            balanceTable.Columns.Add("日期", Type.GetType("System.String"));
            balanceTable.Columns.Add("股票代碼", Type.GetType("System.String"));
            balanceTable.Columns.Add("賣出價格", Type.GetType("System.Decimal"));
            balanceTable.Columns.Add("數量", Type.GetType("System.String"));
            balanceTable.Columns.Add("買進價格", Type.GetType("System.Decimal"));
            balanceTable.Columns.Add("賣出總價", Type.GetType("System.Decimal"));
            balanceTable.Columns.Add("買進總價", Type.GetType("System.Decimal"));
            balanceTable.Columns.Add("價差", Type.GetType("System.Decimal"));

            // Views in records tab.
            recordView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            recordView.DataSource = recordsTable.DefaultView;

            recordsTable.Columns.Add("編號", Type.GetType("System.String"));
            recordsTable.Columns.Add("日期", Type.GetType("System.String"));
            recordsTable.Columns.Add("股票代碼", Type.GetType("System.String"));
            recordsTable.Columns.Add("價格", Type.GetType("System.Decimal"));
            recordsTable.Columns.Add("數量", Type.GetType("System.String"));
            recordsTable.Columns.Add("類型", Type.GetType("System.String"));
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Refresh the view of summary.
            updateSummaryView();

            // Refresh the view of records.
            recordsOpt.initializeDatabase();
            recordsOpt.updateView(recordsTable, stockTime.Value);
        }

        #region sumary tab
        private void mappingMonthSelector_ValueChanged(object sender, EventArgs e)
        {
            updateSummaryView();
        }

        private void updateSummaryView ()
        {
            BalanceOperation.updateView(balanceTable, mappingMonthSelector.Value, numberPerPage, balancePage);

            decimal totalDiff = BalanceOperation.calculateMonthlyTotal(balanceTable);
            monthlyProfit.Text = String.Format("{0:0.000}", totalDiff * 1000);
            monthlyProfit.ForeColor = (totalDiff > 0) ? Color.Red : Color.Green;
        }
        #endregion

        #region record tab
        private void click_add_button(object sender, EventArgs e)
        {
            if (symbol.Text.Length < 1)
            {
                MessageBox.Show("必須輸入股票代碼。");
                return;
            }
            if (price.Value < 1)
            {
                MessageBox.Show("必須輸入合法的交易價格。");
                return;
            }
            if (amount.Value < 1)
            {
                MessageBox.Show("必須輸入合法的交易數量。");
                return;
            }

            RecordType actionType;
            Enum.TryParse<RecordType>(action.SelectedValue.ToString(), out actionType);

            Nullable<Guid> resultId = recordsOpt.recordTransaction(stockTime.Value, symbol.Text, price.Value, amount.Value, actionType);
            
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

            recordsOpt.updateView(recordsTable, stockTime.Value);
        }

        private void recordDeleteButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("確定要刪除選取的紀錄嗎？", "確認刪除", MessageBoxButtons.YesNo);
            if (result == DialogResult.No)
            {
                return;
            }

            // Start delete the records.
            foreach (DataGridViewRow item in recordView.SelectedRows)
            {
                DataRow row = recordsTable.Rows[item.Index];
                recordsOpt.deleteRecord(Guid.Parse(row["編號"].ToString()));
            }

            recordsOpt.updateView(recordsTable, stockTime.Value);
        }

        private void clear_when_enter(object senderObj, EventArgs e)
        {
            Control sender = (Control)senderObj;
            sender.Text = String.Empty;
        }

        private void monthSelector_ValueChanged(object sender, EventArgs e)
        {
            recordsOpt.updateView(recordsTable, monthSelector.Value);
        }
        #endregion
    }
}