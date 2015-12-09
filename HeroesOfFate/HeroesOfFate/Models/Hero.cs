using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HeroesOfFate.Models
{
    public abstract class Hero : Creature
    {
        private List<Skill> skillSet; 
        private List<Item> inventory;



        protected Hero(int x,int y,short exp,short level,double damage,double health,double armor)
            :base(x,y,exp,level,damage,health,armor)
        {
            
        }

    }
}
