using System;

namespace BitcoinNET.RPCClient
{
    //Courtesy mb300sd Bitcoin.NET
	class CoinRPCException : Exception 
	{
		public RPCError Error
		{
			get;
			private set;
		}

		public CoinRPCException(RPCError rpcError)
			: base (rpcError.message)
		{
			Error = rpcError;
		}

		public CoinRPCException(RPCError rpcError, Exception innerException)
			: base(rpcError.message, innerException)
		{
			Error = rpcError;
		}
	}
}
