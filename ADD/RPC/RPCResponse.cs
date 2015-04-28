using System;

namespace ADD.RPCClient
{
	//Courtesy mb300sd Bitcoin.NET Implementation
	public class RPCResponse<T>
	{
		public T result;
		public RPCError error;
		public uint id;
	}
}
