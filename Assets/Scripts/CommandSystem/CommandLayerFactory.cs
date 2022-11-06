using System;
using System.Collections.Generic;
using CommandSystem.Config;
using CommandSystem.Logic;
using CommandSystem.Presentation;
using Foundation.ConfigurationSystem;
using Foundation.ServiceLocator;
using UnityEngine;

namespace CommandSystem
{
    public class CommandLayerFactory
    {
        public CommandManagerPresentation CreateCommandManagerPresentation(List<Type> availableCommandsTypes)
        {
            var commandManager = new CommandManager(new Character.Character()); // TODO: Take care of Character

            var config = GetConfig();
            Dictionary<Type, GameObject> commandAssets = ConvertConfigToLogicalData(config.CommandPresentationConfig);
        
            return new CommandManagerPresentation(commandManager, commandAssets, availableCommandsTypes);
        }
    
        CommandManagerPresentationConfig GetConfig()
        {
            return ServiceLocator.Find<ConfigurationManager>().GetConfig<CommandManagerPresentationConfig>();
        }

        Dictionary<Type, GameObject> ConvertConfigToLogicalData(List<CommandManagerPresentationConfig.CommandAssetConfig> commandPresentationConfig)
        {
            var result = new Dictionary<Type, GameObject>();

            foreach (var config in commandPresentationConfig)
                result.Add(config.CommandType, config.Prefab);

            return result;
        }
    }
}