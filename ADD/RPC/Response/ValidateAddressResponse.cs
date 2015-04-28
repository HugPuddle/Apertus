using System;
using System.Collections.Generic;

namespace ADD.RPCClient
{
	//Courtesy mb300sd Bitcoin.NET Implementation
    public class ValidateAddressResponse
    {
        public bool isvalid;
        public string address;
        public bool ismine;
        public bool isscript;
        public string pubkey;
        public bool iscompressed;
        public string account;
    }
}
