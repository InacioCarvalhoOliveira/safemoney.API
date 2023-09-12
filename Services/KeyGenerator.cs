namespace safemoney.API.Services
{

    using System;
    using System.Security.Cryptography;

    public static class KeyGenerator
    {
        public static byte[] Generate256BitKey()
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                byte[] keyBytes = new byte[32]; // 32 bytes = 256 bits
                randomNumberGenerator.GetBytes(keyBytes);
                return keyBytes;
            }
        }
    }
}