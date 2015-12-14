namespace HeroesOfFate.Models.Characters.Monsters
{
    public class Goblin : Monster
    {
        private const double MonsterDamageDefault = 30;
        private const double MonsterHealthDefault = 80;
        private const double MonsterArmorDefault = 0;

        public Goblin(int level = 1) 
            : base(MonsterDamageDefault, MonsterHealthDefault, MonsterArmorDefault, level)
        {

        }
    }
}