// Decompiled with JetBrains decompiler
// Type: THMHJ.CSManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.IO;

namespace THMHJ
{
  public class CSManager
  {
    private int barragecount;
    public Texture2D barrages;
    public Texture2D mist;
    public Texture2D dis;
    public Hashtable conditions;
    public Hashtable results;
    public Hashtable type;
    public Hashtable conditions2;
    public Hashtable results2;
    public Hashtable results3;
    public Hashtable cconditions;
    public Hashtable cresults;
    public Hashtable lconditions;
    public Hashtable lresults;
    public Hashtable lresults2;
    public List<BarrageType> bgset;
    public List<CrazyStorm> esc;
    public List<CrazyStorm> csc;

    public int BarrageCount
    {
      get
      {
        return this.barragecount;
      }
    }

    public CSManager(Texture2D barrages_t, Texture2D mist_t, Texture2D dis_t)
    {
      this.csc = new List<CrazyStorm>();
      this.esc = new List<CrazyStorm>();
      this.barrages = barrages_t;
      this.mist = mist_t;
      this.dis = dis_t;
      this.bgset = new List<BarrageType>();
      this.conditions = new Hashtable();
      this.results = new Hashtable();
      this.type = new Hashtable();
      this.conditions2 = new Hashtable();
      this.results2 = new Hashtable();
      this.results3 = new Hashtable();
      this.cconditions = new Hashtable();
      this.cresults = new Hashtable();
      this.lconditions = new Hashtable();
      this.lresults = new Hashtable();
      this.lresults2 = new Hashtable();
      this.type.Add((object) "正比", (object) 0);
      this.type.Add((object) "固定", (object) 1);
      this.type.Add((object) "正弦", (object) 2);
      this.conditions.Add((object) "", (object) 0);
      this.conditions.Add((object) "当前帧", (object) 0);
      this.conditions.Add((object) "X坐标", (object) 1);
      this.conditions.Add((object) "Y坐标", (object) 2);
      this.conditions.Add((object) "半径", (object) 3);
      this.conditions.Add((object) "半径方向", (object) 4);
      this.conditions.Add((object) "条数", (object) 5);
      this.conditions.Add((object) "周期", (object) 6);
      this.conditions.Add((object) "角度", (object) 7);
      this.conditions.Add((object) "范围", (object) 8);
      this.conditions.Add((object) "宽比", (object) 9);
      this.conditions.Add((object) "高比", (object) 10);
      this.conditions.Add((object) "不透明度", (object) 11);
      this.conditions.Add((object) "朝向", (object) 12);
      this.results.Add((object) "X坐标", (object) 0);
      this.results.Add((object) "Y坐标", (object) 1);
      this.results.Add((object) "半径", (object) 2);
      this.results.Add((object) "半径方向", (object) 3);
      this.results.Add((object) "条数", (object) 4);
      this.results.Add((object) "周期", (object) 5);
      this.results.Add((object) "角度", (object) 6);
      this.results.Add((object) "范围", (object) 7);
      this.results.Add((object) "速度", (object) 8);
      this.results.Add((object) "速度方向", (object) 9);
      this.results.Add((object) "加速度", (object) 10);
      this.results.Add((object) "加速度方向", (object) 11);
      this.results.Add((object) "生命", (object) 12);
      this.results.Add((object) "类型", (object) 13);
      this.results.Add((object) "宽比", (object) 14);
      this.results.Add((object) "高比", (object) 15);
      this.results.Add((object) "R", (object) 16);
      this.results.Add((object) "G", (object) 17);
      this.results.Add((object) "B", (object) 18);
      this.results.Add((object) "不透明度", (object) 19);
      this.results.Add((object) "朝向", (object) 20);
      this.results.Add((object) "子弹速度", (object) 21);
      this.results.Add((object) "子弹速度方向", (object) 22);
      this.results.Add((object) "子弹加速度", (object) 23);
      this.results.Add((object) "子弹加速度方向", (object) 24);
      this.results.Add((object) "横比", (object) 25);
      this.results.Add((object) "纵比", (object) 26);
      this.results.Add((object) "雾化效果", (object) 27);
      this.results.Add((object) "消除效果", (object) 28);
      this.results.Add((object) "高光效果", (object) 29);
      this.results.Add((object) "拖影效果", (object) 30);
      this.results.Add((object) "出屏即消", (object) 31);
      this.results.Add((object) "无敌状态", (object) 32);
      this.conditions2.Add((object) "", (object) 0);
      this.conditions2.Add((object) "当前帧", (object) 0);
      this.conditions2.Add((object) "X坐标", (object) 1);
      this.conditions2.Add((object) "Y坐标", (object) 2);
      this.results2.Add((object) "生命", (object) 0);
      this.results2.Add((object) "类型", (object) 1);
      this.results2.Add((object) "宽比", (object) 2);
      this.results2.Add((object) "高比", (object) 3);
      this.results2.Add((object) "R", (object) 4);
      this.results2.Add((object) "G", (object) 5);
      this.results2.Add((object) "B", (object) 6);
      this.results2.Add((object) "不透明度", (object) 7);
      this.results2.Add((object) "朝向", (object) 8);
      this.results2.Add((object) "子弹速度", (object) 9);
      this.results2.Add((object) "子弹速度方向", (object) 10);
      this.results2.Add((object) "子弹加速度", (object) 11);
      this.results2.Add((object) "子弹加速度方向", (object) 12);
      this.results2.Add((object) "横比", (object) 13);
      this.results2.Add((object) "纵比", (object) 14);
      this.results2.Add((object) "雾化效果", (object) 15);
      this.results2.Add((object) "消除效果", (object) 16);
      this.results2.Add((object) "高光效果", (object) 17);
      this.results2.Add((object) "拖影效果", (object) 18);
      this.results2.Add((object) "出屏即消", (object) 19);
      this.results2.Add((object) "无敌状态", (object) 20);
      this.results3.Add((object) "速度", (object) 0);
      this.results3.Add((object) "速度方向", (object) 1);
      this.results3.Add((object) "加速度", (object) 2);
      this.results3.Add((object) "加速度方向", (object) 3);
      this.cconditions.Add((object) "", (object) 0);
      this.cconditions.Add((object) "当前帧", (object) 0);
      this.cconditions.Add((object) "X坐标", (object) 1);
      this.cconditions.Add((object) "Y坐标", (object) 2);
      this.cconditions.Add((object) "半宽", (object) 3);
      this.cconditions.Add((object) "半高", (object) 4);
      this.cresults.Add((object) "半宽", (object) 0);
      this.cresults.Add((object) "半高", (object) 1);
      this.cresults.Add((object) "启用圆形", (object) 2);
      this.cresults.Add((object) "速度", (object) 3);
      this.cresults.Add((object) "速度方向", (object) 4);
      this.cresults.Add((object) "加速度", (object) 5);
      this.cresults.Add((object) "加速度方向", (object) 6);
      this.cresults.Add((object) "类型", (object) 7);
      this.cresults.Add((object) "ID", (object) 8);
      this.cresults.Add((object) "X坐标", (object) 9);
      this.cresults.Add((object) "Y坐标", (object) 10);
      this.lconditions.Add((object) "", (object) 0);
      this.lconditions.Add((object) "当前帧", (object) 0);
      this.lconditions.Add((object) "半径", (object) 1);
      this.lconditions.Add((object) "半径方向", (object) 2);
      this.lconditions.Add((object) "条数", (object) 3);
      this.lconditions.Add((object) "周期", (object) 4);
      this.lconditions.Add((object) "角度", (object) 5);
      this.lconditions.Add((object) "范围", (object) 6);
      this.lconditions.Add((object) "宽比", (object) 7);
      this.lconditions.Add((object) "长度", (object) 8);
      this.lconditions.Add((object) "不透明度", (object) 9);
      this.lresults.Add((object) "半径", (object) 0);
      this.lresults.Add((object) "半径方向", (object) 1);
      this.lresults.Add((object) "条数", (object) 2);
      this.lresults.Add((object) "周期", (object) 3);
      this.lresults.Add((object) "角度", (object) 4);
      this.lresults.Add((object) "范围", (object) 5);
      this.lresults.Add((object) "速度", (object) 6);
      this.lresults.Add((object) "速度方向", (object) 7);
      this.lresults.Add((object) "加速度", (object) 8);
      this.lresults.Add((object) "加速度方向", (object) 9);
      this.lresults.Add((object) "生命", (object) 10);
      this.lresults.Add((object) "类型", (object) 11);
      this.lresults.Add((object) "宽比", (object) 12);
      this.lresults.Add((object) "长度", (object) 13);
      this.lresults.Add((object) "不透明度", (object) 14);
      this.lresults.Add((object) "子弹速度", (object) 15);
      this.lresults.Add((object) "子弹速度方向", (object) 16);
      this.lresults.Add((object) "子弹加速度", (object) 17);
      this.lresults.Add((object) "子弹加速度方向", (object) 18);
      this.lresults.Add((object) "横比", (object) 19);
      this.lresults.Add((object) "纵比", (object) 20);
      this.lresults.Add((object) "高光效果", (object) 21);
      this.lresults.Add((object) "出屏即消", (object) 22);
      this.lresults.Add((object) "无敌状态", (object) 23);
      this.lresults2.Add((object) "生命", (object) 0);
      this.lresults2.Add((object) "类型", (object) 1);
      this.lresults2.Add((object) "宽比", (object) 2);
      this.lresults2.Add((object) "长度", (object) 3);
      this.lresults2.Add((object) "不透明度", (object) 4);
      this.lresults2.Add((object) "子弹速度", (object) 5);
      this.lresults2.Add((object) "子弹速度方向", (object) 6);
      this.lresults2.Add((object) "子弹加速度", (object) 7);
      this.lresults2.Add((object) "子弹加速度方向", (object) 8);
      this.lresults2.Add((object) "横比", (object) 9);
      this.lresults2.Add((object) "纵比", (object) 10);
      this.lresults2.Add((object) "高光效果", (object) 11);
      this.lresults2.Add((object) "出屏即消", (object) 12);
      this.lresults2.Add((object) "无敌状态", (object) 13);
      StreamReader streamReader = new StreamReader(Cry.Decry("Content/Data/3.xna", 2));
      for (int index = 0; index < 228; ++index)
      {
        string str = streamReader.ReadLine();
        BarrageType barrageType = new BarrageType();
        barrageType.rect = new Rectangle(int.Parse(str.Split('_')[1]), int.Parse(str.Split('_')[2]), int.Parse(str.Split('_')[3]), int.Parse(str.Split('_')[4]));
        barrageType.origin = new Vector2((float) int.Parse(str.Split('_')[5]), (float) int.Parse(str.Split('_')[6]));
        barrageType.origin0 = new Vector2((float) int.Parse(str.Split('_')[5]), (float) int.Parse(str.Split('_')[6]));
        barrageType.pdr0 = (float) int.Parse(str.Split('_')[7]);
        if (str.Split('_')[8] != "")
          barrageType.color = int.Parse(str.Split('_')[8]);
        else
          barrageType.color = -1;
        this.bgset.Add(barrageType);
      }
      streamReader.Close();
    }

