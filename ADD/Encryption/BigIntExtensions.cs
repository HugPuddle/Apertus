using System;
using System.Diagnostics;
using System.Numerics;

namespace Secp256k1
{
    public static class BigIntExtensions
    {
        public static BigInteger ModInverse(this BigInteger n, BigInteger p)
        {
            BigInteger x = 1;
            BigInteger y = 0;
            BigInteger a = p;
            BigInteger b = n;

            while (b != 0)
            {
                BigInteger t = b;
                BigInteger q = BigInteger.Divide(a, t);
                b = a - q * t;
                a = t;
                t = x;
                x = y - q * t;
                y = t;
            }

            if (y < 0)
                return y + p;
            //else
            return y;
        }

        public static bool TestBit(this BigInteger i, int n)
        {
            //[resharper:unused local variable] int bitLength = i.BitLength();
            return !(i >> n).IsEven;
        }

        public static int BitLength(this BigInteger i)
        {
            int bitLength = 0;
            do
            {
                bitLength++;
            }
            while ((i >>= 1) != 0);
            return bitLength;
        }

        public static byte[] ToByteArrayUnsigned(this BigInteger i, bool bigEndian)
        {
            byte[] bytes = i.ToByteArray();
            if (bytes[bytes.Length - 1] == 0x00)
                Array.Resize(ref bytes, bytes.Length - 1);
            if (bigEndian)
                Array.Reverse(bytes, 0, bytes.Length);

            return bytes;
        }

        public static BigInteger Order(this BigInteger b, BigInteger p)
        {
            BigInteger m = 1;
            BigInteger e = 0;

            while (BigInteger.ModPow(b, m, p) != 1)
            {
                m *= 2;
                e++;
            }

            return e;
        }

        private static BigInteger FindS(BigInteger p)
        {
            BigInteger s = p - 1;
            BigInteger e = 0;

            while (s % 2 == 0)
            {
                s /= 2;
                e += 1;
            }

            return s;
        }

        private static BigInteger FindE(BigInteger p)
        {
            BigInteger s = p - 1;
            BigInteger e = 0;

            while (s % 2 == 0)
            {
                s /= 2;
                e += 1;
            }

            return e;
        }

        private static BigInteger TwoExp(BigInteger e)
        {
            BigInteger a = 1;

            while (e > 0)
            {
                a *= 2;
                e--;
            }

            return a;
        }

        public static string ToHex(this BigInteger b)
        {
            return Hex.BigIntegerToHex(b);
        }

        public static string ToHex(this byte[] bytes)
        {
            return Hex.BytesToHex(bytes);
        }

        public static BigInteger HexToBigInteger(this string s)
        {
            return Hex.HexToBigInteger(s);
        }

        public static byte[] HexToBytes(this string s)
        {
            return Hex.HexToBytes(s);
        }

        public static BigInteger ToBigInteger(this byte[] bytes, bool bigEndian)
        {
            byte[] clone = new byte[bytes.Length];
            Buffer.BlockCopy(bytes, 0, clone, 0, bytes.Length);
            Array.Reverse(clone);

            return new BigInteger(bytes);
        }

        public static BigInteger ToBigIntegerUnsigned(this byte[] bytes, bool bigEndian)
        {
            byte[] clone;
            if (bigEndian)
            {
                if (bytes[0] != 0x00)
                {
                    clone = new byte[bytes.Length + 1];
                    Buffer.BlockCopy(bytes, 0, clone, 1, bytes.Length);
                    Array.Reverse(clone);
                    return new BigInteger(clone);
                }
                clone = new byte[bytes.Length];
                Buffer.BlockCopy(bytes, 0, clone, 0, bytes.Length);
                Array.Reverse(clone);
                return new BigInteger(clone);
            }

            if (bytes[bytes.Length - 1] == 0x00)
                return new BigInteger(bytes);

            clone = new byte[bytes.Length + 1];
            Buffer.BlockCopy(bytes, 0, clone, 0, bytes.Length);
            return new BigInteger(clone);
        }

        public static string GetBitcoinAddress(this ECPoint publicKey, bool compressed = true)
        {
            var pubKeyHash = Hash160.Hash(publicKey.EncodePoint(compressed));

            byte[] addressBytes = new byte[pubKeyHash.Length + 1];
            Buffer.BlockCopy(pubKeyHash, 0, addressBytes, 1, pubKeyHash.Length);
            return Base58.EncodeWithCheckSum(addressBytes);
        }

        public static BigInteger ShanksSqrt(this BigInteger a, BigInteger p)
        {
            if (BigInteger.ModPow(a, (p - 1) / 2, p) == (p - 1))
                return -1;

            if (p % 4 == 3)
                return BigInteger.ModPow(a, (p + 1) / 4, p);

            //Initialize 
            BigInteger s = FindS(p);
            BigInteger e = FindE(p);
            BigInteger n = 2;

            while (BigInteger.ModPow(n, (p - 1) / 2, p) == 1)
                n++;

            BigInteger x = BigInteger.ModPow(a, (s + 1) / 2, p);
            BigInteger b = BigInteger.ModPow(a, s, p);
            BigInteger g = BigInteger.ModPow(n, s, p);
            BigInteger r = e;
            BigInteger m = b.Order(p);

#if(DEBUG)
            Debug.WriteLine("{0}, {1}, {2}, {3}, {4}", m, x, b, g, r);
#endif
            while (m > 0)
            {
                x = (x * BigInteger.ModPow(g, TwoExp(r - m - 1), p)) % p;
                b = (b * BigInteger.ModPow(g, TwoExp(r - m), p)) % p;
                g = BigInteger.ModPow(g, TwoExp(r - m), p);
                r = m;
                m = b.Order(p);

#if(DEBUG)
                Debug.WriteLine("{0}, {1}, {2}, {3}, {4}", m, x, b, g, r);
#endif
            }

            return x;
        }
    }
}