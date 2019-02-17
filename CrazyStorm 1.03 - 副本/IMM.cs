// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.IMM
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using System;
using System.Runtime.InteropServices;

namespace CrazyStorm_1._03
{
  internal sealed class IMM
  {
    [DllImport("imm32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr ImmGetContext(IntPtr hWnd);

    [DllImport("imm32.dll", CharSet = CharSet.Auto)]
    public static extern IntPtr ImmAssociateContext(IntPtr hWnd, IntPtr hIMC);
  }
}
