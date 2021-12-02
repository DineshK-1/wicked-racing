// GENERATED AUTOMATICALLY FROM 'Assets/Inputs/Controls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @Controls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @Controls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""Controls"",
    ""maps"": [
        {
            ""name"": ""Car"",
            ""id"": ""1f9c2ad1-5325-4bf8-ab21-881f25ee4ec7"",
            ""actions"": [
                {
                    ""name"": ""Throttle"",
                    ""type"": ""Value"",
                    ""id"": ""b543c5a2-7134-46bc-9a5a-b8890e3b2300"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Brake"",
                    ""type"": ""Value"",
                    ""id"": ""cdb73221-1d80-4f18-8c41-0da5bb5e4e56"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Steer"",
                    ""type"": ""Value"",
                    ""id"": ""67d29b7f-eea0-4aca-ae8c-e09e968bf7b3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""HandBrake"",
                    ""type"": ""Button"",
                    ""id"": ""0b2aaac9-319c-472f-bbcb-7b2a4c662454"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Torque"",
                    ""type"": ""Button"",
                    ""id"": ""0609ea2f-031b-4ce5-8aac-a52c35ad8e81"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""33483ee0-2944-415f-bf59-9c4afd2bd50b"",
                    ""path"": ""<XInputController>/rightTrigger"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""79a5de4a-44fc-4337-bd51-7c1f0cc7c3e5"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Throttle"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""4e6b1af5-9693-483a-9793-9c35ef2269a1"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""3091f0d7-3c60-48d1-9f3e-859d6b124af9"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""696a3424-6aad-46a0-b8fc-aa8ca2cc5f75"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""542282a7-9bda-4b6a-abd9-95503f9dd0ae"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Steer"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""3288f126-1cd4-41aa-9a5b-a17ae6394c88"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""bcb9c5d5-68ce-4e02-af82-56aa4d6b3fe6"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""HandBrake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ec577b32-1f98-44ab-9840-d4fa140f7d9d"",
                    ""path"": ""<Keyboard>/numpadPlus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Torque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5bfd8702-edbb-4057-a3f2-cf7fa715fe4d"",
                    ""path"": ""<Keyboard>/minus"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Torque"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""XD"",
            ""bindingGroup"": ""XD"",
            ""devices"": []
        },
        {
            ""name"": ""New control scheme"",
            ""bindingGroup"": ""New control scheme"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Gamepad>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // Car
        m_Car = asset.FindActionMap("Car", throwIfNotFound: true);
        m_Car_Throttle = m_Car.FindAction("Throttle", throwIfNotFound: true);
        m_Car_Brake = m_Car.FindAction("Brake", throwIfNotFound: true);
        m_Car_Steer = m_Car.FindAction("Steer", throwIfNotFound: true);
        m_Car_HandBrake = m_Car.FindAction("HandBrake", throwIfNotFound: true);
        m_Car_Torque = m_Car.FindAction("Torque", throwIfNotFound: true);
    }

    public void Dispose()
    {
        UnityEngine.Object.Destroy(asset);
    }

    public InputBinding? bindingMask
    {
        get => asset.bindingMask;
        set => asset.bindingMask = value;
    }

    public ReadOnlyArray<InputDevice>? devices
    {
        get => asset.devices;
        set => asset.devices = value;
    }

    public ReadOnlyArray<InputControlScheme> controlSchemes => asset.controlSchemes;

    public bool Contains(InputAction action)
    {
        return asset.Contains(action);
    }

    public IEnumerator<InputAction> GetEnumerator()
    {
        return asset.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Enable()
    {
        asset.Enable();
    }

    public void Disable()
    {
        asset.Disable();
    }

    // Car
    private readonly InputActionMap m_Car;
    private ICarActions m_CarActionsCallbackInterface;
    private readonly InputAction m_Car_Throttle;
    private readonly InputAction m_Car_Brake;
    private readonly InputAction m_Car_Steer;
    private readonly InputAction m_Car_HandBrake;
    private readonly InputAction m_Car_Torque;
    public struct CarActions
    {
        private @Controls m_Wrapper;
        public CarActions(@Controls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Throttle => m_Wrapper.m_Car_Throttle;
        public InputAction @Brake => m_Wrapper.m_Car_Brake;
        public InputAction @Steer => m_Wrapper.m_Car_Steer;
        public InputAction @HandBrake => m_Wrapper.m_Car_HandBrake;
        public InputAction @Torque => m_Wrapper.m_Car_Torque;
        public InputActionMap Get() { return m_Wrapper.m_Car; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CarActions set) { return set.Get(); }
        public void SetCallbacks(ICarActions instance)
        {
            if (m_Wrapper.m_CarActionsCallbackInterface != null)
            {
                @Throttle.started -= m_Wrapper.m_CarActionsCallbackInterface.OnThrottle;
                @Throttle.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnThrottle;
                @Throttle.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnThrottle;
                @Brake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Brake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnBrake;
                @Steer.started -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Steer.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @Steer.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnSteer;
                @HandBrake.started -= m_Wrapper.m_CarActionsCallbackInterface.OnHandBrake;
                @HandBrake.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnHandBrake;
                @HandBrake.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnHandBrake;
                @Torque.started -= m_Wrapper.m_CarActionsCallbackInterface.OnTorque;
                @Torque.performed -= m_Wrapper.m_CarActionsCallbackInterface.OnTorque;
                @Torque.canceled -= m_Wrapper.m_CarActionsCallbackInterface.OnTorque;
            }
            m_Wrapper.m_CarActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Throttle.started += instance.OnThrottle;
                @Throttle.performed += instance.OnThrottle;
                @Throttle.canceled += instance.OnThrottle;
                @Brake.started += instance.OnBrake;
                @Brake.performed += instance.OnBrake;
                @Brake.canceled += instance.OnBrake;
                @Steer.started += instance.OnSteer;
                @Steer.performed += instance.OnSteer;
                @Steer.canceled += instance.OnSteer;
                @HandBrake.started += instance.OnHandBrake;
                @HandBrake.performed += instance.OnHandBrake;
                @HandBrake.canceled += instance.OnHandBrake;
                @Torque.started += instance.OnTorque;
                @Torque.performed += instance.OnTorque;
                @Torque.canceled += instance.OnTorque;
            }
        }
    }
    public CarActions @Car => new CarActions(this);
    private int m_XDSchemeIndex = -1;
    public InputControlScheme XDScheme
    {
        get
        {
            if (m_XDSchemeIndex == -1) m_XDSchemeIndex = asset.FindControlSchemeIndex("XD");
            return asset.controlSchemes[m_XDSchemeIndex];
        }
    }
    private int m_NewcontrolschemeSchemeIndex = -1;
    public InputControlScheme NewcontrolschemeScheme
    {
        get
        {
            if (m_NewcontrolschemeSchemeIndex == -1) m_NewcontrolschemeSchemeIndex = asset.FindControlSchemeIndex("New control scheme");
            return asset.controlSchemes[m_NewcontrolschemeSchemeIndex];
        }
    }
    public interface ICarActions
    {
        void OnThrottle(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnSteer(InputAction.CallbackContext context);
        void OnHandBrake(InputAction.CallbackContext context);
        void OnTorque(InputAction.CallbackContext context);
    }
}
