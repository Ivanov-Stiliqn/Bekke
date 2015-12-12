namespace HeroesOfFate.Models.Items
{
    public class Weapon : Item
    {
        private const double ArmorDefault = 0;
        private bool isOneH;

        public Weapon(double weaponAttack, string id, decimal price) : base(weaponAttack, ArmorDefault, id, price)
        {
            this.Type = ItemType.MainHand;
        }

        public bool IsOneH
        {
            get { return this.isOneH; }
            set { this.isOneH = value; }
        }
    }
}