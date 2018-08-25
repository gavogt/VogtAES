using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using System.IO;

namespace Practice_AES
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create an AES object
            Aes aes = Aes.Create();

        }

        public static string Encrypt(string str, byte[] Key, byte[] IV)
        {
            return str;
        }

        public static Byte[] Decrypt(byte[] Data, byte[] Key, byte[] IV)
        {
            return Data;
        }
    }
}
