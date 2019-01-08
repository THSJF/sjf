// Decompiled with JetBrains decompiler
// Type: Shooting.INI_RW
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.IO;
using System.Runtime.InteropServices;
using System.Text;

namespace Shooting
{
  public class INI_RW
  {
    public string inipath;

    [DllImport("kernel32")]
    private static extern long WritePrivateProfileString(
      string section,
      string key,
      string val,
      string filePath);

    [DllImport("kernel32")]
    private static extern int GetPrivateProfileString(
      string section,
      string key,
      string def,
      StringBuilder retVal,
      int size,
      string filePath);

    public INI_RW(string INIPath)
    {
      this.inipath = INIPath;
    }

    public void IniWriteValue(string Section, string Key, string Value)
    {
      INI_RW.WritePrivateProfileString(Section, Key, Value, this.inipath);
    }

    public string IniReadValue(string Section, string Key)
    {
      StringBuilder retVal = new StringBuilder(500);
      INI_RW.GetPrivateProfileString(Section, Key, "", retVal, 500, this.inipath);
      return retVal.ToString();
    }

    public bool ExistINIFile()
    {
      return File.Exists(this.inipath);
    }
  }
}
