using Enemy.StateMachine;
using UnityEngine;

namespace Enemy.Transitions
{
    public class LostPlayerTransition : EnemyTransition
    {
        [SerializeField] private float _minLostDistance;

        private void Update()
        {
            if(Player != null)
            {
                if (Vector3.Distance(Player.transform.position, Enemy.transform.position) > _minLostDistance)
                    NeedTransit = true;
            }
        }
    }
}
