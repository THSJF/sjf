 
// Type: Shooting.Properties.Resources
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System.CodeDom.Compiler;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.Resources;
using System.Runtime.CompilerServices;

namespace Shooting.Properties
{
  [GeneratedCode("System.Resources.Tools.StronglyTypedResourceBuilder", "4.0.0.0")]
  [DebuggerNonUserCode]
  [CompilerGenerated]
  internal class Resources
  {
    private static ResourceManager resourceMan;
    private static CultureInfo resourceCulture;

    internal Resources()
    {
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static ResourceManager ResourceManager
    {
      get
      {
        if (object.ReferenceEquals((object) Shooting.Properties.Resources.resourceMan, (object) null))
          Shooting.Properties.Resources.resourceMan = new ResourceManager("Shooting.Properties.Resources", typeof (Shooting.Properties.Resources).Assembly);
        return Shooting.Properties.Resources.resourceMan;
      }
    }

    [EditorBrowsable(EditorBrowsableState.Advanced)]
    internal static CultureInfo Culture
    {
      get
      {
        return Shooting.Properties.Resources.resourceCulture;
      }
      set
      {
        Shooting.Properties.Resources.resourceCulture = value;
      }
    }

    internal static Bitmap background
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (background), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap FiveStar
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (FiveStar), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap Menu_Start
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (Menu_Start), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap MyPlane
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (MyPlane), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap Player
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (Player), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap Power
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (Power), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap Score
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (Score), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap Spell
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (Spell), Shooting.Properties.Resources.resourceCulture);
      }
    }

    internal static Bitmap 菜单背景
    {
      get
      {
        return (Bitmap) Shooting.Properties.Resources.ResourceManager.GetObject(nameof (菜单背景), Shooting.Properties.Resources.resourceCulture);
      }
    }
  }
}
