using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class PressAndHold : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public bool isPressed;

    private Button button;

    private void Start()
    {
        button = GetComponent<Button>();
    }
    private void Update()
    {
        if (isPressed)
        {
            button.onClick.Invoke();
        }
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        isPressed = true;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        isPressed = false;
    }
}
