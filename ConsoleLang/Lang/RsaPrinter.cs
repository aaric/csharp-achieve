using System;
using System.Security.Cryptography;
using System.Text;

namespace ConsoleLang.Lang
{
    public class RsaPrinter : MyPrinter
    {
        /**
         * https://try8.cn/tool/cipher/rsa
         */
        public void print()
        {
            string plaintext = "hello world";
            string publicKeyBase64 =
                "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQCiKM2EmJeeQ8fMzK776mWdykCwGF8tP+bUmFYv0VyLZCjLQW7e6HLQG0LCdwTW0bm81nWhLymSPp6G7TrojrTGaOeIn+KCAer0vH8xYX6+oFbohzHxipOjNnnI1LHlgaCctPgQC9lVUKtAnjJy5Vpa+B/fCzKoyBlBOptIMCzNuwIDAQAB";
            // byte[] publicKeyBytes = Convert.FromBase64String(publicKeyBase64);
            string publicKeyXml =
                $"<RSAKeyValue><Modulus>{publicKeyBase64}</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // rsa.ImportCspBlob(publicKeyBytes);
                rsa.FromXmlString(publicKeyXml);
                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] ciphertextBytes = rsa.Encrypt(plaintextBytes, false);
                string ciphertextBase64 = Convert.ToBase64String(ciphertextBytes);
                Console.WriteLine(ciphertextBase64);
            }
        }

        public void print2()
        {
            string plaintext = "hello world";

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);
                Console.WriteLine($"publicKey -> {publicKey}\nprivateKey -> {privateKey}");

                byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
                byte[] ciphertextBytes = rsa.Encrypt(plaintextBytes, false);
                string ciphertextBase64 = Convert.ToBase64String(ciphertextBytes);
                Console.WriteLine($"ciphertextBase64 -> {ciphertextBase64}");
            }
        }
    }
}