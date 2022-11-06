using System;
using System.Collections.Generic;
using CommandSystem.Logic;
using PandasCanPlay.HexaWord.Utility;
using UnityEngine;

namespace CommandSystem.Config
{
    [CreateAssetMenu(fileName="New Command Manager Presentation Config", menuName ="Command Manager Presentation Config")]
    public class CommandManagerPresentationConfig : ScriptableObject
    {
        [Serializable]
        public class CommandAssetConfig
        {
            [Type(typeof(Command), includeAbstracts: false)]
            [SerializeField] private string commandType;
            [SerializeField] private GameObject prefab;

            public Type CommandType => Type.GetType(commandType);
            public GameObject Prefab => prefab;
        }
        
        [SerializeField] private List<CommandAssetConfig> commandPresentationConfig;

        public List<CommandAssetConfig> CommandPresentationConfig => commandPresentationConfig;
    }
}
