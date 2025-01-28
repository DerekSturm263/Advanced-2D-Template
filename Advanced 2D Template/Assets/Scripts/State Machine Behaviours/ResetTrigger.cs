using UnityEngine;

namespace StateMachineBehaviours
{
    public class ResetTrigger : StateMachineBehaviour
    {
        [SerializeField] private string _trigger;

        override public void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            animator.ResetTrigger(_trigger);
        }
    }
}
