
public class NullPlayerTransition : EnemyTransition
{
    private void Update()
    {
        if (Player == null)
            NeedTransit = true;
    }
}
