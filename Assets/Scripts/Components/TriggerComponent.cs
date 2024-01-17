using UnityEngine;
using UnityEngine.Events;

public class TriggerComponent : MonoBehaviour
{
    public UnityEvent<Collider2D> onTriggerEnterEvent;
    public UnityEvent<Collider2D> onTriggerStayEvent;
    public UnityEvent<Collider2D> onTriggerExitEvent;

    public bool checkTag;
    public string TagGameObject;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (checkTag && !other.gameObject.CompareTag(TagGameObject)) return;
        
        onTriggerEnterEvent?.Invoke(other);
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if (checkTag && !other.gameObject.CompareTag(TagGameObject)) return;
        
        onTriggerStayEvent?.Invoke(other);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (checkTag && !other.gameObject.CompareTag(TagGameObject)) return;
        
        onTriggerExitEvent?.Invoke(other);
    }
}
