using Photon.Pun;
using Photon.Realtime;
using UnityEngine;

public class ConnectToServer : MonoBehaviourPunCallbacks
{
    private void Start()
    {
        print("conecting to server...");
        PhotonNetwork.GameVersion = "0.0.1";
        PhotonNetwork.ConnectUsingSettings();
    }

    public override void OnConnectedToMaster()
    {
        print("conected to server");
    }

    public override void OnDisconnected(DisconnectCause cause)
    {
        print("disconected from server for season " + cause.ToString());
    }
}
