using UnityEngine;
using UnityEngine.Events;

public class MouseComponent : MonoBehaviour
{
    public UnityEvent onMouseDownEvent;
    public UnityEvent onMouseUpEvent;
    public UnityEvent onMouseOverEvent;
    public UnityEvent onMouseExitEvent;
    public UnityEvent onMouseEnterEvent;
    
    private void OnMouseDown()
    {
        onMouseDownEvent?.Invoke();
    }

    private void OnMouseUp()
    {
        onMouseUpEvent?.Invoke();
    }

    private void OnMouseOver()
    {
        onMouseOverEvent?.Invoke();
    }

    private void OnMouseExit()
    {
        onMouseExitEvent?.Invoke();
    }

    private void OnMouseEnter()
    {
        onMouseEnterEvent?.Invoke();
    }
}
