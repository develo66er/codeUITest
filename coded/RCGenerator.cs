using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace coded
{
    internal sealed class RCGenerator
    {
        const int BufferSize = 1024;
        byte[] RandomBuffer;
        int BufferOffset;
        static System.Security.Cryptography.RNGCryptoServiceProvider rng;
        static RCGenerator()
        {
            rng = new System.Security.Cryptography.RNGCryptoServiceProvider();
        }
        public RCGenerator()
        {
            RandomBuffer = new byte[BufferSize];
            BufferOffset = RandomBuffer.Length;
        }
        private byte Next()
        {
            if (BufferOffset >= RandomBuffer.Length)
            {
                rng.GetBytes(RandomBuffer);
                BufferOffset = 0;
            }
            return RandomBuffer[BufferOffset++];
        }
        public int Next(int minValue, int maxValue)
        {
            int range = maxValue - minValue;
            return minValue + Next() % range;
        }

        const int MinStringLength = 6;
        const int MaxStringLength = 10;
        public string NextString()
        {
            StringBuilder sb = new StringBuilder();
            int count = Next(MinStringLength, MaxStringLength);
            for (int i = 0; i < count; i++)
                sb.Append((char)Next('a', 'z'));
            return sb.ToString();
        }
    }

}
