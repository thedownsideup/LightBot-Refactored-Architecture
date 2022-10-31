namespace Game.CommandSystem.Logic.Commands
{
    public class JumpCommand : Command
    {
        public JumpCommand(Character character) : base(character)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}