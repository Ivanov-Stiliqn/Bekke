using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HeroesOfFate.Contracts;
using HeroesOfFate.Contracts.FactoryContracts;
using HeroesOfFate.Factories;

namespace HeroesOfFate.GameEngine
{
    public class Core
    {
        private IWeaponFactory weaponFactory = new WeaponFactory();
        private IArmorFactory armorFactory = new ArmorFactory();
        private IPotionFactory potionFactory = new PotionFactory();
        private Database database = new Database();

        //Starting point of the whole class
        public void ImplementItems()
        {
            using (StreamReader file = new StreamReader("..\\..\\resources\\items.txt"))
            {
                string line;
                while ((line = file.ReadLine()) != null)
                {
                    string[] inputArgs = line.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    ParseInputData(inputArgs);
                }

                foreach (var monster in this.database.Monsters)
                {
                    foreach (var item in this.database.Items)
                    {
                        monster.AddItemToLootTable(item);
                    }
                }
            }
        }

        private void ParseInputData(string[] inputArgs)
        {
            string itemType = inputArgs[0];
            string itemName = inputArgs[1];
            string itemId = inputArgs[2];
            switch (itemType)
            {
                case "potion":
                    decimal price = decimal.Parse(inputArgs[3]);
                    IItem potion = this.potionFactory.CreatePotion(itemName, itemId, price);
                    this.database.AddItem(potion);
                    break;
                case "weapon":
                    double weaponAttack = double.Parse(inputArgs[3]);
                    decimal weaponPrice = decimal.Parse(inputArgs[4]);
                    IItem weapon = this.weaponFactory.CreateWeapon(itemName, itemId, weaponAttack, weaponPrice);
                    this.database.AddItem(weapon);
                    break;
                case "armor":
                    double armorDeffence = double.Parse(inputArgs[3]);
                    decimal armorPrice = decimal.Parse(inputArgs[4]);
                    IItem armor = this.armorFactory.CreateArmor(itemName, itemId, armorDeffence, armorPrice);
                    this.database.AddItem(armor);
                    break;
                default:
                    throw new ArgumentException("Such item does not exist at current time");
            }
        }

        public IItem LootRandomItem()
        {
            Random random=new Random();

            int result = random.Next(-5, this.database.Items.Count());

            if (result <0)
            {
                return null;
            }
            return this.database.GetitemByIndex(result);
        }
    }
}
