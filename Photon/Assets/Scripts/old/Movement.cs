using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.XR.CoreUtils;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;
using Photon.Pun;

public class Movement : MonoBehaviour
{
    public float speed = 2f;
    public Transform cameraOffset;

    public XRController controllerL = null;
    public XRController controllerR = null;
    private CharacterController character;
    private Camera _camera;

    private PhotonView pv;

    private void Start()
    {
        character = GetComponent<CharacterController>();
        pv = GetComponent<PhotonView>();
        if (pv.IsMine)
        {
            Camera.main.GetComponent<CameraInsertTarget>().CameraInsert(cameraOffset);
            GetComponent<XROrigin>().Camera = Camera.main;
            _camera = Camera.main;
        }
        /*else
        {
            rigid.isKinematic = true;
        }*/
    }

    // Update is called once per frame
    void Update()
    {
        if (!pv.IsMine) return;

        CommonInput();
    }
    private void CommonInput()
    {
        Vector2 position;
        if (controllerL.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out position))
        //if (controller.inputDevice.TryGetFeatureValue(CommonUsages.primary2DAxis, out Vector2 position))
        {
            var inputVector = new Vector3(position.x, Physics.gravity.y, position.y);
            var inputDirection = transform.TransformDirection(inputVector);
            var lookDirection = new Vector3(0, _camera.transform.eulerAngles.y, 0);
            var newDirection = Quaternion.Euler(lookDirection) * inputDirection;
            character.Move(newDirection * Time.deltaTime * speed);
        }
    }
}
