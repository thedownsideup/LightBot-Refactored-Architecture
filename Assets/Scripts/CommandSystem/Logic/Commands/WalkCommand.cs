namespace CommandSystem.Logic.Commands
{
    public class WalkCommand : Command
    {
        public WalkCommand(Character.Character character) : base(character)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
