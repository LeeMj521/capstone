using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LobbySceneManager : MonoBehaviour
{
    public GameObject createRoomWindow;
    public bool onCreateRoomWindow;
    public GameObject joinRoomWindow;
    public bool onJoinRoomWindow;

    public Toggle passToggle;

    public TMP_InputField inputUserName;
    public TMP_InputField inputCreateRoomName;
    public TMP_InputField inputCreateRoomPass;
    public Slider maxPlayers;
    public TMP_Text maxPlayersCount;
    public TMP_InputField inputJoinRoomName;
    public TMP_InputField inputJoinRoomPass;

    private void Update()
    {
        createRoomWindow.SetActive(onCreateRoomWindow);
        joinRoomWindow.SetActive(onJoinRoomWindow);
        inputCreateRoomPass.interactable = !passToggle;
        maxPlayersCount.text = maxPlayers.value.ToString();
    }
    public void HostButton()
    {
        onCreateRoomWindow = true;
    }
    public void CreateRoomExitButton()
    {
        onCreateRoomWindow = false;
    }
    public void JoinButton()
    {
        onJoinRoomWindow = true;
    }
    public void JoinRoomExitButton()
    {
        onJoinRoomWindow = false;
    }
}
