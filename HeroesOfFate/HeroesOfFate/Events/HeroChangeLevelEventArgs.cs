using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace HeroesOfFate.Events
{
    public class HeroChangeLevelEventArgs
    {
        public HeroChangeLevelEventArgs(int level)
        {
            this.Level = level;
        }

        public int Level { get; set; }
    }
}
