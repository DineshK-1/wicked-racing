using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private const string HORIZONTAL = "Horizontal";
    private const string VERTICAL = "Vertical";

    private float horizontalInput;
    private float verticalInput;
    private float currentSteerAngle;
    private float currentBrakeForce;
    private bool isBraking;
    private bool isHandBraking;

    private Rigidbody rb;
    [SerializeField] private Vector3 centerOfMass;

    [SerializeField] public float maxRpm;
    [SerializeField] public float maxTorque;
    [SerializeField] public float Torque;
    [SerializeField] public float Rpm;
    [SerializeField] public float motorForce;
    [SerializeField] public float breakForce;
    [SerializeField] public float handBreakForce;
    [SerializeField] public float maxSteerAngle;

    [SerializeField] private WheelCollider frontLeft;
    [SerializeField] private WheelCollider rearLeft;
    [SerializeField] private WheelCollider frontRight;
    [SerializeField] private WheelCollider rearRight;

    [SerializeField] private Transform frontLeftTransform;
    [SerializeField] private Transform rearLeftTransform;
    [SerializeField] private Transform frontRightTransform;
    [SerializeField] private Transform rearRightTransform;

    public float speed;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    private void FixedUpdate()
    {

        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        

    }

    private void UpdateWheels()
    {
        Vector3 pos1;
        Quaternion rot1;
        frontLeft.GetWorldPose(out pos1, out rot1);
        frontLeftTransform.position = pos1;
        frontLeftTransform.rotation = rot1;

        Vector3 pos2;
        Quaternion rot2;
        frontRight.GetWorldPose(out pos2, out rot2);
        frontRightTransform.position = pos2;
        frontRightTransform.rotation = rot2;

        Vector3 pos3;
        Quaternion rot3;
        rearLeft.GetWorldPose(out pos3, out rot3);
        rearLeftTransform.position = pos3;
        rearLeftTransform.rotation = rot3;

        Vector3 pos4;
        Quaternion rot4;
        rearRight.GetWorldPose(out pos4, out rot4);
        rearRightTransform.position = pos4;
        rearRightTransform.rotation = rot4;
    }

    private void HandleSteering()
    {
        currentSteerAngle = maxSteerAngle * horizontalInput;
        frontLeft.steerAngle = currentSteerAngle;
        frontRight.steerAngle = currentSteerAngle;
    }

    void ForceCalculator()
    {
        Torque = maxTorque;
        motorForce = (float)((9.5488 / Rpm)* Torque);
    }


    void HandleMotor()
    {
        rearLeft.motorTorque = verticalInput * motorForce;
        rearRight.motorTorque = verticalInput * motorForce;

        if (isBraking)
        {
            frontLeft.brakeTorque = Mathf.Abs(verticalInput) * breakForce;
            frontRight.brakeTorque = Mathf.Abs(verticalInput) * breakForce;
            rearLeft.brakeTorque = Mathf.Abs(verticalInput) * breakForce;
            rearRight.brakeTorque = Mathf.Abs(verticalInput) * breakForce;
        }
        else
        {
            frontLeft.brakeTorque = 0;
            frontRight.brakeTorque = 0;
            rearLeft.brakeTorque = 0;
            rearRight.brakeTorque = 0;
        }
        if (isHandBraking)
        {
            rearLeft.brakeTorque = handBreakForce;
            rearRight.brakeTorque = handBreakForce;
        }
        else
        {
            rearLeft.brakeTorque = 0;
            rearRight.brakeTorque = 0;
        }
       
    }

    void GetInput()
    {
        horizontalInput = Input.GetAxis(HORIZONTAL);
        verticalInput = Input.GetAxis(VERTICAL);
        isHandBraking = Input.GetKey(KeyCode.Space);
        if (verticalInput < 0)
        {
            isBraking = true;
        }
        else
        {
            isBraking = false;
        }
    }
}
