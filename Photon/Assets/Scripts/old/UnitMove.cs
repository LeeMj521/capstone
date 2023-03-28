using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class UnitMove : MonoBehaviour//VR¾Æ´Ô Æ÷Åæ Å×½ºÆ®¿ë
{
    public float speed;
    public Transform cameraOffset;
    private float mouseX = 0;
    private float mouseY = 0;

    //private Rigidbody rigid;
    private CharacterController character;

    private PhotonView pv;
    // Start is called before the first frame update
    void Start()
    {
        //rigid = GetComponent<Rigidbody>();
        character = GetComponent<CharacterController>();

        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            Camera.main.GetComponent<CameraInsertTarget>().CameraInsert(cameraOffset);
        }
        else
        {
            //rigid.isKinematic = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine) return;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        Vector3 newDirection = new Vector3(h, 0, v);
        newDirection.Normalize();
        character.Move(transform.TransformDirection(newDirection) * Time.deltaTime * speed);

        mouseX += Input.GetAxis("Mouse X") * 10;
        transform.eulerAngles = new Vector3(0, mouseX, 0);
        mouseY += Input.GetAxis("Mouse Y") * 10;
        mouseY = Mathf.Clamp(mouseY, -55.0f, 55.0f);
        cameraOffset.localEulerAngles = new Vector3(-mouseY, 0, 0);
    }
}
