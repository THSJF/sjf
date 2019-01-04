// Decompiled with JetBrains decompiler
// Type: THMHJ.Code
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

namespace THMHJ
{
  internal struct Code
  {
    private int stm;
    private string text;

    public int Stm
    {
      get
      {
        return this.stm;
      }
    }

    public string Text
    {
      get
      {
        return this.text;
      }
    }

    public Code(int stm_i, string text_s)
    {
      this.stm = stm_i;
      this.text = text_s;
    }
  }
}
