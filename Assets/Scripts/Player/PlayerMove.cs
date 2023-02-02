using UI.HUD;
using UnityEngine;
using UpgradeSystem;

namespace Player
{
    [RequireComponent(typeof(CharacterController))]
    public class PlayerMove : MonoBehaviour, IUpgradable
    {
        [SerializeField] private Joystick _joystick;
        [SerializeField] private PlayerAnimator _playerAnimator;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _gravity;
        [SerializeField] private float _rotationSpeed;
        [SerializeField] private float _additionalMoveSpeed;

        private CharacterController _characterController;
        private Vector3 _lookDirection;
        private Vector3 _moveDirection;
        private Quaternion _targetRotation;

        private void Awake()
        {
            _characterController = GetComponent<CharacterController>();
        }

        private void Update()
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, _targetRotation, _rotationSpeed * Time.deltaTime);
            _characterController.Move(new Vector3(0, _gravity * -Time.deltaTime, 0));

            Move();
            Rotate();

        }
        public void Upgrade()
        {
            _moveSpeed += _additionalMoveSpeed;
        }

        private void Move()
        {
            _moveDirection.x = _joystick.MoveHorizontal();
            _moveDirection.z = _joystick.MoveVertical();
            
            _characterController.Move(_moveDirection * (_moveSpeed * Time.deltaTime));
            
            var tempMoveDirectionX = Mathf.Abs(_moveDirection.x);
            var tempMoveDirectionZ = Mathf.Abs(_moveDirection.z);
            
            _playerAnimator.DoAnimation(PlayerAnimator.AnimationStates.movement, tempMoveDirectionX + tempMoveDirectionZ);
        }

        private void Rotate()
        {
            if (Vector3.Angle(Vector3.forward, _moveDirection) > 1f)
            {
                _lookDirection = Vector3.RotateTowards(transform.forward, _moveDirection, _moveSpeed, 2f);
                _targetRotation = Quaternion.LookRotation(_lookDirection);
            }
        }
    }
}
