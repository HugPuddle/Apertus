using System;

namespace ADD.RPCClient
{
	//Courtesy mb300sd Bitcoin.NET Implementation
	public class ListReceivedByAddressResponse
	{
		public string address;
		public string account;
		public decimal amount;
		public long confirmations;
	}
}
