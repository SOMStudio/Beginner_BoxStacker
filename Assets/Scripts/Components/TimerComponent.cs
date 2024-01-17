using UnityEngine;
using UnityEngine.Events;

public class TimerComponent : MonoBehaviour
{
    public float startInvoke = 3f;
    public float invokeSecond = 5f;

    [Header("Events")]
    public UnityEvent invokeSecondEvent;

    private void Start()
    {
        Invoke(nameof(TimerTic), startInvoke);
    }

    private void TimerTic()
    {
        invokeSecondEvent?.Invoke();
        
        Invoke(nameof(TimerTic), invokeSecond);
    }
}
