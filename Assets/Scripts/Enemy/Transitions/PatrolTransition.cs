using UnityEngine;

public class PatrolTransition : EnemyTransition
{
    [SerializeField] private float _patrolCooldown = 12;
    private float _time = 0;

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time > _patrolCooldown)
        {
            NeedTransit = true;
            _time = 0;
        }
    }
}
