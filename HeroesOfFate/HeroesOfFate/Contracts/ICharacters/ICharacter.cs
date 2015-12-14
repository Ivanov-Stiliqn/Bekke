namespace HeroesOfFate.Contracts.ICharacters
{
    public interface ICharacter
    {
        double Damage { get; set; }

        double Health { get; set; }

        double Armor { get; set; }

        int Level { get; set; }

        bool IsDead { get; }
    }
}
