// Decompiled with JetBrains decompiler
// Type: Shooting.BaseMyPlane
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using SlimDX;
using System;
using System.Collections.Generic;
using System.Drawing;

namespace Shooting
{
  public class BaseMyPlane : BaseObject
  {
    private int life = 2;
    private int spell = 2;
    private int lifeChip = 0;
    private int spellChip = 0;
    public readonly int nextSpellChip = 4;
    public readonly int[] nextLifeChip = new int[9]
    {
      3,
      5,
      8,
      10,
      12,
      15,
      18,
      20,
      22
    };
    private int lifeUpCount = 0;
    private int power = 100;
    private long score = 0;
    private long hiScore = 0;
    private bool lastX = false;
    private int starPoint = 0;
    public readonly int maxStarPoint = 3000;
    private int nextBluePoint = 300;
    private int nextGreenPoint = 3000;
    private int bluePoint = 0;
    private int greenPoint = 0;
    private int blueLevel = 0;
    private int greenLevel = 0;
    private EnchantmentType enchantmentState = EnchantmentType.None;
    private EnchantmentType lastColor = EnchantmentType.Green;
    private float rate = 1f;
    private int enchantmentCount = 0;
    private int enchantmentCountNeeded = 0;
    private bool OnRotate = false;
    private int Angle3D = 0;
    private const int unmatchedTime = 300;
    private const int deltaGreen = 120;
    private int enchantmentTime;

    public string Name { get; set; }

    public string WeaponType { get; set; }

    public string FullName
    {
      get
      {
        return this.Name + this.WeaponType;
      }
    }

    public bool SlowMove { get; private set; }

    public float HighSpeed { get; set; }

    public float LowSpeed { get; set; }

    public new float Vx { get; private set; }

    public new float Vy { get; private set; }

    public int DeadTime { get; set; }

    public int Life
    {
      get
      {
        return this.life;
      }
      set
      {
        if (value > 8)
          this.life = 8;
        else
          this.life = value;
      }
    }

    public int Spell
    {
      get
      {
        return this.spell;
      }
      set
      {
        if (value > 8)
          this.spell = 8;
        else if (value < 0)
          this.spell = 0;
        else
          this.spell = value;
      }
    }

    public int LifeChip
    {
      get
      {
        return this.lifeChip;
      }
      set
      {
        for (this.lifeChip = value; this.lifeChip >= this.nextLifeChip[this.lifeUpCount]; ++this.lifeUpCount)
        {
          this.Extend();
          this.lifeChip -= this.nextLifeChip[this.lifeUpCount];
        }
      }
    }

    public int SpellChip
    {
      get
      {
        return this.spellChip;
      }
      set
      {
        for (this.spellChip = value; this.spellChip >= this.nextSpellChip; this.spellChip -= this.nextSpellChip)
          this.SpellExtand();
      }
    }

    public int Power
    {
      get
      {
        return this.power;
      }
      set
      {
        if (value > 400)
          this.power = 400;
        else if (value < 100)
          this.power = 100;
        else
          this.power = value;
      }
    }

    public int PowerLevel
    {
      get
      {
        return this.power / 100;
      }
    }

    public long Score
    {
      get
      {
        return this.score;
      }
      set
      {
        if (value > 9999999999L)
          this.score = 9999999999L;
        else if (value < 0L)
          this.score = 0L;
        else
          this.score = value;
      }
    }

    public long HiScore
    {
      get
      {
        if (this.score > this.hiScore)
          return this.score;
        return this.hiScore;
      }
      set
      {
        if (value > 9999999999L)
          this.hiScore = 9999999999L;
        else if (value < 0L)
          this.hiScore = 0L;
        else
          this.hiScore = value;
      }
    }

    public int BluePoint
    {
      get
      {
        return this.bluePoint;
      }
      set
      {
        this.bluePoint = value;
      }
    }

    public int GreenPoint
    {
      get
      {
        return this.greenPoint;
      }
      set
      {
        this.greenPoint = value;
      }
    }

    public int NextBluePoint
    {
      get
      {
        return this.nextBluePoint;
      }
      set
      {
        this.nextBluePoint = value;
      }
    }

    public int NextGreenPoint
    {
      get
      {
        return this.nextGreenPoint;
      }
      set
      {
        this.nextGreenPoint = value;
      }
    }

