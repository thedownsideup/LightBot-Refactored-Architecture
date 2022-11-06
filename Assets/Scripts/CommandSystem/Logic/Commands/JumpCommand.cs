namespace CommandSystem.Logic.Commands
{
    public class JumpCommand : Command
    {
        public JumpCommand(Character.Character character) : base(character)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}