
using Enemy.StateMachine;

namespace Enemy.States
{
    public class IdleState : EnemyState
    {
        private void OnEnable()
        {
            Enemy.Animator.SetTrigger("idle");
        }
    }
}
