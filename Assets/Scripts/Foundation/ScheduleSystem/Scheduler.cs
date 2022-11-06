using System.Collections;
using Foundation.ServiceLocator;
using UnityEngine;

namespace Foundation.ScheduleSystem
{
    public class Scheduler : IService
    {
        private EntityScheduler entity;

        public Scheduler()
        {
            var obj = new GameObject();
            entity = obj.AddComponent<EntityScheduler>();
        }

        public IEnumerator StartCoroutine(IEnumerator enumerator)
        {
            yield return entity.StartCoroutine(enumerator);
        }
    }
}
