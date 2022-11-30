using UnityEngine;
using UnityEngine.Events;

public class EnemyDetection : MonoBehaviour
{
    public event UnityAction<Enemy> EnemyDetected;

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out Enemy enemy))
        {
            Debug.Log("�� �� ���");
            EnemyDetected?.Invoke(enemy);
        }
    }
}
