using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RVC {

    public class DesktopNavigation : Navigation {
     
        void Update () {
            if (photonView.IsMine || ! PhotonNetwork.IsConnected) {
                var x = Input.GetAxis ("Horizontal") * Time.deltaTime * 150.0f ;
                var z = Input.GetAxis ("Vertical") * Time.deltaTime * 3.0f ;
                transform.Rotate (0, x, 0) ;
                transform.Translate (0, 0, z) ;
                if (Input.GetKeyDown (KeyCode.X)) {
                    print (name + " : CatchCamera again") ;
					CatchCamera () ;
				}
    
            }
        }

    }

}