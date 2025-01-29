using System.Collections.Generic;
using UnityEngine;

namespace SingletonBehaviours
{
    public class TrackEventController : Types.SingletonBehaviour<TrackEventController>
    {
        /*private readonly List<System.Action> _nextAction = new();
        private readonly List<System.Action> _everyAction = new();

        [SerializeField] private Types.ReturningUnityEvent<int> _getBPM;

        private int _frame;

        private void FixedUpdate()
        {
            ++_frame;

            int spm = (int)(60 / Time.fixedDeltaTime);

            if (_frame % (spm / _getBPM.Invoke()) == 0)
            {
                foreach (System.Action action in _nextAction)
                {
                    action.Invoke();
                }
                _nextAction.Clear();

                foreach (System.Action action in _everyAction)
                {
                    action.Invoke();
                }
            }
        }

        public void ResetFrame()
        {
            _frame = 0;
        }

        public void ExecuteOnNextBeat(System.Action action)
        {
            _nextAction.Add(action);
        }

        public void ExecuteEventOnNextBeat(MonoBehaviours.InvokeableEvent gameObject) => ExecuteOnNextBeat(() => gameObject.Invoke());

        public void ExecuteOnEveryBeat(System.Action action)
        {
            _everyAction.Add(action);
        }

        public void ExecuteEventOnEveryBeat(MonoBehaviours.InvokeableEvent gameObject) => ExecuteOnEveryBeat(() => gameObject.Invoke());*/
    }
}
