namespace Shooting
{
  public class BaseBoss : BaseObject
  {
    private int spellcardHP = 2000;
    private float armor = 0.0f;
    private const int unmatchedTime = 100;

    public int SpellcardHP
    {
      get
      {
        return this.spellcardHP;
      }
      set
      {
        this.spellcardHP = value;
      }
    }

    public int UnmatchedTime
    {
      get
      {
        return 100;
      }
    }

    public int Life { get; set; }

    public int MaxHP { get; set; }

    public bool OnSpell { get; set; }

    public int SpellTime { get; set; }

    public float Armon
    {
      get
      {
        return this.armor;
      }
      set
      {
        if ((double) value < 0.0)
          this.armor = 0.0f;
       // else if ((double) value > 1.0)
      //    this.armor = 1f;
        else
          this.armor = value;
      }
    }

    public override void HitCheckAll()
    {
      if (this.Life < 0 || !this.HitEnabled)
        return;
      if (this.MyPlane.HitEnabled && this.HitCheck((BaseObject) this.MyPlane))
        this.MyPlane.PreMiss();
      for (int index = this.MyBulletList.Count - 1; index >= 0; --index)
      {
        if (this.HitCheck(this.MyBulletList[index]))
        {
          if (this.Time > this.UnmatchedTime)
          {
            if (this.MyPlane.EnchantmentState == EnchantmentType.Red)
              this.HealthPoint -= (float) ((double) this.MyBulletList[index].Damage * 1.25 * (1.0 - (double) this.Armon));
            else
              this.HealthPoint -= (float) this.MyBulletList[index].Damage * (1f - this.Armon);
          }
          this.MyBulletList[index].GiveEndEffect();
          this.MyBulletList.RemoveAt(index);
          this.MyPlane.Score += 10L;
          if ((double) this.HealthPoint <= 200.0)
            this.StageData.SoundPlay("se_damage01.wav");
        }
      }
    }
  }
}
