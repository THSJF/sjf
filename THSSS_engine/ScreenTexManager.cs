using SlimDX.Direct3D9;

namespace Shooting
{
  public class ScreenTexManager
  {
    public ScreenTexture[] ScreenTex { get; private set; }

    private int ScreenLevel { get; set; }

    public Texture RenderTexture
    {
      get
      {
        return this.ScreenTex[this.ScreenLevel].renderTexture;
      }
    }

    public ScreenTexManager(Device DeviceMain)
    {
      this.ScreenTex = new ScreenTexture[5];
      for (int index = 0; index < this.ScreenTex.Length; ++index)
        this.ScreenTex[index] = new ScreenTexture(DeviceMain, 640, 480);
    }

    public void Begin()
    {
      this.ScreenTex[this.ScreenLevel++].Begin();
    }

    public void End()
    {
      this.ScreenTex[--this.ScreenLevel].End();
    }

    public void Reset()
    {
      for (int index = 0; index < this.ScreenTex.Length; ++index)
      {
        if (this.ScreenTex[index] != null)
          this.ScreenTex[index].Reset();
      }
    }

    public void Dispose()
    {
      for (int index = 0; index < this.ScreenTex.Length; ++index)
      {
        if (this.ScreenTex[index] != null)
          this.ScreenTex[index].Dispose();
      }
    }
  }
}
