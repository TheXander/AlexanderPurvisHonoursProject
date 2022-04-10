// GENERATED AUTOMATICALLY FROM 'Assets/EdditorFiles/InputSystem/PlayerInputActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""b6d53a0f-a5f2-4369-89da-27a1a27478ba"",
            ""actions"": [
                {
                    ""name"": ""Movment"",
                    ""type"": ""Value"",
                    ""id"": ""9b6f761f-9cb7-4e5d-9fcc-16fb74d7c8e1"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""EnterDoor"",
                    ""type"": ""Button"",
                    ""id"": ""0543a022-bf78-4eee-b709-4af0910f59cc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""JoyEnterDoor"",
                    ""type"": ""Value"",
                    ""id"": ""e82dc327-321d-48fb-b1e4-e26457754734"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""d8800996-002f-4583-81fb-2c9a7cb28d9a"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""307df1a8-3e26-4947-a6f7-dbf39f5b5c72"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""7f9e620c-5ed9-4a7c-9d66-0c545105cb35"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""c3ba6cb4-3639-4090-858a-63167930b859"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""78f2c4a2-a03c-4cb3-b923-1f4d7432e56d"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""2898fa38-4816-4312-b314-c2135ae969a1"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""6c23143e-1fa4-42ea-805b-a54b4ac149d0"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Movment"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""45eada9d-cb06-49aa-9f5e-76ab9c634f21"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""EnterDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ff618502-7579-4a79-b53a-60e2f32898d7"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""JoyEnterDoor"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d440e6c-6be9-4592-9197-6c6268dbd5be"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8b201fbb-8eea-452f-afb4-f2b6cc9a569e"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Interact"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // Gameplay
        m_Gameplay = asset.FindActionMap("Gameplay", throwIfNotFound: true);
        m_Gameplay_Movment = m_Gameplay.FindAction("Movment", throwIfNotFound: true);
        m_Gameplay_EnterDoor = m_Gameplay.FindAction("EnterDoor", throwIfNotFound: true);
        m_Gameplay_JoyEnterDoor = m_Gameplay.FindAction("JoyEnterDoor", throwIfNotFound: true);
        m_Gameplay_Interact = m_Gameplay.FindAction("Interact", throwIfNotFound: true);
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

    // Gameplay
    private readonly InputActionMap m_Gameplay;
    private IGameplayActions m_GameplayActionsCallbackInterface;
    private readonly InputAction m_Gameplay_Movment;
    private readonly InputAction m_Gameplay_EnterDoor;
    private readonly InputAction m_Gameplay_JoyEnterDoor;
    private readonly InputAction m_Gameplay_Interact;
    public struct GameplayActions
    {
        private @PlayerInputActions m_Wrapper;
        public GameplayActions(@PlayerInputActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Movment => m_Wrapper.m_Gameplay_Movment;
        public InputAction @EnterDoor => m_Wrapper.m_Gameplay_EnterDoor;
        public InputAction @JoyEnterDoor => m_Wrapper.m_Gameplay_JoyEnterDoor;
        public InputAction @Interact => m_Wrapper.m_Gameplay_Interact;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Movment.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovment;
                @Movment.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovment;
                @Movment.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMovment;
                @EnterDoor.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnterDoor;
                @EnterDoor.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnterDoor;
                @EnterDoor.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnEnterDoor;
                @JoyEnterDoor.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoyEnterDoor;
                @JoyEnterDoor.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoyEnterDoor;
                @JoyEnterDoor.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnJoyEnterDoor;
                @Interact.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnInteract;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Movment.started += instance.OnMovment;
                @Movment.performed += instance.OnMovment;
                @Movment.canceled += instance.OnMovment;
                @EnterDoor.started += instance.OnEnterDoor;
                @EnterDoor.performed += instance.OnEnterDoor;
                @EnterDoor.canceled += instance.OnEnterDoor;
                @JoyEnterDoor.started += instance.OnJoyEnterDoor;
                @JoyEnterDoor.performed += instance.OnJoyEnterDoor;
                @JoyEnterDoor.canceled += instance.OnJoyEnterDoor;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnMovment(InputAction.CallbackContext context);
        void OnEnterDoor(InputAction.CallbackContext context);
        void OnJoyEnterDoor(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
    }
}
