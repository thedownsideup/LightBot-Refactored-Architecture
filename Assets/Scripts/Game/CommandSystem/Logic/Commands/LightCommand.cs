namespace Game.CommandSystem.Logic.Commands
{
    public class LightCommand : Command
    {
        public LightCommand(Character character) : base(character)
        {
        }

        public override void Execute()
        {
            throw new System.NotImplementedException();
        }
    }
}
