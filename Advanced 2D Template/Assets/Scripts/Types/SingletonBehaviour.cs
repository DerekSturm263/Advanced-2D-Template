using UnityEngine;

namespace Types
{
    public abstract class SingletonBehaviourBase : MonoBehaviour
    {
        public virtual void Initialize() { }
        public virtual void Shutdown() { }
    }

    public abstract class SingletonBehaviour<T> : SingletonBehaviourBase where T : MonoBehaviour
    {
        private static T s_instance;
        public static T Instance => s_instance;

        private void Awake()
        {
            s_instance = this as T;
            Initialize();

            Debug.Log($"{name}: Initialized");
        }

        private void OnDestroy()
        {
            Shutdown();
            s_instance = null;
         
            Debug.Log($"{name}: Shutdown");
        }
    }
}
