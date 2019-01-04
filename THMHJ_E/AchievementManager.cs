// Decompiled with JetBrains decompiler
// Type: THMHJ.AchievementManager
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using Microsoft.Xna.Framework.Graphics;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization.Formatters.Binary;

namespace THMHJ
{
  public class AchievementManager
  {
    private static int[] achivIndex = new int[3]{ 0, 6, 22 };
    private static Texture2D boardTex;
    private AchievementBase[] achivs;
    private static string[][] achivName;
    private List<Board> showBoards;

    public static Texture2D BoardTex
    {
      get
      {
        return AchievementManager.boardTex;
      }
    }

    public AchievementManager(Texture2D board)
    {
      AchievementManager.boardTex = board;
      this.showBoards = new List<Board>();
      AchievementManager.achivName = this.LoadAchievementList();
      this.Initialize();
    }

    public void Check(AchievementType achivtype, int achivid, Hashtable data)
    {
      int index = AchievementManager.achivIndex[(int) achivtype] + achivid;
      if (Main.Replay || Main.Mode == Modes.NETWORK)
        return;
      if (!this.achivs[index].get)
      {
        if (!this.achivs[index].Check(data))
          return;
        this.showBoards.Add(new Board(AchievementManager.boardTex, AchievementManager.achivName[(int) achivtype][achivid]));
        this.AddFinishFlag(achivtype, achivid, this.achivs[index].finishedlevel);
      }
      else
      {
        if (this.achivs[index].finished || !this.achivs[index].Check(data))
          return;
        this.AddFinishFlag(achivtype, achivid, this.achivs[index].finishedlevel);
      }
    }

    private void Initialize()
    {
      this.achivs = new AchievementBase[30];
      for (int index1 = 0; index1 < AchievementManager.achivName.Length; ++index1)
      {
        for (int index2 = 0; index2 < AchievementManager.achivName[index1].Length; ++index2)
        {
          if (AchievementManager.achivIndex[index1] + index2 < this.achivs.Length)
            this.achivs[AchievementManager.achivIndex[index1] + index2] = (AchievementBase) Assembly.Load("THMHJ").CreateInstance("THMHJ.Achievements." + AchievementManager.achivName[index1][index2]);
        }
      }
      SpecialData specialData = this.LoadSpecialData();
      for (int index1 = 0; index1 < specialData.ach.Length; ++index1)
      {
        for (int index2 = 0; index2 < specialData.ach[index1].achiv.Length; ++index2)
        {
          this.achivs[AchievementManager.achivIndex[index1] + index2].get = specialData.ach[index1].achiv[index2].get;
          for (int index3 = 0; index3 < this.achivs[AchievementManager.achivIndex[index1] + index2].finishedlevel.Length; ++index3)
            this.achivs[AchievementManager.achivIndex[index1] + index2].finishedlevel[index3] = specialData.ach[index1].achiv[index2].level[index3];
        }
      }
    }

    private void AddFinishFlag(AchievementType achivtype, int achivid, bool[] level)
    {
      SpecialData data = this.LoadSpecialData();
      data.ach[(int) achivtype].achiv[achivid].get = true;
      for (int index = 0; index < level.Length; ++index)
        data.ach[(int) achivtype].achiv[achivid].level[index] = level[index];
      this.SaveSpecialData(data);
    }

    private string[][] LoadAchievementList()
    {
      StreamReader streamReader = new StreamReader(Cry.Decry("Content/Data/9.xna", 2));
      string[][] strArray = new string[3][];
      int index1 = 0;
      while (!streamReader.EndOfStream)
      {
        int length = int.Parse(streamReader.ReadLine());
        strArray[index1] = new string[length];
        for (int index2 = 0; index2 < length; ++index2)
          strArray[index1][index2] = streamReader.ReadLine().Split("：".ToCharArray())[0];
        ++index1;
      }
      return strArray;
    }

    private SpecialData LoadSpecialData()
    {
      Stream serializationStream = Cry.Decry("Content\\Data\\8.xna", 2);
      SpecialData specialData = (SpecialData) new BinaryFormatter().Deserialize(serializationStream);
      serializationStream.Close();
      return specialData;
    }

    private void SaveSpecialData(SpecialData data)
    {
      FileStream fileStream = new FileStream("Content\\Data\\8.xna", FileMode.Create);
      new BinaryFormatter().Serialize((Stream) fileStream, (object) data);
      fileStream.Close();
      Cry.Encry("Content\\Data\\8.xna", 2);
    }

    public void Update()
    {
      if (this.showBoards.Count <= 0)
        return;
      if (this.showBoards[0].Finished)
        this.showBoards.RemoveAt(0);
      else
        this.showBoards[0].Update();
    }

    public void Draw(SpriteBatch s)
    {
      if (this.showBoards.Count <= 0)
        return;
      this.showBoards[0].Draw(s);
    }
  }
}
