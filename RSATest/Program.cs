using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Security.Cryptography;

namespace RSATest
{
    class Program
    {
        static void Main(string[] args)
        {
            ////Crypto - same keys
            //string plaintext = "Hello";
            //string tempKey = Guid.NewGuid().ToString() + "-" + Guid.NewGuid().ToString();
            //string encryptString = Crypto.EncryptStringAES(plaintext, tempKey);
            //string decryptString = Crypto.DecryptStringAES(encryptString, tempKey);

            ////AES256 - different keys
            //Tuple<string, string> keys = AES256.CreateKeyPair();
            //string plainText = "Hello world.";
            //byte[] encryptedByte = AES256.Encrypt(keys.Item2, plainText);
            //string decryptText = AES256.Decrypt(keys.Item1, encryptedByte);

            JWT test = new JWT();
            test.Test();
        }
    }
}
