using System;
using System.Security.Cryptography;
using System.Text;

namespace SaveLoad
{
    public sealed class Сryptographer
    {
        private readonly byte[] Key = Convert.FromBase64String("AsISxq9OwdZag1163OJqwovXfSWG98m+sPjVwJecfe4=");
        private readonly byte[] IV = Convert.FromBase64String("Aq0UThtJhjbuyWXtmZs1rw==");
        
        public byte[] DecryptData(string serializedData)
        {
            using var encryptor = Aes.Create();
            encryptor.Key = Key;
            encryptor.IV = IV;

            var transform = encryptor.CreateEncryptor();
            var encryptedData = transform.TransformFinalBlock(Encoding.UTF8.GetBytes(serializedData),
                0, serializedData.Length);
            
            return encryptedData;
        }

        public string EncryptData(byte[] encryptedData)
        {
            using var deсryptor = Aes.Create();
            deсryptor.Key = Key;
            deсryptor.IV = IV;

            var transform = deсryptor.CreateDecryptor();
            var decryptedData = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
            var jsonData = Encoding.UTF8.GetString(decryptedData);
            return jsonData;
        }
    }
}