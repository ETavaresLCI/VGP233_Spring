using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    private float zBound = 30.0f;

    // Update is called once per frame
    void Update()
    {
        if(transform.position.z > zBound || transform.position.z < -zBound)
        {
            Destroy(gameObject);
        }
    }
}
