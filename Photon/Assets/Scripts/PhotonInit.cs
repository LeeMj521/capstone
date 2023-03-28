using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.SceneManagement;

public class PhotonInit : MonoBehaviourPunCallbacks
{

    public LobbySceneManager lobbySM;

    private void Awake()
    {
        PhotonNetwork.ConnectUsingSettings();
        PhotonNetwork.AutomaticallySyncScene = true;
    }
    void Start()
    {
        //txtUserName.text = PlayerPrefs.GetString("USER_NAME", "USER_" + Random.Range(1, 1000));
        lobbySM.inputUserName.text = "USER_" + Random.Range(1, 1000);
        lobbySM.inputCreateRoomName.text = "ROOM_" + Random.Range(1, 1000);
    }

    public void OnCreateRoomClick()
    {
        RoomOptions roomOptions = new RoomOptions();
        roomOptions.IsVisible = true;//���� ���Ǹ�Ͽ� ���̴��� ����
        roomOptions.MaxPlayers = (byte)(lobbySM.maxPlayers.value);
        roomOptions.IsOpen = true;//���� �����ִ��� ����
        //roomOptions.CustomRoomProperties = new Hashtable() { { "password", "mypassword" } };
        PhotonNetwork.CreateRoom(lobbySM.inputCreateRoomName.text, roomOptions);
    }
    public void OnJoinRoomClick()
    {
        //PhotonNetwork.JoinRoom("RoomName");
        PhotonNetwork.JoinRandomRoom();
    }

    //override
    public override void OnConnectedToMaster()
    {
        base.OnConnectedToMaster();
        Debug.Log("Connect To Master");
    }
    public override void OnJoinRoomFailed(short returnCode, string message)
    {
        base.OnJoinRoomFailed(returnCode, message);
        Debug.Log("Failed join room");
    }
    public override void OnJoinedRoom()
    {
        base.OnJoinedRoom();
        Debug.Log("Join room");
        //PhotonNetwork�� ������ ����� ��� ���� ��Ų��
        //GameManager���� ���� ������ �ٽ� �����Ѵ�
        PhotonNetwork.IsMessageQueueRunning = false;
        SceneManager.LoadScene("RoomScene");
    }
}
