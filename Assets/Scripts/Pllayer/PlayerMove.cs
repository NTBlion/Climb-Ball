using System.Collections;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour, IUpgradable
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private float _gravity;
    [SerializeField] private float _rotationSpeed;
    [SerializeField] private float _additionalMoveSpeed;

    private bool _hasTarget = false;

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
        if (_hasTarget == false)
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
        _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);
        float tempMoveDirectionX = Mathf.Abs(_moveDirection.x);
        float tempMoveDirectionZ = Mathf.Abs(_moveDirection.z);
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
