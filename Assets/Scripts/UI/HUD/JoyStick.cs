using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _stick;
    [SerializeField] private Image _joystickBackground;

    private Vector2 _inputDirection;

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition = Vector2.zero;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = (joystickPosition.x / _joystickBackground.rectTransform.sizeDelta.x);
            joystickPosition.y = (joystickPosition.y / _joystickBackground.rectTransform.sizeDelta.y);

            _inputDirection = new Vector2(joystickPosition.x * 2, joystickPosition.y * 2 - 1);
            _inputDirection = (_inputDirection.magnitude > 1f) ? _inputDirection.normalized : _inputDirection;

            _stick.rectTransform.anchoredPosition = new Vector2(_inputDirection.x * (_stick.rectTransform.sizeDelta.x / 2), _inputDirection.y * (_stick.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputDirection = Vector2.zero;
        _stick.rectTransform.anchoredPosition = Vector2.zero;
    }

    public float MoveHorizontal()
    {
        if (_inputDirection.x != 0)
            return _inputDirection.x;
        else return 0;
    }

    public float MoveVertical()
    {
        if (_inputDirection.y != 0)
            return _inputDirection.y;
        else return 0;
    }
}
