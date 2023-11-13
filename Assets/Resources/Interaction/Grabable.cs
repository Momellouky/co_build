using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RVC {

    public class Grabable : MonoBehaviourPun {

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
                    print ("LocalCatch : photonView.isRuntimeInstantiated") ;
	    			photonView.RequestOwnership () ;
       		        // add code here
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
       		    // add code here
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
           	        // add code here
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
           		    // add code here
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

    }

}