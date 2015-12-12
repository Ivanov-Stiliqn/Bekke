using HeroesOfFate.Contracts.IMonster;

namespace HeroesOfFate.Models
{
    public abstract class Monster : Character
    {
        private const short MonsterLevelDefault = 1;

        protected Monster(
            double damage,
            double health,
            double armor,
            int level = MonsterLevelDefault)
            :base(damage,health,armor,level)
        {
            
        }


    }
}