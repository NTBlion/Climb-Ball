using UnityEngine;

public class PlayerTracker : MonoBehaviour
{
    [SerializeField] private Player _player;
    [SerializeField] private Vector3 _offset;
    [SerializeField] private Vector3 _offset2;

    private void LateUpdate()
    {
        if (_player != null)
            transform.position = _player.transform.position + _offset;
    }
}
