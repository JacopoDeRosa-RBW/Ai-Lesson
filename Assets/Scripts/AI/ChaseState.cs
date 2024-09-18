using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "New  State", menuName = "AI/States/Chase State")]
    public class ChaseState : State
    {
        private Transform _target;

        [SerializeField] private float _radius;
        [SerializeField] private string _tag = "Player";

        public override void EnterState(AiStateMachine owner)
        {
            base.EnterState(owner);

            Collider[] colliders = Physics.OverlapSphere(OwnerBrain.transform.position, _radius);

            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag(_tag))
                {
                    _target = collider.transform;
                   
                }
            }


        }


        public override void UpdateState()
        {
            base.UpdateState();

            OwnerBrain.Agent.SetDestination(_target.position);
        }

    }
}
