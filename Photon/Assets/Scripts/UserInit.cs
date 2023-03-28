using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UserInit : MonoBehaviour
{
    public Transform cameraOffset;

    private PhotonView pv;

    // Start is called before the first frame update
    void Start()
    {
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            Camera.main.GetComponent<CameraInsertTarget>().CameraInsert(cameraOffset);
            //GetComponent<XROrigin>().Camera = Camera.main;
            //_camera = Camera.main;
        }
        else
        {
            //name »ý¼º
        }
    }
}
