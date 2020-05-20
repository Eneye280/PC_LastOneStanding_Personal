using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Photon;
using Photon.Pun;

public class AutoLoby : MonoBehaviourPunCallbacks
{
    public Button connectButton;
    public Button JoinRandomButton;
    public Text log;
    public Text playerCount;
    public int playersCount;

    public byte maxPlayerPerRoom = 4;

    private void Start()
    {
        Connected();
    }
    public void Connected()
    {
        if(!PhotonNetwork.IsConnected)
        {
            if(PhotonNetwork.ConnectUsingSettings())
            {
                log.text += "\nConnected to server";
            }
            else
            {
                log.text += "\nFailed Connecting to server";
            }
        }
    }

    public override void OnConnectedToMaster()
    {
        connectButton.interactable = false;
        JoinRandomButton.interactable = true;
    }

    public void JoinRandom()
    {
        if(!PhotonNetwork.JoinRandomRoom())
        {
            log.text += "\nFailed Joinig Room";
        }
    }

    public override void OnJoinRandomFailed(short returnCode, string message)
    {
        log.text += "\nNo Rooms to join,creating one...";

        if (PhotonNetwork.CreateRoom(null,new Photon.Realtime.RoomOptions() { MaxPlayers = maxPlayerPerRoom }))
        {
            log.text += "\nRoom Created";
        }
        else
        {
            log.text += "\nFailed Creating Room";
        }
    }

    public override void OnJoinedRoom()
    {
        log.text += "\nJoined";
        JoinRandomButton.interactable = false;
    }

    private void FixedUpdate()
    {
        if(PhotonNetwork.CurrentRoom != null)
        {
            playersCount = PhotonNetwork.CurrentRoom.PlayerCount;
            playerCount.text = playersCount + "/" + maxPlayerPerRoom;
        }

    }

}