    public CrazyStorm Createnew(int stage, int barrageid, Hashtable barragec)
    {
      if (stage == 0)
        stage = 1;
      CrazyStorm crazyStorm = Main.SpecialMode == Modes.SPELLCARD ? ((CrazyStorm) barragec[(object) barrageid.ToString()]).Clone(true) : ((CrazyStorm) barragec[(object) (stage.ToString() + barrageid.ToString())]).Clone(true);
      this.csc.Add(crazyStorm);
      return crazyStorm;
    }

    public CrazyStorm Createnew(string id, Hashtable barragec)
    {
      CrazyStorm crazyStorm = ((CrazyStorm) barragec[(object) id]).Clone(true);
      this.csc.Add(crazyStorm);
      return crazyStorm;
    }

    public CrazyStorm Createnew(bool add, string id, Hashtable barragec)
    {
      CrazyStorm crazyStorm = ((CrazyStorm) barragec[(object) id]).Clone(add);
      this.esc.Add(crazyStorm);
      return crazyStorm;
    }

    public CrazyStorm Find(string id)
    {
      foreach (CrazyStorm crazyStorm in this.esc)
      {
        if (crazyStorm.Id.Equals(id))
          return crazyStorm;
      }
      return (CrazyStorm) null;
    }

    public void Update(Character Player, EnemyManager em, Boss boss)
    {
      this.barragecount = 0;
      for (int index = 0; index < this.csc.Count; ++index)
      {
        int num = this.csc[index].BarrageCount();
        this.barragecount += num;
        if (this.csc[index].IsClosing() && (num == 0 || this.csc[index].IsItemed()))
        {
          this.csc.RemoveAt(index);
          --index;
        }
        else if (this.csc[index].Run() && this.csc[index].Add)
          this.csc[index].Update(Player, em, boss);
      }
      for (int index = 0; index < this.esc.Count; ++index)
      {
        if (this.esc[index].IsClosing() && this.esc[index].BarrageCount() == 0)
        {
          this.esc.RemoveAt(index);
          --index;
        }
        else if (this.esc[index].Run() && this.esc[index].Add)
          this.esc[index].Update(Player, em, boss);
      }
    }

    public void Draw(SpriteBatch s, Vector2 Quakeset)
    {
      for (int index = 0; index < this.csc.Count; ++index)
      {
        if (this.csc[index].Run())
          this.csc[index].Draw(s, Quakeset);
      }
      for (int index = 0; index < this.esc.Count; ++index)
      {
        if (this.esc[index].Run())
          this.esc[index].Draw(s, Quakeset);
      }
    }
  }
}
