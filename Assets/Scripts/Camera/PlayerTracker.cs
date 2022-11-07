using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Camera _camera;
    [SerializeField] private Vector3 _offset;

    private void LateUpdate()
    {
        if (_player != null)
        _camera.transform.position = _player.transform.position + _offset;
    }
}
