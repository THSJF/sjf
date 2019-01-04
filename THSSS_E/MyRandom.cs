// Decompiled with JetBrains decompiler
// Type: Shooting.MyRandom
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;

namespace Shooting
{
  public class MyRandom : Random
  {
    public int ranValue { get; private set; }

    public MyRandom()
    {
    }

    public MyRandom(int Seed)
      : base(Seed)
    {
    }

    public override int Next()
    {
      this.ranValue = base.Next();
      return this.ranValue;
    }

    public override int Next(int maxValue)
    {
      this.ranValue = base.Next(maxValue);
      return this.ranValue;
    }

    public override int Next(int minValue, int maxValue)
    {
      this.ranValue = base.Next(minValue, maxValue);
      return this.ranValue;
    }

    public override double NextDouble()
    {
      double num = base.NextDouble();
      this.ranValue = (int) (num * 100.0);
      return num;
    }

    public override void NextBytes(byte[] buffer)
    {
      this.ranValue = 0;
      base.NextBytes(buffer);
    }

    public double NextPMDouble()
    {
      return 2.0 * this.NextDouble() - 1.0;
    }
  }
}
