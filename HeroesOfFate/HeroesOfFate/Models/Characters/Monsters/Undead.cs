namespace HeroesOfFate.Models.Characters.Monsters
{
    public class Undead : Monster
    {
        private const double MonsterDamageDefault = 40;
        private const double MonsterHealthDefault = 100;
        private const double MonsterArmorDefault = 0;

        public Undead(int level = 1) 
            : base(MonsterDamageDefault, MonsterHealthDefault, MonsterArmorDefault, level)
        {
        }
    }
}