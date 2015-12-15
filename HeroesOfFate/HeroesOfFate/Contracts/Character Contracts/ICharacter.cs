namespace HeroesOfFate.Contracts
{
    public interface ICharacter
    {
        double Health { get; set; }

        int Level { get; set; }

        bool IsDead { get; }
    }
}
