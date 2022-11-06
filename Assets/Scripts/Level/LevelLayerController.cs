using System;
using System.Collections.Generic;
using Foundation.ConfigurationSystem;
using Foundation.ServiceLocator;
using Level.Config;
using Level.Logic;
using UnityEngine;

namespace Level
{
    public class LevelLayerController
    {
        private List<Type> availableCommands = new List<Type>();
        
        public void InitializeLevelLayer()
        {
            LevelsController levelsController = new LevelLayerFactory().CreateLevelsController();
            availableCommands = levelsController.GetAvailableCommands();
        }
        
        LevelLayerConfig GetConfig()
        {
            return ServiceLocator.Find<ConfigurationManager>().GetConfig<LevelLayerConfig>();
        }

        public List<Type> GetAvailableCommands()
        {
            return availableCommands;
        }
    }
}
