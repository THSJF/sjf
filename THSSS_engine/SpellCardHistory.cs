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
