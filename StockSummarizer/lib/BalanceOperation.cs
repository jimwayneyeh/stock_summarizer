using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
using System.IO;

using StockSummarizer.model;
using System.Diagnostics;

namespace StockSummarizer.lib
{
    class BalanceOperation
    {
        static string dbPath = @".\stock_summarizer.sqlite";
        static string cnStr = "data source=" + dbPath + ";Version=3;";
        static string balanceTable = "stock_balance";

        // 1 - 0.003 - 0.001425
        static Decimal sellTax = 0.995575m;
        // 1 + 0.001425
        static Decimal buyTax = 1.001425m;

        private Transaction transaction;

        public BalanceOperation(Guid guid)
        {
            initializeDatabase();

            this.transaction = StockRecordOperation.getTransaction(guid);
        }

        public void initializeDatabase()
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
                    String sql = String.Format(
                        "CREATE TABLE IF NOT EXISTS {0} (guid STRING PRIMARY KEY, sell_id STRING, buy_id STRING, "
                        + "FOREIGN KEY(sell_id) REFERENCES {1}(guid), "
                        + "FOREIGN KEY(buy_id) REFERENCES {1}(guid))",
                        balanceTable, StockRecordOperation.transactionTable);
                    using (var command = new SQLiteCommand(sql, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    // Create index.
                    sql = String.Format("CREATE INDEX IF NOT EXISTS sell_id_index ON {0} (sell_id)",
                        balanceTable);
                    using (var command = new SQLiteCommand(sql, conn))
                    {
                        command.ExecuteNonQuery();
                    }

                    sql = String.Format("CREATE INDEX IF NOT EXISTS buy_id_index ON {0} (buy_id)",
                        balanceTable);
                    using (var command = new SQLiteCommand(sql, conn))
                    {
                        command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Transaction getTransaction ()
        {
            return transaction;
        }

        public void getNotConsumedBuying(DataTable table)
        {
            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    conn.Open();
    
                    String sql = String.Format(
                        "SELECT * FROM {0} WHERE symbol = '{1}' AND amount > 0 AND action = {2}",
                        StockRecordOperation.transactionTable, this.transaction.symbol, (int) RecordType.買進);
                    Debug.WriteLine(String.Format("SQL: {0}", sql));

                    using (var command = new SQLiteCommand(sql, conn))
                    {
                        command.ExecuteNonQuery();

                        using (SQLiteDataReader reader = command.ExecuteReader()) {
                            table.Clear();

                            while (reader.Read())
                            {
                                decimal price = Decimal.Parse(reader["price"].ToString());
                                decimal amount = Decimal.Parse(reader["amount"].ToString());

                                DataRow row = table.NewRow();
                                row["編號"] = reader["guid"];
                                row["日期"] = reader["timestamp"];
                                row["價格"] = price.ToString();
                                row["數量"] = amount.ToString();

                                table.Rows.Add(row);
                            }
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int updateRemainingAmountToRecord(Guid id, decimal amount)
        {
            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    conn.Open();

                    String sql = String.Format(
                        "UPDATE {0} SET remain_amount = {1} WHERE guid = '{2}'",
                        StockRecordOperation.transactionTable, amount, id);
                    Debug.WriteLine(String.Format("SQL for updating remaining amount: {0}", sql));
                    using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public int addBalanceRecord(Guid selectedId)
        {
            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    conn.Open();
                    
                    String sql = String.Format(
                        "INSERT INTO {0} (guid, sell_id, buy_id) VALUES ('{1}', '{2}', '{3}')",
                        balanceTable, Guid.NewGuid(), transaction.guid, selectedId);
                    Debug.WriteLine(String.Format("SQL for creating a balance record: {0}", sql));
                    using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                    {
                        return command.ExecuteNonQuery();
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        private void get ()
        {
            string sql = String.Format(
                "SELECT * FROM {0}, {1} WHERE {0}.sell_id = {1}.guid AND {0}.buy_id = {1}.guid",
                balanceTable, StockRecordOperation.transactionTable);
        }

        public static void updateView(DataTable table, DateTime date, int numberPerPage, int page)
        {
            table.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    DateTime nextMonth = date.AddMonths(1);
                    DateTime startOfNextMonth = new DateTime(nextMonth.Year, nextMonth.Month, 1);
                    DateTime endOfLastMonth = new DateTime(date.Year, date.Month, 1).AddDays(-1);

                    String sql = String.Format(
                        "SELECT REC_SELL.timestamp, REC_SELL.amount, REC_SELL.price AS sell_price, REC_SELL.symbol, REC_BUY.price AS buy_price FROM {0} AS MAP " +
                        "LEFT JOIN {1} AS REC_SELL ON MAP.sell_id = REC_SELL.guid " +
                        "LEFT JOIN {1} AS REC_BUY ON MAP.buy_id = REC_BUY.guid " +
                        "WHERE REC_SELL.timestamp < '{2}' AND REC_SELL.timestamp > '{3}' ORDER BY REC_SELL.timestamp DESC LIMIT {4} OFFSET {5}",
                        balanceTable,
                        StockRecordOperation.transactionTable,
                        String.Format("{0}-{1:00}-{2:00}", startOfNextMonth.Year, startOfNextMonth.Month, startOfNextMonth.Day),
                        String.Format("{0}-{1:00}-{2:00}T24", endOfLastMonth.Year, endOfLastMonth.Month, endOfLastMonth.Day),
                        numberPerPage, 
                        numberPerPage * (page - 1));
                    Debug.WriteLine(String.Format("SQL for showing sumary of monthly transactions: {0}", sql));

                    conn.Open();

                    using (SQLiteCommand command = new SQLiteCommand(sql, conn))
                    {
                        using (SQLiteDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
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
                        }
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public static decimal calculateMonthlyTotal(DataTable table)
        {
            decimal totalDiff = 0;

            foreach (DataRow row in table.Rows)
            {
                decimal sellPrice = Decimal.Parse(row["賣出價格"].ToString());
                Int32 amount = Int32.Parse(row["數量"].ToString());
                decimal buyPrice = Decimal.Parse(row["買進價格"].ToString());

                // 0.995575 = 1 - 0.003 - 0.001425
                // 1 + 0.001425
                totalDiff += sellPrice * amount * sellTax - buyPrice * amount * buyTax;
            }

            return totalDiff;
        }
    }
}
