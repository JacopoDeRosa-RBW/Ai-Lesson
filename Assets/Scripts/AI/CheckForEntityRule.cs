using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace AI
{
    [CreateAssetMenu(fileName = "New Patrol State", menuName = "AI/Transitions/Enitity Check Rule")]
    public class CheckForEntityRule : TransitionRule
    {
        [SerializeField] private float _radius;
        [SerializeField] private string _tag = "Player";
        [SerializeField] private LayerMask _checkMask;

        public override bool Valid(State state)
        {
            Collider[] colliders = Physics.OverlapSphere(state.OwnerBrain.transform.position, _radius, _checkMask);

            foreach (Collider collider in colliders)
            {
                if (collider.gameObject.CompareTag(_tag))
                {
                    Debug.Log("Target Found");
                    return true;
                }
            }

            return false;
        }

    }
}
