// Decompiled with JetBrains decompiler
// Type: THMHJ.Cry
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace THMHJ {
    public class Cry {
        public static string Key;
        public static string Vector;

        private static byte[][] Keys() {
            return new byte[4][]
            {
        new byte[16]
        {
          (byte) 79,
          (byte) 14,
          (byte) 42,
          (byte) 91,
          (byte) 9,
          (byte) 12,
          (byte) 143,
          (byte) 221,
          (byte) 62,
          (byte) 193,
          (byte) 178,
          (byte) 163,
          byte.MaxValue,
          (byte) 162,
          (byte) 5,
          (byte) 7
        },
        new byte[16]
        {
          (byte) 28,
          (byte) 91,
          (byte) 61,
          (byte) 0,
          (byte) 5,
          (byte) 4,
          (byte) 127,
          (byte) 187,
          (byte) 204,
          (byte) 45,
          (byte) 195,
          (byte) 212,
          (byte) 170,
          (byte) 241,
          (byte) 242,
          (byte) 248
        },
        new byte[16]
        {
          (byte) 204,
          (byte) 219,
          (byte) 153,
          (byte) 8,
          byte.MaxValue,
          (byte) 250,
          (byte) 154,
          (byte) 184,
          (byte) 199,
          (byte) 109,
          (byte) 227,
          (byte) 171,
          (byte) 202,
          (byte) 253,
          (byte) 254,
          (byte) 250
        },
        new byte[16]
        {
          (byte) 79,
          (byte) 145,
          (byte) 221,
          (byte) 238,
          (byte) 198,
          (byte) 51,
          (byte) 249,
          (byte) 164,
          (byte) 187,
          (byte) 17,
          (byte) 252,
          (byte) 13,
          (byte) 241,
          (byte) 184,
          (byte) 23,
          (byte) 0
        }
            };
        }

        public static string Encry(string strString,string strKey) {
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
            cryptoServiceProvider1.Key=cryptoServiceProvider2.ComputeHash(Encoding.Default.GetBytes(strKey));
            cryptoServiceProvider1.Mode=CipherMode.ECB;
            ICryptoTransform encryptor = cryptoServiceProvider1.CreateEncryptor();
            byte[] bytes = Encoding.Default.GetBytes(strString);
            return Convert.ToBase64String(encryptor.TransformFinalBlock(bytes,0,bytes.Length));
        }

        public static byte[] Encry(string FileName,int type) {
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
            cryptoServiceProvider1.Key=cryptoServiceProvider2.ComputeHash(Cry.Keys()[type]);
            cryptoServiceProvider1.Mode=CipherMode.ECB;
            ICryptoTransform encryptor = cryptoServiceProvider1.CreateEncryptor();
            byte[] inputBuffer = File.ReadAllBytes(FileName);
            byte[] buffer = encryptor.TransformFinalBlock(inputBuffer,0,inputBuffer.Length);
            FileStream fileStream = type==3 ? File.Create(Cry.Cuts(FileName,".",1)+".rpy") : File.Create(Cry.Cuts(FileName,".",1)+".xna");
            fileStream.Write(buffer,0,buffer.GetLength(0));
            fileStream.Close();
            return buffer;
        }

        public static string Cuts(string word,string num,int array) {
            char[] charArray = num.ToCharArray();
            return word.Split(charArray)[array-1];
        }

        public static string Decry(string strString,string Keys) {
            byte[] inputBuffer = Convert.FromBase64String(strString);
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
            cryptoServiceProvider1.Key=cryptoServiceProvider2.ComputeHash(Encoding.Default.GetBytes(Keys));
            cryptoServiceProvider1.Mode=CipherMode.ECB;
            return Encoding.Default.GetString(cryptoServiceProvider1.CreateDecryptor().TransformFinalBlock(inputBuffer,0,inputBuffer.Length));
        }

        public static Stream Decry(string FileName,int type) {
            byte[] numArray = File.ReadAllBytes(FileName);
            TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
            cryptoServiceProvider1.Key=cryptoServiceProvider2.ComputeHash(Keys()[type]);
            cryptoServiceProvider1.Mode=CipherMode.ECB;
            ICryptoTransform decryptor = cryptoServiceProvider1.CreateDecryptor();
            byte[] inputBuffer = numArray;

            if(!File.Exists(FileName+".png")) {
                MemoryStream ms = new MemoryStream(decryptor.TransformFinalBlock(inputBuffer,0,inputBuffer.Length));
                FileStream file = new FileStream(FileName+".png",FileMode.Create,FileAccess.Write);
                byte[] bytes = new byte[ms.Length];
                ms.Read(bytes,0,(int)ms.Length);
                file.Write(bytes,0,bytes.Length);
                file.Close();
                ms.Close();
            }

            return new MemoryStream(decryptor.TransformFinalBlock(inputBuffer,0,inputBuffer.Length));
        }

        public static byte[] Encrypt(byte[] Data) {
            byte[] rgbKey = new byte[32];
            Array.Copy((Array)Encoding.UTF8.GetBytes(Cry.Key.PadRight(rgbKey.Length)),(Array)rgbKey,rgbKey.Length);
            byte[] rgbIV = new byte[16];
            Array.Copy((Array)Encoding.UTF8.GetBytes(Cry.Vector.PadRight(rgbIV.Length)),(Array)rgbIV,rgbIV.Length);
            Rijndael rijndael = Rijndael.Create();
            using(MemoryStream memoryStream = new MemoryStream()) {
                using(CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream,rijndael.CreateEncryptor(rgbKey,rgbIV),CryptoStreamMode.Write)) {
                    cryptoStream.Write(Data,0,Data.Length);
                    cryptoStream.FlushFinalBlock();
                    return memoryStream.ToArray();
                }
            }
        }

        public static byte[] Decrypt(byte[] Data) {
            byte[] rgbKey = new byte[32];
            Array.Copy((Array)Encoding.UTF8.GetBytes(Cry.Key.PadRight(rgbKey.Length)),(Array)rgbKey,rgbKey.Length);
            byte[] rgbIV = new byte[16];
            Array.Copy((Array)Encoding.UTF8.GetBytes(Cry.Vector.PadRight(rgbIV.Length)),(Array)rgbIV,rgbIV.Length);
            Rijndael rijndael = Rijndael.Create();
            using(MemoryStream memoryStream1 = new MemoryStream(Data)) {
                using(CryptoStream cryptoStream = new CryptoStream((Stream)memoryStream1,rijndael.CreateDecryptor(rgbKey,rgbIV),CryptoStreamMode.Read)) {
                    using(MemoryStream memoryStream2 = new MemoryStream()) {
                        byte[] buffer = new byte[1024];
                        int count;
                        while((count=cryptoStream.Read(buffer,0,buffer.Length))>0)
                            memoryStream2.Write(buffer,0,count);
                        return memoryStream2.ToArray();
                    }
                }
            }
        }
    }
}
