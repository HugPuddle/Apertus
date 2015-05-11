using System;
using System.Collections.Generic;

namespace BitcoinNET.RPCClient
{
    //Courtesy mb300sd Bitcoin.NET
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
