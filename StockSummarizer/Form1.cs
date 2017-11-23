using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SQLite;
using System.IO;

using System.Diagnostics;

namespace StockSummarizer
{
    public partial class Form1 : Form
    {
        private DataTable table = new DataTable();

        private int page = 1;
        private int numberPerPage = 20;

        // 1 - 0.003 - 0.001425
        private Decimal sellTax = 0.995575m;
        // 1 + 0.001425
        private Decimal buyTax = 1.001425m;

        public Form1()
        {
            InitializeComponent();
            
            initializeDatabase();

            initializeView();
            updateView();
        }

        private void initializeView ()
        {
            gridView.DataSource = table.DefaultView;

            table.Columns.Add("日期", Type.GetType("System.String"));
            table.Columns.Add("股票代碼", Type.GetType("System.String"));
            table.Columns.Add("賣出價格", Type.GetType("System.Decimal"));
            table.Columns.Add("數量", Type.GetType("System.String"));
            table.Columns.Add("買進價格", Type.GetType("System.Decimal"));

            table.Columns.Add("賣出總價", Type.GetType("System.Decimal"));
            table.Columns.Add("買進總價", Type.GetType("System.Decimal"));
            table.Columns.Add("價差", Type.GetType("System.Decimal"));
        }

        static string dbPath = @".\stock_summarizer.sqlite";
        static string cnStr = "data source=" + dbPath + ";Version=3;";

        private void initializeDatabase ()
        {
            if (!File.Exists(dbPath))
            {
                SQLiteConnection.CreateFile(dbPath);
            }

            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    conn.Open();

                    // Create database.
                    String sql = "CREATE TABLE IF NOT EXISTS stock_summarizer (symbol VARCHAR(6), sell_price NUMERIC, amount INTEGER, buy_price NUMERIC, timestamp STRING)";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();

                    // Create index.
                    sql = "CREATE INDEX IF NOT EXISTS timestamp_index ON stock_summarizer (timestamp)";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
                } finally
                {
                    conn.Close();
                }
            }
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (symbol.Text.Length < 1)
            {
                MessageBox.Show("必須輸入股票代碼。");
            }
            if (amount.Value < 1)
            {
                MessageBox.Show("必須輸入數量。");
            }

            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                int result = 0;

                try
                {
                    conn.Open();

                    String sql = String.Format(
                        "INSERT INTO stock_summarizer (symbol, sell_price, amount, buy_price, timestamp) VALUES ('{0}', {1}, {2}, {3}, '{4}')",
                        symbol.Text, sellPrice.Value, amount.Value, buyPrice.Value, stockTime.Value.ToLocalTime().ToString("s"));
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    result = command.ExecuteNonQuery();
                } finally
                {
                    conn.Close();
                }

                // Flush the grid.
                if (result > 0)
                {
                    updateView();
                }
            }
        }

        private void updateView()
        {
            table.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    DateTime nextMonth = monthSelector.Value.AddMonths(1);
                    DateTime startOfNextMonth = new DateTime(nextMonth.Year, nextMonth.Month, 1);
                    DateTime endOfLastMonth = new DateTime(monthSelector.Value.Year, monthSelector.Value.Month, 1).AddDays(-1);

                    String sql = String.Format(
                        "SELECT * FROM stock_summarizer WHERE timestamp < '{0}' AND timestamp > '{1}' ORDER BY timestamp DESC LIMIT {2} OFFSET {3}",
                        String.Format("{0}-{1:00}-{2:00}", startOfNextMonth.Year, startOfNextMonth.Month, startOfNextMonth.Day),
                        String.Format("{0}-{1:00}-{2:00}T24", endOfLastMonth.Year, endOfLastMonth.Month, endOfLastMonth.Day),
                        numberPerPage, numberPerPage * (page - 1));
                    Debug.WriteLine(String.Format("SQL for data grid: {0}", sql));

                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("Row: {0} {1}", reader["timestamp"], reader["symbol"]));

                        decimal sellPrice = Decimal.Parse(reader["sell_price"].ToString());
                        decimal amount = Decimal.Parse(reader["amount"].ToString());
                        decimal buyPrice = Decimal.Parse(reader["buy_price"].ToString());

                        DataRow row = table.NewRow();
                        row["日期"] = reader["timestamp"];
                        row["股票代碼"] = reader["symbol"];
                        row["賣出價格"] = sellPrice.ToString();
                        row["數量"] = amount.ToString();
                        row["買進價格"] = buyPrice.ToString();

                        decimal totalSell = sellPrice * amount * sellTax * 1000m;
                        decimal totalBuy = buyPrice * amount * buyTax * 1000m;
                        row["賣出總價"] = String.Format("{0:0.000}", totalSell);
                        row["買進總價"] = String.Format("{0:0.000}", totalBuy);
                        row["價差"] = String.Format("{0:0.000}", (totalSell - totalBuy));

                        table.Rows.Add(row);
                    }
                } finally
                {
                    conn.Close();
                }
            }

            calculateMonthlyTotal();
        }

        private void calculateMonthlyTotal ()
        {
            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    DateTime nextMonth = monthSelector.Value.AddMonths(1);
                    DateTime startOfNextMonth = new DateTime(nextMonth.Year, nextMonth.Month, 1);
                    DateTime endOfLastMonth = new DateTime(monthSelector.Value.Year, monthSelector.Value.Month, 1).AddDays(-1);

                    String sql = String.Format(
                        "SELECT * FROM stock_summarizer WHERE timestamp < '{0}' AND timestamp > '{1}'",
                        String.Format("{0}-{1:00}-{2:00}", startOfNextMonth.Year, startOfNextMonth.Month, startOfNextMonth.Day),
                        String.Format("{0}-{1:00}-{2:00}T24", endOfLastMonth.Year, endOfLastMonth.Month, endOfLastMonth.Day));
                    Debug.WriteLine(String.Format("SQL for calculate monthly total: {0}", sql));

                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();

                    decimal totalDiff = 0;

                    while (reader.Read())
                    {
                        decimal sellPrice = Decimal.Parse(reader["sell_price"].ToString());
                        Int32 amount = Int32.Parse(reader["amount"].ToString());
                        decimal buyPrice = Decimal.Parse(reader["buy_price"].ToString());

                        // 0.995575 = 1 - 0.003 - 0.001425
                        // 1 + 0.001425
                        totalDiff += sellPrice * amount * sellTax - buyPrice * amount * buyTax;
                    }

                    monthlyTotal.Text = String.Format("{0:0.000}", totalDiff * 1000);

                    monthlyTotal.ForeColor = (totalDiff > 0) ? Color.Red : Color.Green;
                    
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void monthSelector_ValueChanged(object sender, EventArgs e)
        {
            updateView();
        }

        private void numeric_enter(object senderObj, EventArgs e)
        {
            Control sender = (Control)senderObj;
            sender.Text = String.Empty;
        }
    }
}
