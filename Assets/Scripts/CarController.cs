using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    public enum DriveTrain
    {
        All_Wheel_Drive,
        Rear_Wheel_Drive,
        Front_Wheel_Drive,
    }

    public DriveTrain DType;

    private IM _IM;

    private float SteerInput;
    private float ThrottleInput;
    private float BrakeInput;

    private float currentSteerAngle;
    private float currentBrakeForce;
    private float currentMotorForce;
    private bool isBraking;
    private bool isHandBraking;

    private Rigidbody rb;
    [SerializeField] private Vector3 centerOfMass;

    public float Torque;
    public float motorForce;
    public float brakeForce;
    public float handBreakForce;
    public float maxSteerAngle;

    private GameObject Colliders;
    private GameObject Meshes;

    private WheelCollider frontLeft;
    private WheelCollider frontRight;
    private WheelCollider rearLeft;
    private WheelCollider rearRight;

    private Transform frontLeftTransform;
    private Transform frontRightTransform;
    private Transform rearLeftTransform;
    private Transform rearRightTransform;

    public float speed;

    [Header("Bools")]
    public bool isAccelerating;
    public bool Braking;

    [Header("Slip Values")]
    public float rearSlipLat;
    public float rearSlipLong;

    public float frontSlipLat;
    public float frontSlipLong;

    public Vector3 CamOffset;

    public Text speedText;
    public Text torqueText;
    public Text FLForwardSlipText;
    public Text FLSidewaySlipText;
    public Text RLForwardSlipText;
    public Text RLSidewaySlipText;
    private void Start()
    {
        Colliders = gameObject.transform.Find("WheelColliders").gameObject;
        Meshes = gameObject.transform.Find("WheelMeshes").gameObject;

        frontLeft = Colliders.transform.Find("Wheel_FL").GetComponent<WheelCollider>();
        frontRight = Colliders.transform.Find("Wheel_FR").GetComponent<WheelCollider>();
        rearLeft = Colliders.transform.Find("Wheel_RL").GetComponent<WheelCollider>();
        rearRight = Colliders.transform.Find("Wheel_RR").GetComponent<WheelCollider>();

        frontLeftTransform = Meshes.transform.Find("Tires.FL").GetComponent<Transform>();
        frontRightTransform = Meshes.transform.Find("Tires.FR").GetComponent<Transform>();
        rearLeftTransform = Meshes.transform.Find("Tires.RL").GetComponent<Transform>();
        rearRightTransform = Meshes.transform.Find("Tires.RR").GetComponent<Transform>();

        _IM = GameObject.Find("InputManager").GetComponent<IM>();

        rb = GetComponent<Rigidbody>();
        rb.centerOfMass = centerOfMass;
    }

    private void Update()
    {
        torqueText.text = "Torque: " + currentMotorForce.ToString();
    }

    private void FixedUpdate()
    {
        CalculateBools();
        GetInput();
        HandleMotor();
        HandleSteering();
        UpdateWheels();
        DetectSlip();
    }

    void GetInput()
    {
        ThrottleInput = _IM.Throttle;
        BrakeInput = _IM.Brake;
        SteerInput = _IM.Steer;

        currentMotorForce = ThrottleInput * motorForce;
        currentBrakeForce = BrakeInput * brakeForce;
        currentSteerAngle = SteerInput * maxSteerAngle;
        isHandBraking = _IM.Handbrake;
    }

    private void CalculateBools()
    {
        if (BrakeInput > 0)
        {
            isBraking = true;
        }
        else
        {
            isBraking = false;
        }
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
        float speed = rb.velocity.magnitude * 3.6f;
        speedText.text = "Speed: " + speed.ToString();

        rearLeft.GetGroundHit(out WheelHit wheelData);
        frontLeft.GetGroundHit(out WheelHit wheelData2);

        rearSlipLat = wheelData.sidewaysSlip;
        rearSlipLong = wheelData.forwardSlip;

        frontSlipLat = wheelData2.sidewaysSlip;
        frontSlipLong = wheelData2.forwardSlip;

        FLForwardSlipText.text = "FL Forward Slip:" + frontSlipLong.ToString();
        FLSidewaySlipText.text = "FL Sideways Slip:" + frontSlipLat.ToString() + " RPM:" + frontLeft.rpm;

        RLForwardSlipText.text = "RL Forward Slip:" + rearSlipLong.ToString() + " RPM:" + rearLeft.rpm;
        RLSidewaySlipText.text = "RL Sideways Slip:" + rearSlipLat.ToString();
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
        frontLeft.steerAngle = currentSteerAngle;
        frontRight.steerAngle = currentSteerAngle;
    }

    void HandleMotor()
    {
        if (DType == DriveTrain.All_Wheel_Drive)
        {
            rearLeft.motorTorque = currentMotorForce;
            rearRight.motorTorque = currentMotorForce;
            frontLeft.motorTorque = currentMotorForce;
            frontRight.motorTorque = currentMotorForce;
        }
        else if(DType == DriveTrain.Rear_Wheel_Drive)
        {
            rearLeft.motorTorque = currentMotorForce;
            rearRight.motorTorque = currentMotorForce;
        }
        else if (DType == DriveTrain.Front_Wheel_Drive)
        {
            frontLeft.motorTorque = currentMotorForce;
            frontRight.motorTorque = currentMotorForce;
        }



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
}
