﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BitcoinNET.RPCClient
{       
	//Courtesy mb300sd Bitcoin.NET
	
    public class GetRawDataTransactionResponse
    {
        public class Input
        {
            public class ScriptSig
            {
                public string asm;
                public string hex;
            }

            public string txid;
            public int vout;
            public ScriptSig scriptSig;
            public long sequence;
        }

        public class Output
        {
            public class ScriptPubKey
            {
                public string asm;
                public string hex;
                public int reqSigs;
                public string type;
                public string[] addresses;
            }

            public decimal value;
            public int n;
            public ScriptPubKey scriptPubKey;

        }

        public string hex;
        public string txid;
        public int version;
        public int locktime;
        public string data;
        public Input[] vin;
        public Output[] vout;
        public string blockhash;
        public int confirmations;
        public long blocktime;

        public static implicit operator GetRawDataTransactionResponse(String s)
        {
            return new GetRawDataTransactionResponse() { hex = s };
        }
    }
}
