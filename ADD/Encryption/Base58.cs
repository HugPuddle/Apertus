using System;
using System.Linq;
using System.Numerics;

namespace Secp256k1
{
    /// <summary>
    /// Modified from CodesInChaos' public domain code
    /// 
    /// https://gist.github.com/CodesInChaos/3175971
    /// </summary>
    public static class Base58
    {
        public const int CheckSumSizeInBytes = 4;

        private const string Digits = "123456789ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz";

        public static string EncodeWithCheckSum(byte[] data)
        {
            return Encode(AddCheckSum(data));
        }

        public static byte[] RemoveCheckSum(byte[] data)
        {
            byte[] result = new byte[data.Length - CheckSumSizeInBytes];
            Buffer.BlockCopy(data, 0, result, 0, data.Length - CheckSumSizeInBytes);

            return result;
        }

        public static bool VerifyCheckSum(byte[] data)
        {
            byte[] result = new byte[data.Length - CheckSumSizeInBytes];
            Buffer.BlockCopy(data, 0, result, 0, data.Length - CheckSumSizeInBytes);
            byte[] correctCheckSum = GetCheckSum(result);
            for (int i = CheckSumSizeInBytes; i >= 1; i--)
            {
                if (data[data.Length - i] != correctCheckSum[CheckSumSizeInBytes - i])
                {
                    return false;
                }
            }
            return true;
        }

        public static bool DecodeWithCheckSum(string base58, out byte[] decoded)
        {
            var dataWithCheckSum = Decode(base58);
            var success = VerifyCheckSum(dataWithCheckSum);
            decoded = RemoveCheckSum(dataWithCheckSum);

            return success;
        }

        public static string Encode(byte[] data)
        {
            // Decode byte[] to BigInteger
            BigInteger intData = 0;
            for (int i = 0; i < data.Length; i++)
            {
                intData = intData * 256 + data[i];
            }

            // Encode BigInteger to Base58 string
            string result = "";
            while (intData > 0)
            {
                int remainder = (int)(intData % 58);
                intData /= 58;
                result = Digits[remainder] + result;
            }

            // Append `1` for each leading 0 byte
            for (int i = 0; i < data.Length && data[i] == 0; i++)
            {
                result = '1' + result;
            }
            return result;
        }

        public static byte[] Decode(string base58)
        {
            // Decode Base58 string to BigInteger 
            BigInteger intData = 0;
            for (int i = 0; i < base58.Length; i++)
            {
                int digit = Digits.IndexOf(base58[i]); //Slow
                if (digit < 0)
                    throw new FormatException(string.Format("Invalid Base58 character `{0}` at position {1}", base58[i], i));
                intData = intData * 58 + digit;
            }

            // Encode BigInteger to byte[]
            // Leading zero bytes get encoded as leading `1` characters
            int leadingZeroCount = base58.TakeWhile(c => c == '1').Count();
            var leadingZeros = Enumerable.Repeat((byte)0, leadingZeroCount);
            var bytesWithoutLeadingZeros =
                intData.ToByteArray()
                .Reverse()// to big endian
                .SkipWhile(b => b == 0);//strip sign byte
            var result = leadingZeros.Concat(bytesWithoutLeadingZeros).ToArray();
            return result;
        }

        public static byte[] AddCheckSum(byte[] data)
        {
            byte[] checkSum = GetCheckSum(data);

            var result = new byte[checkSum.Length + data.Length];
            Buffer.BlockCopy(data, 0, result, 0, data.Length);
            Buffer.BlockCopy(checkSum, 0, result, data.Length, checkSum.Length);
            return result;
        }

        private static byte[] GetCheckSum(byte[] data)
        {
            var hash = SHA256.DoubleHash(data);
            Array.Resize(ref hash, CheckSumSizeInBytes);
            return hash;
        }
    }
}
