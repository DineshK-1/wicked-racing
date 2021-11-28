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
    private float currentMotorForce;
    private bool isBraking;
    private bool isHandBraking;

    public bool isAccelerating;
    public bool Braking;

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
        CurrentCalculate();
        CalculateBools();
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        DetectSlip();
    }

    private void CurrentCalculate()
    {
        currentMotorForce = verticalInput * motorForce;
        currentBrakeForce = Mathf.Abs(verticalInput * motorForce);
    }

    private void CalculateBools()
    {
        if (currentMotorForce > 0)
        {
            isAccelerating = true;
        }
        else
        {
            isAccelerating = false;
        }

        if (currentBrakeForce > 0)
        {
            Braking = true;
        }
    }

    private void DetectSlip()
    {
        float slipLat;
        float slipLong;
        float speed = rb.velocity.magnitude * 3.6f;

        rearLeft.GetGroundHit(out WheelHit wheelData);
        slipLat = wheelData.sidewaysSlip;
        slipLong = wheelData.forwardSlip;

        Debug.Log("Speed: "+ speed.ToString() + " Lat:"+slipLat.ToString()+ " Long:"+slipLong.ToString());
    }

    private void UpdateWheels()
    {
        UpdateWheelPose(frontLeft, frontLeftTransform);
        UpdateWheelPose(frontRight, frontRightTransform);
        UpdateWheelPose(rearLeft, rearLeftTransform);
        UpdateWheelPose(rearRight, rearRightTransform);
    }

    private void UpdateWheelPose(WheelCollider _collider, Transform _transform)
    {
        Vector3 _pos = _transform.position;
        Quaternion _quat = _transform.rotation;

        _collider.GetWorldPose(out _pos, out _quat);

        _transform.position = _pos;
        _transform.rotation = _quat;
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
        rearLeft.motorTorque = currentMotorForce;
        rearRight.motorTorque = currentMotorForce; 

        if (isBraking)
        {
            frontLeft.brakeTorque = currentBrakeForce;
            frontRight.brakeTorque = currentBrakeForce;
            rearLeft.brakeTorque = currentBrakeForce;
            rearRight.brakeTorque = currentBrakeForce;
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
        isHandBraking = Input.GetKey(KeyCode.C);
        /*
        if (verticalInput < 0)
        {
            isBraking = true;
        }
        else
        {
            isBraking = false;
        }
        */
    }
}
