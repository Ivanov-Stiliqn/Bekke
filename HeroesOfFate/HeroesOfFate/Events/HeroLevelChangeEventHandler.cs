using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfFate.Events
{
    public delegate void HeroLevelChangeEventHandler(object sender, HeroChangeLevelEventArgs eventArgs);
}
