// Decompiled with JetBrains decompiler
// Type: Shooting.SpellCardHistory
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;

namespace Shooting
{
  public class SpellCardHistory
  {
    public string MyPlaneFullName { get; set; }

    public DifficultLevel Rank { get; set; }

    public int Index { get; set; }

    public string Name { get; set; }

    public int Recorded { get; set; }

    public int History { get; set; }

    public string Data2String()
    {
      return this.Index.ToString() + (object) '\t' + this.MyPlaneFullName + (object) '\t' + ((int) this.Rank).ToString() + (object) '\t' + this.Recorded.ToString() + (object) '\t' + this.History.ToString() + "\r\n";
    }

    public void String2Data(string Data)
    {
      char[] chArray = new char[1]{ '\t' };
      string[] strArray = Data.Split(chArray);
      this.Index = Convert.ToInt32(strArray[0]);
      this.MyPlaneFullName = strArray[1];
      this.Rank = (DifficultLevel) Convert.ToInt32(strArray[2]);
      this.Recorded = Convert.ToInt32(strArray[3]);
      this.History = Convert.ToInt32(strArray[4]);
    }
  }
}
