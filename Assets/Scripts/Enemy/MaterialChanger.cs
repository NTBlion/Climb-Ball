using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class MaterialChanger : MonoBehaviour
{
    [SerializeField] private SkinnedMeshRenderer _meshRenderer;
    [SerializeField] private Material _hitMaterial;

    private float _delay = 0.3f;

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
        _meshRenderer.material = _hitMaterial;
        yield return new WaitForSeconds(_delay);
        _meshRenderer.material = _startMaterial;
        StopCoroutine(ChangeMaterial());
    }
}
