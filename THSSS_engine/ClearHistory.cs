using System;

namespace Shooting
{
  public class ClearHistory
  {
    public string MyPlaneFullName { get; set; }

    public DifficultLevel Rank { get; set; }

    public int StartTimes { get; set; }

    public long PlayingTime { get; set; }

    public int ClearTimes { get; set; }

    public int NoContinueClearTimes { get; set; }

    public int PracticeLevel { get; set; }

    public string Data2String()
    {
      return this.MyPlaneFullName + (object) '\t' + ((int) this.Rank).ToString() + (object) '\t' + this.StartTimes.ToString() + (object) '\t' + this.PlayingTime.ToString() + (object) '\t' + this.ClearTimes.ToString() + (object) '\t' + this.NoContinueClearTimes.ToString() + (object) '\t' + this.PracticeLevel.ToString() + "\r\n";
    }

    public void String2Data(string Data)
    {
      char[] chArray = new char[1]{ '\t' };
      string[] strArray = Data.Split(chArray);
      this.MyPlaneFullName = strArray[0];
      this.Rank = (DifficultLevel) Convert.ToInt32(strArray[1]);
      this.StartTimes = Convert.ToInt32(strArray[2]);
      this.PlayingTime = (long) Convert.ToInt32(strArray[3]);
      this.ClearTimes = Convert.ToInt32(strArray[4]);
      this.NoContinueClearTimes = Convert.ToInt32(strArray[5]);
      this.PracticeLevel = Convert.ToInt32(strArray[6]);
    }
  }
}