    public int StarPoint
    {
      get
      {
        return this.starPoint;
      }
      set
      {
        if (value >= this.maxStarPoint)
        {
          if (this.starPoint < this.maxStarPoint)
          {
            if (this.LastColor == EnchantmentType.Red)
              this.ChangeEnchantment(EnchantmentType.Red);
            else if (this.LastColor == EnchantmentType.Blue)
              this.ChangeEnchantment(EnchantmentType.Blue);
            else if (this.LastColor == EnchantmentType.Green)
              this.ChangeEnchantment(EnchantmentType.Green);
            this.StageData.SoundPlay("se_focusrot.wav");
            BaseBackground baseBackground1 = new BaseBackground(this.StageData, "pl02b", this.Position, 0.0f, 0.0);
            baseBackground1.ScaleVelocity = 1f;
            baseBackground1.LifeTime = 26;
            baseBackground1.TransparentVelocity = -10f;
            baseBackground1.Active = false;
            baseBackground1.ColorValue = Color.Black;
            BaseBackground baseBackground2 = new BaseBackground(this.StageData, "pl02b", this.Position, 0.0f, 0.0);
            baseBackground2.ScaleVelocity = 1f;
            baseBackground2.LifeTime = 26;
            baseBackground2.TransparentVelocity = -10f;
            baseBackground2.Active = false;
            baseBackground2.ColorValue = Color.Black;
            BaseBackground baseBackground3 = new BaseBackground(this.StageData, "pl02b", this.Position, 0.0f, 0.0);
            baseBackground3.ScaleVelocity = 1f;
            baseBackground3.LifeTime = 26;
            baseBackground3.TransparentVelocity = -10f;
            baseBackground3.Active = false;
            baseBackground3.ColorValue = Color.Black;
            EnchantmentMagicCircle enchantmentMagicCircle = new EnchantmentMagicCircle(this.StageData, this.OriginalPosition);
          }
          this.starPoint = this.maxStarPoint;
        }
        else if (value < 0)
          this.starPoint = 0;
        else
          this.starPoint = value;
      }
    }

    public EnchantmentType EnchantmentState
    {
      get
      {
        return this.enchantmentState;
      }
      set
      {
        this.enchantmentState = value;
      }
    }

    public EnchantmentType LastColor
    {
      get
      {
        return this.lastColor;
      }
      set
      {
        this.lastColor = value;
      }
    }

