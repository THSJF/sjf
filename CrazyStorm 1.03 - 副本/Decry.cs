// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.Cry
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace CrazyStorm_1._03
{
  internal class Cry
  {
    private static byte[] Keys = new byte[16]
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
    };
    private static byte[] Keys2 = new byte[16]
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
    };

    public static string Decry(string strString, string Keys)
    {
      TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
      MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
      cryptoServiceProvider1.Key = cryptoServiceProvider2.ComputeHash(Encoding.Default.GetBytes(Keys));
      cryptoServiceProvider1.Mode = CipherMode.ECB;
      ICryptoTransform decryptor = cryptoServiceProvider1.CreateDecryptor();
      byte[] inputBuffer = Convert.FromBase64String(strString);
      return Encoding.Default.GetString(decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }

    public static Stream Decry(string FileName)
    {
      TripleDESCryptoServiceProvider cryptoServiceProvider1 = new TripleDESCryptoServiceProvider();
      MD5CryptoServiceProvider cryptoServiceProvider2 = new MD5CryptoServiceProvider();
      cryptoServiceProvider1.Key = cryptoServiceProvider2.ComputeHash(Cry.Keys);
      cryptoServiceProvider1.Mode = CipherMode.ECB;
      ICryptoTransform decryptor = cryptoServiceProvider1.CreateDecryptor();
      byte[] numArray1 = new byte[0];
      byte[] numArray2 = new byte[0];
      byte[] inputBuffer = File.ReadAllBytes(FileName);
      return (Stream) new MemoryStream(decryptor.TransformFinalBlock(inputBuffer, 0, inputBuffer.Length));
    }
  }
}
