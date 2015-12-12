namespace HeroesOfFate.Models.Items
{
    public class Potion : Item
    {
        protected Potion(ItemType type, string id, double weaponAttack, double armorDefence, double healthEffect, decimal price) 
            : base(type, weaponAttack, armorDefence,id, price)
        {
            HealthEffect = healthEffect;
        }

        public double HealthEffect { get; set; }
    }
}