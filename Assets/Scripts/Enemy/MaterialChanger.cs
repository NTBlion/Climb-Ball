using System.Collections;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class MaterialChanger : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _meshRenderer;
        [SerializeField] private Material _hitMaterial;

        private float _delayBeforeResetMaterial = 0.7f;
        private float _delayBeforeChangeMaterial = 0.3f;

        private Enemy _enemy;
        private Material _startMaterial;


        private void Awake()
        {
            _startMaterial = _meshRenderer.material;
            _enemy = GetComponent<Enemy>();
        }

        private void OnEnable()
        {
            _enemy.TookDamage += OnTakeDamage;
        }

        private void OnDisable()
        {
            _enemy.TookDamage -= OnTakeDamage;
        }


        private void OnTakeDamage()
        {
            StartCoroutine(ChangeMaterial());
        }

        private IEnumerator ChangeMaterial()
        {
            yield return new WaitForSeconds(_delayBeforeChangeMaterial);
            _meshRenderer.material = _hitMaterial;
            yield return new WaitForSeconds(_delayBeforeResetMaterial);
            _meshRenderer.material = _startMaterial;
            StopCoroutine(ChangeMaterial());
        }
    }
}
