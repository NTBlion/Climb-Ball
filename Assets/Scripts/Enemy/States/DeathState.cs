using System.Collections;
using UnityEngine;

public class DeathState : EnemyState
{
    private void OnEnable()
    {
        StartCoroutine(Die());
    }

    private IEnumerator Die()
    {
        Enemy.BoxCollider.enabled = false;
        Enemy.Agent.enabled = false;
        Enemy.Animator.SetTrigger("die");
        Enemy.DropGem();
        yield return new WaitForSeconds(5);
        Destroy(Enemy.gameObject);
    }
}
