namespace Game.CommandSystem.Logic
{
    public abstract class Command
    {
        private Character character;

        protected Command(Character character)
        {
            this.character = character;
        }

        public abstract void Execute();
    }
}
