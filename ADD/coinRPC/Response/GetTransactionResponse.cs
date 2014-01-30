using System;
using System.Collections.Generic;

namespace ADD.RPCClient
{
	//Courtesy mb300sd Bitcoin.NET Implementation
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
}
