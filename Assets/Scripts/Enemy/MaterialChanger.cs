using System.Collections;
using UnityEngine;

namespace Enemy
{
    [RequireComponent(typeof(Enemy))]
    public class MaterialChanger : MonoBehaviour
    {
        [SerializeField] private SkinnedMeshRenderer _meshRenderer;
        [SerializeField] private Material _hitMaterial;

        private float _delay = 0.7f;

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
            yield return new WaitForSeconds(0.3f);
            _meshRenderer.material = _hitMaterial;
            yield return new WaitForSeconds(_delay);
            _meshRenderer.material = _startMaterial;
            StopCoroutine(ChangeMaterial());
        }
    }
}
