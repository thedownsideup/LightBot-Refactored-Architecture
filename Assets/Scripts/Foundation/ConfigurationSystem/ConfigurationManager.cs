using Foundation.ServiceLocator;
using UnityEngine;

namespace Foundation.ConfigurationSystem
{
    public class ConfigurationManager : IService //TODO improve this so its not dependable on string
    {
        public T GetConfig<T>() where T : Object
        {
            return Resources.Load<T>($"Configs/{nameof(T)}");
        }
    }
}