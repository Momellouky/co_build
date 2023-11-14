using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RVC {
	
	public class PhotonTool : MonoBehaviourPun {
        public void CreateSharedObject(GameObject objectToInstanciate)
        {

            if (photonView.IsMine)
            {

                PhotonNetwork.Instantiate(objectToInstanciate.name, transform.position, transform.rotation, 0);

            }

        }
    }

}