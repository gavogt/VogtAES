﻿using System;
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
            byte[] encrypted = default;
            string message = String.Empty;
            string decrypted = String.Empty;

            // Create an AES object
            Aes aes = Aes.Create();

            Console.WriteLine("What is the message you'd like to encrypt?: ");
            message = Console.ReadLine();

            try
            {
                encrypted = Encrypt(message, aes.Key, aes.IV);
                Console.WriteLine(encrypted);

                // cw snippet
                Console.WriteLine("Here");
                decrypted = Decrypt(encrypted, aes.Key, aes.IV);
                Console.WriteLine(decrypted);
                
            }
            catch
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                Console.WriteLine("Error! Please try again!");
                
            }


        }

        /// <summary>
        /// Method that takes a string to be encrypted by AES
        /// </summary>
        /// <param name="str">String to pass in to be encrypted</param>
        /// <param name="Key">Key for the data</param>
        /// <param name="IV">Initialization Vector for the data</param>
        /// <returns></returns>
        public static byte[] Encrypt(string str, byte[] Key, byte[] IV)
        {
            Aes aes = Aes.Create();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, aes.CreateEncryptor(Key, IV), CryptoStreamMode.Write);

            // Couldn't remember again
            Byte[] toEncrypt = new ASCIIEncoding().GetBytes(str);

            cs.Write(toEncrypt, 0, toEncrypt.Length);
            cs.FlushFinalBlock();

            byte[] encrypted = ms.ToArray();

            ms.Close();
            cs.Close();

            return encrypted;

        }


        #region Decrypt
        /// <summary>
        /// Method that decrypts AES
        /// </summary>
        /// <param name="Data">Byte Array to pass in the encrypted data</param>
        /// <param name="Key">Key for the data</param>
        /// <param name="IV">Initialization Vector for the data</param>
        /// <returns></returns>
        public static string Decrypt(byte[] Data, byte[] Key, byte[] IV)
        {
            Aes aes = Aes.Create();

            MemoryStream ms = new MemoryStream();
            CryptoStream cs = new CryptoStream(ms, aes.CreateDecryptor(Key, IV), CryptoStreamMode.Read);

            // Couldn't remember
            byte[] decrypted = new byte[Data.Length];

            cs.Read(decrypted, 0, decrypted.Length);

            return new ASCIIEncoding().GetString(decrypted);

        }
        #endregion
    }
}
