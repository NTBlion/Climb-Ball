using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolState : EnemyState
{
    private void OnEnable()
    {
        Enemy.Animator.SetTrigger("run");
        Enemy.Agent.SetDestination(transform.position + new Vector3(Random.Range(-3, 3), 0, Random.Range(-3, 3)));
    }
}
