using HeroesOfFate.Contracts;

namespace HeroesOfFate.Models.Items.Chests
{
    public class GoldChest : Chest, IGoldChest
    {
        private double gold;
        private double exp;

        public GoldChest(string id, double gold, double exp) : base(id)
        {
            this.Gold = gold;
            this.Exp = exp;
        }

        public double Gold
        {
            get { return this.gold; }
            set { this.gold = value; }
        }

        public double Exp
        {
            get { return this.exp; }
            set { this.exp = value; }
        }
    }
}