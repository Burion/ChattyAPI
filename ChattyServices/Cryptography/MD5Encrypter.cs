using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.Text;

namespace ChattyServices.Cryptography
{
    public static class MD5Encrypter
    {
        public static string Encode(string input)
        {
            using (var md5 = MD5.Create())
            {
                byte[] inputBytes = Encoding.UTF8.GetBytes(input);
                var output = md5.ComputeHash(inputBytes);

                return Convert.ToHexString(output);
            }
        }
    }
}
