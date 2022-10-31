using System;
using System.Collections.Generic;
using Game.CommandSystem.Logic;
using UnityEngine;
using PandasCanPlay.HexaWord.Utility;

namespace Game.CommandSystem.Presentation
{
    [CreateAssetMenu(fileName="New Command Manager Presentation Config", menuName ="Command Manager Presentation Config")]
    public class CommandManagerPresentationConfig : ScriptableObject
    {
        [Serializable]
        class CommandPresentationConfig
        {
            [SerializeField] private GameObject prefab;
            [TypeAttribute(typeof(Command), includeAbstracts: false)]
            [SerializeField] private string commandType;
        }
        
        [SerializeField] private List<CommandPresentationConfig> commandPresentationConfig;
    }
}
