using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;

namespace CryptoCrew.Authentication
{
    public class X509Cert
    {
        public static X509Certificate2 getCertificate()
        {
            // The path to the certificate.
            string Certificate = "/App_Data/Certificates/Badri.cer";

            // Load the certificate into an X509Certificate object.
            X509Certificate2 cert = new X509Certificate2(Certificate);

            // Get the value.
            return cert;
        }
    }
    public static class RandomString
    {
        // Generate a random number between two numbers  
        public static int RandomNumber(int min, int max)
        {
            Random random = new Random();
            return random.Next(min, max);
        }
        // Generate a random string with a given size  
        public static string generate(int size, bool lowerCase)
        {
            StringBuilder builder = new StringBuilder();
            Random random = new Random();
            char ch;
            for (int i = 0; i < size; i++)
            {
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));
                builder.Append(ch);
            }
            if (lowerCase)
                return builder.ToString().ToLower();
            return builder.ToString();
        }
        // Generate a random password  
        public static string RandomPassword()
        {
            StringBuilder builder = new StringBuilder();
            builder.Append(generate(4, true));
            builder.Append(RandomNumber(1000, 9999));
            builder.Append(generate(2, false));
            return builder.ToString();
        }
    }


    public class StringEncryption
    {
        public static string Encrypt(string input)
        {
            X509Certificate2 cert2 = X509Cert.getCertificate();

            string output = string.Empty;

            using (RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert2.PublicKey.Key)
            {
                byte[] bytesData = Encoding.UTF8.GetBytes(input);
                byte[] bytesEncrypted = csp.Encrypt(bytesData, false);
                output = Convert.ToBase64String(bytesEncrypted);
            }

            return output;
        }
    }

    public class StringDecryption
    {
        public string Decrypt(string input)
        {
            X509Certificate2 cert = X509Cert.getCertificate();

            string text = string.Empty;

            try
            {
                using (RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key)
                {
                    byte[] bytesEncrypted = Convert.FromBase64String(input);
                    byte[] bytesDecrypted = csp.Decrypt(bytesEncrypted, false);
                    text = Encoding.UTF8.GetString(bytesDecrypted);
                }
                return text;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                throw;
            }
        }
    }
}