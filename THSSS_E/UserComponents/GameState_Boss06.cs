 
// Type: Shooting.GameState_Boss06
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

namespace Shooting
{
  internal class GameState_Boss06 : GameState_SSS06, IGameState
  {
    public GameState_Boss06(GlobalDataPackage GlobalData)
      : base(GlobalData)
    {
      this.StageName = "Bs6";
      this.testStartTime = 8400;
    }

    public override void Drama()
    {
      base.Drama();
      this.MyPlane.EnchantmentCount = this.MyPlane.EnchantmentCountNeeded;
    }
  }
}
