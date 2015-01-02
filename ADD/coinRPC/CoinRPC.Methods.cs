using System;
using System.Collections.Generic;
using System.Linq;

namespace ADD.RPCClient
{
	//Courtesy mb300sd Bitcoin.NET Implementation
	public partial class CoinRPC
	{
	
  	    //Keep For Future Use
        //public string GetNewAddress(string Account = "")
        //{
        //    return RpcCall<string>
        //        (new RPCRequest("getnewaddress", new Object[] { Account }));
        //}

	
		public IEnumerable<string> GetRawMemPool()
		{
			return RpcCall<IEnumerable<string>>
				(new RPCRequest("getrawmempool"));
		}

		public GetRawTransactionResponse GetRawTransaction(string TxId, int Verbose = 0)
		{
			return RpcCall<GetRawTransactionResponse>
				(new RPCRequest("getrawtransaction", new Object[] { TxId, Verbose }));
		}

        ////Keep For Future Use
        //public decimal GetReceivedByAddress(string BitcoinAddress, int MinConf = 1)
        //{
        //    return RpcCall<decimal>
        //        (new RPCRequest("getreceivedbyaddress", new Object[] { BitcoinAddress, MinConf }));
        //}

		public GetTransactionResponse GetTransaction(string TxID)
		{
			return RpcCall<GetTransactionResponse>
				(new RPCRequest("gettransaction", new Object[] { TxID }));
		}

     		
		public IDictionary<string, decimal> ListAccounts(int MinConf = 1)
		{
			return RpcCall<IDictionary<string, decimal>>
				(new RPCRequest("listaccounts", new Object[] { MinConf }));
		}

		
		public IEnumerable<ListReceivedByAddressResponse> ListReceivedByAddress(int MinConf = 1, bool IncludeEmpty = false)
		{
			return RpcCall<IEnumerable<ListReceivedByAddressResponse>>
				(new RPCRequest("listreceivedbyaddress", new Object[] { MinConf, IncludeEmpty }));
		}

        //Keep for future use
        //public ListSinceBlockResponse ListSinceBlock(string BlockHash = null, int TargetConfirmations = 1)
        //{
        //    if (BlockHash == null)
        //    {
        //        return RpcCall<ListSinceBlockResponse>
        //            (new RPCRequest("listsinceblock"));
        //    }
        //    return RpcCall<ListSinceBlockResponse>
        //        (new RPCRequest("listsinceblock", new Object[] { BlockHash, TargetConfirmations }));
        //}

		
		public string SendMany(string FromAccount, IDictionary<string, decimal> ToBitcoinAddresses, int MinConf = 1, string Comment = "")
		{
			return RpcCall<string>
				(new RPCRequest("sendmany", new Object[] { FromAccount, ToBitcoinAddresses, MinConf, Comment }));
		}

        public void SetTXFee(decimal fee)
        {
            RpcCall<Object>
                (new RPCRequest("settxfee",new Object[] {fee}));
        }

		
        public string SignMessage(string BitcoinAddress, string Message)
        {
            return RpcCall<string>
                (new RPCRequest("signmessage", new Object[] { BitcoinAddress, Message }));
        }


        public bool VerifyMessage(string BitcoinAddress, string Signature, string Message)
        {
            return RpcCall<bool>
                (new RPCRequest("verifymessage", new Object[] { BitcoinAddress, Signature, Message }));
        }

		
	}
}
