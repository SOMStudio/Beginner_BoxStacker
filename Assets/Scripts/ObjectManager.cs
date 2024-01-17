using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObjectManager : MonoBehaviour
{
    [SerializeField] private int speed = 5;

    private Rigidbody2D rigidbodyObj;

    private Camera mainCamera;
    private MouseComponent mouseComponent;

    private bool holdObject;
    
    private void Start()
    {
        InitReferences();
        InitListeners();
    }

    private void InitReferences()
    {
        mainCamera = Camera.main;
        rigidbodyObj = GetComponent<Rigidbody2D>();
        
        mouseComponent = GetComponent<MouseComponent>();
        if (mouseComponent == null) mouseComponent = gameObject.AddComponent<MouseComponent>();
    }
    
    private void  InitListeners()
    {
        if (mouseComponent.onMouseDownEvent == null) mouseComponent.onMouseDownEvent = new UnityEvent();
        mouseComponent.onMouseDownEvent.AddListener(OnMouseDownEvent);
        
        if (mouseComponent.onMouseUpEvent == null) mouseComponent.onMouseUpEvent = new UnityEvent();
        mouseComponent.onMouseUpEvent.AddListener(OnMouseUpEvent);
    }

    private void OnMouseDownEvent()
    {
        if (!holdObject) holdObject = true;
    }

    private void OnMouseUpEvent()
    {
        if (holdObject) holdObject = false;
    }

    private void Update()
    {
        if (holdObject)
        {
            var worldPointMouse = mainCamera.ScreenToWorldPoint(Input.mousePosition);
            var moveVector = worldPointMouse - transform.position;
            
            if (moveVector.magnitude > 0)
            {
                rigidbodyObj.velocity = moveVector * speed;
            }
        }
    }
}
