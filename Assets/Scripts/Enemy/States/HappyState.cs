
using Enemy.StateMachine;

namespace Enemy.States
{
    public class HappyState : EnemyState
    {
        private void OnEnable()
        {
            Enemy.Weapon.gameObject.SetActive(false);
            Enemy.Animator.SetTrigger("dance");
        }
    }
}