    public int EnchantmentTime
    {
      get
      {
        return this.enchantmentTime;
      }
      set
      {
        if (value > 0)
        {
          this.enchantmentTime = value;
        }
        else
        {
          if (this.enchantmentTime > 0)
          {
            if (this.enchantmentTime == 1)
            {
              ++this.EnchantmentCount;
              this.Rate += 0.1f;
              long Bonus = 0;
              if (this.enchantmentState == EnchantmentType.Blue)
                Bonus = (long) (this.HighItemScore * 20);
              else if (this.enchantmentState == EnchantmentType.Green)
                Bonus = 1000000L;
              else if (this.enchantmentState == EnchantmentType.Red)
                Bonus = 5120000L;
              this.score += Bonus;
              EnchantmentBonus enchantmentBonus = new EnchantmentBonus(this.StageData, Bonus);
              this.StageData.SoundPlay("se_cardget.wav");
            }
            else
            {
              BaseEffect baseEffect1 = new BaseEffect(this.StageData, "pl02b", this.Position, 0.0f, 0.0);
              baseEffect1.ScaleVelocity = 1f;
              baseEffect1.LifeTime = 26;
              baseEffect1.TransparentVelocity = -10f;
              baseEffect1.Active = false;
              baseEffect1.ColorValue = Color.Black;
              BaseEffect baseEffect2 = new BaseEffect(this.StageData, "pl02b", this.Position, 0.0f, 0.0);
              baseEffect2.ScaleVelocity = 1f;
              baseEffect2.LifeTime = 26;
              baseEffect2.TransparentVelocity = -10f;
              baseEffect2.Active = false;
              baseEffect2.ColorValue = Color.Black;
              BaseEffect baseEffect3 = new BaseEffect(this.StageData, "pl02b", this.Position, 0.0f, 0.0);
              baseEffect3.ScaleVelocity = 1f;
              baseEffect3.LifeTime = 26;
              baseEffect3.TransparentVelocity = -10f;
              baseEffect3.Active = false;
              baseEffect3.ColorValue = Color.Black;
            }
            if (this.enchantmentState == EnchantmentType.Green)
            {
              this.Time = this.UnmatchedTime - 60;
              this.DeadTime = -1;
              SpellDisable spellDisable = new SpellDisable(this.StageData);
            }
            this.StarPoint = 0;
            this.StageData.SoundPlay("ice005.wav");
            TextureObject textureObject = this.TextureObjectDictionary["White"];
            int num1 = 16;
            int num2 = 8;
            Color color = Color.White;
            if (this.enchantmentState == EnchantmentType.Blue)
              color = Color.Blue;
            else if (this.enchantmentState == EnchantmentType.Green)
              color = Color.Green;
            else if (this.enchantmentState == EnchantmentType.Red)
              color = Color.Red;
            int num3;
            for (int index = 0; index < num1; ++index)
            {
              for (num3 = 0; num3 < num2; ++num3)
              {
                Model_Triangle modelTriangle = new Model_Triangle(this.StageData.DeviceMain, textureObject, index.ToString() + "_" + num3.ToString(), new Vector2((float) index / (float) num1, (float) num3 / (float) num2), new Vector2((float) (index + 1) / (float) num1, (float) num3 / (float) num2), new Vector2((float) index / (float) num1, (float) (num3 + 1) / (float) num2), 640 / num1, 480 / num2);
                BaseParticle3D baseParticle3D = new BaseParticle3D();
                baseParticle3D.StageData = this.StageData;
                baseParticle3D.Position = new PointF((float) (index * 640 / num1), (float) (num3 * 480 / num2));
                baseParticle3D.model = (IModel) modelTriangle;
                baseParticle3D.Velocity = (float) this.Ran.Next(20) / 10f;
                baseParticle3D.LifeTime = 30;
                baseParticle3D.DirectionDegree = (double) this.Ran.Next(360);
                baseParticle3D.RotatingAxis = new Vector3((float) this.Ran.Next(-100, 100), (float) this.Ran.Next(-100, 100), (float) this.Ran.Next(-100, 100));
                baseParticle3D.AngularVelocity3D = (float) this.Ran.Next(20) / 100f;
                baseParticle3D.TransparentVelocity = -6f;
                baseParticle3D.ScaleVelocity = -0.005f;
                baseParticle3D.ColorValue = color;
                baseParticle3D.TransparentValueF = 150f;
                this.StageData.Particle3D.ParticleList.Add(baseParticle3D);
              }
            }
            for (int index = 0; index < num1; ++index)
            {
              for (num3 = 0; num3 < num2; ++num3)
              {
                Model_Triangle modelTriangle = new Model_Triangle(this.StageData.DeviceMain, textureObject, index.ToString() + "_" + num3.ToString(), new Vector2((float) (index + 1) / (float) num1, (float) (num3 + 1) / (float) num2), new Vector2((float) index / (float) num1, (float) (num3 + 1) / (float) num2), new Vector2((float) (index + 1) / (float) num1, (float) num3 / (float) num2), 640 / num1, 480 / num2);
                BaseParticle3D baseParticle3D = new BaseParticle3D();
                baseParticle3D.StageData = this.StageData;
                baseParticle3D.Position = new PointF((float) ((index + 1) * 640 / num1), (float) ((num3 + 1) * 480 / num2));
                baseParticle3D.model = (IModel) modelTriangle;
                baseParticle3D.Angle = Math.PI;
                baseParticle3D.Velocity = (float) this.Ran.Next(20) / 10f;
                baseParticle3D.LifeTime = 30;
                baseParticle3D.DirectionDegree = (double) this.Ran.Next(360);
                baseParticle3D.RotatingAxis = new Vector3((float) this.Ran.Next(-100, 100), (float) this.Ran.Next(-100, 100), (float) this.Ran.Next(-100, 100));
                baseParticle3D.AngularVelocity3D = (float) this.Ran.Next(20) / 100f;
                baseParticle3D.TransparentVelocity = -6f;
                baseParticle3D.ScaleVelocity = -0.005f;
                baseParticle3D.ColorValue = color;
                baseParticle3D.TransparentValueF = 150f;
                this.StageData.Particle3D.ParticleList.Add(baseParticle3D);
              }
            }
          }
          this.enchantmentTime = 0;
          this.enchantmentState = EnchantmentType.None;
        }
      }
    }

    public int EnchantmentCount
    {
      get
      {
        return this.enchantmentCount;
      }
      set
      {
        this.enchantmentCount = value;
      }
    }

    public int EnchantmentCountNeeded
    {
      get
      {
        return this.enchantmentCountNeeded;
      }
      set
      {
        this.enchantmentCountNeeded = value;
      }
    }

