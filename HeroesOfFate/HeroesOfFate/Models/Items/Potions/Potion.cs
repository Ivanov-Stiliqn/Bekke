namespace HeroesOfFate.Models.Items
{
    public class Potion : Item
    {
        public Potion(string id, double potionEffect) : base(id)
        {
            PotionEffect = potionEffect;
        }

        public double PotionEffect;
    }
}