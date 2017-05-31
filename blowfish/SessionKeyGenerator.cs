using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace blowfish
{
    class SessionKeyGenerator
    {
        public string GenerateSK(uint keyLength)
        {
            
            byte[] buffer;
            Random rnd = new Random();
            string sessionKey;

            switch (keyLength)
            {
              

                case 128:
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey = BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    break;
                case 256:
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey = BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    break;

                case 448:
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey = BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey = BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey += BitConverter.ToUInt64(buffer, 0).ToString();
                    buffer = new byte[sizeof(Int64)];
                    rnd.NextBytes(buffer);
                    sessionKey = BitConverter.ToUInt64(buffer, 0).ToString();
                    break;

                default:
                    sessionKey = "";
                    break;
            }
            return sessionKey;
        }
    }
}
