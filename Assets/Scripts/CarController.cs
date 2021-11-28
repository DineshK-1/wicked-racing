using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
    [SerializeField] public float brakeForce;
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

    public Text speedText;
    public Text torqueText;
    public Text FLForwardSlipText;
    public Text FLSidewaySlipText;
    public Text RLForwardSlipText;
    public Text RLSidewaySlipText;

    private void Update()
    {
        speedText.text = "Speed: " + speed.ToString();
        torqueText.text = "Torque: " + currentMotorForce.ToString();

    }

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
        //currentBrakeForce = Mathf.Abs(verticalInput * motorForce);
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

        if (isBraking || isHandBraking)
        {
            Braking = true;
        }
        else
        {
            Braking = false;
        }
    }

    private void DetectSlip()
    {
        float rearSlipLat;
        float rearSlipLong;

        float frontSlipLat;
        float frontSlipLong;

        float speed = rb.velocity.magnitude * 3.6f;

        rearLeft.GetGroundHit(out WheelHit wheelData);
        frontLeft.GetGroundHit(out WheelHit wheelData2);

        

        rearSlipLat = wheelData.sidewaysSlip;
        rearSlipLong = wheelData.forwardSlip;

        frontSlipLat = wheelData2.sidewaysSlip;
        frontSlipLong = wheelData2.forwardSlip;

        FLForwardSlipText.text = "FL Forward Slip:" + frontSlipLong.ToString();
        FLSidewaySlipText.text = "FL Sideways Slip:" + frontSlipLat.ToString();

        RLForwardSlipText.text = "RL Forward Slip:" + rearSlipLong.ToString();
        RLSidewaySlipText.text = "RL Sideways Slip:" + rearSlipLat.ToString();

        //Debug.Log( "RW Forward Slip:" + rearSlipLong.ToString() + " FW Forward Slip:" + frontSlipLong.ToString());
        Debug.Log("RW Sideways Slip:" + rearSlipLat.ToString() + " FW Sideways Slip:" + frontSlipLat.ToString());
        // Debug.Log("RW Forward Slip:"+ rearSlipLong.ToString() +" RW Sideways Slip:" + rearSlipLat.ToString() + " FW Forward Slip:" + frontSlipLong.ToString() + " FW Sideways Slip:" + frontSlipLat.ToString());
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
            frontLeft.brakeTorque = brakeForce;
            frontRight.brakeTorque = brakeForce;
            rearLeft.brakeTorque = brakeForce;
            rearRight.brakeTorque = brakeForce;
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
        isBraking = Input.GetKey(KeyCode.C);
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
