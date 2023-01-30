
using Enemy.StateMachine;

namespace Enemy.States
{
    public class ChaseState : EnemyState
    {
        private void OnEnable()
        {
            Enemy.Animator.SetTrigger("run");
        }

        private void Update()
        {
            if (Player != null)
                Enemy.Agent.SetDestination(Player.transform.position);
        }
    }
}
