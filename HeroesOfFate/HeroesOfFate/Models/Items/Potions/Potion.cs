namespace HeroesOfFate.Models.Items
{
    public class Potion : Item
    {
        public Potion(string id, double potionEffect, decimal price) : base(id, price)
        {
            PotionEffect = potionEffect;
        }

        public double PotionEffect;
    }
}