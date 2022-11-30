using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float _damage;
    [SerializeField] private float _attackRange;
    [SerializeField] private float _attackDelay;
    [SerializeField] private EnemyDetection _enemyDetection;

    private float _time = 0;

    private void OnEnable()
    {
        _enemyDetection.EnemyDetected += OnEnemyDetect;
    }

    private void OnDisable()
    {
        _enemyDetection.EnemyDetected -= OnEnemyDetect;
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    private void OnEnemyDetect(Enemy enemy)
    {
        Debug.Log("ссс");
        enemy.ApplyDamage(_damage);
    }
}
