using System.Collections.Generic;

namespace Shooting
{
  public class ReplayInfo
  {
    public List<MyPlaneInfo> MyPlaneData = new List<MyPlaneInfo>();
    public string Version;
    public string PlayerName;
    public string MyPlaneName;
    public string Date;
    public string Time;
    public string WeaponType;
    public DifficultLevel Rank;
    public string StartStage;
    public string LastStage;
    public string SlowRate;
  }
}
