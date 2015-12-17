using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using HeroesOfFate.Contracts;
using HeroesOfFate.Contracts.FactoryContracts;
using HeroesOfFate.Factories;
using HeroesOfFate.GameEngine.IO;
using HeroesOfFate.GameEngine;
using HeroesOfFate.Models.Characters.Heroes;

namespace HeroesOfFate.GameEngine
{
    public class Core
    {
        private IWeaponFactory weaponFactory = new WeaponFactory();
        private IArmorFactory armorFactory = new ArmorFactory();
        private IPotionFactory potionFactory = new PotionFactory();
        private Database database = new Database();
        private ConsoleReader reader = new ConsoleReader();
        private ConsoleWriter writer = new ConsoleWriter();
        private Hero hero;

        public void Run()
        {
            while (true)
            {
                this.StartScreen();
            }
        }

        private void StartScreen()
        {
            StringBuilder chooseOption = new StringBuilder();

            string title = "Heroes Of Fate";
            chooseOption.AppendLine(title.PadLeft(45).ToUpper());
            chooseOption.AppendLine(Environment.NewLine);
            chooseOption.AppendLine("Start New Adventure (start)" + Environment.NewLine);
            chooseOption.AppendLine("Commands (help)" + Environment.NewLine);
            chooseOption.AppendLine("Exit");
            this.writer.PrintCommand(chooseOption.ToString());

            string[] inputParams = this.reader.ReadCommand().Split();

            switch (inputParams[0])
            {
                case "start":
                    this.CreateHero();
                    break;
                case "help":
                    this.CommandsInfo();
                    break;
                case "exit":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Unknown command.");
            }
        }

        private void CreateHero()
        {
            Console.Clear();

            StringBuilder chooseOption = new StringBuilder();

            chooseOption.AppendLine("To create your hero write it in the following format:");
            chooseOption.AppendLine("(hero profession) (hero name) (hero race)" + Environment.NewLine);
            chooseOption.AppendLine("Choose your hero's profession:");
            chooseOption.AppendLine("The avalable professions are: Warrior, Archer and Mage" + Environment.NewLine);
            chooseOption.AppendLine("The Warrior has:                 The Archer has:                 The Mage has:");
            chooseOption.AppendLine("Basic attack: 25 - 75            Basic attack: 75 - 100          Basic attack: 100 - 125");
            chooseOption.AppendLine("Health: 250                      Health: 200                     Health: 150");
            chooseOption.AppendLine("Armor: 125                       Armor: 100                      Armor: 75" + Environment.NewLine);

            chooseOption.AppendLine("What is your hero's name and race ?");
            chooseOption.AppendLine("The avalable races are: Human, Elf, Orc, Dwarf or Werewolf");
            this.writer.PrintCommand(chooseOption.ToString());

            string[] inputParams = this.reader.ReadCommand().Split();

            switch (inputParams[0])
            {
                case "warrior":
                    if (inputParams[2] == "human") { hero = new Warrior(inputParams[1], Race.Human);}
                    if (inputParams[2] == "elf") { hero = new Warrior(inputParams[1], Race.Elf); }
                    if (inputParams[2] == "orc") { hero = new Warrior(inputParams[1], Race.Orc); }
                    if (inputParams[2] == "dwarf") { hero = new Warrior(inputParams[1], Race.Dwarf); }
                    if (inputParams[2] == "werewolf") { hero = new Warrior(inputParams[1], Race.Werewolf); }
                    this.ImplementItems();
                    Engine.GameStart();
                    break;

                case "archer":
                    if (inputParams[2] == "human") { hero = new Archer(inputParams[1], Race.Human); }
                    if (inputParams[2] == "elf") { hero = new Archer(inputParams[1], Race.Elf); }
                    if (inputParams[2] == "orc") { hero = new Archer(inputParams[1], Race.Orc); }
                    if (inputParams[2] == "dwarf") { hero = new Archer(inputParams[1], Race.Dwarf); }
                    if (inputParams[2] == "werewolf") { hero = new Archer(inputParams[1], Race.Werewolf); }
                    this.ImplementItems();
                    Engine.GameStart();
                    break;

                case "mage":
                    if (inputParams[2] == "human") { hero = new Mage(inputParams[1], Race.Human); }
                    if (inputParams[2] == "elf") { hero = new Mage(inputParams[1], Race.Elf); }
                    if (inputParams[2] == "orc") { hero = new Mage(inputParams[1], Race.Orc); }
                    if (inputParams[2] == "dwarf") { hero = new Mage(inputParams[1], Race.Dwarf); }
                    if (inputParams[2] == "werewolf") { hero = new Mage(inputParams[1], Race.Werewolf); }
                    this.ImplementItems();
                    Engine.GameStart();
                    break;
            }
        }

        private void CommandsInfo()
        {
            Console.Clear();
            StringBuilder output = new StringBuilder();


            output.AppendLine("Those are the ingame commands:");
            output.AppendLine("-move (number of steps) (direction) - the number must be integer,\n the directions can be: right/left/up/down");
            output.AppendLine("-inventory - view the equipted items and the inventory of the hero");
            output.AppendLine("-exit - quits the current game" + Environment.NewLine);
            output.AppendLine("Use \"back\" to go to the Start Screen again or\n \"quit\" to exit(the monster will find you never the less).");

            this.writer.PrintCommand(output.ToString());

            string input = this.reader.ReadCommand();


            switch (input)
            {
                case "back":
                    Console.Clear();
                    this.StartScreen();
                    break;
                case "quit":
                    Environment.Exit(0);
                    break;
                default:
                    throw new ArgumentException("Unknow command.");
            }
        }

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
