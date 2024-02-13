using UnityEngine;

public class magCamera : MonoBehaviour
{
    // create a Transform variable , which will be assigned to the main Camera
    // of the XR rig in unity
    public Transform mainCamera;

    // since the magnifying glass and camera are always moving, we will use
    // Update() since it will run the following code every frame
    void Update()
    {
        // create a vectore for the difference of the two positions
        // essentially between the two cameras
        Vector3 differencePosition = mainCamera.position - transform.position;

        // now make a vector for the the contrasting direction 
        Vector3 otherPosition = -differencePosition;

        transform.rotation = Quaternion.LookRotation(otherPosition.normalized);
        //transform.LookAt(mainCameraTransform);

    }
}
