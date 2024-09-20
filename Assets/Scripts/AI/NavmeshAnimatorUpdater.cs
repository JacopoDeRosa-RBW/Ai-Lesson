using System.Collections;
using UnityEngine;
using UnityEngine.AI;

namespace AI
{
    [RequireComponent(typeof(Animator)), RequireComponent(typeof(NavMeshAgent))]
    public class NavmeshAnimatorUpdater : MonoBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private NavMeshAgent _agent;
        [SerializeField] private string _speedVarName;


        private void OnValidate()
        {
            if(_animator == null || _agent == null)
            {
                _animator = GetComponent<Animator>();
                _agent = GetComponent<NavMeshAgent>();
            }
        }

        private void Update()
        {
           _animator.SetFloat(_speedVarName, _agent.velocity.magnitude);
        }

    }
}