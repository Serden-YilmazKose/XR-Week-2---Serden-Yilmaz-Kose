using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
// The following code was taken from the Document

public class CustomGrab : MonoBehaviour
{
    // This script should be attached to both controller objects in the scene
    // Make sure to define the input in the editor (LeftHand/Grip and RightHand/Grip recommended respectively)
    CustomGrab otherHand = null;
    public List<Transform> nearObjects = new List<Transform>();
    public Transform grabbedObject = null;
    public InputActionReference action;
    bool grabbing = false;

    private void Start()
    {
        action.action.Enable();

        // Find the other hand
        foreach (CustomGrab c in transform.parent.GetComponentsInChildren<CustomGrab>())
        {
            if (c != this)
                otherHand = c;
        }
    }

    // the following variables are for rotation and position
    // they will be changes throughout the game
    private Quaternion oldRotation;
    private Vector3 oldPosition;

    // Since grabbing, moving, and rotating is a constant action
    // we will need to run our code in the Update() part, which runs every frame
    void Update()
    {
        grabbing = action.action.IsPressed();

        if (grabbing)
        {
            // Grab nearby object or the object in the other hand
            if (!grabbedObject)
                grabbedObject = nearObjects.Count > 0 ? nearObjects[0] : otherHand.grabbedObject;

            if (grabbedObject)
            {
                // Change these to add the delta position and rotation instead
                // Save the position and rotation at the end of Update function, so you can compare previous

                // We need to find the rotation and position
                Vector3 currentPosition = transform.position - oldPosition;
                Quaternion currentRotation = transform.rotation * Quaternion.Inverse(oldRotation);

                // a new rotation and position needs to be made
                grabbedObject.position += currentPosition;
                grabbedObject.rotation = currentRotation * grabbedObject.rotation;

                // Save current position and rotation for the next frame
                oldPosition = transform.position;
                oldRotation = transform.rotation;
            }
        }
        // If let go of button, release object
        else if (grabbedObject)
            grabbedObject = null;

        // change the rotation and position to their new ones
        oldPosition = transform.position;
        oldRotation = transform.rotation;
    }


    private void OnTriggerEnter(Collider other)
    {
        // Make sure to tag grabbable objects with the "grabbable" tag
        // You also need to make sure to have colliders for the grabbable objects and the controllers
        // Make sure to set the controller colliders as triggers or they will get misplaced
        // You also need to add Rigidbody to the controllers for these functions to be triggered
        // Make sure gravity is disabled though, or your controllers will (virtually) fall to the ground

        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Add(t);
    }

    private void OnTriggerExit(Collider other)
    {
        Transform t = other.transform;
        if (t && t.tag.ToLower() == "grabbable")
            nearObjects.Remove(t);
    }
}