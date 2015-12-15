namespace HeroesOfFate.Models.Items.Weapons
{
    public class Weapon : Item
    {
        private const double ArmorDefault = 0;
        private bool isOneH;

        public Weapon(string id, double weaponAttack, decimal price) 
            : base(id, weaponAttack, ArmorDefault, price)
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