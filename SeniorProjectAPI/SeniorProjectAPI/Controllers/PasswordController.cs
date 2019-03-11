using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Security.Cryptography;

namespace SeniorProjectAPI.Controllers
{
    public class PasswordController
    {
        public static Tuple<byte[], string> password_hash_with_salt(string password)
        {
            var rngCsp = new RNGCryptoServiceProvider();
            byte[] salt = new byte[20];
            rngCsp.GetBytes(salt);
            var password_bytes = ASCIIEncoding.ASCII.GetBytes(password);
            byte[] data_input = new byte[password_bytes.Length];
            for (int i = 0; i < password_bytes.Length; i++)
            {
                data_input[i] = password_bytes[i];
            }
            for (int i = 0; i < password_bytes.Length; i++)
            {
                data_input[i + password_bytes.Length] = salt[i];
            }

            SHA512 shaM = new SHA512Managed();
            var hashed_byte_array = shaM.ComputeHash(data_input);
            string hashed_result = System.Convert.ToBase64String(hashed_byte_array);
            return new Tuple<byte[], string>(salt, hashed_result);
        }


    }
}