
using Enemy.StateMachine;

namespace Enemy.Transitions
{
    public class NullPlayerTransition : EnemyTransition
    {
        private void Update()
        {
            if (Player == null)
                NeedTransit = true;
        }
    }
}
