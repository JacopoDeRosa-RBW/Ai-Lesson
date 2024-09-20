using AI;
using System.Collections;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "New Distance Transition", menuName = "AI/Transitions/Distance Check Rule")]
    public class DistanceTransitionRule : TransitionRule
    {
        [SerializeField] private float _maxDistance;

        public override bool Valid(State state)
        {
            ChaseState chaseState = state as ChaseState;

            if (chaseState != null) return Vector3.Distance(state.OwnerBrain.transform.position, chaseState.Target.position) > _maxDistance;

            return false;
        }
    }
}