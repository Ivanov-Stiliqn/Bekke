namespace HeroesOfFate.Models.Items.Potions
{
    public class Potion : Item
    {
        protected Potion(string id, double weaponAttack, double armorDefence, double healthEffect, decimal price) 
            : base(id, weaponAttack, armorDefence, price)
        {
            this.HealthEffect = healthEffect;
            this.Type = ItemType.Potion;
        }

        public double HealthEffect { get; set; }
    }
}