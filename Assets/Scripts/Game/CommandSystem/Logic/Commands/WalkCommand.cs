namespace Game.CommandSystem.Logic.Commands
{
    public class WalkCommand : Command
    {
        public WalkCommand(Character character) : base(character)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
