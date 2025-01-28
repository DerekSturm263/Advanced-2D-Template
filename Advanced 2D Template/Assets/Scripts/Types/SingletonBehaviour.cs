using UnityEngine;

namespace Types
{
    public abstract class SingletonBehaviourBase : MonoBehaviour
    {
        public abstract void Initialize();
        public abstract void Shutdown();
    }

    public abstract class SingletonBehaviour<T> : SingletonBehaviourBase where T : MonoBehaviour
    {
        private static T s_instance;
        public static T Instance => s_instance;

        public override void Initialize()
        {
            s_instance = this as T;

            Application.quitting += Shutdown;
        }

        public override void Shutdown()
        {
            Application.quitting -= Shutdown;

            s_instance = null;
        }
    }
}
