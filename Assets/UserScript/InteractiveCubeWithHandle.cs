using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

#region CUBE_WITH_SIX_HANDLES
//public class InteractiveCubeWithHandle : MonoBehaviourPun
//{
//    public GameObject topHandle;

//    public GameObject bottomHandle;

//    public GameObject leftHandle;

//    public GameObject rightHandle;

//    public GameObject frontHandle;

//    public GameObject backHandle;

//    private void LOGING_POSITION(Vector3 position)
//    {
//        Debug.Log($"TopHandle position {topHandle.transform.position}");
//        Debug.Log($"BottomHandle position {bottomHandle.transform.position}");
//        Debug.Log($"Cube position {transform.position}");
//        Debug.Log($"Cube CALCULATED position {position}");
//    }
//    void Update()
//    {

//        if (photonView.IsMine)
//        {
//            Vector3 position = new Vector3();
//            if (ActiveHandles.activeHandlesNumber() >= 1)
//            {
//                position = ComputePosition();
//                //LOGING_POSITION(position);
//                Debug.Log("Calling computePosition");
//                transform.position = position;
//            }

//        }

//    }

//    Vector3 ComputePosition()
//    {

//        Vector3 position = (topHandle.transform.position +

//                              bottomHandle.transform.position +

//                              leftHandle.transform.position +

//                              rightHandle.transform.position +

//                              frontHandle.transform.position +

//                              backHandle.transform.position) / 6.00f;
//        return position;

//    }
//}
#endregion

#region CUBE_WITH_TWO_HANDLES 
// used in project
public class InteractiveCubeWithHandle : MonoBehaviourPun
{

    public GameObject frontHandle;
    public GameObject backHandle;

    private void LOGING_POSITION(Vector3 position)
    {
        Debug.Log($"Cube position {transform.position}");
        Debug.Log($"Cube CALCULATED position {position}");
    }
    void Update()
    {

        if (photonView.IsMine)
        {
            Vector3 position = new Vector3();
            if (ActiveHandles.activeHandlesNumber() >= 1 /* && ComputePositionDecision.getNbrUser() == 2 */ )
            {
                position = ComputePosition();
                //LOGING_POSITION(position);
                Debug.Log("Calling computePosition");
                transform.position = position;
            }

        }
        else 
        {
            Debug.LogWarning($"PhotonView.isMine is false");
        }

    }

    Vector3 ComputePosition()
    {

        Vector3 position = (frontHandle.transform.position + backHandle.transform.position) / 2.00f;
        return position;

    }
}
#endregion