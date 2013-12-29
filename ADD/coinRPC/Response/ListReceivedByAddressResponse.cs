using System;

namespace ADD.RPCClient
{
	public class ListReceivedByAddressResponse
	{
		public string address;
		public string account;
		public decimal amount;
		public long confirmations;
	}
}
