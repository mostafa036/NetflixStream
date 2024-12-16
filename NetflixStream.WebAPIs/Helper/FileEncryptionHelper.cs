using Microsoft.Extensions.Options;
using System.Runtime.Intrinsics.Arm;
using System.Text;
using System.Security.Cryptography;

namespace NetflixStream.WebAPIs.Helper
{
    public class FileEncryptionHelper
    {
        private readonly byte[] _encryptionKey;
        private readonly byte[] _iv = new byte[16]; 

        public FileEncryptionHelper(IOptions<EncryptionSettings> encryptionSettings)
        {
            _encryptionKey = Encoding.UTF8.GetBytes(encryptionSettings.Value.EncryptionKey);
        }

        //public byte[] EncryptFile(string filePath)
        //{
        //    byte[] fileBytes = File.ReadAllBytes(filePath);

        //    using (Aes aes = Aes.Create())
        //    {

        //        aes.Key = _encryptionKey;
        //        aes.IV = _iv;

        //        using (ICryptoTransform encryptor = aes.CreateEncryptor(aes.Key, aes.IV))

        //        using (MemoryStream msEncrypt = new MemoryStream())
        //        {
        //            using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        //            {
        //                csEncrypt.Write(fileBytes, 0, fileBytes.Length);
        //                csEncrypt.FlushFinalBlock();
        //            }
        //            return msEncrypt.ToArray();
        //        }
        //    }
        //}




    }
}
