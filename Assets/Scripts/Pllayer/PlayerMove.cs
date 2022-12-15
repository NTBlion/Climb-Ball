using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] private JoyStick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PlayerAnimator _playerAnimator;
    [SerializeField] private PlayerAttack _playerAttack;

    public bool _hasTarget = false;

    private Vector3 _lookDirection;
    private Vector3 _moveDirection;

    private void Update()
    {
        Move();
        if (_hasTarget == false)
            Rotate();
        if (_hasTarget == true)
        LookAtTarget();
    }

    private void Move()
    {
        _moveDirection.x = _joystick.MoveHorizontal();
        _moveDirection.z = _joystick.MoveVertical();
        transform.Translate(_moveDirection * _moveSpeed * Time.deltaTime, Space.World);
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
        transform.LookAt(_playerAttack._hitEnemies[0].transform);
    }
}
