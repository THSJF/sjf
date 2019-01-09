using System;

namespace Shooting
{
  public class ScoreHistory
  {
    public string MyPlaneFullName { get; set; }

    public DifficultLevel Rank { get; set; }

    public string PlayerName { get; set; }

    public long Score { get; set; }

    public string Date { get; set; }

    public string Time { get; set; }

    public string Stage { get; set; }

    public string SlowRate { get; set; }

    public string Data2String()
    {
      return this.MyPlaneFullName + (object) '\t' + ((int) this.Rank).ToString() + (object) '\t' + this.PlayerName + (object) '\t' + this.Score.ToString() + (object) '\t' + this.Date + (object) '\t' + this.Time + (object) '\t' + this.Stage + (object) '\t' + this.SlowRate + "\r\n";
    }

    public string Data2DrawString()
    {
      return this.PlayerName.PadRight(8) + this.Score.ToString().PadLeft(11) + this.Date.PadLeft(12) + this.Time.PadLeft(6) + this.Stage.PadLeft(4) + this.SlowRate.PadLeft(5);
    }

    public string Data2DrawStringSimple()
    {
      return this.PlayerName.PadRight(8) + this.Score.ToString().PadLeft(11) + this.Stage.PadLeft(5) + this.SlowRate.PadLeft(6);
    }

    public void String2Data(string Data)
    {
      char[] chArray = new char[1]{ '\t' };
      string[] strArray = Data.Split(chArray);
      this.MyPlaneFullName = strArray[0];
      this.Rank = (DifficultLevel) Convert.ToInt32(strArray[1]);
      this.PlayerName = strArray[2];
      this.Score = Convert.ToInt64(strArray[3]);
      this.Date = strArray[4];
      this.Time = strArray[5];
      this.Stage = strArray[6];
      this.SlowRate = strArray[7];
    }

    public void Copy(ScoreHistory SH)
    {
      this.String2Data(SH.Data2String().Replace("\r\n", string.Empty));
    }
  }
}
