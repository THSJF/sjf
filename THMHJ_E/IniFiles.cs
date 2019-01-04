// Decompiled with JetBrains decompiler
// Type: IniFiles
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Text;

public class IniFiles
{
  protected string IniFileName;

  public event IniFiles.EventHandler IniFileChanged;

  public event IniFiles.EventHandler Initialization;

  public string FileName
  {
    get
    {
      return this.IniFileName;
    }
    set
    {
      if (!(value != this.IniFileName))
        return;
      this.IniFileName = value;
      this.OnIniFileChanged(new EventArgs());
    }
  }

  protected void OnIniFileChanged(EventArgs e)
  {
    if (this.IniFileChanged == null)
      return;
    this.IniFileChanged((object) null, e);
  }

  protected void OnInitialization(EventArgs e)
  {
    if (this.Initialization == null)
      return;
    this.Initialization((object) null, e);
  }

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
    string defVal,
    StringBuilder retVal,
    int size,
    string filePath);

  public IniFiles(string FileName)
  {
    this.IniFileName = FileName;
  }

  public void WriteValue(string Section, string Key, string Value)
  {
    IniFiles.WritePrivateProfileString(Section, Key, Value, this.IniFileName);
  }

  public string ReadValue(string Section, string Key, string Default)
  {
    StringBuilder retVal = new StringBuilder(500);
    IniFiles.GetPrivateProfileString(Section, Key, Default, retVal, 500, this.IniFileName);
    return retVal.ToString();
  }

  public bool ExistINIFile()
  {
    return File.Exists(this.IniFileName);
  }

  private void NewDirectory(string path)
  {
    if (Directory.Exists(path))
      return;
    Directory.CreateDirectory(path);
  }

  public void AddNotes(string Notes)
  {
    string iniFileName = this.IniFileName;
    this.NewDirectory(Directory.GetParent(iniFileName).ToString());
    FileStream fileStream = new FileStream(iniFileName, FileMode.OpenOrCreate, FileAccess.Write);
    StreamWriter streamWriter = new StreamWriter((Stream) fileStream);
    streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
    streamWriter.WriteLine(";" + Notes);
    streamWriter.Flush();
    streamWriter.Close();
    fileStream.Close();
    streamWriter.Dispose();
    fileStream.Dispose();
  }

  public void AddText(string Text)
  {
    string iniFileName = this.IniFileName;
    this.NewDirectory(Directory.GetParent(iniFileName).ToString());
    FileStream fileStream = new FileStream(iniFileName, FileMode.OpenOrCreate, FileAccess.Write);
    StreamWriter streamWriter = new StreamWriter((Stream) fileStream);
    streamWriter.BaseStream.Seek(0L, SeekOrigin.End);
    streamWriter.WriteLine(Text);
    streamWriter.Flush();
    streamWriter.Close();
    fileStream.Close();
    streamWriter.Dispose();
    fileStream.Dispose();
  }

  public void WriteValue(string Section, string Key, int Value)
  {
    this.WriteValue(Section, Key, Value.ToString());
  }

  public void WriteValue(string Section, string Key, bool Value)
  {
    this.WriteValue(Section, Key, Value.ToString());
  }

  public void WriteValue(string Section, string Key, DateTime Value)
  {
    this.WriteValue(Section, Key, Value.ToString());
  }

  public void WriteValue(string Section, string Key, object Value)
  {
    this.WriteValue(Section, Key, Value.ToString());
  }

  public int ReadValue(string Section, string Key, int Default)
  {
    return Convert.ToInt32(this.ReadValue(Section, Key, Default.ToString()));
  }

  public bool ReadValue(string Section, string Key, bool Default)
  {
    return Convert.ToBoolean(this.ReadValue(Section, Key, Default.ToString()));
  }

  public DateTime ReadValue(string Section, string Key, DateTime Default)
  {
    return Convert.ToDateTime(this.ReadValue(Section, Key, Default.ToString()));
  }

  public string ReadValue(string Section, string Key)
  {
    return this.ReadValue(Section, Key, "");
  }

  public delegate void EventHandler(object sender, EventArgs e);
}
