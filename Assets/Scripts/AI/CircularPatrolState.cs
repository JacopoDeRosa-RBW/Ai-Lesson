using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace AI
{
    [CreateAssetMenu(fileName = "New Patrol State", menuName = "AI/States/Circular Patrol State")]
    public class CircularPatrolState : State
    {
        [SerializeField] private string _patrolRouteId;
        [SerializeField] private float _pointChangeInterval;

        private float _timeAtNextChange = 0;
        private int _currentDestination;

        private PatrolRoute _patrolRoute;

     


        public override void EnterState(AiStateMachine owner)
        {
            base.EnterState(owner);

            _timeAtNextChange = 0;

            foreach (PatrolRoute route in FindObjectsOfType<PatrolRoute>())
            {
                
                if (route.Id == _patrolRouteId)
                {
                    _patrolRoute = route;
                    Debug.Log("Patrol route found");
                    return;
                }
            }

            Debug.Log("No Route Found");
        }

        public override void ExitState()
        {
            base.ExitState();
        }

        public override void UpdateState()
        {
            base.UpdateState();
            if(_patrolRoute) { Debug.Log("Route is fine, Time is: " + _timeAtNextChange.ToString()); }
            if (_patrolRoute && Time.time >= _timeAtNextChange)
            {
                Debug.Log("Going to next point");

                OwnerBrain.Agent.SetDestination(_patrolRoute.GetPoint(_currentDestination).position);

                _timeAtNextChange = Time.time + _pointChangeInterval;
                _currentDestination++;
                if (_currentDestination >= _patrolRoute.RouteLenght) _currentDestination = 0;
            }
        }
    }

}

