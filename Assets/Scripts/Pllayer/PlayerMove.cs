using UnityEngine;
using System.Collections.Generic;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private JoyStick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerAttack _playerAttack;

    private bool _hasTarget = false;

    private Vector3 _lookDirection;
    private Vector3 _moveDirection;

    private CharacterController _characterController;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
        if (_hasTarget == false)
            Rotate();
        if(_playerAttack._hitEnemies[0] != null)
            _hasTarget = true;
            LookAtTarget();
    }

    private void Move()
    {
        _moveDirection.x = _joystick.MoveHorizontal();
        _moveDirection.z = _joystick.MoveVertical();
        _characterController.Move(_moveDirection * _moveSpeed * Time.deltaTime);
        _playerAnimator.DoAnimation(PlayerAnimator.AnimationStates.run, true);
    }

    private void Rotate()
    {
        if (Vector3.Angle(Vector3.forward, _moveDirection) > 1f)
        {
            _lookDirection = Vector3.RotateTowards(transform.forward, _moveDirection, _moveSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(_lookDirection);
        }
    }

    private void LookAtTarget()
    {
        _lookDirection = Vector3.RotateTowards(transform.forward, _playerAttack._hitEnemies[0].transform.position - transform.position, _moveSpeed,0f);
        transform.rotation = Quaternion.LookRotation(_lookDirection);
    }
}
