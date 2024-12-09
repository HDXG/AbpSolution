using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RYDesign.AspNetCore.Utils
{
    /// <summary>
    /// 加密方法类
    /// </summary>
    public static  class Md5CryptUtils
    {
        /// <summary>
        /// MD5进行加密
        /// </summary>
        /// <param name="Str"></param>
        /// <returns></returns>
        public static string Md5Encrypt(string Str)
        {
            MD5 md5 = MD5.Create();
            byte[] data = Encoding.Default.GetBytes(Str);
            byte[] md5data = md5.ComputeHash(data);
            md5.Clear();
            StringBuilder stringBuilder = new StringBuilder();
            for (int i = 0; i < md5data.Length; i++)
            {
                stringBuilder.Append(md5data[i].ToString("x2"));
            }
            return stringBuilder.ToString();
        }


        /// <summary>
        /// 判断md5内容是否一致
        /// </summary>
        /// <param name="StrNew">内容</param>
        /// <param name="StrOld">原内容加密的MD5</param>
        /// <returns></returns>
        public static bool Md5Decrypt(string StrNew, string StrOld) => Md5Encrypt(StrNew) == StrOld;


    }
}
