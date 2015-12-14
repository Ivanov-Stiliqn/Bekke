namespace HeroesOfFate.Models.Characters.Monsters
{
    public class Boss : Monster
    {
        private const double MonsterDamageDefault = 200;
        private const double MonsterHealthDefault = 400;
        private const double MonsterArmorDefault = 0;

        public Boss(int level = 1) 
            : base(MonsterDamageDefault, MonsterHealthDefault, MonsterArmorDefault, level)
        {

        }
    }
}