﻿using System.Management;

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
