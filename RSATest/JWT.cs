using Jose;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Reflection;

namespace RSATest
{
    public class JWT
    {
        private X509Certificate2 X509()
        {
            return new X509Certificate2("certificate.p12", "1", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
        }

        private RSACryptoServiceProvider PrivateKey()
        {
            var key = (RSACryptoServiceProvider)X509().PrivateKey;

            RSACryptoServiceProvider newKey = new RSACryptoServiceProvider();
            newKey.ImportParameters(key.ExportParameters(true));

            return newKey;
        }

        private RSACryptoServiceProvider PublicKey()
        {
            return (RSACryptoServiceProvider)X509().PublicKey.Key;
        }

        public void Test()
        {
            string s = "Hello World";
            var payload = new Dictionary<string, object>() 
                {
                    { "email", "abc@gmail.com" },
                    { "phone", 1300819380 }
                };


            //RS256            
            X509Certificate2 keys = new X509Certificate2("certificate.p12", "1", X509KeyStorageFlags.Exportable | X509KeyStorageFlags.MachineKeySet);
            var publickey = PublicKey();
            var privatekey = PrivateKey();
            string token = Jose.JWT.Encode(payload, PrivateKey(), JwsAlgorithm.RS256);
            string json = Jose.JWT.Decode(token, privatekey);//decode + verify signature


            ////HS256
            //var secretKey = new byte[] { 164, 60, 194, 0, 161, 189, 41, 38, 130, 89, 141, 164, 45, 170, 159, 209, 69, 137, 243, 216, 191, 131, 47, 250, 32, 107, 231, 117, 37, 158, 225, 234 };
            //string token = Jose.JWT.Encode(payload, secretKey, JwsAlgorithm.HS256);
            //string json = Jose.JWT.Decode(token, secretKey);
        }
    }
}
