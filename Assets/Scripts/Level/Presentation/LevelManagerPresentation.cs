using UnityEngine;

namespace Level.Presentation
{
    public class CurrentLevelManagerPresentation
    {
        private GameObject map;

        public CurrentLevelManagerPresentation(GameObject map)
        {
            this.map = map;
        }

        private void CreateWorld()
        {
            Object.Instantiate(map);
        }
    }
}
