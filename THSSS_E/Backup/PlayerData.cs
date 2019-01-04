﻿// Decompiled with JetBrains decompiler
// Type: Shooting.PlayerData
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Shooting
{
  public class PlayerData
  {
    private static string[] SCNameEN = new string[37]
    {
      "星符「夏夜的晚星」",
      "四叶「大自然之花环」",
      "魔矢「无限之箭」",
      "天诏「琴引山之诏琴」",
      "使魔「自动狩猎装置」",
      "天箭「星之箭」",
      "火符「逼近的火焰」",
      "火光「火精灵之灾」",
      "木灵「大屋津姬命」",
      "妖符「柳下妖蝉」",
      "绿符「柳叶风暴」",
      "魔镜「幻影之境」",
      "镜符「月季色红梦裂隙」",
      "阴阳「神鬼一击」",
      "辉针「闪耀万针剑」",
      "镜符「山吹色波纹裂隙」",
      "流光「幻影魔炮」",
      "星符「急速彗星」",
      "镜符「瑠璃色银河裂隙」",
      "岚符「大孔雀暴风」",
      "秘术「遗忘之封印」",
      "镜符「若竹色翠石裂隙」",
      "空想「恋之宣告」",
      "「古明地恋的消失」",
      "虹奥义「光幕结界」",
      "杀箭「新星爆炸箭」",
      "火舞「夏夜流火」",
      "机关「火焰发射装置」",
      "混沌「守护的心意」",
      "焰符「原始的烈焰」",
      "「星神降临仪式」",
      "许愿星「星火辉迹」",
      "耀星「白夜永昼之光」",
      "星雨「故乡之星」",
      "星图「宇宙棋盘」",
      "「弹幕之海」",
      "「流星神话」"
    };
    private static string[] SCNameHL = new string[46]
    {
      "微风「摇曳的三叶草」",
      "星符「夏夜的晚星」",
      "四叶「大自然之花环」",
      "夜风「轮回的幸运之星」",
      "魔矢「轮回的万箭」",
      "异器「琴引山之神弓」",
      "魔狩「星夜的狩猎舞曲」",
      "华箭「紫星之花」",
      "秘术「龙卷旋风之箭」",
      "火符「燃烧地狱火海」",
      "火光「午夜的大火灾」",
      "木魅「枛津姬命」",
      "妖符「柳下妖蝉」",
      "深绿「舞动的翠绿之风」",
      "叶符「德律阿得斯的圣枝」",
      "魔镜「虚无幽幻之境」",
      "镜符「月季色红梦裂隙」",
      "阴阳「神鬼一击」",
      "辉针「闪耀万针剑」",
      "镜符「山吹色波纹裂隙」",
      "流光「幻影魔炮」",
      "星符「急速彗星」",
      "镜符「瑠璃色银河裂隙」",
      "岚符「大孔雀暴风」",
      "秘术「遗忘之封印」",
      "镜符「若竹色翠石裂隙」",
      "空想「恋之宣告」",
      "「古明地恋的消失」",
      "虹奥义「光幕结界」",
      "境界「三原色」",
      "杀箭「新星爆炸箭」",
      "火舞「夏夜流火」",
      "焰机「星夜的火焰舞曲」",
      "混沌「守护之心」",
      "焰符「八百里的烈焰」",
      "「星神降临仪式」",
      "烈焰「焚秽净世」",
      "许愿星「星火辉迹」",
      "耀星「白夜永昼之光」",
      "星雨「故乡之星」",
      "星图「宇宙棋盘」",
      "「弹幕之海」",
      "「流星神话」",
      "第一个愿望「无尽之财」",
      "第二个愿望「无穷之力」",
      "第三个愿望「永生不灭」"
    };
    private static string[] SCNameEx = new string[35]
    {
      "青符「东之国度的树叶」",
      "柳符「新生的柳叶绿芽」",
      "蝶恋「千年之愿」",
      "风符「环形气流」",
      "速风「双龙卷」",
      "风切「狂风交错」",
      "舞风「阵风螺旋」",
      "飓风「台风眼」",
      "天岚「逆卷神风」",
      "「雾隐流剑技 ～ 暴风疾斩」",
      "绽放「爱意的玫瑰」",
      "幻花「仙晶玉莲」",
      "萱草「忘却之爱」",
      "荣符「生长与枯萎的循环」",
      "花咲「百花缭乱」",
      "花符「云上的花田」",
      "「雾隐流剑技 ～ 血染之樱」",
      "冬临「初雪之寒径」",
      "仙器「太乙冰凌」",
      "霜冻「寒霜封印」",
      "米雪「冷云雪晶」",
      "六花「冰结界的雪花阵」",
      "雪幕「冰雪流凌」",
      "「雾隐流剑技 ～ 落雪凝霜」",
      "迴梦「月色琉璃光」",
      "幽光「幻月蝶」",
      "倒映「天之月水之月」",
      "仙幻「月葬」",
      "净符「月光世界」",
      "皎符「星月炮」",
      "「雾隐流剑技 ～ 天地银蛇」",
      "仙境「风花雪月」",
      "仙蝶「无限的彩灵」",
      "「未定」",
      "「雾隐之蝶」"
    };
    private const string FileName = "Score.dat";
    public List<SpellCardHistory> SC_History;

    private FileStream ScoreFile { get; set; }

    public bool PlaneAEnabled { get; set; }

    public bool PlaneBEnabled { get; set; }

    public bool UltraEnabled { get; set; }

    public bool ExtraEnabled { get; set; }

    public string PlayerName { get; set; }

    public bool[] MusicState { get; set; }

    public List<ScoreHistory> S_History { get; set; }

    public List<ClearHistory> C_History { get; set; }

    public PlayerData()
    {
      this.CreatNewData();
      if (!File.Exists("Score.dat"))
      {
        this.SaveData();
      }
      else
      {
        try
        {
          this.LoadData();
        }
        catch
        {
          int num = (int) MessageBox.Show("读取分数记录错误。", "Score Error");
        }
      }
    }

    private void CreatNewData()
    {
      this.PlayerName = "";
      this.MusicState = new bool[15];
      this.S_History = new List<ScoreHistory>();
      for (int index1 = 0; index1 < 6; ++index1)
      {
        for (int index2 = 0; index2 < 10; ++index2)
        {
          for (int index3 = 0; index3 < 5; ++index3)
          {
            string str;
            switch (index3)
            {
              case 0:
                str = "ReimuA";
                break;
              case 1:
                str = "MarisaA";
                break;
              case 2:
                str = "SanaeA";
                break;
              case 3:
                str = "KoishiA";
                break;
              case 4:
                str = "PlaneA";
                break;
              default:
                str = "AyaA";
                break;
            }
            this.S_History.Add(new ScoreHistory()
            {
              MyPlaneFullName = str,
              Rank = (DifficultLevel) index1,
              PlayerName = "-------",
              Score = (long) ((10 - index2) * 100000),
              Date = "----/--/--",
              Time = "--:--",
              Stage = "---",
              SlowRate = "-.-%"
            });
          }
        }
      }
      this.C_History = new List<ClearHistory>();
      for (int index1 = 0; index1 < 6; ++index1)
      {
        for (int index2 = 0; index2 < 5; ++index2)
        {
          string str;
          switch (index2)
          {
            case 0:
              str = "ReimuA";
              break;
            case 1:
              str = "MarisaA";
              break;
            case 2:
              str = "SanaeA";
              break;
            case 3:
              str = "KoishiA";
              break;
            case 4:
              str = "PlaneA";
              break;
            default:
              str = "AyaA";
              break;
          }
          this.C_History.Add(new ClearHistory()
          {
            MyPlaneFullName = str,
            Rank = (DifficultLevel) index1,
            StartTimes = 0,
            PlayingTime = 0L,
            ClearTimes = 0,
            NoContinueClearTimes = 0,
            PracticeLevel = 1
          });
        }
      }
      this.SC_History = new List<SpellCardHistory>();
      for (int index1 = 0; index1 < 5; ++index1)
      {
        int num = 1;
        string str;
        switch (index1)
        {
          case 0:
            str = "ReimuA";
            break;
          case 1:
            str = "MarisaA";
            break;
          case 2:
            str = "SanaeA";
            break;
          case 3:
            str = "KoishiA";
            break;
          case 4:
            str = "PlaneA";
            break;
          default:
            str = "AyaA";
            break;
        }
        for (int index2 = 0; index2 < 6; ++index2)
        {
          if (index2 < 2)
          {
            for (int index3 = 0; index3 < PlayerData.SCNameEN.Length; ++index3)
              this.SC_History.Add(new SpellCardHistory()
              {
                MyPlaneFullName = str,
                Rank = (DifficultLevel) index2,
                Name = PlayerData.SCNameEN[index3],
                Index = num++,
                Recorded = 0,
                History = 0
              });
          }
          else if (index2 < 5)
          {
            for (int index3 = 0; index3 < PlayerData.SCNameHL.Length; ++index3)
              this.SC_History.Add(new SpellCardHistory()
              {
                MyPlaneFullName = str,
                Rank = (DifficultLevel) index2,
                Name = PlayerData.SCNameHL[index3],
                Index = num++,
                Recorded = 0,
                History = 0
              });
          }
          else
          {
            for (int index3 = 0; index3 < PlayerData.SCNameEx.Length; ++index3)
              this.SC_History.Add(new SpellCardHistory()
              {
                MyPlaneFullName = str,
                Rank = (DifficultLevel) index2,
                Name = PlayerData.SCNameEx[index3],
                Index = num++,
                Recorded = 0,
                History = 0
              });
          }
        }
      }
    }

    public void SaveData()
    {
      this.ScoreFile = new FileStream("Score.dat", FileMode.Create);
      string tmp = (string) null;
      tmp = tmp + this.PlayerName + "\r\n";
      // ISSUE: reference to a compiler-generated field
      this.SC_History.ForEach((Action<SpellCardHistory>) (x => this.tmp += x.Data2String()));
      // ISSUE: reference to a compiler-generated field
      this.S_History.ForEach((Action<ScoreHistory>) (x => this.tmp += x.Data2String()));
      // ISSUE: reference to a compiler-generated field
      this.C_History.ForEach((Action<ClearHistory>) (x => this.tmp += x.Data2String()));
      tmp = Encryption.Encrypt(tmp);
      StreamWriter streamWriter = new StreamWriter((Stream) this.ScoreFile);
      streamWriter.Write(tmp);
      streamWriter.Close();
    }

    public void LoadData()
    {
      string[] strArray = File.ReadAllLines("Score.dat", Encoding.Default);
      strArray[0] = Encryption.Decrypt(strArray[0]);
      strArray[0] = strArray[0].Replace("\r\n", "\n");
      string[] stringList = strArray[0].Split('\n');
      int i = 0;
      this.PlayerName = stringList[i++];
      this.SC_History.ForEach((Action<SpellCardHistory>) (x => x.String2Data(stringList[i++])));
      this.S_History.ForEach((Action<ScoreHistory>) (x => x.String2Data(stringList[i++])));
      this.C_History.ForEach((Action<ClearHistory>) (x => x.String2Data(stringList[i++])));
      this.CheckEnable();
    }

    public void CheckEnable()
    {
      this.C_History.ForEach((Action<ClearHistory>) (x =>
      {
        if (x.NoContinueClearTimes <= 0)
          return;
        this.ExtraEnabled = true;
      }));
    }
  }
}
