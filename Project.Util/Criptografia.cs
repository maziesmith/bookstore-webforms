using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Project.Util
{
    public class Criptografia
    {
        /// <summary>
        /// Método de criptografia utilizando o algorítimo MD5.
        /// </summary>
        /// <param name="senha"></param>
        /// <returns></returns>
        public static string Encriptar(string senha)
        {
            MD5 md5 = new MD5CryptoServiceProvider();

            byte[] hash = md5.ComputeHash(Encoding.UTF8.GetBytes(senha));

            return BitConverter.ToString(hash).Replace("-", string.Empty);
        }
    }
}
