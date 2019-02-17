// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.History
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections.Generic;

namespace CrazyStorm_1._03
{
  internal class History
  {
    public static List<string> history = new List<string>();

    public static void Clear()
    {
      History.history.Clear();
    }

    public static void Draw(SpriteBatch s)
    {
      for (int index = (int) MathHelper.Clamp((float) (History.history.Count - 4), 0.0f, (float) (History.history.Count - 1)); index < History.history.Count; ++index)
        Main.font.Draw(s, History.history[index], new Vector2(9f, (float) (285 + (History.history.Count - 1 - index) * 42)), Color.White);
    }
  }
}
