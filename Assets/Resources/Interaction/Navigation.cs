using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RVC {

    public class Navigation : MonoBehaviourPunCallbacks {
     
        #region Public Fields

        // to be able to manage the offset of the camera
        public Vector3 cameraPositionOffset = new Vector3 (0, 1.6f, 0) ;
        public Quaternion cameraOrientationOffset = new Quaternion () ;
 
        [Tooltip("The local player instance. Use this to know if the local player is represented in the Scene")]
        public static GameObject LocalPlayerInstance;
        protected Transform cameraTransform ;
        protected Camera theCamera ;

        #endregion
        public void Awake () {
            // #Important
            // used in GameManager.cs: we keep track of the localPlayer instance to prevent instantiation when levels are synchronized
            if (photonView.IsMine) {
                LocalPlayerInstance = this.gameObject;
            }
            // #Critical
            // we flag as don't destroy on load so that instance survives level synchronization, thus giving a seamless experience when levels load.
            //DontDestroyOnLoad (this.gameObject) ;
        }

        protected void Start () {
            CatchCamera () ;
        }

        [PunRPC] public void CatchCamera () {
            if (photonView.IsMine  || ! PhotonNetwork.IsConnected) {
                // attach the camera to the navigation rig
                theCamera = (Camera)GameObject.FindObjectOfType (typeof(Camera)) ;
                theCamera.enabled = true ;
                cameraTransform = theCamera.transform ;
                cameraTransform.SetParent (transform) ;
                cameraTransform.localPosition = cameraPositionOffset ;
                cameraTransform.localRotation = cameraOrientationOffset ;
            }
        }

    }

}