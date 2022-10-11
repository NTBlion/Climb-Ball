using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMove : MonoBehaviour
{
    [SerializeField] private Joystick _joystick;
    [SerializeField] private float _moveSpeed;

    private CharacterController _characterController;
    private Vector3 _moveDirection;

    private void Awake()
    {
        _characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Move();
    }

    private void Move()
    {
        _moveDirection = Vector3.zero;
        _moveDirection.x = _joystick.Horizontal * _moveSpeed;
        _moveDirection.z = _joystick.Vertical * _moveSpeed;

        _characterController.Move(_moveDirection * Time.deltaTime);

        if (Vector3.Angle(Vector3.forward, _moveDirection) > 1f || Vector3.Angle(Vector3.forward, _moveDirection) == 0f)
        {
            Vector3 direction = Vector3.RotateTowards(transform.forward, _moveDirection, _moveSpeed, 0.0f);
            transform.rotation = Quaternion.LookRotation(direction);
        }
    }
}
