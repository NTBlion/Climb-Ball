using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private JoyStick _joystick;
    [SerializeField] private float _moveSpeed;
    [SerializeField] private PlayerAttack _playerAttack;
    [SerializeField] private PlayerAnimator _playerAnimator;

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
        Rotate();
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
}
