using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "New Patrol State", menuName = "AI/States/Patrol State")]
    public class PatrolState : State
    {
        [SerializeField] private string _patrolRouteId;
        [SerializeField] private float _pointChangeInterval;

        private float _timeAtNextChange;

        private PatrolRoute _patrolRoute;


        public override void EnterState(AiStateMachine owner)
        {
            base.EnterState(owner);

            foreach(PatrolRoute route in FindObjectsOfType<PatrolRoute>())
            {
                if(route.Id == _patrolRouteId)
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
            if(_patrolRoute && Time.time >= _timeAtNextChange)
            {
                OwnerBrain.Agent.SetDestination(_patrolRoute.GetRandomPoint().position);
                _timeAtNextChange = Time.time + _pointChangeInterval;
            }
        }
    }
}
