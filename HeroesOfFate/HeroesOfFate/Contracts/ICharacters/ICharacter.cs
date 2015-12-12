using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfFate.Contracts
{
    public interface ICharacter
    {
        double Damage { get; set; }

        double Health { get; set; }

        double Armor { get; set; }

        int Level { get; set; }

        bool IsDead { get; }
    }
}
