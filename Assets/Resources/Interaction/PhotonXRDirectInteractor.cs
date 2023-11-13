using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using UnityEngine.InputSystem;

namespace RVC {

    public class PhotonXRDirectInteractor : XRDirectInteractor {

        PhotonTool photonTool ;
        public GameObject objectToInstanciate ;
        public InputAction create ;

		new void Start () {
			photonTool = (PhotonTool)GameObject.FindObjectOfType (typeof(PhotonTool)) ;
            print ("PhotonXRDirectInteractor " + name + " Start : photonView.IsMine = " + photonTool.photonView.IsMine) ;
            if (! photonTool.photonView.IsMine) {
                enabled = false ;
            }
		}

        protected void OnTriggerEnter (Collider col) {
            base.OnTriggerEnter (col) ;
            IXRInteractable interactable ;
            interactionManager.TryGetInteractableForCollider (col, out interactable) ;
            if (interactable != null) {
                attachTransform.SetPositionAndRotation (interactable.transform.position, interactable.transform.rotation) ;
            }
        }

    }

}

