using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInsertTarget : MonoBehaviour
{
    public void CameraInsert(Transform target)
    {
        transform.SetParent(target);
        transform.localPosition = Vector3.zero;
        transform.localRotation = Quaternion.identity;
    }
}
