using System;
using System.Collections.Generic;

namespace BitcoinNET.RPCClient
{
    //Courtesy mb300sd Bitcoin.NET
	public class GetTransactionResponse
	{
		public class Details
		{
			public string account;
			public string address;
			public string category;
			public decimal amount;
			public decimal fee;
		}
		public decimal amount;
		public decimal fee;
		public long confirmations;
		public string blockhash;
		public int blockindex;
		public string txid;
		public long time;
		public long timereceived;
		public IEnumerable<Details> details;
	}

    public class DataCoinGetTransactionResponse
    {
        public class Details
        {
            public string account;
            public string address;
            public string category;
            public decimal amount;
            public decimal fee;
        }
        public decimal amount;
        public decimal fee;
        public long confirmations;
        public string blockhash;
        public int blockindex;
        public int blocktime;
        public string txid;
        public long time;
        public string data;
        public long timereceived;
        public IEnumerable<Details> details;
    }
}
