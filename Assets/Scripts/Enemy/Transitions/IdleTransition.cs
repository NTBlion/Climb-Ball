
public class IdleTransition : EnemyTransition
{
    private void Update()
    {
        if (Enemy.Agent.remainingDistance <= Enemy.Agent.stoppingDistance)
            NeedTransit = true;
    }
}
