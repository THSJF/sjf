// Decompiled with JetBrains decompiler
// Type: Shooting.JoystickCapture
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using SlimDX.DirectInput;
using System;
using System.Collections.Generic;

namespace Shooting
{
  public class JoystickCapture
  {
    public JoystickState currentJoystickState = new JoystickState();
    public JoystickState lastJoystickState = new JoystickState();
    private Joystick joystick;

    public JoystickCapture(IntPtr handle)
    {
      SlimDX.DirectInput.DirectInput directInput = new SlimDX.DirectInput.DirectInput();
      foreach (DeviceInstance device in (IEnumerable<DeviceInstance>) directInput.GetDevices(DeviceClass.GameController, DeviceEnumerationFlags.AttachedOnly))
      {
        try
        {
          this.joystick = new Joystick(directInput, device.InstanceGuid);
          this.joystick.SetCooperativeLevel(handle, CooperativeLevel.Foreground | CooperativeLevel.Exclusive);
          break;
        }
        catch (DirectInputException ex)
        {
        }
      }
      if (this.joystick == null)
        return;
      foreach (DeviceObjectInstance deviceObjectInstance in (IEnumerable<DeviceObjectInstance>) this.joystick.GetObjects())
      {
        if ((deviceObjectInstance.ObjectType & ObjectDeviceType.Axis) != ObjectDeviceType.All)
          this.joystick.GetObjectPropertiesById((int) deviceObjectInstance.ObjectType).SetRange(-1000, 1000);
      }
      this.joystick.Acquire();
    }

    public void UpdateInput(ref KeyClass KClass)
    {
      if (this.joystick == null || this.joystick.Acquire().IsFailure || this.joystick.Poll().IsFailure)
        return;
      this.lastJoystickState = this.currentJoystickState;
      this.currentJoystickState = this.joystick.GetCurrentState();
      if (Result.Last.IsFailure)
        return;
      KClass.ArrowLeft = this.currentJoystickState.X < -600;
      KClass.ArrowRight = this.currentJoystickState.X > 600;
      KClass.ArrowUp = this.currentJoystickState.Y < -600;
      KClass.ArrowDown = this.currentJoystickState.Y > 600;
      KClass.Key_Shift = this.currentJoystickState.IsPressed(MapJoyStick.Slow);
      KClass.Key_Z = this.currentJoystickState.IsPressed(MapJoyStick.Shoot);
      KClass.Key_X = this.currentJoystickState.IsPressed(MapJoyStick.Bomb);
      KClass.Key_Ctrl = this.currentJoystickState.IsPressed(MapJoyStick.Skip);
      KClass.Key_ESC = this.currentJoystickState.IsPressed(MapJoyStick.Pause);
      KClass.Key_plus |= KClass.Key_Ctrl;
      KClass.Key_minus |= KClass.Key_Shift;
    }

    public void Dispose()
    {
      if (this.joystick != null)
      {
        this.joystick.Unacquire();
        this.joystick.Dispose();
      }
      this.joystick = (Joystick) null;
    }
  }
}
