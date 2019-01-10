using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Shooting {
    internal class Encryption {
        public static string Encrypt(string pToEncrypt) {
            string s1 = "SeiweLL0";
            string s2 = "0SeiweLL";
            DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
            cryptoServiceProvider.Key=Encoding.ASCII.GetBytes(s1);
            cryptoServiceProvider.IV=Encoding.ASCII.GetBytes(s2);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,cryptoServiceProvider.CreateEncryptor(),CryptoStreamMode.Write);
            cryptoStream.Write(bytes,0,bytes.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            foreach(byte num in memoryStream.ToArray()) {
                stringBuilder.AppendFormat("{0:X2}",num);
            }
            return stringBuilder.ToString();
        }
        public static string Decrypt(string pToDecrypt) {
            string s1 = "SeiweLL0";
            string s2 = "0SeiweLL";
            DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
            byte[] buffer = new byte[pToDecrypt.Length/2];
            for(int index = 0;index<pToDecrypt.Length/2;++index) {
                int int32 = Convert.ToInt32(pToDecrypt.Substring(index*2,2),16);
                buffer[index]=(byte)int32;
            }
            cryptoServiceProvider.Key=Encoding.ASCII.GetBytes(s1);
            cryptoServiceProvider.IV=Encoding.ASCII.GetBytes(s2);
            MemoryStream memoryStream = new MemoryStream();
            CryptoStream cryptoStream = new CryptoStream(memoryStream,cryptoServiceProvider.CreateDecryptor(),CryptoStreamMode.Write);
            cryptoStream.Write(buffer,0,buffer.Length);
            cryptoStream.FlushFinalBlock();
            StringBuilder stringBuilder = new StringBuilder();
            return Encoding.Default.GetString(memoryStream.ToArray());
        }
    }
}
