using System;

namespace ADD.RPCClient
{
	public class RPCResponse<T>
	{
		public T result;
		public RPCError error;
		public uint id;
	}
}
