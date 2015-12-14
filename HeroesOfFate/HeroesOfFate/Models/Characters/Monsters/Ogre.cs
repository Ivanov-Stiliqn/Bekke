namespace HeroesOfFate.Models.Characters.Monsters
{
    public class Ogre : Monster
    {
        private const double MonsterDamageDefault = 50;
        private const double MonsterHealthDefault = 120;
        private const double MonsterArmorDefault = 0;

        public Ogre(int level = 1) 
            : base(MonsterDamageDefault, MonsterHealthDefault, MonsterArmorDefault, level)
        {
        }
    }
}