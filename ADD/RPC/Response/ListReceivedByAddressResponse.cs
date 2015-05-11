using System;

namespace BitcoinNET.RPCClient
{
    //Courtesy mb300sd Bitcoin.NET
	public class ListReceivedByAddressResponse
	{
		public string address;
		public string account;
		public decimal amount;
		public long confirmations;
	}
}
