using System;
using System.Collections.Generic;
using Foundation.ConfigurationSystem;
using Foundation.ServiceLocator;
using Level.Config;
using Level.Logic;
using UnityEngine;

namespace Level
{
    public class LevelLayerFactory
    {
        public LevelsController CreateLevelsController()
        {
            LevelLayerConfig config = GetConfig();
            List<LevelLayerData> data = ConvertConfigToData(config);
            return new LevelsController(data);
        }
    
        private LevelLayerConfig GetConfig()
        {
            return ServiceLocator.Find<ConfigurationManager>().GetConfig<LevelLayerConfig>();
        }

        private List<LevelLayerData> ConvertConfigToData(LevelLayerConfig config)
        {
            List<LevelLayerData> result = new List<LevelLayerData>();
            
            foreach (var levelConfig in config.LevelConfigs)
            {
                LevelLayerData data = new LevelLayerData(levelConfig);
                result.Add(data);
            }
            
            return result;
        }
    }
}
