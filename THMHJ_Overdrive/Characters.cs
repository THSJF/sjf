// Decompiled with JetBrains decompiler
// Type: THMHJ.Characters
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

namespace THMHJ
{
  public class Characters
  {
    public static Attribute[] attribute = new Attribute[8];
    public static Record[] record = new Record[4];

    public static void Initialize()
    {
      for (int index = 1; index <= 4; ++index)
      {
        Characters.record[index - 1].HISCORE = 0L;
        if (index == 1)
        {
          Characters.attribute[0].MOVE = 7f;
          Characters.attribute[4].MOVE = 4f;
          Characters.attribute[0].ADJUST = 0;
          Characters.attribute[4].ADJUST = 0;
          Characters.attribute[0].BODY = 0;
          Characters.attribute[4].BODY = 0;
          Characters.attribute[0].CHILDREN = 0;
          Characters.attribute[4].CHILDREN = 0;
        }
        else if (index == 2)
        {
          Characters.attribute[1].MOVE = 8f;
          Characters.attribute[5].MOVE = 5f;
          Characters.attribute[1].ADJUST = 0;
          Characters.attribute[5].ADJUST = 0;
          Characters.attribute[1].BODY = 0;
          Characters.attribute[5].BODY = 0;
          Characters.attribute[1].CHILDREN = 0;
          Characters.attribute[5].CHILDREN = 0;
        }
        else if (index == 3)
        {
          Characters.attribute[2].MOVE = 7f;
          Characters.attribute[6].MOVE = 4f;
          Characters.attribute[2].ADJUST = 0;
          Characters.attribute[6].ADJUST = 0;
          Characters.attribute[2].BODY = 0;
          Characters.attribute[6].BODY = 0;
          Characters.attribute[2].CHILDREN = 0;
          Characters.attribute[6].CHILDREN = 0;
        }
        else if (index == 4)
        {
          Characters.attribute[3].MOVE = 5f;
          Characters.attribute[7].MOVE = 3f;
          Characters.attribute[3].ADJUST = 0;
          Characters.attribute[7].ADJUST = 0;
          Characters.attribute[3].BODY = 0;
          Characters.attribute[7].BODY = 0;
          Characters.attribute[3].CHILDREN = 0;
          Characters.attribute[7].CHILDREN = 0;
        }
      }
    }
  }
}
