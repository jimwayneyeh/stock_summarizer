﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data;
using System.Data.SQLite;
using System.IO;

using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;

namespace StockSummarizer.lib
{
    class StockRecordOperation
    {
        static string dbPath = @".\stock_summarizer.sqlite";
        static string cnStr = "data source=" + dbPath + ";Version=3;";

        static string transactionTable = "stock_transactions";

        // 1 - 0.003 - 0.001425
        private static decimal sellTax = 0.995575m;
        // 1 + 0.001425
        private static decimal buyTax = 1.001425m;

        public enum RecordType {
            買進,
            賣出,
            內部借券,
            回補};

        private int page = 1;
        private int numberPerPage = 20;

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
                        "CREATE TABLE IF NOT EXISTS {0} (symbol VARCHAR(6), price NUMERIC, amount NUMERIC, timestamp STRING, action NUMERIC)", 
                        transactionTable);
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();

                    // Create index.
                    sql = "CREATE INDEX IF NOT EXISTS timestamp_index ON stock_summarizer (timestamp)";
                    new SQLiteCommand(sql, conn).ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public Int32 recordTransaction(DateTime time, String symbol, decimal price, decimal amount, RecordType actionType)
        {
            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    conn.Open();

                    String sql = String.Format(
                        "INSERT INTO {0} (symbol, price, amount, timestamp, action) VALUES ('{1}', {2}, {3}, '{4}', {5})",
                        transactionTable, symbol, price, amount, time.ToLocalTime().ToString("s"), (Int16) actionType);
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    return command.ExecuteNonQuery();
                }
                finally
                {
                    conn.Close();
                }
            }
        }

        public void updateView(DataTable table, DateTime selectedDate)
        {
            table.Clear();

            using (SQLiteConnection conn = new SQLiteConnection(cnStr))
            {
                try
                {
                    DateTime nextMonth = selectedDate.AddMonths(1);
                    DateTime startOfNextMonth = new DateTime(nextMonth.Year, nextMonth.Month, 1);
                    DateTime endOfLastMonth = new DateTime(selectedDate.Year, selectedDate.Month, 1).AddDays(-1);

                    String sql = String.Format(
                        "SELECT * FROM {0} WHERE timestamp < '{1}' AND timestamp > '{2}' ORDER BY timestamp DESC LIMIT {3} OFFSET {4}",
                        transactionTable,
                        String.Format("{0}-{1:00}-{2:00}", startOfNextMonth.Year, startOfNextMonth.Month, startOfNextMonth.Day),
                        String.Format("{0}-{1:00}-{2:00}T24", endOfLastMonth.Year, endOfLastMonth.Month, endOfLastMonth.Day),
                        numberPerPage, 
                        numberPerPage * (page - 1));
                    Debug.WriteLine(String.Format("SQL for data grid: {0}", sql));

                    conn.Open();
                    SQLiteCommand command = new SQLiteCommand(sql, conn);
                    SQLiteDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        Debug.WriteLine(String.Format("Row: {0} {1}", reader["timestamp"], reader["symbol"]));

                        decimal price = Decimal.Parse(reader["price"].ToString());
                        decimal amount = Decimal.Parse(reader["amount"].ToString());

                        RecordType actionType = (RecordType)Int16.Parse(reader["action"].ToString());

                        DataRow row = table.NewRow();
                        row["日期"] = reader["timestamp"];
                        row["股票代碼"] = reader["symbol"];
                        row["價格"] = price.ToString();
                        row["數量"] = amount.ToString();
                        row["類型"] = String.Format("{0}", actionType);
                        
                        
                        table.Rows.Add(row);
                    }
                }
                finally
                {
                    conn.Close();
                }
            }
        }
    }
}
