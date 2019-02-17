// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.Center
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace CrazyStorm_1._03
{
  public class Center
  {
    public static float ox = 315f;
    public static float oy = 240f;
    public static float ospeed = 0.0f;
    public static float ospeedd = 0.0f;
    public static float oaspeed = 0.0f;
    public static float oaspeedd = 0.0f;
    public static float speedx = 0.0f;
    public static float speedy = 0.0f;
    public static float aspeedx = 0.0f;
    public static float aspeedy = 0.0f;
    public static float x = 315f;
    public static float y = 240f;
    public static float speed = 0.0f;
    public static float speedd = 0.0f;
    public static float aspeed = 0.0f;
    public static float aspeedd = 0.0f;
    public static List<string> events = new List<string>();
    public static bool Available = true;
    public static bool Aim = false;
    public static List<Event> Events = new List<Event>();
    public static List<CExecution> Eventsexe = new List<CExecution>();
    private static Centermanager form;

    public static void Clear()
    {
      Center.x = 315f;
      Center.y = 240f;
      Center.speed = 0.0f;
      Center.speedd = 0.0f;
      Center.aspeed = 0.0f;
      Center.aspeedd = 0.0f;
      Center.ox = Center.x;
      Center.oy = Center.y;
      Center.ospeed = Center.speed;
      Center.ospeedd = Center.speedd;
      Center.oaspeed = Center.aspeed;
      Center.oaspeedd = Center.aspeedd;
      Center.speedx = 0.0f;
      Center.speedy = 0.0f;
      Center.aspeedx = 0.0f;
      Center.aspeedy = 0.0f;
      Center.events = new List<string>();
      Center.Available = true;
    }

    public static void Update()
    {
      if (Main.Available & !Time.Playing)
      {
        Center.ox = Center.x;
        Center.oy = Center.y;
        Center.ospeed = Center.speed;
        Center.ospeedd = Center.speedd;
        Center.oaspeed = Center.aspeed;
        Center.oaspeedd = Center.aspeedd;
        Center.aspeedx = Center.aspeed * (float) Math.Cos((double) MathHelper.ToRadians(Center.aspeedd));
        Center.aspeedy = Center.aspeed * (float) Math.Sin((double) MathHelper.ToRadians(Center.aspeedd));
        Center.speedx = Center.speed * (float) Math.Cos((double) MathHelper.ToRadians(Center.speedd));
        Center.speedy = Center.speed * (float) Math.Sin((double) MathHelper.ToRadians(Center.speedd));
        int x = Main.mousestate.X;
        int y = Main.mousestate.Y;
        Center.Aim = x >= 776 & x <= 794 & y >= 505 & y <= 521;
        if (Main.mousestate.LeftButton == Microsoft.Xna.Framework.Input.ButtonState.Pressed & Main.prostate.LeftButton != Microsoft.Xna.Framework.Input.ButtonState.Pressed && Center.Aim)
        {
          if (Center.form != null)
            Center.form.Close();
          Center.form = new Centermanager();
          Center.form.关闭中心.Checked = !Center.Available;
          Center.form.X坐标.Text = Center.x.ToString();
          Center.form.Y坐标.Text = Center.y.ToString();
          Center.form.速度.Text = Center.speed.ToString();
          Center.form.速度方向.Text = Center.speedd.ToString();
          Center.form.加速度.Text = Center.aspeed.ToString();
          Center.form.加速度方向.Text = Center.aspeedd.ToString();
          foreach (string str in Center.events)
          {
            TextBox 事件体 = Center.form.事件体;
            事件体.Text = 事件体.Text + str + "\r\n";
          }
          Center.form.Show();
        }
      }
      if (!(Main.Available & Center.Available & Time.Playing))
        return;
      Center.speedx += Center.aspeedx;
      Center.speedy += Center.aspeedy;
      Center.ox += Center.speedx;
      Center.oy += Center.speedy;
      Hashtable hashtable1 = new Hashtable();
      Hashtable hashtable2 = new Hashtable();
      hashtable1.Add((object) "当前帧", (object) Time.now);
      hashtable2.Add((object) "速度", (object) Center.ospeed);
      hashtable2.Add((object) "速度方向", (object) Center.ospeedd);
      hashtable2.Add((object) "加速度", (object) Center.oaspeed);
      hashtable2.Add((object) "加速度方向", (object) Center.oaspeedd);
      foreach (string str1 in Center.events)
      {
        if (!str1.Contains("PlayMusic") && !str1.Contains("UseKira") && !str1.Contains("BanSound"))
        {
          string s = str1.Split('：')[0];
          string str2 = "";
          string str3 = "";
          string str4 = str1.Split('：')[1];
          int num1 = 0;
          string str5 = "";
          int num2 = 0;
          string str6 = "";
          float num3 = 0.0f;
          int num4 = 0;
          if (s.Contains("="))
          {
            str2 = s.Split('=')[0];
            str3 = "=";
            s = s.Split('=')[1];
          }
          if (str3 == "=" && (double) float.Parse(hashtable1[(object) str2].ToString()) == (double) float.Parse(s))
          {
            if (str1.Contains("变化到"))
            {
              num1 = 0;
              string[] strArray = str4.Split("变化到".ToCharArray())[3].Split("，".ToCharArray());
              num2 = (int) Main.results3[(object) str4.Split("变化到".ToCharArray())[0]];
              str6 = str4.Split("变化到".ToCharArray())[0];
              if (strArray[0].Contains<char>('+'))
                num3 = (float) ((double) float.Parse(strArray[0].Split('+')[0]) + (double) MathHelper.Lerp((float) -(double) float.Parse(strArray[0].Split('+')[1]), float.Parse(strArray[0].Split('+')[1]), (float) Main.rand.NextDouble()));
              else
                num3 = num2 == 1 || num2 == 3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.position.X, Player.position.Y, Center.ox, Center.oy))) : float.Parse(strArray[0]);
              str5 = strArray[1];
              num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
            }
            else if (str1.Contains("增加"))
            {
              num1 = 1;
              string[] strArray = str4.Split("增".ToCharArray())[1].Split("，".ToCharArray());
              strArray[0] = strArray[0].Replace("加", "");
              num2 = (int) Main.results3[(object) str4.Split("增".ToCharArray())[0]];
              str6 = str4.Split("增".ToCharArray())[0];
              if (strArray[0].Contains<char>('+'))
                num3 = (float) ((double) float.Parse(strArray[0].Split('+')[0]) + (double) MathHelper.Lerp((float) -(double) float.Parse(strArray[0].Split('+')[1]), float.Parse(strArray[0].Split('+')[1]), (float) Main.rand.NextDouble()));
              else
                num3 = num2 == 1 || num2 == 3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.position.X, Player.position.Y, Center.ox, Center.oy))) : float.Parse(strArray[0]);
              str5 = strArray[1];
              num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
            }
            else if (str1.Contains("减少"))
            {
              num1 = 2;
              string[] strArray = str4.Split("减少".ToCharArray())[2].Split("，".ToCharArray());
              num2 = (int) Main.results3[(object) str4.Split("减少".ToCharArray())[0]];
              str6 = str4.Split("减少".ToCharArray())[0];
              if (strArray[0].Contains<char>('+'))
                num3 = (float) ((double) float.Parse(strArray[0].Split('+')[0]) + (double) MathHelper.Lerp((float) -(double) float.Parse(strArray[0].Split('+')[1]), float.Parse(strArray[0].Split('+')[1]), (float) Main.rand.NextDouble()));
              else
                num3 = num2 == 1 || num2 == 3 ? (!strArray[0].Contains("自机") ? float.Parse(strArray[0]) : MathHelper.ToDegrees(Main.Twopointangle(Player.position.X, Player.position.Y, Center.ox, Center.oy))) : float.Parse(strArray[0]);
              str5 = strArray[1];
              num4 = int.Parse(strArray[2].Split("帧".ToCharArray())[0]);
            }
            if (str1.Contains("跟随自机"))
              Center.Eventsexe.Add(new CExecution()
              {
                changetype = 3,
                ctime = 60
              });
            else if (str1.Contains("范围移动"))
            {
              Center.Eventsexe.Add(new CExecution()
              {
                changetype = 4,
                ctime = 60,
                value = MathHelper.Lerp(float.Parse(str1.Split('，')[1]), float.Parse(str1.Split('，')[2]), (float) Main.rand.NextDouble()),
                value2 = MathHelper.Lerp(float.Parse(str1.Split('，')[3]), float.Parse(str1.Split('，')[4]), (float) Main.rand.NextDouble())
              });
            }
            else
            {
              CExecution cexecution = new CExecution()
              {
                change = num1,
                changetype = (int) Main.type[(object) str5],
                changevalue = num2,
                value = num3,
                region = hashtable2[(object) str6].ToString(),
                time = num4
              };
              cexecution.ctime = cexecution.time;
              Center.Eventsexe.Add(cexecution);
            }
          }
        }
      }
      for (int index = 0; index < Center.Eventsexe.Count; ++index)
      {
        if (!Center.Eventsexe[index].NeedDelete)
        {
          Center.Eventsexe[index].Update();
        }
        else
        {
          Center.Eventsexe.RemoveAt(index);
          --index;
        }
      }
    }

    public static void Draw(SpriteBatch s)
    {
      if (!(Main.Available & Center.Available))
        return;
      if (!Time.Playing)
        s.Draw(Main.center, new Vector2(Center.x + 170f, Center.y + 21f), new Rectangle?(), Color.White, 0.0f, new Vector2(18f, 18f), 1f, SpriteEffects.None, 1f);
      if (!Time.Playing)
        return;
      s.Draw(Main.center, new Vector2(Center.ox + 170f, Center.oy + 21f), new Rectangle?(), Color.White, 0.0f, new Vector2(18f, 18f), 1f, SpriteEffects.None, 1f);
    }
  }
}
