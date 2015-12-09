using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfFate.Contracts
{
    public interface IMovable
    {
        double X { get; set; }
                        
        double Y { get; set; }

        void Move(double x,double y);

    }
}
