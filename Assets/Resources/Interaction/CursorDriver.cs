using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

namespace RVC {

	public class CursorDriver : MonoBehaviourPun {

		private bool active ;
		private Camera theCamera ;

		void Start () {
			if (photonView.IsMine || ! PhotonNetwork.IsConnected) {
				// get the camera
				theCamera = (Camera)GameObject.FindObjectOfType (typeof(Camera)) ;
				active = false ;
			}
		}
		
		void Update () {
			if (photonView.IsMine  || ! PhotonNetwork.IsConnected) {
				if (Input.GetKeyDown (KeyCode.LeftAlt)) {
					active = true ;
				}
				if (Input.GetKeyUp (KeyCode.LeftAlt)) {
					active = false ;
				}
				if ((Input.mousePosition != null) && (active)) {
					Vector3 point = new Vector3 () ;
					Vector3 mousePos = Input.mousePosition ;
					float deltaZ = Input.mouseScrollDelta.y / 10.0f ;
					transform.Translate (0, 0, deltaZ) ;
					point = theCamera.ScreenToWorldPoint (new Vector3 (mousePos.x, mousePos.y, transform.localPosition.z)) ;
					transform.position = point ;
				}				
			}
		}

	}

}