    public bool FscEnabled
    {
      get
      {
        return this.EnchantmentCount >= this.EnchantmentCountNeeded && this.Difficulty > DifficultLevel.Normal;
      }
    }

    public float Rate
    {
      get
      {
        return this.rate;
      }
      set
      {
        this.rate = value;
      }
    }

    public int HighItemScore { get; set; }

    public int Graze { get; set; }

    public int UnmatchedTime
    {
      get
      {
        return 300;
      }
    }

    public TextureObject[] TxtureObjects { get; set; }

    public PointF[] SubPlanePoint { get; set; }

    public List<BaseSubPlane> SubPlaneList { get; set; }

    public bool SpellEnabled { get; set; }

    public int LifeUpCount
    {
      get
      {
        return this.lifeUpCount;
      }
      set
      {
        this.lifeUpCount = value;
      }
    }

    public BaseMyPlane()
    {
    }

    public BaseMyPlane(StageDataPackage StageData, Point Position)
    {
      this.StageData = StageData;
      this.Position = (PointF) Position;
      this.TxtureObjects = new TextureObject[72];
      for (int index = 0; index < 72; ++index)
        this.TxtureObjects[index] = this.TextureObjectDictionary["MyPlane" + index.ToString("D3")];
      this.TxtureObject = this.TxtureObjects[0];
      this.SubPlanePoint = new PointF[4];
      this.HighSpeed = 4.5f;
      this.LowSpeed = 2f;
      this.Region = 1;
      this.Time = this.UnmatchedTime;
      this.DeadTime = -1;
      this.SubPlaneList = new List<BaseSubPlane>()
      {
        new BaseSubPlane(StageData, "MySubPlane", (PointF) Position),
        new BaseSubPlane(StageData, "MySubPlane", (PointF) Position),
        new BaseSubPlane(StageData, "MySubPlane", (PointF) Position),
        new BaseSubPlane(StageData, "MySubPlane", (PointF) Position)
      };
      this.Name = "Plane";
      this.WeaponType = "A";
      this.SpellEnabled = true;
      this.HighItemScore = 100000;
    }

    public virtual void Refresh()
    {
      this.Time = 300;
      this.EnchantmentCount = 0;
      this.SubPlaneList.ForEach((Action<BaseSubPlane>) (x => x.Refresh()));
      this.SpellEnabled = true;
    }

    public override void Move()
    {
      this.Vx = 0.0f;
      this.Vy = 0.0f;
      float x1 = this.OriginalPosition.X;
      float y1 = this.OriginalPosition.Y;
      this.SlowMove = this.KClass.Key_Shift;
      if (!this.SlowMove)
      {
        if (this.KClass.ArrowRight)
          this.Vx += this.HighSpeed;
        if (this.KClass.ArrowLeft)
          this.Vx -= this.HighSpeed;
        if (this.KClass.ArrowUp)
          this.Vy += this.HighSpeed;
        if (this.KClass.ArrowDown)
          this.Vy -= this.HighSpeed;
      }
      else
      {
        if (this.KClass.ArrowRight)
          this.Vx += this.LowSpeed;
        if (this.KClass.ArrowLeft)
          this.Vx -= this.LowSpeed;
        if (this.KClass.ArrowUp)
          this.Vy += this.LowSpeed;
        if (this.KClass.ArrowDown)
          this.Vy -= this.LowSpeed;
      }
      if ((double) this.Vx != 0.0 && (double) this.Vy != 0.0)
      {
        this.Vx = 0.71f * this.Vx;
        this.Vy = 0.71f * this.Vy;
      }
      float x2 = x1 + this.Vx;
      float y2 = y1 - this.Vy;
      Rectangle boundRect;
      if ((double) x2 < (double) (this.TxtureObject.Width / 2 - 6))
      {
        x2 = (float) (this.TxtureObject.Width / 2 - 6);
      }
      else
      {
        double num1 = (double) x2;
        boundRect = this.BoundRect;
        double num2 = (double) (boundRect.Width - this.TxtureObject.Width / 2 + 6);
        if (num1 > num2)
        {
          boundRect = this.BoundRect;
          x2 = (float) (boundRect.Width - this.TxtureObject.Width / 2 + 6);
        }
      }
      if ((double) y2 < (double) (this.TxtureObject.Height / 2))
      {
        y2 = (float) (this.TxtureObject.Height / 2);
      }
      else
      {
        double num1 = (double) y2;
        boundRect = this.BoundRect;
        double num2 = (double) (boundRect.Height - this.TxtureObject.Height / 2 + 8);
        if (num1 >= num2)
        {
          boundRect = this.BoundRect;
          y2 = (float) (boundRect.Height - this.TxtureObject.Height / 2 + 8);
        }
      }
      this.OriginalPosition = new PointF(x2, y2);
    }

