namespace CommandSystem.Logic
{
    public abstract class Command
    {
        private Character.Character character;

        protected Command(Character.Character character)
        {
            this.character = character;
        }

        public abstract void Execute();
    }
}
