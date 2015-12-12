namespace HeroesOfFate.Models.Items.Weapons.OneHWeapons
{
    public class HandCrossbow : Weapon
    {
        public HandCrossbow(double weaponAttack, string id, decimal price) : base(weaponAttack, id, price)
        {
            this.IsOneH = true;
            
        }
    }
}