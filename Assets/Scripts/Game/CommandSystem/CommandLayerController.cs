using System;
using System.Collections.Generic;
using Game.CommandSystem.Logic;
using Game.CommandSystem.Presentation;

namespace Game.CommandSystem
{
    public class CommandLayerController
    {
        private List<Type> availableCommandsTypes;
        private List<CommandManagerPresentationConfig> commandManagerConfig;
        private Character character;
        
        public CommandLayerController(List<Type> availableCommandTypes, List<CommandManagerPresentationConfig> commandManagerConfig,
            Character character)
        {
            this.availableCommandsTypes = availableCommandTypes;
            this.commandManagerConfig = commandManagerConfig;
            this.character = character;
        }

        public void InitializeCommandLayer()
        {
            CommandManager commandManager = new CommandManager(availableCommandsTypes, character);
            CommandManagerPresentation commandManagerPresentation = new CommandManagerPresentation(availableCommandsTypes, commandManagerConfig, commandManager);
        }
    }
}
