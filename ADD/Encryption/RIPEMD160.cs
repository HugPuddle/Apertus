using System.Security.Cryptography;

namespace Secp256k1
{
    public class RIPEMD160
    {
        private static readonly RIPEMD160Managed ripemd160 = new RIPEMD160Managed();

        public static byte[] Hash(byte[] data)
        {
            return ripemd160.ComputeHash(data);
        }

        public static byte[] Hash(string hexData)
        {
            byte[] bytes = Hex.HexToBytes(hexData);
            return Hash(bytes);
        }
    }
}
