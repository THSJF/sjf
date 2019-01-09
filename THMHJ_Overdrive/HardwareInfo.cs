// Decompiled with JetBrains decompiler
// Type: THMHJ.HardwareInfo
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System;
using System.Management;
using System.Net;
using System.Runtime.InteropServices;

namespace THMHJ
{
  public class HardwareInfo
  {
    public string GetHostName()
    {
      return Dns.GetHostName();
    }

    public string GetCpuID()
    {
      try
      {
        ManagementObjectCollection instances = new ManagementClass("Win32_Processor").GetInstances();
        string str = (string) null;
        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = instances.GetEnumerator())
        {
          if (enumerator.MoveNext())
            str = enumerator.Current.Properties["ProcessorId"].Value.ToString();
        }
        return str;
      }
      catch
      {
        return "";
      }
    }

    public string GetHardDiskID()
    {
      try
      {
        ManagementObjectSearcher managementObjectSearcher = new ManagementObjectSearcher("SELECT * FROM Win32_PhysicalMedia");
        string str = (string) null;
        using (ManagementObjectCollection.ManagementObjectEnumerator enumerator = managementObjectSearcher.Get().GetEnumerator())
        {
          if (enumerator.MoveNext())
            str = enumerator.Current["SerialNumber"].ToString().Trim();
        }
        return str;
      }
      catch
      {
        return "";
      }
    }

    public string GetMacAddress()
    {
      string str = "";
      try
      {
        HardwareInfo.NCB ncb = new HardwareInfo.NCB();
        ncb.ncb_command = (byte) 55;
        int cb1 = Marshal.SizeOf(typeof (HardwareInfo.LANA_ENUM));
        ncb.ncb_buffer = Marshal.AllocHGlobal(cb1);
        ncb.ncb_length = (ushort) cb1;
        char ch1 = HardwareInfo.Win32API.Netbios(ref ncb);
        HardwareInfo.LANA_ENUM structure = (HardwareInfo.LANA_ENUM) Marshal.PtrToStructure(ncb.ncb_buffer, typeof (HardwareInfo.LANA_ENUM));
        Marshal.FreeHGlobal(ncb.ncb_buffer);
        if (ch1 != char.MinValue)
          return "";
        for (int index = 0; index < (int) structure.length; ++index)
        {
          ncb.ncb_command = (byte) 50;
          ncb.ncb_lana_num = structure.lana[index];
          if (HardwareInfo.Win32API.Netbios(ref ncb) != char.MinValue)
            return "";
          ncb.ncb_command = (byte) 51;
          ncb.ncb_lana_num = structure.lana[index];
          ncb.ncb_callname[0] = (byte) 42;
          int cb2 = Marshal.SizeOf(typeof (HardwareInfo.ADAPTER_STATUS)) + Marshal.SizeOf(typeof (HardwareInfo.NAME_BUFFER)) * 30;
          ncb.ncb_buffer = Marshal.AllocHGlobal(cb2);
          ncb.ncb_length = (ushort) cb2;
          char ch2 = HardwareInfo.Win32API.Netbios(ref ncb);
          HardwareInfo.ASTAT astat;
          astat.adapt = (HardwareInfo.ADAPTER_STATUS) Marshal.PtrToStructure(ncb.ncb_buffer, typeof (HardwareInfo.ADAPTER_STATUS));
          Marshal.FreeHGlobal(ncb.ncb_buffer);
          if (ch2 == char.MinValue)
          {
            if (index > 0)
              str += ":";
            str = string.Format("{0,2:X}{1,2:X}{2,2:X}{3,2:X}{4,2:X}{5,2:X}", (object) astat.adapt.adapter_address[0], (object) astat.adapt.adapter_address[1], (object) astat.adapt.adapter_address[2], (object) astat.adapt.adapter_address[3], (object) astat.adapt.adapter_address[4], (object) astat.adapt.adapter_address[5]);
          }
        }
      }
      catch
      {
      }
      return str.Replace(' ', '0');
    }

    public enum NCBCONST
    {
      NRC_GOODRET = 0,
      NCBNAMSZ = 16, // 0x00000010
      NUM_NAMEBUF = 30, // 0x0000001E
      NCBRESET = 50, // 0x00000032
      NCBASTAT = 51, // 0x00000033
      NCBENUM = 55, // 0x00000037
      MAX_LANA = 254, // 0x000000FE
    }

    public struct ADAPTER_STATUS
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 6)]
      public byte[] adapter_address;
      public byte rev_major;
      public byte reserved0;
      public byte adapter_type;
      public byte rev_minor;
      public ushort duration;
      public ushort frmr_recv;
      public ushort frmr_xmit;
      public ushort iframe_recv_err;
      public ushort xmit_aborts;
      public uint xmit_success;
      public uint recv_success;
      public ushort iframe_xmit_err;
      public ushort recv_buff_unavail;
      public ushort t1_timeouts;
      public ushort ti_timeouts;
      public uint reserved1;
      public ushort free_ncbs;
      public ushort max_cfg_ncbs;
      public ushort max_ncbs;
      public ushort xmit_buf_unavail;
      public ushort max_dgram_size;
      public ushort pending_sess;
      public ushort max_cfg_sess;
      public ushort max_sess;
      public ushort max_sess_pkt_size;
      public ushort name_count;
    }

    public struct NAME_BUFFER
    {
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
      public byte[] name;
      public byte name_num;
      public byte name_flags;
    }

    public struct NCB
    {
      public byte ncb_command;
      public byte ncb_retcode;
      public byte ncb_lsn;
      public byte ncb_num;
      public IntPtr ncb_buffer;
      public ushort ncb_length;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
      public byte[] ncb_callname;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 16)]
      public byte[] ncb_name;
      public byte ncb_rto;
      public byte ncb_sto;
      public IntPtr ncb_post;
      public byte ncb_lana_num;
      public byte ncb_cmd_cplt;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 10)]
      public byte[] ncb_reserve;
      public IntPtr ncb_event;
    }

    public struct LANA_ENUM
    {
      public byte length;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 254)]
      public byte[] lana;
    }

    [StructLayout(LayoutKind.Auto)]
    public struct ASTAT
    {
      public HardwareInfo.ADAPTER_STATUS adapt;
      [MarshalAs(UnmanagedType.ByValArray, SizeConst = 30)]
      public HardwareInfo.NAME_BUFFER[] NameBuff;
    }

    public class Win32API
    {
      [DllImport("NETAPI32.DLL")]
      public static extern char Netbios(ref HardwareInfo.NCB ncb);
    }
  }
}
