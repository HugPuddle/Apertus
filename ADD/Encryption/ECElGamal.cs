using System;
using System.Numerics;
using System.Security.Cryptography;

namespace Secp256k1
{
    public class ECElGamal
    {
        private RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public ECPoint GenerateKey(ECPoint publicKey, out byte[] key)
        {
            return GenerateKey(publicKey, out key, null);
        }

        public ECPoint GenerateKey(ECPoint publicKey, out byte[] key, BigInteger? k)
        {
            for (int i = 0; i < 100; i++)
            {
                if (k == null)
                {
                    byte[] kBytes = new byte[33];
                    rngCsp.GetBytes(kBytes);
                    kBytes[32] = 0;

                    k = new BigInteger(kBytes);
                }

                if (k.Value.IsZero || k.Value >= Secp256k1.N) continue;

                var tag = Secp256k1.G.Multiply(k.Value);
                var keyPoint = publicKey.Multiply(k.Value);

                if (keyPoint.IsInfinity || tag.IsInfinity) continue;

                key = SHA256.DoubleHash(keyPoint.EncodePoint(false));

                return tag;
            }

            throw new Exception("Unable to generate key");
        }

        public byte[] DecipherKey(BigInteger privateKey, ECPoint tag)
        {
            var keyPoint = tag.Multiply(privateKey);
            var key = SHA256.DoubleHash(keyPoint.EncodePoint(false));

            return key;
        }
    }
}
