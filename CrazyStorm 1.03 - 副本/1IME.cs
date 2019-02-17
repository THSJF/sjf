// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.WindowInputCapturer
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace CrazyStorm_1._03
{
  public sealed class WindowInputCapturer : NativeWindow, IDisposable
  {
    public static List<Character> myCharacters = new List<Character>();
    private IntPtr context = IntPtr.Zero;
    private const int DLGC_WANTCHARS = 128;
    private const int DLGC_WANTALLKEYS = 4;
    private Game game;
    private bool disposed;

    public WindowInputCapturer(IntPtr windowHandle, Game game)
    {
      this.AssignHandle(windowHandle);
      this.game = game;
    }

    public void Dispose()
    {
      if (this.disposed)
        return;
      this.ReleaseHandle();
      this.disposed = true;
    }

    protected override void WndProc(ref System.Windows.Forms.Message message)
    {
      if (message.Msg == 81)
        return;
      if (message.Msg == 641 && message.WParam.ToInt32() == 1)
      {
        IntPtr context = IMM.ImmGetContext(this.Handle);
        if (this.context == IntPtr.Zero)
          this.context = context;
        IMM.ImmAssociateContext(this.Handle, this.context);
      }
      base.WndProc(ref message);
      switch (message.Msg)
      {
        case 135:
          if (WindowInputCapturer.Is32Bit)
          {
            int num = message.Result.ToInt32() | 132;
            message.Result = new IntPtr(num);
            break;
          }
          long num1 = message.Result.ToInt64() | 132L;
          message.Result = new IntPtr(num1);
          break;
        case 258:
          int int32 = message.WParam.ToInt32();
          Character character = new Character();
          character.IsUsed = false;
          character.Chars = (char) int32;
          switch (int32)
          {
            case 8:
              character.CharaterType = characterType.BackSpace;
              break;
            case 9:
              character.CharaterType = characterType.Tab;
              break;
            case 13:
              character.CharaterType = characterType.Enter;
              break;
            case 27:
              character.CharaterType = characterType.Esc;
              break;
            default:
              character.CharaterType = characterType.Char;
              break;
          }
          WindowInputCapturer.myCharacters.Add(character);
          break;
      }
    }

    private static bool Is32Bit
    {
      get
      {
        return IntPtr.Size == 4;
      }
    }

    private enum WindowMessages
    {
      WM_GETDLGCODE = 135, // 0x00000087
      WM_CHAR = 258, // 0x00000102
    }
  }
}
