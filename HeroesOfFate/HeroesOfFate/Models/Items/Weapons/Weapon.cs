namespace HeroesOfFate.Models.Items
{
    public class Weapon : Item
    {
        public Weapon(string id, double weaponAttack, decimal price) : base(id, price)
        {
            WeaponAttack = weaponAttack;
        }

        public double WeaponAttack { get; set; }
    }
}