using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;

namespace RVC {

    public class Grabable : MonoBehaviourPun, IPunOwnershipCallbacks
    {

        private Color catchableColor = Color.cyan ;
        private Color caughtColor = Color.yellow ;
        private Color initialColor ;

        protected Rigidbody rb ;
        protected Renderer colorRenderer ;

        protected bool caught = false ;
        protected int numberOfTools = 0 ;

        public virtual void Start () {
            colorRenderer = GetComponentInChildren <Renderer> () ;
            initialColor = colorRenderer.material.color ;
            rb = GetComponent<Rigidbody> () ;
        }

        void Update () {
            
        }

        public virtual void LocalCatch () {
            print ("LocalCatch") ;
            if (! caught) {
    			if (PhotonNetwork.IsConnected) {
                    print ("LocalCatch : photonView.isRuntimeInstantiated");
                    photonView.TransferOwnership(PhotonNetwork.LocalPlayer);
                    //photonView.RequestOwnership();
                    // show interaction awerness to all the users
                    photonView.RPC("Catch", RpcTarget.Others);
                    PhotonNetwork.SendAllOutgoingCommands();

                }
                Catch () ;
            }
        }



        [PunRPC]
        public virtual void Catch () {
            print ("Catch") ;
            rb.isKinematic = true ;
            caught = true ;
            ShowCaught () ;
        }

        [PunRPC] 
        public void ShowCaught () {
            print ("ShowCaught") ;
            if (caught) {
                colorRenderer.material.color = caughtColor ;
            }
        }

        public virtual void LocalRelease () {
            print ("LocalRelease") ;
    		if (PhotonNetwork.IsConnected) {
                photonView.RPC("Release", RpcTarget.Others);
                PhotonNetwork.SendAllOutgoingCommands();
            }
            Release () ;
        }

        [PunRPC]
        public virtual void Release () {
            print ("Release") ;
            rb.isKinematic = false ;
            caught = false ;
            ShowReleased () ;
        }

        [PunRPC] 
        public void ShowReleased () {
            print ("ShowReleased") ;
            if (! caught) {
                colorRenderer.material.color = catchableColor ;
            }
        }

        public void LocalShowCatchable () {
            print ("LocalShowCatchable") ;
            if (! caught) {
                ShowCatchable () ;
                if (PhotonNetwork.IsConnected) {
                    photonView.RPC("ShowCatchable", RpcTarget.Others);
                    PhotonNetwork.SendAllOutgoingCommands();
                }
            } else {
                numberOfTools = numberOfTools + 1 ;
            }
        }
        
        [PunRPC]
        public void ShowCatchable () {
            numberOfTools = numberOfTools + 1 ;
            print ("ShowCatchable numberOfTools = " + numberOfTools) ;
            if (numberOfTools == 1) {
                colorRenderer.material.color = catchableColor ;
            }
        }
        
        public void LocalHideCatchable () {
            print ("LocalHideCatchable") ;
            if (! caught) {
                HideCatchable () ;
                if (PhotonNetwork.IsConnected) {
                    photonView.RPC("HideCatchable", RpcTarget.Others);
                    PhotonNetwork.SendAllOutgoingCommands();
                }
            } else {
                numberOfTools = numberOfTools - 1 ;
            }
        }

        [PunRPC]
        public void HideCatchable () {
            numberOfTools = numberOfTools - 1 ;
            if (numberOfTools == 0) {
                print ("HideCatchable numberOfTools = " + numberOfTools) ;
                colorRenderer.material.color = initialColor ;
            }
        }

        public void OnOwnershipTransfered(PhotonView targetView, Player previousOwner)
        {
            Debug.Log("On Ownership Transfered");
        }

        public void OnOwnershipTransferFailed(PhotonView targetView, Player senderOfFailedRequest)
        {
            Debug.Log("OwnerShip transfer failed.");
        }

        public void OnOwnershipRequest(PhotonView targetView, Player requestingPlayer)
        {
            Debug.Log("OnOwnershipRequest callback");
            targetView.TransferOwnership(requestingPlayer);
            Debug.Log("Ownership transfered. ");
        }


        private void TransferOwnership(int targetPlayerId)
        {
            // Ensure the PhotonView is valid
            if (photonView != null)
            {
                // Find the target player based on their player ID
                Player targetPlayer = PhotonNetwork.CurrentRoom.GetPlayer(targetPlayerId);

                // Check if the target player is valid
                if (targetPlayer != null)
                {
                    // Transfer ownership to the target player
                    photonView.TransferOwnership(targetPlayer);
                }
                else
                {
                    Debug.LogError("Target player not found!");
                }
            }
            else
            {
                Debug.LogError("PhotonView is null!");
            }
        }
    }

}