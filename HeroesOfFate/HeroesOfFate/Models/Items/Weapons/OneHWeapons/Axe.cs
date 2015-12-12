namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class Axe : Weapon
    {
        

        public Axe(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = true;
            
        }
    }
}