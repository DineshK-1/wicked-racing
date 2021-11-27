using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform objectToFollow;
    public Vector3 Offset;
    public float followSpeed = 10;
    public float lookSpeed = 10;

    public void LookAtTarget()
    {
        Vector3 _lookDirection = objectToFollow.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }
    
    public void MoveToTarget()
    {
        Vector3 _TargetPos = objectToFollow.position +
            objectToFollow.forward * Offset.z +
            objectToFollow.right * Offset.x +
            objectToFollow.up * Offset.y;

        transform.position = Vector3.Lerp(transform.position, _TargetPos, followSpeed * Time.deltaTime);
    }

    private void FixedUpdate()
    {
        LookAtTarget();
        MoveToTarget();
    }
}
