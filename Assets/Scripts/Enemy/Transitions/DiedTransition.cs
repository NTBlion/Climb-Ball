
public class DiedTransition : EnemyTransition
{
    private void Update()
    {
        if(Enemy.Health <= 0)
            NeedTransit = true;
    }
}
