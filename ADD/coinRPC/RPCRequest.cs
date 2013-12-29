using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace ADD.RPCClient
{
	[JsonObject(MemberSerialization=MemberSerialization.Fields)]
	public class RPCRequest
	{
		string jsonrpc = "2.0";
		uint id = 1;
		string method;

		[JsonProperty(PropertyName="params", NullValueHandling=NullValueHandling.Ignore)]
		IList<Object> requestParams = null;

		public RPCRequest(string method, IList<Object> requestParams = null, uint id = 1)
		{
			this.method = method;
			this.requestParams = requestParams;
			this.id = id;

			String.IsNullOrEmpty(this.jsonrpc); // Suppress warning
		}
	}
}
