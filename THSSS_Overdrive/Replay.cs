// Decompiled with JetBrains decompiler
// Type: Shooting.Replay
// Assembly: THSSS, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: 9501F839-8E36-4763-8C1B-4AB9B7BE2AA4
// Assembly location: E:\东方project\非官方游戏\东方夏夜祭 ～ Shining Shooting Star\THSSS.exe

using System;
using System.IO;
using System.Text;

namespace Shooting
{
  public class Replay
  {
    private FileStream ReplayData { get; set; }

    private string FileName { get; set; }

    public long DataPosition
    {
      get
      {
        return this.ReplayData.Position;
      }
      set
      {
        this.ReplayData.Position = value;
      }
    }

    public bool CanRead
    {
      get
      {
        return this.ReplayData.CanRead;
      }
    }

    public static ReplayInfo ReadTitle(string fileName)
    {
      string[] strArray1 = File.ReadAllLines(fileName, Encoding.Default);
      try
      {
        int num = 0;
                do { }
                while(strArray1[++num]!="ReplayInformation"&&num<strArray1.Length-1);
        ReplayInfo replayInfo = new ReplayInfo()
        {
          Version = strArray1[num + 1],
          PlayerName = strArray1[num + 2],
          Date = strArray1[num + 3],
          Time = strArray1[num + 4],
          MyPlaneName = strArray1[num + 5],
          WeaponType = strArray1[num + 6],
          Rank = (DifficultLevel) Convert.ToInt32(strArray1[num + 7]),
          StartStage = strArray1[num + 8],
          LastStage = strArray1[num + 9],
          SlowRate = strArray1[num + 10]
        };
        for (int index = num + 11; index < strArray1.Length; ++index)
        {
          char[] chArray = new char[1]{ '\t' };
          string[] strArray2 = strArray1[index].Split(chArray);
          MyPlaneInfo myPlaneInfo = new MyPlaneInfo()
          {
            Life = Convert.ToInt32(strArray2[0]),
            Spell = Convert.ToInt32(strArray2[1]),
            Power = Convert.ToInt32(strArray2[2]),
            Score = Convert.ToInt64(strArray2[3]),
            Graze = Convert.ToInt32(strArray2[4]),
            PosX = (float) Convert.ToDouble(strArray2[5]),
            PosY = (float) Convert.ToDouble(strArray2[6]),
            LifeChip = Convert.ToInt32(strArray2[7]),
            SpellChip = Convert.ToInt32(strArray2[8]),
            LifeUpCount = Convert.ToInt32(strArray2[9]),
            StarPoint = Convert.ToInt32(strArray2[10]),
            HighItemScore = Convert.ToInt32(strArray2[11]),
            Rate = (float) Convert.ToDouble(strArray2[12]),
            LastColor = (EnchantmentType) Convert.ToInt32(strArray2[13]),
            DataPosition = Convert.ToInt64(strArray2[14])
          };
          replayInfo.MyPlaneData.Add(myPlaneInfo);
        }
        return replayInfo;
      }
      catch
      {
        return new ReplayInfo();
      }
    }

    public void WriteKey(int KeyValue)
    {
      this.ReplayData.WriteByte((byte) (KeyValue & (int) byte.MaxValue));
      this.ReplayData.WriteByte((byte) ((uint) (byte) (KeyValue >> 8) & (uint) byte.MaxValue));
    }

    public int ReadKey()
    {
      return this.ReplayData.ReadByte() + (this.ReplayData.ReadByte() << 8);
    }

    public void CreatRpy()
    {
      this.ReplayData = new FileStream(".\\Replay\\AutoSave.rpy", FileMode.Create);
    }

    public void SaveRpy(string fileName, ReplayInfo repInfo)
    {
      if (this.ReplayData.CanRead)
      {
        this.ReplayData.WriteByte((byte) 240);
        this.ReplayData.WriteByte((byte) 15);
        string tmp = (string) null;
        tmp += "\r\n";
        tmp += "ReplayInformation";
        tmp += "\r\n";
        tmp += "ver 1.00";
        tmp += "\r\n";
        tmp += repInfo.PlayerName;
        tmp += "\r\n";
        string str1 = tmp;
        DateTime dateTime = DateTime.Now;
        dateTime = dateTime.Date;
        string str2 = dateTime.ToString("yy'/'MM'/'dd");
        tmp = str1 + str2;
        tmp += "\r\n";
        string str3 = tmp;
        dateTime = DateTime.Now;
        string shortTimeString = dateTime.ToShortTimeString();
        tmp = str3 + shortTimeString;
        tmp += "\r\n";
        tmp += repInfo.MyPlaneName;
        tmp += "\r\n";
        tmp += repInfo.WeaponType.ToString();
        tmp += "\r\n";
        tmp += ((int) repInfo.Rank).ToString();
        tmp += "\r\n";
        tmp += repInfo.StartStage;
        tmp += "\r\n";
        tmp += repInfo.LastStage;
        tmp += "\r\n";
        tmp += repInfo.SlowRate;
        repInfo.MyPlaneData.ForEach((Action<MyPlaneInfo>) (x =>
        {
          tmp += "\r\n";
          tmp = tmp + x.Life.ToString() + (object) '\t' + x.Spell.ToString() + (object) '\t' + x.Power.ToString() + (object) '\t' + x.Score.ToString() + (object) '\t' + x.Graze.ToString() + (object) '\t' + x.PosX.ToString() + (object) '\t' + x.PosY.ToString() + (object) '\t' + x.LifeChip.ToString() + (object) '\t' + x.SpellChip.ToString() + (object) '\t' + x.LifeUpCount.ToString() + (object) '\t' + x.StarPoint.ToString() + (object) '\t' + x.HighItemScore.ToString() + (object) '\t' + x.Rate.ToString() + (object) '\t' + ((int) x.LastColor).ToString() + (object) '\t' + x.DataPosition.ToString();
        }));
        StreamWriter streamWriter = new StreamWriter((Stream) this.ReplayData);
        streamWriter.Write(tmp);
        streamWriter.Close();
        this.ReplayData.Close();
      }
      if (!(fileName != ".\\Replay\\AutoSave.rpy"))
        return;
      File.Copy(".\\Replay\\AutoSave.rpy", fileName, true);
    }

    public void LoadRpy(string fileName)
    {
      this.FileName = fileName;
      this.ReplayData = new FileInfo(fileName).OpenRead();
    }

    public void ReloadRpy()
    {
      this.ReplayData = new FileInfo(this.FileName).OpenRead();
    }

    public void CloseRpy()
    {
      if (this.ReplayData == null)
        return;
      this.ReplayData.Close();
    }

    public void Dispose()
    {
      if (this.ReplayData == null)
        return;
      this.ReplayData.Close();
      this.ReplayData.Dispose();
    }
  }
}
