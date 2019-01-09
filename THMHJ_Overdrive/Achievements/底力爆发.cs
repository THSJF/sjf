// Decompiled with JetBrains decompiler
// Type: THMHJ.Achievements.底力爆发
// Assembly: THMHJ, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null
// MVID: FA599C3E-E096-4E32-9FA9-826FC23213B4
// Assembly location: F:\BaiduNetdiskDownload\thmhj 1.04\THMHJ.exe

using System.Collections;

namespace THMHJ.Achievements {
    internal sealed class 底力爆发:AchievementBase {
        public override bool Check(Hashtable data) {
            if(!((string)data["name"]=="终焉「恶魔祭典」")||(bool)data["shoot"]||(bool)data["bomb"]) {
                return false;
            }
            finishedlevel[(int)data["level"]]=true;
            int num = 0;
            for(int index = 0;index<finishedlevel.Length;++index) {
                if(finishedlevel[index])
                    ++num;
            }
            if(num==finishedlevel.Length)
                finished=true;
            get=true;
            return true;
        }
    }
}
