using System;
using System.Collections.Generic;
using UnityEngine;

namespace Level.Config
{
    [CreateAssetMenu(fileName="New Level Config", menuName ="Level Config")]
    public class LevelLayerConfig : ScriptableObject
    {
        [Serializable]
        public class LevelConfig
        {
            [SerializeField] private  int numberOfLightables;
            [SerializeField] private List<Type> availableCommands;
            [SerializeField] private GameObject map;

            public int NumberOfLightables => numberOfLightables;

            public List<Type> AvailableCommands => availableCommands;

            public GameObject Map => map;
        }
        
        [SerializeField] private List<LevelConfig> levelConfigs;

        public List<LevelConfig> LevelConfigs => levelConfigs;
    }
}