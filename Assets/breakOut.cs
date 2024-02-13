using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class breakOut : MonoBehaviour
{
    public Transform roomPosition;
    public Transform breakOutPosition;

    [SerializeField]
    private InputActionReference action;

    private bool inside = true;

    void Start()
    {
            action.action.Enable();
            action.action.performed += (ctx) =>
            {
                TogglePosition();
            };
    }

    void TogglePosition()
    {
        inside = !inside;

        if (inside)
        {
            transform.position = roomPosition.position;
        }
        else
        {
            transform.position = breakOutPosition.position;
        }
    }
}
