using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Config
{
    public class LevelLayerData
    {
        public int NumberOfLightables { get; }
        public List<Type> AvailableCommands { get; }
        public GameObject Map { get; }

        public LevelLayerData(LevelLayerConfig.LevelConfig levelConfig)
        {
            NumberOfLightables = levelConfig.NumberOfLightables;
            AvailableCommands = levelConfig.AvailableCommands;
            Map = levelConfig.Map;
        }
    }

}