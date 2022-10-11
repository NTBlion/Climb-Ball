using UnityEngine;

public class FoundPlayerTransition : EnemyTransition
{
    [SerializeField] private float _foundDistance;

    private void Update()
    {
        if (Vector3.Distance(Player.transform.position, Enemy.transform.position) < _foundDistance)
            NeedTransit = true;
    }
}
