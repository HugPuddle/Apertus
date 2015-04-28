using System;
using System.Numerics;

namespace Secp256k1
{
    public class ECPoint : ICloneable
    {
        private readonly bool _isInfinity;
        private readonly BigInteger _x;
        private BigInteger _y;

        public ECPoint(BigInteger x, BigInteger y):this(x, y, false)
        {
        }

        public ECPoint(BigInteger x, BigInteger y, bool isInfinity)
        {
            _x = x;
            _y = y;
            _isInfinity = isInfinity;
        }

        private ECPoint()
        {
            _isInfinity = true;
        }

        public BigInteger X
        {
            get { return _x; }
        }

        public BigInteger Y
        {
            get { return _y; }
        }

        public static ECPoint Infinity
        {
            get { return new ECPoint(); }
        }

        public bool IsInfinity
        {
            get { return _isInfinity; }
        }

        public object Clone()
        {
            return new ECPoint(_x, _y, _isInfinity);
        }

        //TODO: Rename to Encode (point is implied)
        public byte[] EncodePoint(bool compressed)
        {
            if (IsInfinity)
                return new byte[1];

            byte[] x = X.ToByteArrayUnsigned(true);
            byte[] encoded;
            if (!compressed)
            {
                byte[] y = Y.ToByteArrayUnsigned(true);
                encoded = new byte[65];
                encoded[0] = 0x04;
                Buffer.BlockCopy(y, 0, encoded, 33 + (32 - y.Length), y.Length);
            }
            else
            {
                encoded = new byte[33];
                encoded[0] = (byte) (Y.TestBit(0) ? 0x03 : 0x02);
            }

            Buffer.BlockCopy(x, 0, encoded, 1 + (32 - x.Length), x.Length);
            return encoded;
        }

        //TODO: Rename to Decode (point is implied)
        public static ECPoint DecodePoint(byte[] encoded)
        {
            if (encoded == null || ((encoded.Length != 33 && encoded[0] != 0x02 && encoded[0] != 0x03) && (encoded.Length != 65 && encoded[0] != 0x04)))
                throw new FormatException("Invalid encoded point");

            var unsigned = new byte[32];
            Buffer.BlockCopy(encoded, 1, unsigned, 0, 32);
            BigInteger x = unsigned.ToBigIntegerUnsigned(true);
            BigInteger y;
            byte prefix = encoded[0];

            if (prefix == 0x04) //uncompressed PubKey
            {
                Buffer.BlockCopy(encoded, 33, unsigned, 0, 32);
                y = unsigned.ToBigIntegerUnsigned(true);
            }
            else // compressed PubKey
            {
                // solve y
                y = ((x * x * x + 7) % Secp256k1.P).ShanksSqrt(Secp256k1.P);

                if (y.IsEven ^ prefix == 0x02) // negate y for prefix (0x02 indicates y is even, 0x03 indicates y is odd)
                    y = -y + Secp256k1.P;      // TODO:  DRY replace this and body of Negate() with call to static method
            }
            return new ECPoint(x, y);
        }

        public ECPoint Negate()
        {
            var r = (ECPoint) Clone();
            r._y = -r._y + Secp256k1.P;
            return r;
        }

        public ECPoint Subtract(ECPoint b)
        {
            return Add(b.Negate());
        }

        public ECPoint Add(ECPoint b)
        {
            BigInteger m;
            //[Resharper unused local variable] BigInteger r = 0;

            if (IsInfinity)
                return b;
            if (b.IsInfinity)
                return this;

            if (X - b.X == 0)
            {
                if (Y - b.Y == 0)
                    m = 3 * X * X * (2 * Y).ModInverse(Secp256k1.P);
                else
                    return Infinity;
            }
            else
            {
                var mx = (X - b.X);
                if (mx < 0)
                    mx += Secp256k1.P;
                m = (Y - b.Y) * mx.ModInverse(Secp256k1.P);
            }

            m = m % Secp256k1.P;

            var v = Y - m * X;
            var x3 = (m * m - X - b.X);
            x3 = x3 % Secp256k1.P;
            if (x3 < 0)
                x3 += Secp256k1.P;
            var y3 = -(m * x3 + v);
            y3 = y3 % Secp256k1.P;
            if (y3 < 0)
                y3 += Secp256k1.P;

            return new ECPoint(x3, y3);
        }

        public ECPoint Twice()
        {
            return Add(this);
        }

        public ECPoint Multiply(BigInteger b)
        {
            if (b.Sign == -1)
                throw new FormatException("The multiplicator cannot be negative");

            b = b % Secp256k1.N;

            ECPoint result = Infinity;
            ECPoint temp = null;

            //[Resharper local variable only assigned not used] int bit = 0;
            do
            {
                temp = temp == null ? this : temp.Twice();

                if (!b.IsEven)
                    result = result.Add(temp);
                //bit++;
            }
            while ((b >>= 1) != 0);

            return result;
        }
    }
}