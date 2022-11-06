using System;
using System.Collections.Generic;

namespace CommandSystem.Logic
{
    public class CommandManager
    {
        private Character.Character character;

        public CommandManager(Character.Character character)
        {
            this.character = character;
        }
        
        //Was this supposed to be here lmao
        public void Execute(List<Type> commandTypes)
        {
            CommandFactory commandFactory = new CommandFactory(character);

            foreach (var commandType in commandTypes)
            {
                commandFactory.CreateCommand(commandType);
            }
        }
    }
}
