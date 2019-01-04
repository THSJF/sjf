// Decompiled with JetBrains decompiler
// Type: Shooting.CharacterName
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Drawing;

namespace Shooting
{
  internal class CharacterName : BaseStoryItem
  {
    public CharacterName(StageDataPackage StageData, string textureName)
      : base(StageData)
    {
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Right - 70);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Top + 300);
      this.Position = new PointF((float) num1, (float) num2);
      this.Velocity = 0.0f;
      this.Direction = Math.PI / 2.0;
      this.TransparentValueF = 0.0f;
      this.TxtureObject = this.TextureObjectDictionary[textureName];
      this.TransparentVelocityDictionary.Add(10, 20f);
      this.TransparentVelocityDictionary.Add(210, -10f);
    }
  }
}
