using System;
using System.Collections.Generic;
using Game.CommandSystem.Logic;
using UnityEngine;

namespace Game.CommandSystem.Presentation
{
    public class CommandManagerPresentation
    {
        //CommandButtons
    
        private List<Type> availableCommandsTypes;
        private List<Type> selectedCommandsTypes;
        private List<CommandManagerPresentationConfig> commandManagerConfig;
        
        private CommandManager commandManager;

        public CommandManagerPresentation(List<Type> availableCommandsTypes, List<CommandManagerPresentationConfig> 
            commandManagerConfig, CommandManager commandManager)
        {
            this.availableCommandsTypes = availableCommandsTypes;
            this.commandManagerConfig = commandManagerConfig;
            this.commandManager = commandManager;
        }

        Dictionary<Type, GameObject> MapCommandManagerConfigs()
        {
            Dictionary<Type, GameObject> commandManagerConfigMap = new Dictionary<Type, GameObject>();
            
            foreach (var config in commandManagerConfig)
            {
                //Add to dictionary
            }
            
            return commandManagerConfigMap;
        }
        
        //If play button clicked commandManager.Execute
    }
}
