using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UpgradeSystem;

namespace Player
{
    public class PlayerAttack : MonoBehaviour, IUpgradable
    {
        [SerializeField] private float _damage;
        [SerializeField] private float _attackRange;
        [SerializeField] private float _additionalDamage;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private LayerMask _layerMask;

        private float _attackDelay = 1f;
        private float _time;

        #region Attack

        private void FixedUpdate()
        {
            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _attackRange, _layerMask);
            
            _time += Time.deltaTime;
            if (_time > _attackDelay)
            {
                foreach (var hit in hitColliders)
                {
                    _playerAnimator.DoAnimation(PlayerAnimator.AnimationStates.attack);
                    hit.GetComponent<Enemy.Enemy>().ApplyDamage(_damage);
                }
                
                _time = 0;
            }
        }
        
        #endregion

        public void Upgrade()
        {
            _damage += _additionalDamage;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            Gizmos.DrawSphere(transform.position, _attackRange);
        }
    }
}