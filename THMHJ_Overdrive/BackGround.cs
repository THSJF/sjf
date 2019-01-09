// Decompiled with JetBrains decompiler
// Type: THMHJ.BackGround
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace THMHJ
{
  internal class BackGround
  {
    private CrazyStorm particle;
    private bool particleinited;
    private int stage;
    private int time;
    private int fadetime;
    private int light;
    private bool thisloop;
    private bool Anti;
    private float shakespeed;
    private float shakemax;
    private float shaketime;
    private float step;
    private float stepx;
    private float stepy;
    private float steps;
    private Vector3 stepc;
    private float steptarget;
    private float steptime;
    private float stepxtarget;
    private float stepxtime;
    private float stepytarget;
    private float stepytime;
    private bool changex;
    private bool changey;
    private bool changez;
    private float xorigin;
    private float yorigin;
    private float zorigin;
    private float xtarget;
    private float ytarget;
    private float ztarget;
    private int xtime;
    private int ytime;
    private int ztime;
    private bool changetx;
    private bool changety;
    private bool changetz;
    private float txorigin;
    private float tyorigin;
    private float tzorigin;
    private float txtarget;
    private float tytarget;
    private float tztarget;
    private int txtime;
    private int tytime;
    private int tztime;
    private Vector3 vp;
    private Vector3 vtp;
    private Vector3 vup;
    private string text;
    private StreamReader rd;
    private ContentManager c;
    private GraphicsDevice gd;
    private GraphicsDeviceManager g;
    private RenderTarget2D renderTarget;
    private Matrix cameraViewMatrix;
    private Matrix cameraProjectionMatrix;
    private Hashtable modelc;
    private Hashtable backgc;
    private List<ModelM> ModelCollection;
    private _3DPraticleManager _3dpraticle;

    public BackGround(
      ContentManager ct,
      GraphicsDeviceManager gdm,
      GraphicsDevice graphics,
      int stage_i,
      _3DPraticleManager tdpraticle)
    {
      this._3dpraticle = tdpraticle;
      this.stage = stage_i;
      this.c = ct;
      this.g = gdm;
      this.gd = graphics;
      PresentationParameters presentationParameters = this.g.GraphicsDevice.PresentationParameters;
      this.cameraProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(0.7853982f, 1.333333f, 20f, 600f);
      this.vp = new Vector3(0.0f, 165.122f, -146.684f);
      this.vtp = new Vector3(0.0f, 30.733f, 0.0f);
      this.vup = new Vector3(0.0f, 1f, 0.0f);
      this.cameraViewMatrix = Matrix.CreateLookAt(this.vp, this.vtp, this.vup);
      this.renderTarget = new RenderTarget2D(this.g.GraphicsDevice, presentationParameters.BackBufferWidth, presentationParameters.BackBufferHeight, 1, presentationParameters.BackBufferFormat, presentationParameters.MultiSampleType, presentationParameters.MultiSampleQuality);
      this.Anti = this.g.GraphicsDevice.PresentationParameters.MultiSampleType != MultiSampleType.None;
      this.ModelCollection = new List<ModelM>();
    }

    public void Texture(Hashtable model_c, Hashtable backg_c)
    {
      this.modelc = model_c;
      this.backgc = backg_c;
      this.Load();
    }

    private void Load()
    {
      this.rd = (StreamReader) this.backgc[(object) (this.stage.ToString() + "1")];
      this.text = this.rd.ReadLine();
    }

    public void Load(int stage_i)
    {
      this.particleinited = true;
      this.time = 0;
      this.thisloop = false;
      this.steps = 0.0f;
      this.stage = stage_i;
      this.vp = new Vector3(0.0f, 165.122f, -146.684f);
      this.vtp = new Vector3(0.0f, 30.733f, 0.0f);
      this.vup = new Vector3(0.0f, 1f, 0.0f);
      this._3dpraticle.Dispose();
      this.rd = (StreamReader) this.backgc[(object) (this.stage.ToString() + "1")];
    }

    public void ChangeX(float tg, int t)
    {
      this.xorigin = this.vp.X;
      this.xtarget = tg;
      this.xtime = t;
      this.changex = true;
    }

    public void ChangeY(float tg, int t)
    {
      this.yorigin = this.vp.Y;
      this.ytarget = tg;
      this.ytime = t;
      this.changey = true;
    }

    public void ChangeZ(float tg, int t)
    {
      this.zorigin = this.vp.Z;
      this.ztarget = tg;
      this.ztime = t;
      this.changez = true;
    }

    public void ChangeTX(float tg, int t)
    {
      this.txorigin = this.vtp.X;
      this.txtarget = tg;
      this.txtime = t;
      this.changetx = true;
    }

    public void ChangeTY(float tg, int t)
    {
      this.tyorigin = this.vtp.Y;
      this.tytarget = tg;
      this.tytime = t;
      this.changety = true;
    }

    public void ChangeTZ(float tg, int t)
    {
      this.tzorigin = this.vtp.Z;
      this.tztarget = tg;
      this.tztime = t;
      this.changetz = true;
    }

    public void ChangeUpdate()
    {
      if (this.changex)
      {
        this.vp.X += (this.xtarget - this.xorigin) / (float) this.xtime;
        if ((double) Math.Abs(this.vp.X - this.xtarget) < 1.0 / 1000.0)
        {
          this.changex = false;
          this.vp.X = this.xtarget;
        }
      }
      if (this.changey)
      {
        this.vp.Y += (this.ytarget - this.yorigin) / (float) this.ytime;
        if ((double) Math.Abs(this.vp.Y - this.ytarget) < 1.0 / 1000.0)
        {
          this.changey = false;
          this.vp.Y = this.ytarget;
        }
      }
      if (!this.changez)
        return;
      this.vp.Z += (this.ztarget - this.zorigin) / (float) this.ztime;
      if ((double) Math.Abs(this.vp.Z - this.ztarget) >= 1.0 / 1000.0)
        return;
      this.changez = false;
      this.vp.Z = this.ztarget;
    }

    public void ChangeTUpdate()
    {
      if (this.changetx)
      {
        this.vtp.X += (this.txtarget - this.txorigin) / (float) this.txtime;
        if ((double) Math.Abs(this.vtp.X - this.txtarget) < 1.0 / 1000.0)
        {
          this.changetx = false;
          this.vtp.X = this.txtarget;
        }
      }
      if (this.changety)
      {
        this.vtp.Y += (this.tytarget - this.tyorigin) / (float) this.tytime;
        if ((double) Math.Abs(this.vtp.Y - this.tytarget) < 1.0 / 1000.0)
        {
          this.changety = false;
          this.vtp.Y = this.tytarget;
        }
      }
      if (!this.changetz)
        return;
      this.vtp.Z += (this.tztarget - this.tzorigin) / (float) this.tztime;
      if ((double) Math.Abs(this.vtp.Z - this.tztarget) >= 1.0 / 1000.0)
        return;
      this.changetz = false;
      this.vtp.Z = this.tztarget;
    }

    public void Update(Boss boss)
    {
      if (!this.particleinited)
      {
        if (this.stage == 7)
        {
          this.particle = Program.game.game.PlayEffect(true, "bg", new Vector2(315f, 240f));
          this.particle.BanSound(true);
          this.particle.effect = true;
        }
        else if (this.particle != null)
          this.particle.Close();
        this.particleinited = true;
      }
      if (this.text != "" && !this.text.Contains("End"))
      {
        string str1 = this.text.Split(']')[1];
        string str2 = this.text.Split('[')[1].Split(']')[0];
        if (this.time == int.Parse(str2.Split(':')[0]) * 3600 + int.Parse(str2.Split(':')[1]) * 60 + int.Parse(str2.Split(':')[2]))
        {
          if (str1.Contains("SetModel"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            ModelM modelM = new ModelM((Model) this.modelc[(object) str3.Split(',')[0]], new Vector3(float.Parse(str3.Split(',')[1]), float.Parse(str3.Split(',')[2]), (float) ((double) float.Parse(str3.Split(',')[3]) + (double) this.stepc.Z)), (BlendTypes) int.Parse(str3.Split(',')[6]));
            if (str3.Split(',').Length == 8)
              modelM.ats.Z -= this.stepc.Z;
            modelM.label = str3.Split(',')[4];
            modelM.IsC = (bool.Parse(str3.Split(',')[5]) ? 1 : 0) != 0;
            modelM.light = this.light;
            this.ModelCollection.Add(modelM);
          }
          else if (str1.Contains("DelModel"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            for (int index = 0; index < this.ModelCollection.Count; ++index)
            {
              if (this.ModelCollection[index].label == str3.Split(',')[0])
                this.ModelCollection.RemoveAt(index);
            }
          }
          else if (str1.Contains("SetRunningStepX"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            this.stepxtarget = float.Parse(str3.Split(',')[0]);
            this.stepxtime = (float) int.Parse(str3.Split(',')[1]);
          }
          else if (str1.Contains("SetRunningStepY"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            this.stepytarget = float.Parse(str3.Split(',')[0]);
            this.stepytime = (float) int.Parse(str3.Split(',')[1]);
          }
          else if (str1.Contains("SetRunningStep"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            this.steptarget = float.Parse(str3.Split(',')[0]);
            this.steptime = (float) int.Parse(str3.Split(',')[1]);
          }
          else if (str1.Contains("ClearRunningStep"))
          {
            this.steps = 0.0f;
            this.stepc = new Vector3(0.0f, 0.0f, 0.0f);
            this.thisloop = false;
          }
          else if (str1.Contains("SetPraticleLauncher"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            Launcher launcher = new Launcher(new ModelM((Model) this.modelc[(object) str3.Split(',')[0]], (BlendTypes) int.Parse(str3.Split(',')[19])), this._3dpraticle)
            {
              rectvta = new Vector3(float.Parse(str3.Split(',')[1]), float.Parse(str3.Split(',')[2]), float.Parse(str3.Split(',')[3])),
              rectvtb = new Vector3(float.Parse(str3.Split(',')[4]), float.Parse(str3.Split(',')[5]), float.Parse(str3.Split(',')[6])),
              rotater = new Vector3(float.Parse(str3.Split(',')[7]), float.Parse(str3.Split(',')[8]), float.Parse(str3.Split(',')[9])),
              speedr = new Vector3(float.Parse(str3.Split(',')[10]), float.Parse(str3.Split(',')[11]), float.Parse(str3.Split(',')[12])),
              attach = (bool.Parse(str3.Split(',')[13]) ? 1 : 0) != 0,
              fade = (bool.Parse(str3.Split(',')[14]) ? 1 : 0) != 0,
              quan = int.Parse(str3.Split(',')[15]),
              times = int.Parse(str3.Split(',')[16]),
              life = int.Parse(str3.Split(',')[17]),
              id = int.Parse(str3.Split(',')[18])
            };
          }
          else if (str1.Contains("SetPraticle"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            int index = this._3dpraticle.GetIndex(int.Parse(str3.Split(',')[0]));
            this._3dpraticle.LauncherCollection[index].setting.scale = new Vector3(float.Parse(str3.Split(',')[1]), float.Parse(str3.Split(',')[2]), float.Parse(str3.Split(',')[3]));
            this._3dpraticle.LauncherCollection[index].setting.life = int.Parse(str3.Split(',')[4]);
            this._3dpraticle.LauncherCollection[index].setting.speed = new Vector3(float.Parse(str3.Split(',')[5]), float.Parse(str3.Split(',')[6]), float.Parse(str3.Split(',')[7]));
            if (str3.Split(',').Length > 9)
            {
              this._3dpraticle.LauncherCollection[index].setting.acced = new Vector3(float.Parse(str3.Split(',')[8]), float.Parse(str3.Split(',')[9]), float.Parse(str3.Split(',')[10]));
              this._3dpraticle.LauncherCollection[index].setting.rotate = new Vector3(float.Parse(str3.Split(',')[11]), float.Parse(str3.Split(',')[12]), float.Parse(str3.Split(',')[13]));
              this._3dpraticle.LauncherCollection[index].setting.rotates = new Vector3(float.Parse(str3.Split(',')[14]), float.Parse(str3.Split(',')[15]), float.Parse(str3.Split(',')[16]));
              this._3dpraticle.LauncherCollection[index].setting.fadetime = int.Parse(str3.Split(',')[17]);
            }
            else
              this._3dpraticle.LauncherCollection[index].setting.fadetime = int.Parse(str3.Split(',')[8]);
          }
          else if (str1.Contains("SetColor"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            if (this.GetModelid(str3.Split(',')[4]) != -1)
            {
              this.ModelCollection[this.GetModelid(str3.Split(',')[4])].ChangeColorX(float.Parse(str3.Split(',')[0]), int.Parse(str3.Split(',')[3]));
              this.ModelCollection[this.GetModelid(str3.Split(',')[4])].ChangeColorY(float.Parse(str3.Split(',')[1]), int.Parse(str3.Split(',')[3]));
              this.ModelCollection[this.GetModelid(str3.Split(',')[4])].ChangeColorZ(float.Parse(str3.Split(',')[2]), int.Parse(str3.Split(',')[3]));
            }
          }
          else if (str1.Contains("SetAlpha"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            if (this.GetModelid(str3.Split(',')[2]) != -1)
              this.ModelCollection[this.GetModelid(str3.Split(',')[2])].ChangeAlpha(float.Parse(str3.Split(',')[0]), int.Parse(str3.Split(',')[1]));
          }
          else if (str1.Contains("ChangeView"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            if ((double) float.Parse(str3.Split(',')[0]) != 0.0)
              this.ChangeX(float.Parse(str3.Split(',')[0]), int.Parse(str3.Split(',')[3]));
            if ((double) float.Parse(str3.Split(',')[1]) != 0.0)
              this.ChangeY(float.Parse(str3.Split(',')[1]), int.Parse(str3.Split(',')[3]));
            if ((double) float.Parse(str3.Split(',')[2]) != 0.0)
              this.ChangeZ(float.Parse(str3.Split(',')[2]), int.Parse(str3.Split(',')[3]));
          }
          else if (str1.Contains("ChangeTarget"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            if ((double) float.Parse(str3.Split(',')[0]) != 0.0)
              this.ChangeTX(float.Parse(str3.Split(',')[0]), int.Parse(str3.Split(',')[3]));
            if ((double) float.Parse(str3.Split(',')[1]) != 0.0)
              this.ChangeTY(float.Parse(str3.Split(',')[1]), int.Parse(str3.Split(',')[3]));
            if ((double) float.Parse(str3.Split(',')[2]) != 0.0)
              this.ChangeTZ(float.Parse(str3.Split(',')[2]), int.Parse(str3.Split(',')[3]));
          }
          else if (str1.Contains("ChangeField"))
            this.cameraProjectionMatrix = Matrix.CreatePerspectiveFieldOfView(0.7853982f, this.g.GraphicsDevice.Viewport.AspectRatio, 20f, float.Parse(str1.Split('(')[1].Split(')')[0].Split(',')[0]));
          else if (str1.Contains("Shake"))
          {
            string str3 = str1.Split('(')[1].Split(')')[0];
            this.shakemax = (float) int.Parse(str3.Split(',')[0]);
            this.shakespeed = float.Parse(str3.Split(',')[1]);
          }
          else if (str1.Contains("LightSetting"))
            this.light = int.Parse(str1.Split('(')[1].Split(')')[0].Split(',')[0]);
          else if (str1.Contains("Open"))
            this.fadetime = 1;
          else if (str1.Contains("Fadein"))
            this.fadetime = 3;
          else if (str1.Contains("Fadeout"))
            this.fadetime = 2;
          else if (str1.Contains("End"))
            goto label_66;
          this.text = this.rd.ReadLine();
label_66:
          --this.time;
        }
      }
      if (this.fadetime == 1)
      {
        Program.game.game.bgcolor.a -= 0.0084f;
        if ((double) Program.game.game.bgcolor.a <= 0.0)
        {
          this.fadetime = 0;
          Program.game.game.bgcolor.a = 0.0f;
        }
      }
      else if (this.fadetime == 2)
      {
        Program.game.game.bgcolor.a += 0.04f;
        if ((double) Program.game.game.bgcolor.a >= 1.0)
        {
          this.fadetime = 0;
          Program.game.game.bgcolor.a = 1f;
        }
      }
      else if (this.fadetime == 3)
      {
        Program.game.game.bgcolor.a -= 0.04f;
        if ((double) Program.game.game.bgcolor.a <= 0.0)
        {
          this.fadetime = 0;
          Program.game.game.bgcolor.a = 0.0f;
        }
      }
      if ((double) this.shakemax != 0.0)
      {
        float num = (float) Math.Sin((double) MathHelper.ToRadians(this.shaketime)) * MathHelper.ToRadians(this.shakemax);
        this.vup.X = (float) Math.Sin((double) num);
        this.vup.Y = (float) Math.Cos((double) num);
        this.shaketime += this.shakespeed;
        if ((double) this.shaketime > 360.0)
          this.shaketime -= 360f;
      }
      if ((double) this.steptime != 0.0)
        this.step += (this.steptarget - this.step) / this.steptime;
      if ((double) this.stepxtime != 0.0)
        this.stepx += (this.stepxtarget - this.stepx) / this.stepxtime;
      if ((double) this.stepytime != 0.0)
        this.stepy += (this.stepytarget - this.stepy) / this.stepytime;
      if (this._3dpraticle != null)
        this._3dpraticle.Update(this.step);
      this.stepc += new Vector3(this.stepx, this.stepy, this.step);
      this.steps += this.step;
      if (this.GetModelid("1001") != -1 && this.GetModelid("1002") != -1)
      {
        if ((double) this.vtp.Z + (double) this.stepc.Z > 1.0 && (double) this.steps >= 642.0 && !this.thisloop)
        {
          this.ModelCollection[this.GetModelid("1001")].ats.Z = this.ModelCollection[this.GetModelid("1002")].ats.Z + 642.759f;
          this.thisloop = true;
        }
        if ((double) this.vtp.Z + (double) this.stepc.Z > 1.0 && (double) this.steps >= 1284.0 && this.thisloop)
        {
          this.ModelCollection[this.GetModelid("1002")].ats.Z = this.ModelCollection[this.GetModelid("1001")].ats.Z + 642.759f;
          this.thisloop = false;
          this.steps = 0.0f;
        }
      }
      if (this.GetModelid("1003") != -1)
        this.ModelCollection[this.GetModelid("1003")].ats.Z += this.step;
      this.cameraViewMatrix = Matrix.CreateLookAt(this.vp + this.stepc, this.vtp + this.stepc, this.vup);
      if (boss == null)
        ++this.time;
      foreach (ModelM model in this.ModelCollection)
        model.ChangeUpdate();
      this.ChangeUpdate();
      this.ChangeTUpdate();
    }

    public void Draw(NSpriteBatch s, bool Pause)
    {
      this.gd.SetRenderTarget(0, this.renderTarget);
      foreach (ModelM model in this.ModelCollection)
      {
        if (model.label != "1003")
          model.Draw(this.Anti, this.cameraViewMatrix, this.cameraProjectionMatrix, this.g.GraphicsDevice);
      }
      if (this._3dpraticle != null)
        this._3dpraticle.Draw((SpriteBatch) s, this.Anti, this.cameraViewMatrix, this.cameraProjectionMatrix, this.g.GraphicsDevice);
      if (this.GetModelid("1003") != -1)
        this.ModelCollection[this.GetModelid("1003")].Draw(this.Anti, this.cameraViewMatrix, this.cameraProjectionMatrix, this.g.GraphicsDevice);
      this.gd.SetRenderTarget(0, (RenderTarget2D) null);
    }

    public Texture2D GetRender()
    {
      return this.renderTarget.GetTexture();
    }

    private int GetModelid(string label)
    {
      for (int index = 0; index < this.ModelCollection.Count; ++index)
      {
        if (this.ModelCollection[index].label == label)
          return index;
      }
      return -1;
    }

    private bool Checkifexist(Matrix projection, Matrix view, Vector3 goal)
    {
      return new BoundingFrustum(view * projection).Contains(goal) != ContainmentType.Disjoint;
    }
  }
}
