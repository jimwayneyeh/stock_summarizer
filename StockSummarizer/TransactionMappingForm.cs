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
using System.Diagnostics;

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

            remainValue.Text = operation.getTransaction().amount.ToString();
        }

        private void initializeView()
        {
            gridView.DataSource = table.DefaultView;
            gridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            
            table.Columns.Add("編號", Type.GetType("System.String"));
            table.Columns.Add("日期", Type.GetType("System.String"));
            table.Columns.Add("價格", Type.GetType("System.Decimal"));
            table.Columns.Add("數量", Type.GetType("System.Decimal"));
        }

        private void TransactionMappingForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            decimal remainAmount = Decimal.Parse(remainValue.Text);
            
            if (remainAmount > 0)
            {
                DialogResult result = MessageBox.Show("尚未完成沖帳紀錄，確定不設定了嗎？", "", MessageBoxButtons.YesNo);
                e.Cancel = (result == DialogResult.No);
            }
        }

        private void chooseButton_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow item in gridView.SelectedRows)
            {
                DataRow row = table.Rows[item.Index];
                Debug.WriteLine(String.Format("Selected amount: {0} {1}", row["數量"], row["編號"]));

                Guid selectedId = Guid.Parse(row["編號"].ToString());
                decimal selectedAmount = Decimal.Parse(row["數量"].ToString());
                decimal remainAmount = Decimal.Parse(remainValue.Text);

                // Calculate the remaining amount after assigning the record.
                if (remainAmount > selectedAmount)
                {
                    operation.updateRemainingAmountToRecord(selectedId, 0);
                    remainAmount -= selectedAmount;
                }
                else
                {
                    operation.updateRemainingAmountToRecord(selectedId, selectedAmount - remainAmount);
                    remainAmount = 0;
                }

                // Write balance record.
                operation.addBalanceRecord(selectedId);

                // Set the new amount back to the label.
                remainValue.Text = remainAmount.ToString();

                if (remainAmount == 0)
                {
                    MessageBox.Show("沖帳紀錄已完成。");
                    this.Close();
                } else
                {
                    // Refresh the form.
                    operation.getNotConsumedBuying(table);
                }
            }
        }

    }
}
