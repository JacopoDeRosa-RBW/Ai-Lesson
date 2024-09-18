using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    [CreateAssetMenu(fileName = "New State", menuName = "AI/States/Base State")]
    public class State : ScriptableObject
    {
        [SerializeField] private Transition[] _transitions;

        private AiStateMachine _ownerBrain;

        public AiStateMachine OwnerBrain => _ownerBrain;

        public virtual void EnterState(AiStateMachine owner)
        {
            _ownerBrain = owner;
        } 
        
        public virtual void ExitState()
        {

        }

        public virtual void UpdateState()
        {
            foreach (Transition transition in _transitions)
            {
                if(transition.CheckTransition(this))
                {
                    _ownerBrain.SetCurrentState(transition.TargetState);
                    return;
                }
            }
        }
        

    }
}
