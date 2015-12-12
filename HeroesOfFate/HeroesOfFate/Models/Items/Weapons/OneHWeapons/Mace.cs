namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class Mace : Weapon
    {
        public Mace(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = true;
            

        }
    }
}