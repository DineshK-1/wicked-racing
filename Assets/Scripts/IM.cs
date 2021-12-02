using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class IM : MonoBehaviour
{
    public PlayerInput m_PlayerInput;
    private InputActionMap Car;
    private InputAction m_Steer;
    private InputAction m_Throttle;
    private InputAction m_Brake;
    private InputAction m_HandBrake;

    public float Throttle;
    public float Steer;
    public float Brake;
    public bool Handbrake;
    public bool TorqueI;

    private void Awake()
    { 
        m_Throttle = m_PlayerInput.actions["Throttle"];
        m_Steer = m_PlayerInput.actions["Steer"];
        m_Brake = m_PlayerInput.actions["Brake"];
        m_HandBrake = m_PlayerInput.actions["HandBrake"];

        m_Throttle.performed += M_Throttle_performed;
        m_Throttle.canceled += M_Throttle_canceled;

        m_Steer.performed += M_Steer_performed;
        m_Steer.canceled += M_Steer_canceled;

        m_Brake.performed += M_Brake_performed;
        m_Brake.canceled += M_Brake_canceled;

        m_HandBrake.started += M_HandBrake_started;
        m_HandBrake.canceled += M_HandBrake_canceled;

        m_Throttle.Enable();
        m_Steer.Enable();
        m_Brake.Enable();
        m_HandBrake.Enable();
    }

    private void M_HandBrake_canceled(InputAction.CallbackContext obj)
    {
        Handbrake = false;
    }

    private void M_HandBrake_started(InputAction.CallbackContext obj)
    {
        Handbrake = true;
    }

    private void M_Brake_canceled(InputAction.CallbackContext obj)
    {
        Brake = 0;
    }

    private void M_Brake_performed(InputAction.CallbackContext obj)
    {
        Brake = obj.ReadValue<float>();
    }

    private void M_Steer_canceled(InputAction.CallbackContext obj)
    {
        Steer = 0;
    }

    private void M_Steer_performed(InputAction.CallbackContext obj)
    {
        Steer = obj.ReadValue<float>();
    }

    private void M_Throttle_canceled(InputAction.CallbackContext obj)
    {
        Throttle = 0;
    }

    private void M_Throttle_performed(InputAction.CallbackContext obj)
    {
        Throttle = obj.ReadValue<float>();
    }
}
