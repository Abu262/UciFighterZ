// GENERATED AUTOMATICALLY FROM 'Assets/PlayerControls.inputactions'

using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class PlayerControls : IInputActionCollection
{
    private InputActionAsset asset;
    public PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""9a42f278-4b4a-444d-ba6a-59a868049e15"",
            ""actions"": [
                {
                    ""name"": ""Special2"",
                    ""type"": ""Button"",
                    ""id"": ""9bd89045-55b5-4cd1-bbfd-c875ae558820"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""High2"",
                    ""type"": ""Button"",
                    ""id"": ""2a902672-8867-47e9-af88-f29cfd54854d"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Medium2"",
                    ""type"": ""Button"",
                    ""id"": ""ca655958-e966-42d1-bf6a-e71cd9eb2e73"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Low2"",
                    ""type"": ""Button"",
                    ""id"": ""47ee1818-51a7-403e-9031-6f568eab85cc"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move2"",
                    ""type"": ""Button"",
                    ""id"": ""4dfcee81-b86b-469e-8969-27ce286dc5f0"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Special1"",
                    ""type"": ""Button"",
                    ""id"": ""6844c1ea-ad7a-4563-9396-5c1eb9512a9c"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""High1"",
                    ""type"": ""Button"",
                    ""id"": ""5bc37081-4853-406d-9340-71b621a0b171"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Medium1"",
                    ""type"": ""Button"",
                    ""id"": ""cb9d58ca-2a41-493d-9976-40e71ce8af40"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Low1"",
                    ""type"": ""Button"",
                    ""id"": ""70b55abd-5429-4127-9bda-40fbf87fbf0f"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Move1"",
                    ""type"": ""Button"",
                    ""id"": ""da7b9c33-c74a-4c7a-93aa-d23410afbd95"",
                    ""expectedControlType"": """",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""822d053d-8b2f-496b-977b-6c22a5e0d69d"",
                    ""path"": ""<Gamepad>/buttonSouth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3c6a976f-5675-42a0-94e1-2c9493a01284"",
                    ""path"": ""<Gamepad>/buttonWest"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""High2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""708db341-7a50-4f2f-8052-c900bdc911a8"",
                    ""path"": ""<Gamepad>/buttonNorth"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""49833da4-71cd-4827-9ead-867c3ebcf257"",
                    ""path"": ""<Gamepad>/buttonEast"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Low2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7044b80f-1f54-42f1-8555-598dcc4dac9c"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move2"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""401cd225-f280-4a87-9d13-aca50706fd68"",
                    ""path"": ""<Gamepad>/dpad/down"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Special1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""2c533fc8-beda-4b15-8d68-fb3e1ae6512e"",
                    ""path"": ""<Gamepad>/dpad/left"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""High1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""ef234173-c278-430a-88c5-50da4bfe39c7"",
                    ""path"": ""<Gamepad>/dpad/up"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Medium1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0db03e9e-1a2e-4636-8728-1e21c02bdeeb"",
                    ""path"": ""<Gamepad>/dpad/right"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Low1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""5be43a3d-bbdd-4a09-ba78-773e048a9952"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move1"",
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
        m_Gameplay_Special2 = m_Gameplay.FindAction("Special2", throwIfNotFound: true);
        m_Gameplay_High2 = m_Gameplay.FindAction("High2", throwIfNotFound: true);
        m_Gameplay_Medium2 = m_Gameplay.FindAction("Medium2", throwIfNotFound: true);
        m_Gameplay_Low2 = m_Gameplay.FindAction("Low2", throwIfNotFound: true);
        m_Gameplay_Move2 = m_Gameplay.FindAction("Move2", throwIfNotFound: true);
        m_Gameplay_Special1 = m_Gameplay.FindAction("Special1", throwIfNotFound: true);
        m_Gameplay_High1 = m_Gameplay.FindAction("High1", throwIfNotFound: true);
        m_Gameplay_Medium1 = m_Gameplay.FindAction("Medium1", throwIfNotFound: true);
        m_Gameplay_Low1 = m_Gameplay.FindAction("Low1", throwIfNotFound: true);
        m_Gameplay_Move1 = m_Gameplay.FindAction("Move1", throwIfNotFound: true);
    }

    ~PlayerControls()
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
    private readonly InputAction m_Gameplay_Special2;
    private readonly InputAction m_Gameplay_High2;
    private readonly InputAction m_Gameplay_Medium2;
    private readonly InputAction m_Gameplay_Low2;
    private readonly InputAction m_Gameplay_Move2;
    private readonly InputAction m_Gameplay_Special1;
    private readonly InputAction m_Gameplay_High1;
    private readonly InputAction m_Gameplay_Medium1;
    private readonly InputAction m_Gameplay_Low1;
    private readonly InputAction m_Gameplay_Move1;
    public struct GameplayActions
    {
        private PlayerControls m_Wrapper;
        public GameplayActions(PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Special2 => m_Wrapper.m_Gameplay_Special2;
        public InputAction @High2 => m_Wrapper.m_Gameplay_High2;
        public InputAction @Medium2 => m_Wrapper.m_Gameplay_Medium2;
        public InputAction @Low2 => m_Wrapper.m_Gameplay_Low2;
        public InputAction @Move2 => m_Wrapper.m_Gameplay_Move2;
        public InputAction @Special1 => m_Wrapper.m_Gameplay_Special1;
        public InputAction @High1 => m_Wrapper.m_Gameplay_High1;
        public InputAction @Medium1 => m_Wrapper.m_Gameplay_Medium1;
        public InputAction @Low1 => m_Wrapper.m_Gameplay_Low1;
        public InputAction @Move1 => m_Wrapper.m_Gameplay_Move1;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                Special2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial2;
                Special2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial2;
                Special2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial2;
                High2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHigh2;
                High2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHigh2;
                High2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHigh2;
                Medium2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMedium2;
                Medium2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMedium2;
                Medium2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMedium2;
                Low2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLow2;
                Low2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLow2;
                Low2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLow2;
                Move2.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove2;
                Move2.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove2;
                Move2.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove2;
                Special1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial1;
                Special1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial1;
                Special1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSpecial1;
                High1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHigh1;
                High1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHigh1;
                High1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnHigh1;
                Medium1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMedium1;
                Medium1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMedium1;
                Medium1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMedium1;
                Low1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLow1;
                Low1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLow1;
                Low1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnLow1;
                Move1.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove1;
                Move1.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove1;
                Move1.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove1;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                Special2.started += instance.OnSpecial2;
                Special2.performed += instance.OnSpecial2;
                Special2.canceled += instance.OnSpecial2;
                High2.started += instance.OnHigh2;
                High2.performed += instance.OnHigh2;
                High2.canceled += instance.OnHigh2;
                Medium2.started += instance.OnMedium2;
                Medium2.performed += instance.OnMedium2;
                Medium2.canceled += instance.OnMedium2;
                Low2.started += instance.OnLow2;
                Low2.performed += instance.OnLow2;
                Low2.canceled += instance.OnLow2;
                Move2.started += instance.OnMove2;
                Move2.performed += instance.OnMove2;
                Move2.canceled += instance.OnMove2;
                Special1.started += instance.OnSpecial1;
                Special1.performed += instance.OnSpecial1;
                Special1.canceled += instance.OnSpecial1;
                High1.started += instance.OnHigh1;
                High1.performed += instance.OnHigh1;
                High1.canceled += instance.OnHigh1;
                Medium1.started += instance.OnMedium1;
                Medium1.performed += instance.OnMedium1;
                Medium1.canceled += instance.OnMedium1;
                Low1.started += instance.OnLow1;
                Low1.performed += instance.OnLow1;
                Low1.canceled += instance.OnLow1;
                Move1.started += instance.OnMove1;
                Move1.performed += instance.OnMove1;
                Move1.canceled += instance.OnMove1;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);
    public interface IGameplayActions
    {
        void OnSpecial2(InputAction.CallbackContext context);
        void OnHigh2(InputAction.CallbackContext context);
        void OnMedium2(InputAction.CallbackContext context);
        void OnLow2(InputAction.CallbackContext context);
        void OnMove2(InputAction.CallbackContext context);
        void OnSpecial1(InputAction.CallbackContext context);
        void OnHigh1(InputAction.CallbackContext context);
        void OnMedium1(InputAction.CallbackContext context);
        void OnLow1(InputAction.CallbackContext context);
        void OnMove1(InputAction.CallbackContext context);
    }
}
