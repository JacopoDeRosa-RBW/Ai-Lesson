using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    public class AiStateMachine : MonoBehaviour
    {
        [SerializeField] private State _defaultState = null;
        [SerializeField] private NavMeshAgent _agent;

        private State _currentState = null;

        public NavMeshAgent Agent => _agent;

        private void Awake()
        {
            SetCurrentState(_defaultState);
        }

        public void SetCurrentState(State state)
        {
           // Exit current state if not null then set and enter the next state

           if(_currentState) _currentState.ExitState();

           _currentState = state;

           if (_currentState) _currentState.EnterState(this);
        }

        private void Update()
        {
            if(_currentState) _currentState.UpdateState();
        }


    }
}
