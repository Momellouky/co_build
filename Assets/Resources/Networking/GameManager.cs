using System;
using System.Collections;


using UnityEngine;
using UnityEngine.SceneManagement;


using Photon.Pun;
using Photon.Realtime;


namespace RVC {
    public class GameManager : MonoBehaviourPunCallbacks {

        #region Public Fields

        public static GameManager Instance ;

        [Tooltip("The prefab to use for representing the player")]
        //public QuestNavigation questPrefab ;
        public Navigation desktopPrefab ;
        Navigation playerPrefab ;
        GameObject rigGO ;

        #endregion

        void Start () {
            Instance = this ;
            String nickName = PhotonNetwork.NickName ;
            String platformName = SystemInfo.deviceName ;
            String platformModel = SystemInfo.deviceModel ;
            DeviceType platformType = SystemInfo.deviceType ;
            playerPrefab = desktopPrefab ;
            // if (platformType == DeviceType.Desktop) {
            //     playerPrefab = desktopPrefab ;
            // } else {
            //     playerPrefab = questPrefab ;
            // }

            if (playerPrefab == null) {
                Debug.LogError ("<Color=Red><a>Missing</a></Color> playerPrefab Reference. Please set it up in GameObject 'Game Manager'", this) ;
            } else {
                //Debug.LogFormat("We are Instantiating LocalPlayer from {0}", Application.loadedLevelName);
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                Debug.LogFormat ("We are Instantiating LocalPlayer from {0}", SceneManagerHelper.ActiveSceneName) ;
                // we're in a room. spawn a character for the local player. it gets synced by using PhotonNetwork.Instantiate
                rigGO = PhotonNetwork.Instantiate (this.playerPrefab.name, new Vector3 (0f, 0.5f, 0f), Quaternion.identity, 0) ;
                Debug.LogFormat ("Ignoring scene load for {0}", SceneManagerHelper.ActiveSceneName) ;
            }
        }

        #region Private Methods

        #endregion

        #region Photon Callbacks

        /// <summary>
        /// Called when the local player left the room. We need to load the launcher scene.
        /// </summary>
        public override void OnLeftRoom () {
            SceneManager.LoadScene (0) ;
        }

        public override void OnPlayerEnteredRoom (Player other) {
            Debug.LogFormat ("OnPlayerEnteredRoom() {0}", other.NickName) ; // not seen if you're the player connecting
            // we load the Arena only once, for the first user who connects, it is made by the launcher
            if (PhotonNetwork.IsMasterClient) {
                Debug.LogFormat ("OnPlayerEnteredRoom IsMasterClient {0}", PhotonNetwork.IsMasterClient) ; // called before OnPlayerLeftRoom
            }
        }

        public override void OnPlayerLeftRoom (Player other) {
            Debug.LogFormat ("OnPlayerLeftRoom() {0}", other.NickName) ; // seen when other disconnects
        }

        #endregion

        #region Public Methods

        public void LeaveRoom () {
            PhotonNetwork.LeaveRoom () ;
        }

        #endregion

		[PunRPC] void SomebodyJoined (PhotonMessageInfo info) {
            Navigation rig = (Navigation)rigGO.GetComponent (typeof (Navigation)) ;
            rig.CatchCamera () ;
		}

    }
}