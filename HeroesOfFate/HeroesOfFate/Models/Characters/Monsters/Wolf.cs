namespace HeroesOfFate.Models.Characters.Monsters
{
    public class Wolf : Monster
    {
        private const double MonsterDamageDefault = 20;
        private const double MonsterHealthDefault = 50;
        private const double MonsterArmorDefault = 0;

        public Wolf(int level = 1) 
            : base(MonsterDamageDefault, MonsterHealthDefault, MonsterArmorDefault,level)
        {
        }
    }
}