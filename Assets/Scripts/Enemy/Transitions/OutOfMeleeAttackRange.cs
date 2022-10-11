using UnityEngine;

public class OutOfMeleeAttackRange : EnemyTransition
{
    [SerializeField] private float _minOutOfMeleeAttackRange;

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, Enemy.transform.position) > _minOutOfMeleeAttackRange)
            NeedTransit = true;
    }
}
