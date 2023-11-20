using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubePositioner : MonoBehaviour
{
    public Transform largerCube;

    void Start()
    {
        // Calculate position for the front face of the larger cube
        Vector3 frontFacePosition = largerCube.position + largerCube.forward * (largerCube.localScale.z / 2 + transform.localScale.z / 2);
        transform.position = frontFacePosition;

        // Repeat similar steps for other faces (back, left, right, top, bottom)
        // ...

        // Optionally, you can rotate the smaller cube to align with the face normals of the larger cube
        transform.rotation = largerCube.rotation;
    }
}
