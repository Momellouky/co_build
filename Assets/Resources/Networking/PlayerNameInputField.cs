using UnityEngine;


using Photon.Pun;
using Photon.Realtime;


using System.Collections;
using UnityEngine.UI;

namespace RVC {
    /// <summary>
    /// Player name input field. Let the user input his name, will appear above the player in the game.
    /// </summary>
    //[RequireComponent(typeof(InputField))]
    public class PlayerNameInputField : MonoBehaviour {

        #region Private Constants

        // Store the PlayerPref Key to avoid typos
        const string playerNamePrefKey = "PlayerName";
        const string xPos = "0";
        const string yPos = "0";
        const string zPos = "0";


        #endregion


        #region MonoBehaviour CallBacks


        /// <summary>
        /// MonoBehaviour method called on GameObject by Unity during initialization phase.
        /// </summary>
        void Start () {
            string defaultName = "string.Empty" ;
            //InputField _inputField = this.GetComponent<InputField>();
            // if (_inputField != null)
            // {
            //     if (PlayerPrefs.HasKey(playerNamePrefKey))
            //     {
            //         defaultName = PlayerPrefs.GetString(playerNamePrefKey);
            //         _inputField.text = defaultName;
            //     }
            // }
            PhotonNetwork.NickName = defaultName;
            //PhotonNetwork.SetPlayerCustomProperties
        }

        #endregion

        #region Public Methods

        /// <summary>
        /// Sets the name of the player, and save it in the PlayerPrefs for future sessions.
        /// </summary>
        /// <param name="value">The name of the Player</param>
        public void SetPlayerName (string value) {
            // #Important
            if (string.IsNullOrEmpty(value)) {
                Debug.LogError ("Player Name is null or empty") ;
                return ;
            }
            PhotonNetwork.NickName = value ;
            PlayerPrefs.SetString (playerNamePrefKey, value) ;
        }

        public void setXPos(string xPos)
        {
            if(string.IsNullOrEmpty(xPos))
            {
                xPos = "0" ;
            }
            int x = int.Parse(xPos);
            Debug.Log($"Setting x position {x}");
            PlayerPrefs.SetInt ("x", x);
        }

        public void setZPos(string zPos) {
            if (string.IsNullOrEmpty(zPos))
            {
                zPos = "0";
            }
            int z = int.Parse(zPos);
            Debug.Log($"Setting z position {z}");
            PlayerPrefs.SetInt ("z", z);
        }

        #endregion
    }
}