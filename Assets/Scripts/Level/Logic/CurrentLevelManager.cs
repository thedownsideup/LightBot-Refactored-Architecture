using System;
using UnityEngine;

namespace Level.Logic
{
    public class CurrentLevelManager
    {
        private int numberOfLightables;
        private int numberOfLit;

        private Action onLevelOver;

        public CurrentLevelManager(int numberOfLightables, Action onLevelOver)
        {
            this.numberOfLightables = numberOfLightables;
            this.onLevelOver = onLevelOver;
        }

        private void LevelComplete()
        {
            onLevelOver.Invoke();
        }

        private void CheckLevelComplete()
        {
            if (numberOfLightables == numberOfLit)
                LevelComplete();
        }
    }
}
