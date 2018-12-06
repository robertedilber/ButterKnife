using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class ClickableButton : MonoBehaviour, IClickable
{

    public UnityEvent onButtonClick, onPointEvent, onUnpointEvent;

    public void Clicked() => onButtonClick.Invoke();

    public void PointerEnter() => onPointEvent.Invoke();

    public void PointerExit() => onUnpointEvent.Invoke();

}
