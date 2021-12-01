using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public PlayerInput m_PlayerInput;
    private InputAction m_Steer;
    private InputAction m_Throttle;
    private InputAction m_Brake;

    public float Throttle;
    public float Steer;
    public float Brake;

    private void Awake()
    {
        m_Throttle = m_PlayerInput.actions["Throttle"];
        m_Steer = m_PlayerInput.actions["Steer"];
        m_Brake = m_PlayerInput.actions["Brake"];
    }

    private void Update()
    {
        Throttle = m_Throttle.ReadValue<float>();
    }

}
