using System;

namespace BitcoinNET.RPCClient
{
    //Courtesy mb300sd Bitcoin.NET
	public class RPCResponse<T>
	{
		public T result;
		public RPCError error;
		public uint id;
	}
}