    public virtual void SubPlaneCtrl()
    {
      if (this.KClass.Key_Shift)
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y - 30f);
            break;
          case 2:
            ref PointF local1 = ref this.SubPlanePoint[0];
            double num1 = (double) this.OriginalPosition.X - 15.0;
            PointF originalPosition1 = this.OriginalPosition;
            double num2 = (double) originalPosition1.Y - 30.0;
            PointF pointF1 = new PointF((float) num1, (float) num2);
            local1 = pointF1;
            ref PointF local2 = ref this.SubPlanePoint[1];
            originalPosition1 = this.OriginalPosition;
            double num3 = (double) originalPosition1.X + 15.0;
            originalPosition1 = this.OriginalPosition;
            double num4 = (double) originalPosition1.Y - 30.0;
            PointF pointF2 = new PointF((float) num3, (float) num4);
            local2 = pointF2;
            break;
          case 3:
            ref PointF local3 = ref this.SubPlanePoint[0];
            double x1 = (double) this.OriginalPosition.X;
            PointF originalPosition2 = this.OriginalPosition;
            double num5 = (double) originalPosition2.Y - 30.0;
            PointF pointF3 = new PointF((float) x1, (float) num5);
            local3 = pointF3;
            ref PointF local4 = ref this.SubPlanePoint[1];
            originalPosition2 = this.OriginalPosition;
            double num6 = (double) originalPosition2.X + 20.0;
            originalPosition2 = this.OriginalPosition;
            double num7 = (double) originalPosition2.Y - 20.0;
            PointF pointF4 = new PointF((float) num6, (float) num7);
            local4 = pointF4;
            ref PointF local5 = ref this.SubPlanePoint[2];
            originalPosition2 = this.OriginalPosition;
            double num8 = (double) originalPosition2.X - 20.0;
            originalPosition2 = this.OriginalPosition;
            double num9 = (double) originalPosition2.Y - 20.0;
            PointF pointF5 = new PointF((float) num8, (float) num9);
            local5 = pointF5;
            break;
          case 4:
            ref PointF local6 = ref this.SubPlanePoint[0];
            double num10 = (double) this.OriginalPosition.X - 15.0;
            PointF originalPosition3 = this.OriginalPosition;
            double num11 = (double) originalPosition3.Y - 40.0;
            PointF pointF6 = new PointF((float) num10, (float) num11);
            local6 = pointF6;
            ref PointF local7 = ref this.SubPlanePoint[1];
            originalPosition3 = this.OriginalPosition;
            double num12 = (double) originalPosition3.X + 15.0;
            originalPosition3 = this.OriginalPosition;
            double num13 = (double) originalPosition3.Y - 40.0;
            PointF pointF7 = new PointF((float) num12, (float) num13);
            local7 = pointF7;
            ref PointF local8 = ref this.SubPlanePoint[2];
            originalPosition3 = this.OriginalPosition;
            double num14 = (double) originalPosition3.X - 30.0;
            originalPosition3 = this.OriginalPosition;
            double num15 = (double) originalPosition3.Y - 30.0;
            PointF pointF8 = new PointF((float) num14, (float) num15);
            local8 = pointF8;
            ref PointF local9 = ref this.SubPlanePoint[3];
            originalPosition3 = this.OriginalPosition;
            double num16 = (double) originalPosition3.X + 30.0;
            originalPosition3 = this.OriginalPosition;
            double num17 = (double) originalPosition3.Y - 30.0;
            PointF pointF9 = new PointF((float) num16, (float) num17);
            local9 = pointF9;
            break;
        }
      }
      else
      {
        switch (this.PowerLevel)
        {
          case 1:
            this.SubPlanePoint[0] = new PointF(this.OriginalPosition.X, this.OriginalPosition.Y - 40f);
            break;
          case 2:
            ref PointF local10 = ref this.SubPlanePoint[0];
            double num18 = (double) this.OriginalPosition.X - 25.0;
            PointF originalPosition4 = this.OriginalPosition;
            double num19 = (double) originalPosition4.Y - 20.0;
            PointF pointF10 = new PointF((float) num18, (float) num19);
            local10 = pointF10;
            ref PointF local11 = ref this.SubPlanePoint[1];
            originalPosition4 = this.OriginalPosition;
            double num20 = (double) originalPosition4.X + 25.0;
            originalPosition4 = this.OriginalPosition;
            double num21 = (double) originalPosition4.Y - 20.0;
            PointF pointF11 = new PointF((float) num20, (float) num21);
            local11 = pointF11;
            break;
          case 3:
            ref PointF local12 = ref this.SubPlanePoint[0];
            double x2 = (double) this.OriginalPosition.X;
            PointF originalPosition5 = this.OriginalPosition;
            double num22 = (double) originalPosition5.Y - 40.0;
            PointF pointF12 = new PointF((float) x2, (float) num22);
            local12 = pointF12;
            ref PointF local13 = ref this.SubPlanePoint[1];
            originalPosition5 = this.OriginalPosition;
            double num23 = (double) originalPosition5.X + 30.0;
            originalPosition5 = this.OriginalPosition;
            double num24 = (double) originalPosition5.Y - 20.0;
            PointF pointF13 = new PointF((float) num23, (float) num24);
            local13 = pointF13;
            ref PointF local14 = ref this.SubPlanePoint[2];
            originalPosition5 = this.OriginalPosition;
            double num25 = (double) originalPosition5.X - 30.0;
            originalPosition5 = this.OriginalPosition;
            double num26 = (double) originalPosition5.Y - 20.0;
            PointF pointF14 = new PointF((float) num25, (float) num26);
            local14 = pointF14;
            break;
          case 4:
            ref PointF local15 = ref this.SubPlanePoint[0];
            double num27 = (double) this.OriginalPosition.X - 25.0;
            PointF originalPosition6 = this.OriginalPosition;
            double num28 = (double) originalPosition6.Y - 0.0;
            PointF pointF15 = new PointF((float) num27, (float) num28);
            local15 = pointF15;
            ref PointF local16 = ref this.SubPlanePoint[1];
            originalPosition6 = this.OriginalPosition;
            double num29 = (double) originalPosition6.X + 25.0;
            originalPosition6 = this.OriginalPosition;
            double num30 = (double) originalPosition6.Y - 0.0;
            PointF pointF16 = new PointF((float) num29, (float) num30);
            local16 = pointF16;
            ref PointF local17 = ref this.SubPlanePoint[2];
            originalPosition6 = this.OriginalPosition;
            double num31 = (double) originalPosition6.X - 50.0;
            originalPosition6 = this.OriginalPosition;
            double num32 = (double) originalPosition6.Y + 5.0;
            PointF pointF17 = new PointF((float) num31, (float) num32);
            local17 = pointF17;
            ref PointF local18 = ref this.SubPlanePoint[3];
            originalPosition6 = this.OriginalPosition;
            double num33 = (double) originalPosition6.X + 50.0;
            originalPosition6 = this.OriginalPosition;
            double num34 = (double) originalPosition6.Y + 5.0;
            PointF pointF18 = new PointF((float) num33, (float) num34);
            local18 = pointF18;
            break;
        }
      }
      for (int index = 0; index < this.PowerLevel; ++index)
      {
        this.SubPlaneList[index].Enabled = true;
        this.SubPlaneList[index].DestPoint = this.SubPlanePoint[index];
        this.SubPlaneList[index].Ctrl();
      }
      for (int powerLevel = this.PowerLevel; powerLevel < this.SubPlaneList.Count; ++powerLevel)
      {
        this.SubPlaneList[powerLevel].Enabled = false;
        this.SubPlaneList[powerLevel].Position = this.Position;
      }
    }

    public virtual void TextureCtrl()
    {
      if ((double) this.Vx > 0.5)
      {
        if (this.SlowMove)
        {
          this.OnRotate = false;
          if (0 <= this.Angle3D && this.Angle3D < 30)
            this.Angle3D += 5;
          else if (this.Angle3D < 0)
            this.Angle3D = 0;
        }
        else if (!this.OnRotate)
        {
          if (0 <= this.Angle3D && this.Angle3D < 40)
            this.Angle3D += 5;
          else if (this.Angle3D < 0)
            this.OnRotate = true;
        }
        else
          this.Angle3D += 13;
      }
      else if ((double) this.Vx < -0.5)
      {
        if (this.SlowMove)
        {
          this.OnRotate = false;
          if (-30 < this.Angle3D && this.Angle3D <= 0)
            this.Angle3D -= 5;
          else if (this.Angle3D > 0)
            this.Angle3D = 0;
        }
        else if (!this.OnRotate)
        {
          if (-40 < this.Angle3D && this.Angle3D <= 0)
            this.Angle3D -= 5;
          else if (this.Angle3D > 0)
            this.OnRotate = true;
        }
        else
          this.Angle3D -= 13;
      }
      else
      {
        this.Angle3D /= 2;
        if (-10 < this.Angle3D && this.Angle3D < 10)
        {
          this.Angle3D = 0;
          this.OnRotate = false;
        }
      }
      if (this.Angle3D > 180)
        this.Angle3D -= 360;
      else if (this.Angle3D < -180)
        this.Angle3D += 360;
      int index = this.Angle3D / 5;
      if (index < 0)
        index += 72;
      else if (index > 72)
        index -= 72;
      this.TxtureObject = this.TxtureObjects[index];
    }

    public override void Shoot()
    {
      if (this.Time % 3 == 0)
      {
        this.StageData.SoundPlay("se_plst00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        float x = this.Position.X;
        float y = this.Position.Y;
        float num = 7f * (float) Math.Cos((double) this.Angle3D * Math.PI / 180.0);
        BaseMyBullet baseMyBullet1 = new BaseMyBullet(this.StageData, "自机子弹", new PointF(x - num, y), 30f, -1.0 * Math.PI / 2.0);
        BaseMyBullet baseMyBullet2 = new BaseMyBullet(this.StageData, "自机子弹", new PointF(x + num, y), 30f, -1.0 * Math.PI / 2.0);
      }
      if (this.Time % 5 != 0)
        return;
      for (int index = 0; index < this.PowerLevel; ++index)
        this.SubPlaneList[index].Shoot();
    }

    public virtual void SpellShoot()
    {
      Shooting.Spell spell = new Shooting.Spell(this.StageData);
      this.StageData.SoundPlay("se_nep00.wav");
    }

    public virtual void PreMiss()
    {
      if (this.Time < this.UnmatchedTime || this.Time < this.DeadTime || this.SpellList.Count != 0)
        return;
      if (this.EnchantmentState == EnchantmentType.Green)
      {
        new BulletRemover_Small(this.StageData, this.OriginalPosition).Region = 500;
        this.ChangeEnchantment(EnchantmentType.None);
        this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
        {
          if (!(x is BaseSpellCard))
            return;
          ((BaseSpellCard) x).Missed = true;
        }));
      }
      else
      {
        Emitter emitter = new Emitter(this.StageData, this.MyPlane.Position);
        this.StageData.SoundPlay("se_pldead00.wav", this.OriginalPosition.X / (float) this.BoundRect.Width);
        this.DeadTime = this.Time + 20;
      }
    }

    public virtual void Miss()
    {
      if (this.EnchantmentState == EnchantmentType.Red || this.EnchantmentState == EnchantmentType.Blue)
        this.ChangeEnchantment(EnchantmentType.None);
      BulletRemover bulletRemover = new BulletRemover(this.StageData, this.OriginalPosition);
      Rectangle boundRect = this.BoundRect;
      double num1 = (double) (boundRect.Width / 2);
      boundRect = this.BoundRect;
      double num2 = (double) (boundRect.Height + 100);
      this.OriginalPosition = new PointF((float) num1, (float) num2);
      this.Vx = 0.0f;
      this.Vy = 0.0f;
      --this.Life;
      this.Power -= 16;
      this.Time = 0;
      this.DeadTime = -1;
    }

    public override void Ctrl()
    {
      if (!this.Enabled)
        return;
      ++this.Time;
      if (this.Time == this.DeadTime)
        this.Miss();
      else if (this.Time > this.DeadTime)
      {
        if (this.Time == 1 && this.Spell < 2)
          this.Spell = 2;
        if (this.Time > 70)
        {
          this.Move();
        }
        else
        {
          Rectangle boundRect = this.BoundRect;
          double num1 = (double) (boundRect.Width / 2);
          boundRect = this.BoundRect;
          double num2 = (double) (boundRect.Height - 30);
          this.DestPoint = new PointF((float) num1, (float) num2);
          this.Velocity = 2f;
          base.Move();
          this.TextureCtrl();
        }
        this.TextureCtrl();
        this.Direction += 0.0199999995529652;
        this.SubPlaneCtrl();
        --this.EnchantmentTime;
        if (this.EnchantmentState == EnchantmentType.Blue)
          this.ItemList.ForEach((Action<BaseItem>) (x =>
          {
            if (x is ShootingStarShard)
              return;
            x.Obtain = true;
            x.Doubled = true;
          }));
      }
      if (this.Story != null || this.Time <= 70)
        return;
      if (this.KClass.Key_Z && this.TimeMain > 15)
        this.Shoot();
      if (this.KClass.Key_X && !this.lastX)
      {
        if (this.EnchantmentState == EnchantmentType.Green)
        {
          new BulletRemover_Small(this.StageData, this.OriginalPosition).Region = 500;
          this.ChangeEnchantment(EnchantmentType.None);
          this.EnemyPlaneList.ForEach((Action<BaseEnemyPlane>) (x =>
          {
            if (!(x is BaseSpellCard))
              return;
            ((BaseSpellCard) x).Bombed = true;
          }));
        }
        else if (this.Spell > 0 && this.SpellList.Count == 0 && this.Time > 30 && this.SpellEnabled)
        {
          this.SpellShoot();
          --this.Spell;
        }
      }
      this.lastX = this.KClass.Key_X;
    }

    public void RetryClear()
    {
      this.EnchantmentTime = 0;
      this.Life = 2;
      this.Spell = 2;
      this.Power = 400;
      this.Score = (long) this.StageData.ContinueTimes;
      this.Graze = 0;
      this.HiScore = this.StageData.S_History[0].Score;
      this.LifeChip = 0;
      this.SpellChip = 0;
      this.LifeUpCount = 0;
      this.StarPoint = 0;
      this.HighItemScore = 100000;
      this.Rate = 0.0f;
      this.LastColor = EnchantmentType.Green;
    }

    public void Extend()
    {
      if (this.Life < 8)
        ++this.Life;
      else
        ++this.Spell;
      this.StageData.SoundPlay("se_extend.wav");
      BaseEffect baseEffect1 = new BaseEffect(this.StageData, nameof (Extend), new PointF(0.0f, 0.0f), 0.0f, Math.PI / 2.0);
      baseEffect1.Active = false;
      baseEffect1.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 112f);
      baseEffect1.LifeTime = 90;
      baseEffect1.TransparentValueF = 0.0f;
      baseEffect1.Layer = 1;
      BaseEffect baseEffect2 = baseEffect1;
      baseEffect2.TransparentVelocityDictionary.Add(1, 13f);
      baseEffect2.TransparentVelocityDictionary.Add(70, -13f);
    }

    public void SpellExtand()
    {
      this.StageData.SoundPlay("se_cardget.wav");
      ++this.Spell;
      BaseEffect baseEffect1 = new BaseEffect(this.StageData, "SpellExtend", new PointF(0.0f, 0.0f), 0.0f, Math.PI / 2.0);
      baseEffect1.Active = false;
      baseEffect1.OriginalPosition = new PointF((float) (this.BoundRect.Width / 2), 80f);
      baseEffect1.LifeTime = 90;
      baseEffect1.TransparentValueF = 0.0f;
      baseEffect1.Layer = 1;
      BaseEffect baseEffect2 = baseEffect1;
      baseEffect2.TransparentVelocityDictionary.Add(1, 13f);
      baseEffect2.TransparentVelocityDictionary.Add(70, -13f);
    }

    public void ChangeEnchantment(EnchantmentType EnchantmentState)
    {
      switch (EnchantmentState)
      {
        case EnchantmentType.None:
          this.EnchantmentTime = 0;
          break;
        case EnchantmentType.Red:
          this.EnchantmentState = EnchantmentState;
          this.EnchantmentTime = 600;
          break;
        case EnchantmentType.Blue:
          this.EnchantmentState = EnchantmentState;
          this.EnchantmentTime = 600;
          break;
        case EnchantmentType.Green:
          this.EnchantmentState = EnchantmentState;
          this.EnchantmentTime = 420;
          break;
        default:
          this.EnchantmentTime = 0;
          break;
      }
    }

    public override void Show()
    {
      if (this.Time < this.DeadTime || this.Time == 0)
        return;
      if (this.Time < this.UnmatchedTime && this.Time / 2 % 2 == 0)
        this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.Position, Color.DarkBlue);
      else
        this.SpriteMain.Draw2D(this.TxtureObject, 1f, 0.0f, this.Position, Color.White);
      for (int index = 0; index < this.PowerLevel; ++index)
        this.SubPlaneList[index].Show();
    }

    public virtual void ShowCenter()
    {
      if (!this.SlowMove)
        return;
      this.SpriteMain.Draw2D(this.TextureObjectDictionary["MyPlaneCenter1"], 1f, (float) this.Direction * 4f, this.Position, Color.White);
    }
  }
}
