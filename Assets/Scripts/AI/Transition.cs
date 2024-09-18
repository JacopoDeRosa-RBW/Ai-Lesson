using UnityEngine;
using System;

namespace AI
{
    [Serializable]
    public class Transition
    {
        [SerializeField] private State _targetState;
        [SerializeField] private TransitionRule _rule;

        public State TargetState => _targetState;

        public bool CheckTransition(State instigator)
        {
            return _rule.Valid(instigator);
        }
      
    }
}