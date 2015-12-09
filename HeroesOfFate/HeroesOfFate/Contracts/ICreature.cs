

namespace HeroesOfFate.Contracts
{
    public interface ICreature
    {
        double Damage { get; set; }
        
        double Health { get; set; }
        
        double Armor { get; set; }

        short Level { get; set; }

        short Exp { get; set; }

        bool IsDead { get; }
    }
}
