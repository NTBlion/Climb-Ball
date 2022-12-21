using System.Collections;
using UnityEngine;
using DG.Tweening;

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
        StartCoroutine(Dissolve());
        yield return new WaitForSeconds(5);
        Destroy(Enemy.gameObject);
    }

    private IEnumerator Dissolve()
    {
        for (float i = 0; i < 5; i+=Time.deltaTime)
        {
            Enemy.transform.Translate(new Vector2(0,1f * Time.deltaTime));
            yield return null;
        }
    }
}
