using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private JoyStick _joystick;
    [SerializeField] private float _playerMoveSpeed;

    private Vector3 _moveDirection;
    private Vector3 _lookDirection;

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
        _characterController.Move(_moveDirection * _playerMoveSpeed * Time.deltaTime);
    }

    private void Rotate()
    {
        if (Vector3.Angle(Vector3.forward, _moveDirection) > 1f)
        {
            _lookDirection = Vector3.RotateTowards(transform.forward, _moveDirection, _playerMoveSpeed, 0f);
            transform.rotation = Quaternion.LookRotation(_lookDirection);
        }
    }

    private void GetTarget(Collider target)
    {
        _lookDirection = transform.position - target.transform.position;
        transform.rotation = Quaternion.LookRotation(_lookDirection);
    }
}
