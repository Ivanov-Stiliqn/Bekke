namespace HeroesOfFate.Models.Items
{
    public abstract class Weapon : Item
    {
        private const double ArmorDefault = 0;

        protected Weapon(ItemType type, double weaponAttack, string id, decimal price, bool isOneH) : base(type,weaponAttack, ArmorDefault, id, price)
        {
            IsOneH = isOneH;
        }

        public bool IsOneH { get; set; }
    }
}