using System;
using System.Collections.Generic;

namespace Game.CommandSystem.Logic
{
    public class CommandManager
    {
        private List<Type> availableCommandTypes;
        private Character character;

        public List<Type> AvailableCommandTypes => availableCommandTypes;
        
        public CommandManager(List<Type> availableCommandTypes, Character character)
        {
            this.availableCommandTypes = availableCommandTypes;
            this.character = character;
        }

        public void Execute(List<Type> commandTypes)
        {
            CommandFactory commandFactory = new CommandFactory(character);

            foreach (Type commandType in commandTypes)
            {
                commandFactory.CreateCommand(commandType);    
            }
        }
    }
}
