using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Rigidbody))]
public class Gem : MonoBehaviour
{
    [SerializeField] private float _delayBeforeMove;
    [SerializeField] private float _speed;

    private Rigidbody _rigidbody;
    private Player _player;

    private Vector3 _forceDirection;
    private Vector3 _torqueDirection = new Vector3(1, 1, 0) * 5f;
    private Vector3 _offsetY = new Vector3(0, 1, 0);

    private float _time = 0;

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody>();

        _forceDirection = new Vector3(Random.Range(-1f, 1f), 3, Random.Range(-1f, 1f));
    }

    private void OnEnable()
    {
        _player = FindObjectOfType<Player>();

        _rigidbody.AddForce(_forceDirection, ForceMode.Impulse);
        _rigidbody.AddTorque(_torqueDirection, ForceMode.Impulse);

        StartCoroutine(PushUp());
    }

    private void Update()
    {
        _time += Time.deltaTime;

        if (_time >= _delayBeforeMove)
        {
            if (_player != null)
                MoveToPlayer();
        }

    }

    private void MoveToPlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + _offsetY, _speed * Time.deltaTime);

        if (transform.position == _player.transform.position + _offsetY)
        {
            _time = 0;
            Destroy(gameObject);
        }
    }

    private IEnumerator PushUp()
    {
        yield return new WaitForSeconds(_delayBeforeMove - 0.5f);
        _rigidbody.AddForce(_offsetY * 4, ForceMode.Impulse);
        transform.localEulerAngles = Vector3.zero;
        _rigidbody.AddTorque(_offsetY * _rigidbody.maxAngularVelocity, ForceMode.Impulse);
    }
}
