using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class lightSwitch : MonoBehaviour
{
    public Light light;

    [SerializeField]
    private InputActionReference action;

    void Start()
    {
        light = GetComponent<Light>();

        if (action != null)
        {
            action.action.Enable();
            action.action.started += OnActionStarted;
            action.action.canceled += OnActionCanceled;
        }
    }

    private void OnActionStarted(InputAction.CallbackContext ctx)
    {
        light.color = Color.blue;
    }
    
    private void OnActionCanceled(InputAction.CallbackContext ctx)
    {
        light.color = Color.red; 
    }
}
