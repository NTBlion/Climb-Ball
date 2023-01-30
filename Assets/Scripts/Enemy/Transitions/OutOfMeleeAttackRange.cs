using Enemy.StateMachine;
using UnityEngine;

namespace Enemy.Transitions
{
    public class OutOfMeleeAttackRange : EnemyTransition
    {
        [SerializeField] private float _minOutOfMeleeAttackRange;

        private void Update()
        {
            if(Player != null)
            {
                if (Vector3.Distance(Player.transform.position, Enemy.transform.position) > _minOutOfMeleeAttackRange)
                    NeedTransit = true;
            }
        }
    }
}
