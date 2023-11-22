using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;
using UnityEngine.InputSystem;

namespace RVC {

    public class PhotonXRDirectInteractor : XRDirectInteractor {

        PhotonTool photonTool ;
        public GameObject objectToInstanciate_innerWall ;
        public GameObject objectToInstanciate_outerWall ;
        public InputAction create ;
        public InputAction keyPressSpace ;
        public InputAction keyPressControl ;
        private const KeyCode SPACE_KEYBOARD = KeyCode.Space;
        private const KeyCode LEFTSHIFT_KEYBOARD = KeyCode.LeftShift;

        new void Start () {
			photonTool = (PhotonTool)GameObject.FindObjectOfType (typeof(PhotonTool)) ;
            print ("PhotonXRDirectInteractor " + name + " Start : photonView.IsMine = " + photonTool.photonView.IsMine) ;
            if (! photonTool.photonView.IsMine) {
                enabled = false ;
            }
            //create.Enable();
            //create.started += ctx => CreateSharedObject();

            keyPressSpace = new InputAction(binding: "<Keyboard>/" + SPACE_KEYBOARD); // Set up the keyboard input action
            keyPressSpace.Enable();
            keyPressSpace.started += ctx => CreateSharedObject(objectToInstanciate_innerWall);

            keyPressControl = new InputAction(binding: "<Keyboard>/" + LEFTSHIFT_KEYBOARD); // Set up the keyboard input action
            keyPressControl.Enable();
            keyPressControl.started += ctx => CreateSharedObject(objectToInstanciate_outerWall);

        }

        protected void OnTriggerEnter (Collider col) {
            base.OnTriggerEnter (col) ;
            IXRInteractable interactable ;
            interactionManager.TryGetInteractableForCollider (col, out interactable) ;
            if (interactable != null) {
                attachTransform.SetPositionAndRotation (interactable.transform.position, interactable.transform.rotation) ;
            }
        }

        public void CreateSharedObject(GameObject gameobjectToInstantiate)
        {

            photonTool.CreateSharedObject(gameobjectToInstantiate);

        }   

    }

}

