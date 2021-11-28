using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject objectToFollow;
    private Transform objectToFollowT;

    private CarController _carController;

    public Vector3 Offset;

    private Vector3 currentOffset;

    public float followSpeed = 10;
    public float lookSpeed = 10;

    private void Start()
    {
        currentOffset = Offset;

        _carController = objectToFollow.GetComponent<CarController>();
        objectToFollowT = objectToFollow.transform;
    }

    public void LookAtTarget()
    {
        Vector3 _lookDirection = objectToFollowT.position - transform.position;
        Quaternion _rot = Quaternion.LookRotation(_lookDirection, Vector3.up);
        transform.rotation = Quaternion.Lerp(transform.rotation, _rot, lookSpeed * Time.deltaTime);
    }
    
    public void MoveToTarget()
    {
        Vector3 _TargetPos = objectToFollowT.position +
            objectToFollowT.forward * currentOffset.z +
            objectToFollowT.right * currentOffset.x +
            objectToFollowT.up * currentOffset.y;

        transform.position = Vector3.Lerp(transform.position, _TargetPos, followSpeed * Time.deltaTime);
    }
    private void UpdateOffset()
    {
        Vector3 _aOffset = new Vector3(Offset.x, Offset.y, Offset.z - 0.4f);
        Vector3 _bOffset = new Vector3(Offset.x, Offset.y, Offset.z + 0.2f);


        if (_carController.isAccelerating)
        {
            currentOffset = Vector3.Lerp(currentOffset, _aOffset, followSpeed * Time.deltaTime);
        }
        else if (_carController.Braking)
        {
            currentOffset = Vector3.Lerp(currentOffset, _bOffset, followSpeed * Time.deltaTime);
        }
        else
        {
            currentOffset = Vector3.Lerp(currentOffset, Offset, followSpeed * Time.deltaTime);
        }
    }

    private void FixedUpdate()
    {
        UpdateOffset();
        LookAtTarget();
        MoveToTarget();
    }
}
