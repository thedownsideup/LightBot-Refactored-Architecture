using System;
using System.Collections.Generic;
using CommandSystem.Logic;
using UnityEngine;

namespace CommandSystem.Presentation
{
    public class CommandManagerPresentation
    {
        //CommandButtons
    
        private CommandManager commandManager;
        private Dictionary<Type, GameObject> commandAssets;
        private List<Type> availableCommandsTypes;
        private List<Type> selectedCommandsTypes;

        public CommandManagerPresentation(CommandManager commandManager, Dictionary<Type, GameObject> commandAssets, List<Type> availableCommandsTypes)
        {
            this.commandManager = commandManager;
            this.commandAssets = commandAssets;
            this.availableCommandsTypes = availableCommandsTypes;
        }

        //If play button clicked commandManager.Execute
    }
}
