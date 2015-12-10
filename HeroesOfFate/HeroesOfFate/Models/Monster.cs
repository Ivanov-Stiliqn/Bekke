using HeroesOfFate.Contracts.IMonster;

namespace HeroesOfFate.Models
{
    public abstract class Monster : Character
    {
        private const short MonsterLevelDefault = 1;
        private const short MonsterExpDefault = 0;

        protected Monster(
            double damage,
            double health,
            double armor,
            short exp = MonsterExpDefault,
            short level = MonsterLevelDefault)
            :base(damage,health,armor,exp,level)
        {
            
        }


    }
}