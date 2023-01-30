using Enemy.StateMachine;
using UnityEngine;

namespace Enemy.States
{
    public class PatrolState : EnemyState
    {
        private int _minDistanceOffset = -3;
        private int _maxDistanceOffset = 3;

        private void OnEnable()
        {
            Enemy.Animator.SetTrigger("run");
            Enemy.Agent.SetDestination(transform.position + new Vector3(Random.Range(_minDistanceOffset, _maxDistanceOffset), 0, Random.Range(_minDistanceOffset, _maxDistanceOffset)));
        }
    }
}
