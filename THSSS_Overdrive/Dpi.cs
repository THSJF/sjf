// Decompiled with JetBrains decompiler
// Type: Shooting.Dpi
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.Management;

namespace Shooting
{
  public class Dpi
  {
    public static int PixelsPerXLogicalInch;
    public static int PixelsPerYLogicalInch;

    public static void GetDpi()
    {
      using (ManagementClass managementClass = new ManagementClass("Win32_DesktopMonitor"))
      {
        using (ManagementObjectCollection instances = managementClass.GetInstances())
        {
          Dpi.PixelsPerXLogicalInch = 0;
          Dpi.PixelsPerYLogicalInch = 0;
          foreach (ManagementObject managementObject in instances)
          {
            Dpi.PixelsPerXLogicalInch = int.Parse(managementObject.Properties["PixelsPerXLogicalInch"].Value.ToString());
            Dpi.PixelsPerYLogicalInch = int.Parse(managementObject.Properties["PixelsPerYLogicalInch"].Value.ToString());
          }
        }
      }
    }
  }
}
