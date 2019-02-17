// Decompiled with JetBrains decompiler
// Type: CrazyStorm_1._03.SubStringHelper
// Assembly: CrazyStorm 1.03, Version=1.0.0.3, Culture=neutral, PublicKeyToken=null
// MVID: 84431CDC-1E34-49EF-A5C5-D546FEF5A655
// Assembly location: E:\CrazyStorm 1.03I\CrazyStorm 1.03.exe

using System.Text;
using System.Text.RegularExpressions;

namespace CrazyStorm_1._03
{
  public class SubStringHelper
  {
    public static string BackSpaceString(string stringToBackSpace)
    {
      Regex regex = new Regex("[一-龥]+", RegexOptions.Compiled);
      char[] charArray = stringToBackSpace.ToCharArray();
      StringBuilder stringBuilder = new StringBuilder();
      int num = 0;
      for (int index = 0; index < charArray.Length - 1; ++index)
      {
        if (regex.IsMatch(charArray[index].ToString()))
        {
          stringBuilder.Append(charArray[index]);
          num += 2;
        }
        else
        {
          stringBuilder.Append(charArray[index]);
          ++num;
        }
      }
      return stringBuilder.ToString();
    }
  }
}
