using UnityEngine;
using UnityEngine.Events;

namespace MonoBehaviours
{
    public class InvokeableEvent : MonoBehaviour
    {
        [SerializeField] private UnityEvent _event;
        public void Invoke() => _event.Invoke();
    }
}
