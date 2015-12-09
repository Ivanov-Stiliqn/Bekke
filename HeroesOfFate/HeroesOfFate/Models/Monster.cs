using HeroesOfFate.Contracts.IMonster;

namespace HeroesOfFate.Models
{
    public abstract class Monster : Character
    {
        private const short MonsterLevelDefault = 1;
        private const short MonsterExpDefault = 0;

        protected Monster(
            double x,
            double y,
            double damage,
            double health,
            double armor,
            short exp = MonsterExpDefault,
            short level = MonsterLevelDefault)
            :base(x,y,damage,health,armor,exp,level)
        {
            
        }
    }
}