// Decompiled with JetBrains decompiler
// Type: THMHJ.Launcher
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;

namespace THMHJ
{
  internal class Launcher : _3DPraticleManager
  {
    private int time;
    public ModelM model;
    public _3DPraticle setting;
    public Vector3 rectvta;
    public Vector3 rectvtb;
    public Vector3 speedr;
    public Vector3 rotater;
    public bool fade;
    public bool attach;
    public int quan;
    public int times;
    public int life;
    public int id;
    public bool die;

    public Launcher(ModelM m, _3DPraticleManager manager)
    {
      this.model = m;
      this.setting = new _3DPraticle();
      manager?.LauncherCollection.Add(this);
    }

    public void Update(_3DPraticleManager manager)
    {
      ++this.time;
      if (this.time == this.times)
      {
        for (int index = 0; index < this.quan; ++index)
        {
          _3DPraticle obj = new _3DPraticle();
          obj.id = this.id;
          obj.model = this.model;
          obj.scale = this.setting.scale;
          obj.life = this.setting.life;
          float x = this.setting.scale.X;
          float y = this.setting.scale.Y;
          float z = this.setting.scale.Z;
          obj.Position = new Vector3(MathHelper.Lerp(this.rectvta.X / x, this.rectvtb.X / x, (float) Main.rand.NextDouble()), MathHelper.Lerp(this.rectvta.Y / y, this.rectvtb.Y / y, (float) Main.rand.NextDouble()), MathHelper.Lerp(this.rectvta.Z / z, this.rectvtb.Z / z, (float) Main.rand.NextDouble()));
          obj.speed = this.setting.speed;
          obj.speed += new Vector3(MathHelper.Lerp(-this.speedr.X, this.speedr.X, (float) Main.rand.NextDouble()), MathHelper.Lerp(-this.speedr.Y, this.speedr.Y, (float) Main.rand.NextDouble()), MathHelper.Lerp(-this.speedr.Z, this.speedr.Z, (float) Main.rand.NextDouble()));
          obj.acced = this.setting.acced;
          obj.rotate = this.setting.rotate;
          obj.rotate += new Vector3(MathHelper.Lerp(-this.rotater.X, this.rotater.X, (float) Main.rand.NextDouble()), MathHelper.Lerp(-this.rotater.Y, this.rotater.Y, (float) Main.rand.NextDouble()), MathHelper.Lerp(-this.rotater.Z, this.rotater.Z, (float) Main.rand.NextDouble()));
          obj.rotates = this.setting.rotates;
          obj.fade = this.fade;
          obj.fadetime = this.setting.fadetime;
          manager.PraticleColleciton.Add(obj);
        }
        this.time = 0;
      }
      if (this.time < this.life)
        return;
      this.die = true;
    }

    public new void Dispose()
    {
      this.die = true;
    }
  }
}
