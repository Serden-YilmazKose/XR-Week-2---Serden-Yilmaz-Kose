using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class magLens : MonoBehaviour
{
    // since the lens will be moving constantly
    // we will use Update() since it runs it every frame during the game
    // no variables are to be created for this function
    void Update()
    {
        Quaternion rotation = transform.rotation;
        transform.rotation = Quaternion.Euler(rotation.eulerAngles.x, rotation.eulerAngles.y, 0f);
    }
}
