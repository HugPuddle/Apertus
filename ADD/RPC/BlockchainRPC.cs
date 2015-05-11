using System;
using System.IO;
using System.Net;
using System.Text;
using Newtonsoft.Json;

namespace BitcoinNET.RPCClient
{
    //Courtesy mb300sd Bitcoin.NET
	public partial class CoinRPC
	{
		protected Uri uri;

		protected NetworkCredential credentials;

		public CoinRPC(Uri _Uri, NetworkCredential _Credentials)
		{
			uri = _Uri;
			credentials = _Credentials;
		}

		protected string HttpCall(string jsonRequest)
		{
			HttpWebRequest request = (HttpWebRequest)WebRequest.Create(uri);

			request.Method = "POST";
			request.ContentType = "application/json-rpc";

			// always send auth to avoid 401 response
			string auth = credentials.UserName + ":" + credentials.Password;
			auth = Convert.ToBase64String(Encoding.UTF8.GetBytes(auth), Base64FormattingOptions.None);
			request.Headers.Add("Authorization", "Basic " + auth);

			//webRequest.Credentials = Credentials;

			request.ContentLength = jsonRequest.Length;


            try
            {
                using (StreamWriter sw = new StreamWriter(request.GetRequestStream()))
                {
                    sw.Write(jsonRequest);
                }
            }
            catch (WebException wex)
            {
             return "{400:\"" + wex.Message +"\"}";
            }
        

            try
            {
			
				using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
				using (StreamReader sr = new StreamReader(response.GetResponseStream()))
				{
					return sr.ReadToEnd();
				}
			}
			catch (WebException wex)
			{
				using (HttpWebResponse response = (HttpWebResponse)wex.Response)
				using (StreamReader sr = new StreamReader(response.GetResponseStream()))
				{
					if (response.StatusCode != HttpStatusCode.InternalServerError)
					{
						throw;
					}
					return sr.ReadToEnd();
				}
			}
		}

		private T RpcCall<T>(RPCRequest rpcRequest)
		{
			string jsonRequest = JsonConvert.SerializeObject(rpcRequest);
            string result = HttpCall(jsonRequest);

			RPCResponse<T> rpcResponse = JsonConvert.DeserializeObject<RPCResponse<T>>(result);

			if (rpcResponse.error != null)
			{
				throw new CoinRPCException(rpcResponse.error);
			}
			return rpcResponse.result;
		}
	}
}
