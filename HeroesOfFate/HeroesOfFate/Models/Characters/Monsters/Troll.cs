namespace HeroesOfFate.Models.Characters.Monsters
{
    public class Troll : Monster
    {
        private const double MonsterDamageDefault = 60;
        private const double MonsterHealthDefault = 150;
        private const double MonsterArmorDefault = 0;

        public Troll(int level = 1) 
            : base(MonsterDamageDefault, MonsterHealthDefault, MonsterArmorDefault, level)
        {
        }
    }
}