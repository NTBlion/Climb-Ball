public class IdleState : EnemyState
{
    private void OnEnable()
    {
        Enemy.Animator.SetTrigger("idle");
    }
}
