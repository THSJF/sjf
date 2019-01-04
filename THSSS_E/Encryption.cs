// Decompiled with JetBrains decompiler
// Type: Shooting.Encryption
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Shooting
{
  internal class Encryption
  {
    public static string Encrypt(string pToEncrypt)
    {
      string s1 = "SeiweLL0";
      string s2 = "0SeiweLL";
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      byte[] bytes = Encoding.Default.GetBytes(pToEncrypt);
      cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(s1);
      cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(s2);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider.CreateEncryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(bytes, 0, bytes.Length);
      cryptoStream.FlushFinalBlock();
      StringBuilder stringBuilder = new StringBuilder();
      foreach (byte num in memoryStream.ToArray())
        stringBuilder.AppendFormat("{0:X2}", (object) num);
      return stringBuilder.ToString();
    }

    public static string Decrypt(string pToDecrypt)
    {
      string s1 = "SeiweLL0";
      string s2 = "0SeiweLL";
      DESCryptoServiceProvider cryptoServiceProvider = new DESCryptoServiceProvider();
      byte[] buffer = new byte[pToDecrypt.Length / 2];
      for (int index = 0; index < pToDecrypt.Length / 2; ++index)
      {
        int int32 = Convert.ToInt32(pToDecrypt.Substring(index * 2, 2), 16);
        buffer[index] = (byte) int32;
      }
      cryptoServiceProvider.Key = Encoding.ASCII.GetBytes(s1);
      cryptoServiceProvider.IV = Encoding.ASCII.GetBytes(s2);
      MemoryStream memoryStream = new MemoryStream();
      CryptoStream cryptoStream = new CryptoStream((Stream) memoryStream, cryptoServiceProvider.CreateDecryptor(), CryptoStreamMode.Write);
      cryptoStream.Write(buffer, 0, buffer.Length);
      cryptoStream.FlushFinalBlock();
      StringBuilder stringBuilder = new StringBuilder();
      return Encoding.Default.GetString(memoryStream.ToArray());
    }
  }
}
