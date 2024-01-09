using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;


namespace LG
{
    internal class Hash
    {
        public static string creat(string s)
        {
            StringBuilder sb = new StringBuilder();
            SHA256 hash = SHA256Managed.Create();
            Encoding ens = Encoding.UTF8;
            byte[] hashbyte = hash.ComputeHash(ens.GetBytes(s));
            foreach (byte b in hashbyte)
            {
                sb.Append(b.ToString("x2"));
            }
            return sb.ToString();
        }
    }
}
