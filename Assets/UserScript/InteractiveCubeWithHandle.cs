using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime; 

public class InteractiveCubeWithHandle : MonoBehaviourPun
{
    public GameObject topHandle;

    public GameObject bottomHandle;

    public GameObject leftHandle;

    public GameObject rightHandle;

    public GameObject frontHandle;

    public GameObject backHandle;

    private void LOGING_POSITION(Vector3 position) {
        Debug.Log($"TopHandle position {topHandle.transform.position}");
        Debug.Log($"BottomHandle position {bottomHandle.transform.position}");
        Debug.Log($"Cube position {transform.position}");
        Debug.Log($"Cube CALCULATED position {position}");
    }
    void Update()
    {

        if (photonView.IsMine)
        {
            Vector3 position = ComputePosition();
            LOGING_POSITION(position);
            transform.position = position;

        }

    }

    Vector3 ComputePosition()
    {

        Vector3 position = (topHandle.transform.position +

                              bottomHandle.transform.position +

                              leftHandle.transform.position +

                              rightHandle.transform.position +

                              frontHandle.transform.position +

                              backHandle.transform.position) / 6.00f;
        return position; 

    }
}
