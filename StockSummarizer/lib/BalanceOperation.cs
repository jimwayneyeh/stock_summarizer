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
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();

                    // Create index.
                    sql = String.Format("CREATE INDEX IF NOT EXISTS sell_id_index ON {0} (sell_id)",
                        balanceTable);
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();

                    sql = String.Format("CREATE INDEX IF NOT EXISTS buy_id_index ON {0} (buy_id)",
                        balanceTable);
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
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
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();

                    table.Clear();

                    while(reader.Read())
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
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    return command.ExecuteNonQuery();
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
                        "INSERT INTO {0} (guid, sell_id, buy_id) VALUES ({1}, {2}, {3})",
                        balanceTable, transaction.guid, selectedId);
                    Debug.WriteLine(String.Format("SQL for creating a balance record: {0}", sql));
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    return command.ExecuteNonQuery();
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
    }
}
