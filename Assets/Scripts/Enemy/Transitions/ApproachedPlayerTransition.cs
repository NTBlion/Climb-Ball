using UnityEngine;

public class ApproachedPlayerTransition : EnemyTransition
{
    [SerializeField] private float _approachedDistance;

    private void Update()
    {
        if(Player != null)
        {
            if (Vector3.Distance(Player.transform.position, Enemy.transform.position) < _approachedDistance)
                NeedTransit = true;
        }
    }
}
