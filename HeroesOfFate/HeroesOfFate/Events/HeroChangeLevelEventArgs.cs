namespace HeroesOfFate.Events
{
    public class HeroChangeLevelEventArgs
    {
        public HeroChangeLevelEventArgs(int level)
        {
            this.Level = level;
        }

        public int Level { get; set; }
    }
}
