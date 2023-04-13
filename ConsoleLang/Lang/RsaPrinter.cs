using System;
using System.Security.Cryptography;
using System.Text;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Encodings;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Security;

namespace ConsoleLang.Lang
{
    public class RsaPrinter : MyPrinter
    {
        public static string PublicKeyBase64 =
            "MIGfMA0GCSqGSIb3DQEBAQUAA4GNADCBiQKBgQDCQSY+aGmhLzOWMXERzWuVxhPCe5JsEK+p22brmbTYU8pVPQ4LZ0VfGOiNay0D/tpPnt7+edjt9RvLaWz9m9P2MWeiCoLnq9Z0K36w8Wy+zVpr/62VKPXk6YVuO4aVez7V+Bwoz8UvbA7SIxiPTltvDBPrMfBlUDY2futE2ohlywIDAQAB";

        // byte[] publicKeyBytes = Convert.FromBase64String(publicKeyBase64);
        public static string PublicKeyXml =
            $"<RSAKeyValue><Modulus>{PublicKeyBase64}</Modulus><Exponent>AQAB</Exponent></RSAKeyValue>";

        public static string PrivateKeyBase64 =
            "MIICdgIBADANBgkqhkiG9w0BAQEFAASCAmAwggJcAgEAAoGBAMJBJj5oaaEvM5YxcRHNa5XGE8J7kmwQr6nbZuuZtNhTylU9DgtnRV8Y6I1rLQP+2k+e3v552O31G8tpbP2b0/YxZ6IKguer1nQrfrDxbL7NWmv/rZUo9eTphW47hpV7PtX4HCjPxS9sDtIjGI9OW28ME+sx8GVQNjZ+60TaiGXLAgMBAAECgYEAo1etFOUvjT3nnu/MKDAXu0Vn8C2AniYZ0DaRgKMrEozCopJIcQZRqvmC8wegPq/aWwE4ebtz0gQ9bvojj82smOzp8D1g4c9zzwvbpQF86GjBY7pqN8aY3coUXUKk5WNLBBZ0xrLkGXhxUxI1ZI6BiNXLG1+roFGcCcrxckIoDaECQQDovJzn3OaM4lLnS6MTVxRAmH8BZqtz3iSPRdO9afQOCisKw6MhziVC5wGsnFqxa9T8C6GpXJra1lzV9zQJVyg9AkEA1avVEVM6CPuITa6jEsE9ooIh7vTm148QCSXe88LX+0eMsBi1EH2gDoiXDC1ZvV6vrR9N9i1B0lGCCI9KpS4epwJAAkwyZFua7xMg7GWjw4IdkhGvV00zLh6oT73JvFn6bdUN3bpWtvO5DHMJYjHc91lwLdjTjL98S+LH4djh66GvpQJAAQsVvz/oyKJxx+9SXIUVB/YatE/90I+iRGkq7YXGCDQRO8rjF3GFloyUMDsIdSRBN1cvykPuTliXifMpKiVPgQJADdYYNxn7fthBgdd+AL0WNcOp2O7129iuGIVSkSrB8D/iXN4tKA6/edBex4GWLCIgRmkR1DcMpsIKEh08vLiwPg==";

        public static string PrivateKeyXml = $"<RSAKeyValue><D>{PrivateKeyBase64}</D></RSAKeyValue>";

        /**
         * https://try8.cn/tool/cipher/rsa
         */
        public void print()
        {
            string key = "1681180665";
            string plaintext = "hello world";

            // Encrypt
            IAsymmetricBlockCipher engine = new Pkcs1Encoding(new RsaEngine());
            AsymmetricKeyParameter publicKeyParameter = PublicKeyFactory.CreateKey(Convert.FromBase64String(PublicKeyBase64));
            engine.Init(true, publicKeyParameter);
            byte[] plaintextBytes = Encoding.UTF8.GetBytes(plaintext);
            byte[] ciphertextBytes = engine.ProcessBlock(plaintextBytes, 0, plaintextBytes.Length);
            Console.WriteLine(Convert.ToBase64String(ciphertextBytes));

            // Decrypt
            engine = new Pkcs1Encoding(new RsaEngine());
            AsymmetricKeyParameter privateKeyParameter = PrivateKeyFactory.CreateKey(Convert.FromBase64String(PrivateKeyBase64));
            engine.Init(false, privateKeyParameter);
            byte[] resultBytes = engine.ProcessBlock(ciphertextBytes, 0, ciphertextBytes.Length);
            Console.WriteLine(Encoding.UTF8.GetString(resultBytes));
        }

        public void print3()
        {
            string key = "1681180665";
            string plaintext = "hello world";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(1024))
            {
                // Encrypt
                RSAParameters rsaParams = new RSAParameters();
                rsaParams.Modulus = Convert.FromBase64String(PublicKeyBase64);
                rsaParams.Exponent = Convert.FromBase64String("AQAB");
                rsa.ImportParameters(rsaParams);
                byte[] ciphertextBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), false);
                Console.WriteLine(Convert.ToBase64String(ciphertextBytes));

                // Decrypt
            }
        }

        public void print2()
        {
            string key = "1681180665";
            string plaintext = "hello world";
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                // Encrypt
                rsa.FromXmlString(PublicKeyXml);
                byte[] ciphertextBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), false);
                string ciphertextBase64 = Convert.ToBase64String(ciphertextBytes);
                Console.WriteLine(ciphertextBase64);

                // Decrypt
            }
        }

        public void print1()
        {
            string plaintext = "hello world";

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                string publicKey = rsa.ToXmlString(false);
                string privateKey = rsa.ToXmlString(true);
                Console.WriteLine($"publicKey -> {publicKey}\nprivateKey -> {privateKey}");

                // Encrypt
                byte[] ciphertextBytes = rsa.Encrypt(Encoding.UTF8.GetBytes(plaintext), false);
                string ciphertextBase64 = Convert.ToBase64String(ciphertextBytes);
                Console.WriteLine($"ciphertextBase64 -> {ciphertextBase64}");

                // Decrypt
                byte[] plaintextBytes = rsa.Decrypt(Convert.FromBase64String(ciphertextBase64), false);
                Console.WriteLine($"plaintext -> {Encoding.UTF8.GetString(ciphertextBytes)}");
            }
        }
    }
}