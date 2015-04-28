using System;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;

namespace Secp256k1
{
    public class ECEncryption
    {
        private ECElGamal ecElGamal = new ECElGamal();
        private RijndaelManaged aesEncryption = new RijndaelManaged();
        private RNGCryptoServiceProvider rngCsp = new RNGCryptoServiceProvider();

        public ECEncryption()
        {
            aesEncryption.KeySize = 256;
            aesEncryption.BlockSize = 128;
            aesEncryption.Mode = CipherMode.CBC;
            aesEncryption.Padding = PaddingMode.PKCS7;
        }

        public byte[] Encrypt(ECPoint publicKey, string message)
        {
            byte[] data = Encoding.UTF8.GetBytes(message);

            return Encrypt(publicKey, data);
        }

        public byte[] Encrypt(ECPoint publicKey, byte[] data)
        {
            byte[] key;
            var tag = ecElGamal.GenerateKey(publicKey, out key);
            var tagBytes = tag.EncodePoint(false);

            byte[] iv = new byte[16];
            rngCsp.GetBytes(iv);

            aesEncryption.IV = iv;

            aesEncryption.Key = key;

            ICryptoTransform crypto = aesEncryption.CreateEncryptor();

            byte[] cipherData = crypto.TransformFinalBlock(data, 0, data.Length);

            byte[] cipher = new byte[cipherData.Length + 65 + 16];

            Buffer.BlockCopy(tagBytes, 0, cipher, 0, 65);
            Buffer.BlockCopy(aesEncryption.IV, 0, cipher, 65, 16);
            Buffer.BlockCopy(cipherData, 0, cipher, 65 + 16, cipherData.Length);

            return cipher;
        }

        public byte[] Decrypt(BigInteger privateKey, byte[] cipherData)
        {
            byte[] tagBytes = new byte[65];
            Buffer.BlockCopy(cipherData, 0, tagBytes, 0, tagBytes.Length);
            var keyPoint = ECPoint.DecodePoint(tagBytes);

            byte[] iv = new byte[16];
            Buffer.BlockCopy(cipherData, 65, iv, 0, iv.Length);

            byte[] cipher = new byte[cipherData.Length - 16 - 65];
            Buffer.BlockCopy(cipherData, 65 + 16, cipher, 0, cipher.Length);

            byte[] key = ecElGamal.DecipherKey(privateKey, keyPoint);

            aesEncryption.IV = iv;
            aesEncryption.Key = key;

            ICryptoTransform decryptor = aesEncryption.CreateDecryptor();

            byte[] decryptedData = decryptor.TransformFinalBlock(cipher, 0, cipher.Length);

            return decryptedData;
        }
    }
}
