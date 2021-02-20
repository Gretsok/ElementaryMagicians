// GENERATED AUTOMATICALLY FROM 'Assets/100_MOtter/Data/PlayerInputsActions.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @PlayerInputsActions : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerInputsActions()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerInputsActions"",
    ""maps"": [
        {
            ""name"": ""Gameplay"",
            ""id"": ""861dc320-463a-4204-88b2-1fcca6c0ed38"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f2567aef-2ad3-4c2c-b7f4-3a0559b337ad"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FirstMage"",
                    ""type"": ""Button"",
                    ""id"": ""bb2c8d64-4737-4ebe-a465-5271f522fd2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SecondMage"",
                    ""type"": ""Button"",
                    ""id"": ""4f690e00-4cc0-4fe7-8327-234cdad871bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""ThirdMage"",
                    ""type"": ""Button"",
                    ""id"": ""cb6bb925-6aba-4827-bda3-85a1da62f1bc"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FourthMage"",
                    ""type"": ""Button"",
                    ""id"": ""b852c74a-72d3-4fab-9bfe-5db9bd36fd28"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FifthMage"",
                    ""type"": ""Button"",
                    ""id"": ""e46e7b83-228a-4611-9907-7098c8dc8eec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SixthMage"",
                    ""type"": ""Button"",
                    ""id"": ""ef9f36d9-09d9-40db-abe0-f2b672844225"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""SeventhMAge"",
                    ""type"": ""Button"",
                    ""id"": ""3c7cc025-1794-4439-bb1b-b63809c787bb"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""7bebde7d-41b3-45de-8fbb-45eec662295a"",
                    ""path"": ""<Gamepad>/leftStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""Keyboard"",
                    ""id"": ""2612feec-41eb-45d2-9d19-d91ec3511c89"",
                    ""path"": ""2DVector"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""532b4980-de96-49ac-b8d0-2aba8cba8036"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""b5fc71c9-ad44-4a36-8acb-4897ba156aa5"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""9335554f-0377-4266-a267-9d3f2bf2eede"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""d6be5ca3-c089-4a15-ade5-14a6b8e25093"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Move"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""6c05ea80-a694-4711-b818-8890f30f28fe"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FirstMage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""b159069e-b363-4cc2-bff4-bc49ed0ea686"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SecondMage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cc541c2e-3900-4ada-9546-b4a2e36418a3"",
                    ""path"": ""<Keyboard>/v"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ThirdMage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""8f353cf7-25d5-4ad8-82f8-26012cede38c"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FourthMage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""0279e93c-ed6c-4d60-9c0b-9ebaab14929d"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FifthMage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""1016aab1-bb95-46b8-ba39-443a067ecd98"",
                    ""path"": ""<Keyboard>/c"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SixthMage"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""95b84360-962f-4ec2-a477-236101a846e4"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""SeventhMAge"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        },
        {
            ""name"": ""Generic"",
            ""id"": ""07e4799b-1630-41f9-9ea6-178181abe909"",
            ""actions"": [
                {
                    ""name"": ""TogglePause"",
                    ""type"": ""Button"",
                    ""id"": ""ff564b29-9830-4d60-b8e9-5be24f3eb378"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b90f259c-9188-4c49-882c-f1bb3ac10238"",
                    ""path"": ""<Keyboard>/escape"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""TogglePause"",
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
        m_Gameplay_Move = m_Gameplay.FindAction("Move", throwIfNotFound: true);
        m_Gameplay_FirstMage = m_Gameplay.FindAction("FirstMage", throwIfNotFound: true);
        m_Gameplay_SecondMage = m_Gameplay.FindAction("SecondMage", throwIfNotFound: true);
        m_Gameplay_ThirdMage = m_Gameplay.FindAction("ThirdMage", throwIfNotFound: true);
        m_Gameplay_FourthMage = m_Gameplay.FindAction("FourthMage", throwIfNotFound: true);
        m_Gameplay_FifthMage = m_Gameplay.FindAction("FifthMage", throwIfNotFound: true);
        m_Gameplay_SixthMage = m_Gameplay.FindAction("SixthMage", throwIfNotFound: true);
        m_Gameplay_SeventhMAge = m_Gameplay.FindAction("SeventhMAge", throwIfNotFound: true);
        // Generic
        m_Generic = asset.FindActionMap("Generic", throwIfNotFound: true);
        m_Generic_TogglePause = m_Generic.FindAction("TogglePause", throwIfNotFound: true);
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
    private readonly InputAction m_Gameplay_Move;
    private readonly InputAction m_Gameplay_FirstMage;
    private readonly InputAction m_Gameplay_SecondMage;
    private readonly InputAction m_Gameplay_ThirdMage;
    private readonly InputAction m_Gameplay_FourthMage;
    private readonly InputAction m_Gameplay_FifthMage;
    private readonly InputAction m_Gameplay_SixthMage;
    private readonly InputAction m_Gameplay_SeventhMAge;
    public struct GameplayActions
    {
        private @PlayerInputsActions m_Wrapper;
        public GameplayActions(@PlayerInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_Gameplay_Move;
        public InputAction @FirstMage => m_Wrapper.m_Gameplay_FirstMage;
        public InputAction @SecondMage => m_Wrapper.m_Gameplay_SecondMage;
        public InputAction @ThirdMage => m_Wrapper.m_Gameplay_ThirdMage;
        public InputAction @FourthMage => m_Wrapper.m_Gameplay_FourthMage;
        public InputAction @FifthMage => m_Wrapper.m_Gameplay_FifthMage;
        public InputAction @SixthMage => m_Wrapper.m_Gameplay_SixthMage;
        public InputAction @SeventhMAge => m_Wrapper.m_Gameplay_SeventhMAge;
        public InputActionMap Get() { return m_Wrapper.m_Gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void SetCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnMove;
                @FirstMage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFirstMage;
                @FirstMage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFirstMage;
                @FirstMage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFirstMage;
                @SecondMage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondMage;
                @SecondMage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondMage;
                @SecondMage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSecondMage;
                @ThirdMage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThirdMage;
                @ThirdMage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThirdMage;
                @ThirdMage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnThirdMage;
                @FourthMage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFourthMage;
                @FourthMage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFourthMage;
                @FourthMage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFourthMage;
                @FifthMage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFifthMage;
                @FifthMage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFifthMage;
                @FifthMage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnFifthMage;
                @SixthMage.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSixthMage;
                @SixthMage.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSixthMage;
                @SixthMage.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSixthMage;
                @SeventhMAge.started -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSeventhMAge;
                @SeventhMAge.performed -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSeventhMAge;
                @SeventhMAge.canceled -= m_Wrapper.m_GameplayActionsCallbackInterface.OnSeventhMAge;
            }
            m_Wrapper.m_GameplayActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @FirstMage.started += instance.OnFirstMage;
                @FirstMage.performed += instance.OnFirstMage;
                @FirstMage.canceled += instance.OnFirstMage;
                @SecondMage.started += instance.OnSecondMage;
                @SecondMage.performed += instance.OnSecondMage;
                @SecondMage.canceled += instance.OnSecondMage;
                @ThirdMage.started += instance.OnThirdMage;
                @ThirdMage.performed += instance.OnThirdMage;
                @ThirdMage.canceled += instance.OnThirdMage;
                @FourthMage.started += instance.OnFourthMage;
                @FourthMage.performed += instance.OnFourthMage;
                @FourthMage.canceled += instance.OnFourthMage;
                @FifthMage.started += instance.OnFifthMage;
                @FifthMage.performed += instance.OnFifthMage;
                @FifthMage.canceled += instance.OnFifthMage;
                @SixthMage.started += instance.OnSixthMage;
                @SixthMage.performed += instance.OnSixthMage;
                @SixthMage.canceled += instance.OnSixthMage;
                @SeventhMAge.started += instance.OnSeventhMAge;
                @SeventhMAge.performed += instance.OnSeventhMAge;
                @SeventhMAge.canceled += instance.OnSeventhMAge;
            }
        }
    }
    public GameplayActions @Gameplay => new GameplayActions(this);

    // Generic
    private readonly InputActionMap m_Generic;
    private IGenericActions m_GenericActionsCallbackInterface;
    private readonly InputAction m_Generic_TogglePause;
    public struct GenericActions
    {
        private @PlayerInputsActions m_Wrapper;
        public GenericActions(@PlayerInputsActions wrapper) { m_Wrapper = wrapper; }
        public InputAction @TogglePause => m_Wrapper.m_Generic_TogglePause;
        public InputActionMap Get() { return m_Wrapper.m_Generic; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GenericActions set) { return set.Get(); }
        public void SetCallbacks(IGenericActions instance)
        {
            if (m_Wrapper.m_GenericActionsCallbackInterface != null)
            {
                @TogglePause.started -= m_Wrapper.m_GenericActionsCallbackInterface.OnTogglePause;
                @TogglePause.performed -= m_Wrapper.m_GenericActionsCallbackInterface.OnTogglePause;
                @TogglePause.canceled -= m_Wrapper.m_GenericActionsCallbackInterface.OnTogglePause;
            }
            m_Wrapper.m_GenericActionsCallbackInterface = instance;
            if (instance != null)
            {
                @TogglePause.started += instance.OnTogglePause;
                @TogglePause.performed += instance.OnTogglePause;
                @TogglePause.canceled += instance.OnTogglePause;
            }
        }
    }
    public GenericActions @Generic => new GenericActions(this);
    public interface IGameplayActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnFirstMage(InputAction.CallbackContext context);
        void OnSecondMage(InputAction.CallbackContext context);
        void OnThirdMage(InputAction.CallbackContext context);
        void OnFourthMage(InputAction.CallbackContext context);
        void OnFifthMage(InputAction.CallbackContext context);
        void OnSixthMage(InputAction.CallbackContext context);
        void OnSeventhMAge(InputAction.CallbackContext context);
    }
    public interface IGenericActions
    {
        void OnTogglePause(InputAction.CallbackContext context);
    }
}
