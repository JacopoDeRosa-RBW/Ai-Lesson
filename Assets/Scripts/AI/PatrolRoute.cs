using System.Collections;
using UnityEngine;

namespace AI
{
    public class PatrolRoute : MonoBehaviour
    {
        [SerializeField] private Transform[] _patrolPoints;
        [SerializeField] private string _id;

        public string Id => _id;

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;

            foreach (Transform t in _patrolPoints)
            {
                Gizmos.DrawSphere(t.position, 0.25f);
            }
        }

        public Transform GetRandomPoint()
        {
            return _patrolPoints[Random.Range(0, _patrolPoints.Length)];
        }

        public Transform GetPoint(int index)
        {
            return _patrolPoints[index];
        }
    }
}