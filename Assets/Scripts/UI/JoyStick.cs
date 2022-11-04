using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class JoyStick : MonoBehaviour, IDragHandler, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField] private Image _stick;
    [SerializeField] private Image _joystickBackground;

    private Vector2 _inputDirection;


    private void Awake()
    {

    }

    public void OnPointerDown(PointerEventData eventData)
    {
        OnDrag(eventData);
    }

    public void OnDrag(PointerEventData eventData)
    {
        Vector2 joystickPosition;

        if (RectTransformUtility.ScreenPointToLocalPointInRectangle(_joystickBackground.rectTransform, eventData.position, null, out joystickPosition))
        {
            joystickPosition.x = joystickPosition.x * 2 / _joystickBackground.rectTransform.sizeDelta.x;
            joystickPosition.y = joystickPosition.y * 2 / _joystickBackground.rectTransform.sizeDelta.y;

            _inputDirection = new Vector2(joystickPosition.x, joystickPosition.y);

            _inputDirection = (_inputDirection.magnitude > 1) ? _inputDirection.normalized : _inputDirection;

            _stick.rectTransform.anchoredPosition = new Vector2(_inputDirection.x * (_joystickBackground.rectTransform.sizeDelta.x / 2), _inputDirection.y * (_joystickBackground.rectTransform.sizeDelta.y / 2));
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _inputDirection = Vector2.zero;
        _stick.rectTransform.anchoredPosition = Vector2.zero;
    }
}
