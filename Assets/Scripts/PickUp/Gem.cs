using System.Collections;
using UnityEngine;
using UnityEngine.Events;

namespace PickUp
{
    [RequireComponent(typeof(Rigidbody))]
    public class Gem : MonoBehaviour
    {
        [SerializeField] private float _delayBeforeMoveToPlayer;
        [SerializeField] private float _speed;
        [SerializeField] private LayerMask _playerMask;

        private Rigidbody _rigidbody;
        private Player.Player _player;

        private Vector3 _forceDirection;
        private Vector3 _torqueDirection = new Vector3(1, 1, 0) * 5f;
        private Vector3 _offsetY = new Vector3(0, 1, 0);

        private float _delayBeforePushUp;
        private float _radius = 15f;
        private float _minForceDirectionOffset = -5f;
        private float _maxForceDirectionOffset = 5f;
        private float _time = 0;
        private float _groundHeight = 0.369f;

        private bool _forceActive = true;

        public event UnityAction GemCollected;

        private void OnValidate()
        {
            if (_delayBeforeMoveToPlayer <= 0.5f)
                _delayBeforeMoveToPlayer = 0.5f;

            if (_speed <= 0)
                _speed = 1;
        }

        private void Awake()
        {
            _rigidbody = GetComponent<Rigidbody>();

            Collider[] hitColliders = Physics.OverlapSphere(transform.position, _radius, _playerMask);

            foreach (var collider in hitColliders)
            {
                _player = collider.GetComponent<Player.Player>();
            }

            _delayBeforePushUp = _delayBeforeMoveToPlayer - 0.5f;
            _forceDirection = GetForceDirection();
        }

        private void OnEnable()
        {
            _player.PlayerDied += OnPlayerDied;
            _rigidbody.AddForce(_forceDirection, ForceMode.Impulse);
            _rigidbody.AddTorque(_torqueDirection, ForceMode.Impulse);

            StartCoroutine(PushUp());
        }

        private void Update()
        {
            _time += Time.deltaTime;

            if (_time >= _delayBeforeMoveToPlayer && _player != null)
            {
                MoveToPlayer();
            }

            if (transform.position.y < _groundHeight)
            {
                _forceActive = false;
            }

            if (_forceActive == false)
            {
                transform.position = new Vector3(transform.position.x, _groundHeight, transform.position.z);
            }
        }

        private void OnDestroy()
        {
            GemCollected?.Invoke();
            _player.PlayerDied -= OnPlayerDied;
        }

        private void MoveToPlayer()
        {
            transform.position = Vector3.MoveTowards(transform.position, _player.transform.position + _offsetY, _speed * Time.deltaTime);

            if (transform.position == _player.transform.position + _offsetY)
            {
                _time = 0;
                Destroy(gameObject);
            }
            if (transform.position.y < GetLowerHeightInFlight())
            {
                transform.position = new Vector3(transform.position.x, GetLowerHeightInFlight(), transform.position.z);
            }
        }

        private IEnumerator PushUp()
        {
            Vector3 offsetY = new Vector3(0, 120, 0);

            yield return new WaitForSeconds(_delayBeforePushUp);
            _forceActive = true;
            _rigidbody.AddForce(offsetY, ForceMode.Impulse);
            transform.localEulerAngles = Vector3.zero;
            _rigidbody.AddTorque(_offsetY * _rigidbody.maxAngularVelocity, ForceMode.Impulse);
        }

        private void OnPlayerDied()
        {
            StopCoroutine(PushUp());
            Destroy(gameObject);
        }

        private Vector3 GetForceDirection()
        {
            return new Vector3(Random.Range(_minForceDirectionOffset, _maxForceDirectionOffset), 30, Random.Range(_minForceDirectionOffset, _maxForceDirectionOffset));
        }

        private float GetLowerHeightInFlight()
        {
            Vector3 temp = _player.transform.position + _offsetY;
            return temp.y;
        }
    }
}
