namespace HeroesOfFate.Models.Items
{
    public class Weapon : Item
    {
        public Weapon(string id, double weaponAttack) : base(id)
        {
            WeaponAttack = weaponAttack;
        }

        public double WeaponAttack;
    }
}