using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChaseState : EnemyState
{
    private void OnEnable()
    {
        Enemy.Animator.SetTrigger("run");
    }

    private void Update()
    {
        Enemy.Agent.SetDestination(Player.transform.position);
    }
}
