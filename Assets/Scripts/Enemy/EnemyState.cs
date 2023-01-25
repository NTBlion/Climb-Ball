using UnityEngine;

public abstract class EnemyState : MonoBehaviour
{
    [SerializeField] private EnemyTransition[] _transitions;

    protected Enemy Enemy { get; private set; }
    protected Player Player { get; private set; }

    public void Enter(Enemy enemy, Player player)
    {
        if (enabled == false)
        {
            Enemy = enemy;
            Player = player;

            enabled = true;

            foreach (var transition in _transitions)
            {
                transition.enabled = true;
                transition.Init(Player, Enemy);
            }
        }
    }

    public void Exit()
    {
        if (enabled == true)
        {
            foreach (var transition in _transitions)
            {
                transition.enabled = false;
            }

            enabled = false;
        }
    }

    public EnemyState GetNextState()
    {
        foreach (var transition in _transitions)
        {
            if (transition.NeedTransit)
            {
                return transition.TargetState;
            }
        }

        return null;
    }
}
