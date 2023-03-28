using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class GameManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        CreateUser();
        PhotonNetwork.IsMessageQueueRunning = true;
    }
    void CreateUser()
    {
        PhotonNetwork.Instantiate("VRUser", Vector3.zero, Quaternion.identity);
    }
}
