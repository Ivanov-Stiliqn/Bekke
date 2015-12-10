namespace HeroesOfFate.Models.Monsters
{
    public class Ogre : Monster
    {
        private const double MonsterDamageDefault = 0;
        private const double MonsterHealthDefault = 0;
        private const double MonsterArmorDefault = 0;

        public Ogre(short exp = 0, short level = 1) 
            : base(MonsterDamageDefault, MonsterHealthDefault, MonsterArmorDefault, exp, level)
        {
        }
    }
}