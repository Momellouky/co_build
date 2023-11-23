using Photon.Pun;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OwnerShipRequester : MonoBehaviourPun
{



    private PhotonView cubePhotonView;

    public static class gameobjects {
        
        public static GameObject mainCube;
        public static GameObject topHandle;
        public static GameObject bottomHandle;
        public static GameObject leftHandle;
        public static GameObject rightHandle;
        public static GameObject frontHandle;
        public static GameObject backHandle;

    }
    public static class tags
    {
        public static readonly string mainCube = "cubeWithHandles";
        public static readonly string backHandle = "backHandle";
        public static readonly string frontHandle = "frontHandle";
        public static readonly string topHandle = "topHandle";
        public static readonly string bottomHandle = "bottomHandle";
        public static readonly string rightHandle = "rightHandle";
        public static readonly string leftHandle = "leftHandle";
    }

    public static class photonViews
    {
        #region PUBLIC_STATIC_FIELDS
        public static PhotonView mainCube;
        public static PhotonView backHandle;
        public static PhotonView frontHandle;
        //public static PhotonView topHandle;
        //public static PhotonView bottomHandle;
        //public static PhotonView rightHandle;
        //public static PhotonView leftHandle;
        #endregion

        public static void initViews() {
            mainCube = gameobjects.mainCube.GetPhotonView();
            backHandle = gameobjects.backHandle.GetPhotonView();
            frontHandle = gameobjects.frontHandle.GetPhotonView();
            //topHandle = gameobjects.topHandle.GetPhotonView();
            //bottomHandle = gameobjects.bottomHandle.GetPhotonView();
            //rightHandle = gameobjects.rightHandle.GetPhotonView();
            //leftHandle = gameobjects.leftHandle.GetPhotonView(); 
        }
    }

    #region PRIVATE_METHODS
    private void initObjects() {
        Debug.Log("Start Initialisation");

        gameobjects.mainCube = GameObject.FindGameObjectWithTag(tags.mainCube);
        Debug.Log("We have already Get the main cube view"); 
        gameobjects.backHandle = GameObject.FindGameObjectWithTag(tags.backHandle);
        Debug.Log("We have already Get the backHandle view"); 
        gameobjects.frontHandle = GameObject.FindGameObjectWithTag(tags.frontHandle);
        Debug.Log("We have already Get the frontHandle view"); 
        //gameobjects.topHandle = GameObject.FindGameObjectWithTag(tags.topHandle);
        //gameobjects.bottomHandle = GameObject.FindGameObjectWithTag(tags.bottomHandle);
        //gameobjects.rightHandle = GameObject.FindGameObjectWithTag(tags.rightHandle);
        //gameobjects.leftHandle = GameObject.FindGameObjectWithTag(tags.leftHandle);

        Debug.Log("initialize views");

        photonViews.initViews();

        Debug.Log("Initialisation Ended");
    }
    #endregion
    public void requestCubeOwnerShip()
    {
        initObjects();

        Debug.Log($"Request Cube OwnerShip"); 

        if (PhotonNetwork.IsConnected)
        {
            photonViews.mainCube.TransferOwnership(PhotonNetwork.LocalPlayer);
            Debug.Log("LocalCatch : photonView.isRuntimeInstantiated");

            photonViews.mainCube.RPC("Catch", RpcTarget.Others);
            PhotonNetwork.SendAllOutgoingCommands();
        }
    }

    public void requestAllHandlesOwnerShip()
    {
        Debug.Log("requestAllHandlesOwnerShip");

        if (PhotonNetwork.IsConnected)
        {
            photonViews.frontHandle.TransferOwnership(PhotonNetwork.LocalPlayer);
            photonViews.backHandle.TransferOwnership(PhotonNetwork.LocalPlayer);
            //photonViews.topHandle.TransferOwnership(PhotonNetwork.LocalPlayer);
            //photonViews.bottomHandle.TransferOwnership(PhotonNetwork.LocalPlayer);
            //photonViews.rightHandle.TransferOwnership(PhotonNetwork.LocalPlayer);
            //photonViews.leftHandle.TransferOwnership(PhotonNetwork.LocalPlayer);

            photonViews.frontHandle.RPC("Catch", RpcTarget.Others);
            photonViews.backHandle.RPC("Catch", RpcTarget.Others);
            //photonViews.topHandle.RPC("Catch", RpcTarget.Others);
            //photonViews.bottomHandle.RPC("Catch", RpcTarget.Others);
            //photonViews.rightHandle.RPC("Catch", RpcTarget.Others);
            //photonViews.leftHandle.RPC("Catch", RpcTarget.Others);
            PhotonNetwork.SendAllOutgoingCommands();
        }
    }

}
