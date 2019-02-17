using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CrazyStorm_1._03 {
    internal class EnCry {
        private static byte[] Key = new byte[16] { 0x4F,0x0E,0x2A,0x5B,0x09,0x0C,0x8F,0xDD,0x3E,0xC1,0xB2,0xA3,0xFF,0xA2,0x05,0x07 };
        private static byte[] Key2 = new byte[16] { 0x1C,0x5B,0x3D,0x00,0x05,0x04,0x7F,0xBB,0xCC,0x2D,0xC3,0xD4,0xAA,0xF1,0xF2,0xF8 };

        public static string Encry(string strString,string strKey) {
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
            cryptoServiceProvider1.Key=cryptoServiceProvider2.ComputeHash(Encoding.Default.GetBytes(strKey));
            cryptoServiceProvider1.Mode=CipherMode.ECB;
            ICryptoTransform encryptor = cryptoServiceProvider1.CreateEncryptor();
            byte[] bytes = Encoding.Default.GetBytes(strString);
            return Convert.ToBase64String(encryptor.TransformFinalBlock(bytes,0,bytes.Length));
        }

        public static byte[] Encry(string FileName) {
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
            cryptoServiceProvider1.Key=cryptoServiceProvider2.ComputeHash(EnCry.Key);
            cryptoServiceProvider1.Mode=CipherMode.ECB;
            ICryptoTransform encryptor = cryptoServiceProvider1.CreateEncryptor();
            byte[] inputBuffer = File.ReadAllBytes(FileName);
            byte[] buffer = encryptor.TransformFinalBlock(inputBuffer,0,inputBuffer.Length);
            FileStream fileStream = File.Open(EnCry.Cuts(FileName,".",1)+".dat",FileMode.OpenOrCreate);
            fileStream.Write(buffer,0,buffer.GetLength(0));
            fileStream.Close();
            return buffer;
        }

        public static string Cuts(string word,string num,int array) {
            char[] charArray = num.ToCharArray();
            return word.Split(charArray)[array-1];
        }
    }
}
