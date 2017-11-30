using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockSummarizer.model
{
    class Transaction
    {
        public Guid guid { get; set; }
        public string symbol { get; set; }
        public decimal price { get; set; }
        public decimal amount { get; set; }
        public DateTime timestamp { get; set; }
        public RecordType action { get; set; }
        public decimal remainAmount { get; set; }
    }
}
