using UnityEngine;
using UnityEngine.Events;

public class GunManager : MonoBehaviour
{
    [Header("Main")]
    [SerializeField] private int speedMin = 500;
    [SerializeField] private int speedMax = 700;
    [SerializeField] private ForceMode2D forceMode = ForceMode2D.Force;
    [SerializeField] private GameObject[] objectList;

    [Header("Events")]
    public UnityEvent shootEvent;
    
    private TimerComponent timerComponent;
    
    private void Start()
    {
        InitReferences();
        InitListeners();
    }

    private void InitReferences()
    {
        timerComponent = GetComponent<TimerComponent>();
    }
    
    private void  InitListeners()
    {
        timerComponent.invokeSecondEvent.AddListener(Shoot);
    }

    private void Shoot()
    {
        var numberObjectShoot = Random.Range(0, objectList.Length);
        var objectShoot = objectList[numberObjectShoot];

        var speed = Random.Range(speedMin, speedMax);
        
        var instObject = Instantiate(objectShoot, transform.position, Quaternion.identity);
        var rigidBody = instObject.GetComponent<Rigidbody2D>();
        rigidBody.AddForce(transform.up * speed, forceMode);
        
        shootEvent?.Invoke();
    }
}
