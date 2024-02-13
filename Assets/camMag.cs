using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class camMag : MonoBehaviour
{
	// source for the code is here: https://docs.unity3d.com/ScriptReference/Transform.LookAt.html
    // Start is called before the first frame update
	public Transform Lens;
    public Transform Cam;
    void Start()
    {
        
    }

    // Update is called once per frame
	// we will use this since we need a continous update
    void Update()
    {
        
        Vector3 mainCam = Lens.InverseTransformPoint(Cam.position);
        transform.position = Lens.TransformPoint(new Vector3(mainCam.x, -mainCam.y, mainCam.z));

        Vector3 angle = Lens.TransformPoint(new Vector3(-mainCam.x, -mainCam.y, -mainCam.z));
        Cam.transform.LookAt(angle, Lens.up);
        
        transform.LookAt(Cam);

    }
}
