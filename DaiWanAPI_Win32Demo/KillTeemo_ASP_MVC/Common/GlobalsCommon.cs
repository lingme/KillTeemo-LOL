using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace KillTeemo_ASP_MVC.Common
{
    public class GlobalsCommon
    {
        public static readonly string Kill_key = "killTeemo_key";

        /// <summary>
        /// 加密字符串（RSA）
        /// </summary>
        /// <param name="express"></param>
        /// <returns></returns>
        public static string Encryption(string express)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = Kill_key;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] plaindata = System.Text.Encoding.Default.GetBytes(express);
                byte[] encryptdata = rsa.Encrypt(plaindata, false);
                return Convert.ToBase64String(encryptdata);
            }
        }

        /// <summary>
        /// 解密字符串（RSA）
        /// </summary>
        /// <param name="ciphertext"></param>
        /// <returns></returns>
        public static string Decrypt(string ciphertext)
        {
            CspParameters param = new CspParameters();
            param.KeyContainerName = Kill_key;
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(param))
            {
                byte[] encryptdata = Convert.FromBase64String(ciphertext);
                byte[] decryptdata = rsa.Decrypt(encryptdata, false);
                return System.Text.Encoding.Default.GetString(decryptdata);
            }
        }
    }
}