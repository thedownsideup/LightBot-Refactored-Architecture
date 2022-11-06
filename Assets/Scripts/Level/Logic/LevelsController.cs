using System;
using System.Collections.Generic;
using Level.Config;
using Level.Presentation;
using UnityEngine;

namespace Level.Logic
{
    public class LevelsController
    {
        private static int currentLevelIndex = 0;
        private CurrentLevelManager currentLevelManager;
        private CurrentLevelManagerPresentation currentLevelManagerPresentation;
        private List<LevelLayerData> levelsData = new List<LevelLayerData>();

        public LevelsController(List<LevelLayerData> levelsData)
        {
            this.levelsData = levelsData;
        }

        private void CreateCurrentLevel()
        {
            LevelLayerData currentLevelData = levelsData[currentLevelIndex];
            currentLevelManager =
                new CurrentLevelManager(currentLevelData.NumberOfLightables, onLevelOver: GoToNextLevel);
            currentLevelManagerPresentation = new CurrentLevelManagerPresentation(currentLevelData.Map);
            //give available commands to someone
        }

        private void GoToNextLevel()
        {
            currentLevelIndex++;
            CreateCurrentLevel(); //CreateNextLevel?
        }

        public List<Type> GetAvailableCommands()
        {
            return levelsData[currentLevelIndex].AvailableCommands;
        }
    }
}