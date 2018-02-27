using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Hash
{
    internal enum mode { md5, sha1, sha256, sha384, sha512 };

    internal class Hasher
    {
        private mode mode;

        internal mode Mode { get => mode; set => mode = value; }

        internal StringBuilder Calculate(string str, mode mode)
        {
            var bytes = Encoding.UTF8.GetBytes(str);
            byte[] result;
            switch (mode)
            {
                case mode.md5:
                    MD5CryptoServiceProvider mD5Crypto = new MD5CryptoServiceProvider();
                    result = mD5Crypto.ComputeHash(bytes);
                    break;
                case mode.sha1:
                    SHA1CryptoServiceProvider sHA1Crypto = new SHA1CryptoServiceProvider();
                    result = sHA1Crypto.ComputeHash(bytes);
                    break;
                case mode.sha256:
                    SHA256CryptoServiceProvider sHA256Crypto = new SHA256CryptoServiceProvider();
                    result = sHA256Crypto.ComputeHash(bytes);
                    break;
                case mode.sha384:
                    SHA384CryptoServiceProvider sHA384Crypto = new SHA384CryptoServiceProvider();
                    result = sHA384Crypto.ComputeHash(bytes);
                    break;
                default:
                    SHA512CryptoServiceProvider sHA512Crypto = new SHA512CryptoServiceProvider();
                    result = sHA512Crypto.ComputeHash(bytes);
                    break;
            }
            StringBuilder builder = new StringBuilder();
            foreach (var a in result)
                builder.Append(a.ToString("X"));
            return builder;
        }

        internal StringBuilder Calculate(FileStream bytes, mode mode)
        {
            byte[] result;
            switch (mode)
            {
                case mode.md5:
                    MD5CryptoServiceProvider mD5Crypto = new MD5CryptoServiceProvider();
                    result = mD5Crypto.ComputeHash(bytes);
                    break;
                case mode.sha1:
                    SHA1CryptoServiceProvider sHA1Crypto = new SHA1CryptoServiceProvider();
                    result = sHA1Crypto.ComputeHash(bytes);
                    break;
                case mode.sha256:
                    SHA256CryptoServiceProvider sHA256Crypto = new SHA256CryptoServiceProvider();
                    result = sHA256Crypto.ComputeHash(bytes);
                    break;
                case mode.sha384:
                    SHA384CryptoServiceProvider sHA384Crypto = new SHA384CryptoServiceProvider();
                    result = sHA384Crypto.ComputeHash(bytes);
                    break;
                default:
                    SHA512CryptoServiceProvider sHA512Crypto = new SHA512CryptoServiceProvider();
                    result = sHA512Crypto.ComputeHash(bytes);
                    break;
            }
            StringBuilder builder = new StringBuilder();
            foreach (var a in result)
                builder.Append(a.ToString("X"));
            return builder;
        }
    }
}
