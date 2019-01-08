using System.Collections;

namespace Shooting
{
  public class Hash
  {
    public static Hashtable conditions = new Hashtable();
    public static Hashtable results = new Hashtable();
    public static Hashtable type = new Hashtable();
    public static Hashtable conditions2 = new Hashtable();
    public static Hashtable results2 = new Hashtable();
    public static Hashtable results3 = new Hashtable();
    public static Hashtable cconditions = new Hashtable();
    public static Hashtable cresults = new Hashtable();
    public static Hashtable lconditions = new Hashtable();
    public static Hashtable lresults = new Hashtable();
    public static Hashtable lresults2 = new Hashtable();

    public static void Init()
    {
      Hash.type.Add((object) "正比", (object) 0);
      Hash.type.Add((object) "固定", (object) 1);
      Hash.type.Add((object) "正弦", (object) 2);
      Hash.conditions.Add((object) "", (object) 0);
      Hash.conditions.Add((object) "当前帧", (object) 0);
      Hash.conditions.Add((object) "X坐标", (object) 1);
      Hash.conditions.Add((object) "Y坐标", (object) 2);
      Hash.conditions.Add((object) "半径", (object) 3);
      Hash.conditions.Add((object) "半径方向", (object) 4);
      Hash.conditions.Add((object) "条数", (object) 5);
      Hash.conditions.Add((object) "周期", (object) 6);
      Hash.conditions.Add((object) "角度", (object) 7);
      Hash.conditions.Add((object) "范围", (object) 8);
      Hash.conditions.Add((object) "宽比", (object) 9);
      Hash.conditions.Add((object) "高比", (object) 10);
      Hash.conditions.Add((object) "不透明度", (object) 11);
      Hash.conditions.Add((object) "朝向", (object) 12);
      Hash.results.Add((object) "X坐标", (object) 0);
      Hash.results.Add((object) "Y坐标", (object) 1);
      Hash.results.Add((object) "半径", (object) 2);
      Hash.results.Add((object) "半径方向", (object) 3);
      Hash.results.Add((object) "条数", (object) 4);
      Hash.results.Add((object) "周期", (object) 5);
      Hash.results.Add((object) "角度", (object) 6);
      Hash.results.Add((object) "范围", (object) 7);
      Hash.results.Add((object) "速度", (object) 8);
      Hash.results.Add((object) "速度方向", (object) 9);
      Hash.results.Add((object) "加速度", (object) 10);
      Hash.results.Add((object) "加速度方向", (object) 11);
      Hash.results.Add((object) "生命", (object) 12);
      Hash.results.Add((object) "类型", (object) 13);
      Hash.results.Add((object) "宽比", (object) 14);
      Hash.results.Add((object) "高比", (object) 15);
      Hash.results.Add((object) "R", (object) 16);
      Hash.results.Add((object) "G", (object) 17);
      Hash.results.Add((object) "B", (object) 18);
      Hash.results.Add((object) "不透明度", (object) 19);
      Hash.results.Add((object) "朝向", (object) 20);
      Hash.results.Add((object) "子弹速度", (object) 21);
      Hash.results.Add((object) "子弹速度方向", (object) 22);
      Hash.results.Add((object) "子弹加速度", (object) 23);
      Hash.results.Add((object) "子弹加速度方向", (object) 24);
      Hash.results.Add((object) "横比", (object) 25);
      Hash.results.Add((object) "纵比", (object) 26);
      Hash.results.Add((object) "雾化效果", (object) 27);
      Hash.results.Add((object) "消除效果", (object) 28);
      Hash.results.Add((object) "高光效果", (object) 29);
      Hash.results.Add((object) "拖影效果", (object) 30);
      Hash.results.Add((object) "出屏即消", (object) 31);
      Hash.results.Add((object) "无敌状态", (object) 32);
      Hash.conditions2.Add((object) "", (object) 0);
      Hash.conditions2.Add((object) "当前帧", (object) 0);
      Hash.conditions2.Add((object) "X坐标", (object) 1);
      Hash.conditions2.Add((object) "Y坐标", (object) 2);
      Hash.results2.Add((object) "生命", (object) 0);
      Hash.results2.Add((object) "类型", (object) 1);
      Hash.results2.Add((object) "宽比", (object) 2);
      Hash.results2.Add((object) "高比", (object) 3);
      Hash.results2.Add((object) "R", (object) 4);
      Hash.results2.Add((object) "G", (object) 5);
      Hash.results2.Add((object) "B", (object) 6);
      Hash.results2.Add((object) "不透明度", (object) 7);
      Hash.results2.Add((object) "朝向", (object) 8);
      Hash.results2.Add((object) "子弹速度", (object) 9);
      Hash.results2.Add((object) "子弹速度方向", (object) 10);
      Hash.results2.Add((object) "子弹加速度", (object) 11);
      Hash.results2.Add((object) "子弹加速度方向", (object) 12);
      Hash.results2.Add((object) "横比", (object) 13);
      Hash.results2.Add((object) "纵比", (object) 14);
      Hash.results2.Add((object) "雾化效果", (object) 15);
      Hash.results2.Add((object) "消除效果", (object) 16);
      Hash.results2.Add((object) "高光效果", (object) 17);
      Hash.results2.Add((object) "拖影效果", (object) 18);
      Hash.results2.Add((object) "出屏即消", (object) 19);
      Hash.results2.Add((object) "无敌状态", (object) 20);
      Hash.cconditions.Add((object) "", (object) 0);
      Hash.cconditions.Add((object) "当前帧", (object) 0);
      Hash.cconditions.Add((object) "X坐标", (object) 1);
      Hash.cconditions.Add((object) "Y坐标", (object) 2);
      Hash.cconditions.Add((object) "半宽", (object) 3);
      Hash.cconditions.Add((object) "半高", (object) 4);
      Hash.cresults.Add((object) "半宽", (object) 0);
      Hash.cresults.Add((object) "半高", (object) 1);
      Hash.cresults.Add((object) "启用圆形", (object) 2);
      Hash.cresults.Add((object) "速度", (object) 3);
      Hash.cresults.Add((object) "速度方向", (object) 4);
      Hash.cresults.Add((object) "加速度", (object) 5);
      Hash.cresults.Add((object) "加速度方向", (object) 6);
      Hash.cresults.Add((object) "类型", (object) 7);
      Hash.cresults.Add((object) "ID", (object) 8);
      Hash.cresults.Add((object) "X坐标", (object) 9);
      Hash.cresults.Add((object) "Y坐标", (object) 10);
    }
  }
}
