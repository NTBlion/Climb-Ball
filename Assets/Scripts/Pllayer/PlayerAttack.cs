using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class PlayerAttack : MonoBehaviour, IUpgradable
{
    [SerializeField] private float _damage;
    [SerializeField] private float _additionalDamage;
    [SerializeField] private LayerMask _enemyMask;
    [SerializeField] private PlayerAnimator _playerAnimator;

    private float _attackDelay = 1f;
    private float _time = 0;

    private bool _isCorutineActive = false;

    private void FixedUpdate()
    {
        Vector3 yOffset = new Vector3(0, 1, 0);

        RaycastHit hit;
        if (Physics.Raycast(transform.position + yOffset, transform.forward, out hit, 2f, _enemyMask))
        {
            if (_time > _attackDelay)
            {
                Debug.Log("Я запустился");
                StartCoroutine(Attack(hit));
            }
        }
    }

    private void Update()
    {
        _time += Time.deltaTime;
    }

    public void Upgrade()
    {
        _damage += _additionalDamage;
    }

    private IEnumerator Attack(RaycastHit hit)
    {
        if (hit.transform.TryGetComponent(out Enemy enemy))
        {
            if(_time > _attackDelay)
            {
                _playerAnimator.DoAnimation(PlayerAnimator.AnimationStates.attack);
                enemy.ApplyDamage(_damage);
                yield return new WaitForSeconds(_attackDelay);
                _time = 0;
            }
        }
    }
}
