using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
