namespace HeroesOfFate.Models.Items.Chests
{
    public abstract class Chest
    {
        private string id;

        protected Chest(string id)
        {
            this.Id = id;
        }

        public string Id
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }
}