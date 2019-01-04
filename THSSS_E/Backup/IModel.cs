// Decompiled with JetBrains decompiler
// Type: Shooting.IModel
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX.Direct3D9;
using System.Drawing;

namespace Shooting
{
  public interface IModel
  {
    Color ColorValue { get; set; }

    Device DeviceMain { get; set; }

    TextureObject TxtureObject { get; set; }

    int TransparentValue { get; set; }

    string Name { get; set; }

    void Draw();

    void SetModel();

    void SetupMaterial();

    void SetupVertex();

    void SetVertexFormat();

    void Dispose();
  }
}
