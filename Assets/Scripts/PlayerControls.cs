//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.7.0
//     from Assets/Scripts/PlayerControls.inputactions
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public partial class @PlayerControls: IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @PlayerControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""PlayerControls"",
    ""maps"": [
        {
            ""name"": ""gameplay"",
            ""id"": ""5a152aa5-ce4c-4678-a97e-3d2fcef516ba"",
            ""actions"": [
                {
                    ""name"": ""accelerate"",
                    ""type"": ""Value"",
                    ""id"": ""e2062c40-563c-4113-a080-9c5c47d5c13b"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""brake"",
                    ""type"": ""Value"",
                    ""id"": ""4baffbd5-418b-46d3-91ca-a9f687347dc3"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""roll"",
                    ""type"": ""Value"",
                    ""id"": ""1682d68b-9315-4864-a3e8-b96474d46ae6"",
                    ""expectedControlType"": ""Axis"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""turn"",
                    ""type"": ""Value"",
                    ""id"": ""c99209c7-8fa0-4995-818c-21bcb2bbd083"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""InvertVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""fire cannon"",
                    ""type"": ""Button"",
                    ""id"": ""c03db8bd-5c56-466c-810c-65e33f9ef5bd"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""fire missile"",
                    ""type"": ""Button"",
                    ""id"": ""5dcf7ad4-0bdd-43da-ba84-d0485fcfcf2b"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""toggle landing gear"",
                    ""type"": ""Button"",
                    ""id"": ""fe1c7e9a-0a45-4e92-b998-026f2eba9f60"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""toggle auto speed"",
                    ""type"": ""Button"",
                    ""id"": ""da690826-a529-4f24-941a-6d1f202c11d6"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""866a6e47-aab6-4abb-9130-0119f58c2761"",
                    ""path"": ""<Keyboard>/o"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""fire cannon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""7a64551b-14d2-415b-97db-b3855bb62943"",
                    ""path"": ""<Keyboard>/p"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""fire missile"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3d6819ab-5273-4f2c-bd2f-868dded4fa02"",
                    ""path"": ""<Keyboard>/r"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""toggle landing gear"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""cc95c7ee-25d4-430f-a665-bae3ee3e486c"",
                    ""path"": ""1DAxis(minValue=0)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""accelerate"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""31966a26-8a73-45d7-b1c1-b01d7c847d91"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""accelerate"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""3ba4f94e-8d02-4ca2-9b12-7f12fc842504"",
                    ""path"": ""2DVector(mode=2)"",
                    ""interactions"": """",
                    ""processors"": ""InvertVector2(invertY=false)"",
                    ""groups"": """",
                    ""action"": ""turn"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""up"",
                    ""id"": ""2336066a-bb1e-4488-a219-ee3f62b8de26"",
                    ""path"": ""<Keyboard>/s"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""down"",
                    ""id"": ""1ac48977-153c-4f93-aefd-b18d0b30c9f0"",
                    ""path"": ""<Keyboard>/w"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""left"",
                    ""id"": ""1598be3b-7ea0-4fc4-9e35-785ebde7ab50"",
                    ""path"": ""<Keyboard>/a"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""right"",
                    ""id"": ""55459a08-fa33-4339-90ec-00b58b08cd05"",
                    ""path"": ""<Keyboard>/d"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""turn"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": """",
                    ""id"": ""44ac5227-8e9c-4b04-8534-6be4c43998c5"",
                    ""path"": ""<Keyboard>/y"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""toggle auto speed"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""8b9d5c9e-7837-4f1a-a4f1-b048029518a3"",
                    ""path"": ""1DAxis(minValue=0)"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""brake"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""6f12c665-f185-48a4-a2ae-9704da58a332"",
                    ""path"": ""<Keyboard>/leftCtrl"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""brake"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""1D Axis"",
                    ""id"": ""ca72fca0-742b-437e-b2d5-4e1f725a4c33"",
                    ""path"": ""1DAxis"",
                    ""interactions"": """",
                    ""processors"": ""Invert"",
                    ""groups"": """",
                    ""action"": ""roll"",
                    ""isComposite"": true,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": ""negative"",
                    ""id"": ""f003cba9-b665-4e84-b58a-c12d5529c27b"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                },
                {
                    ""name"": ""positive"",
                    ""id"": ""8ecb3472-cca6-4e1e-8d4c-ab4d218e070a"",
                    ""path"": ""<Keyboard>/e"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Keyboard"",
                    ""action"": ""roll"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": true
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""Keyboard"",
            ""bindingGroup"": ""Keyboard"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": true,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
        // gameplay
        m_gameplay = asset.FindActionMap("gameplay", throwIfNotFound: true);
        m_gameplay_accelerate = m_gameplay.FindAction("accelerate", throwIfNotFound: true);
        m_gameplay_brake = m_gameplay.FindAction("brake", throwIfNotFound: true);
        m_gameplay_roll = m_gameplay.FindAction("roll", throwIfNotFound: true);
        m_gameplay_turn = m_gameplay.FindAction("turn", throwIfNotFound: true);
        m_gameplay_firecannon = m_gameplay.FindAction("fire cannon", throwIfNotFound: true);
        m_gameplay_firemissile = m_gameplay.FindAction("fire missile", throwIfNotFound: true);
        m_gameplay_togglelandinggear = m_gameplay.FindAction("toggle landing gear", throwIfNotFound: true);
        m_gameplay_toggleautospeed = m_gameplay.FindAction("toggle auto speed", throwIfNotFound: true);
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

    public IEnumerable<InputBinding> bindings => asset.bindings;

    public InputAction FindAction(string actionNameOrId, bool throwIfNotFound = false)
    {
        return asset.FindAction(actionNameOrId, throwIfNotFound);
    }

    public int FindBinding(InputBinding bindingMask, out InputAction action)
    {
        return asset.FindBinding(bindingMask, out action);
    }

    // gameplay
    private readonly InputActionMap m_gameplay;
    private List<IGameplayActions> m_GameplayActionsCallbackInterfaces = new List<IGameplayActions>();
    private readonly InputAction m_gameplay_accelerate;
    private readonly InputAction m_gameplay_brake;
    private readonly InputAction m_gameplay_roll;
    private readonly InputAction m_gameplay_turn;
    private readonly InputAction m_gameplay_firecannon;
    private readonly InputAction m_gameplay_firemissile;
    private readonly InputAction m_gameplay_togglelandinggear;
    private readonly InputAction m_gameplay_toggleautospeed;
    public struct GameplayActions
    {
        private @PlayerControls m_Wrapper;
        public GameplayActions(@PlayerControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @accelerate => m_Wrapper.m_gameplay_accelerate;
        public InputAction @brake => m_Wrapper.m_gameplay_brake;
        public InputAction @roll => m_Wrapper.m_gameplay_roll;
        public InputAction @turn => m_Wrapper.m_gameplay_turn;
        public InputAction @firecannon => m_Wrapper.m_gameplay_firecannon;
        public InputAction @firemissile => m_Wrapper.m_gameplay_firemissile;
        public InputAction @togglelandinggear => m_Wrapper.m_gameplay_togglelandinggear;
        public InputAction @toggleautospeed => m_Wrapper.m_gameplay_toggleautospeed;
        public InputActionMap Get() { return m_Wrapper.m_gameplay; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GameplayActions set) { return set.Get(); }
        public void AddCallbacks(IGameplayActions instance)
        {
            if (instance == null || m_Wrapper.m_GameplayActionsCallbackInterfaces.Contains(instance)) return;
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Add(instance);
            @accelerate.started += instance.OnAccelerate;
            @accelerate.performed += instance.OnAccelerate;
            @accelerate.canceled += instance.OnAccelerate;
            @brake.started += instance.OnBrake;
            @brake.performed += instance.OnBrake;
            @brake.canceled += instance.OnBrake;
            @roll.started += instance.OnRoll;
            @roll.performed += instance.OnRoll;
            @roll.canceled += instance.OnRoll;
            @turn.started += instance.OnTurn;
            @turn.performed += instance.OnTurn;
            @turn.canceled += instance.OnTurn;
            @firecannon.started += instance.OnFirecannon;
            @firecannon.performed += instance.OnFirecannon;
            @firecannon.canceled += instance.OnFirecannon;
            @firemissile.started += instance.OnFiremissile;
            @firemissile.performed += instance.OnFiremissile;
            @firemissile.canceled += instance.OnFiremissile;
            @togglelandinggear.started += instance.OnTogglelandinggear;
            @togglelandinggear.performed += instance.OnTogglelandinggear;
            @togglelandinggear.canceled += instance.OnTogglelandinggear;
            @toggleautospeed.started += instance.OnToggleautospeed;
            @toggleautospeed.performed += instance.OnToggleautospeed;
            @toggleautospeed.canceled += instance.OnToggleautospeed;
        }

        private void UnregisterCallbacks(IGameplayActions instance)
        {
            @accelerate.started -= instance.OnAccelerate;
            @accelerate.performed -= instance.OnAccelerate;
            @accelerate.canceled -= instance.OnAccelerate;
            @brake.started -= instance.OnBrake;
            @brake.performed -= instance.OnBrake;
            @brake.canceled -= instance.OnBrake;
            @roll.started -= instance.OnRoll;
            @roll.performed -= instance.OnRoll;
            @roll.canceled -= instance.OnRoll;
            @turn.started -= instance.OnTurn;
            @turn.performed -= instance.OnTurn;
            @turn.canceled -= instance.OnTurn;
            @firecannon.started -= instance.OnFirecannon;
            @firecannon.performed -= instance.OnFirecannon;
            @firecannon.canceled -= instance.OnFirecannon;
            @firemissile.started -= instance.OnFiremissile;
            @firemissile.performed -= instance.OnFiremissile;
            @firemissile.canceled -= instance.OnFiremissile;
            @togglelandinggear.started -= instance.OnTogglelandinggear;
            @togglelandinggear.performed -= instance.OnTogglelandinggear;
            @togglelandinggear.canceled -= instance.OnTogglelandinggear;
            @toggleautospeed.started -= instance.OnToggleautospeed;
            @toggleautospeed.performed -= instance.OnToggleautospeed;
            @toggleautospeed.canceled -= instance.OnToggleautospeed;
        }

        public void RemoveCallbacks(IGameplayActions instance)
        {
            if (m_Wrapper.m_GameplayActionsCallbackInterfaces.Remove(instance))
                UnregisterCallbacks(instance);
        }

        public void SetCallbacks(IGameplayActions instance)
        {
            foreach (var item in m_Wrapper.m_GameplayActionsCallbackInterfaces)
                UnregisterCallbacks(item);
            m_Wrapper.m_GameplayActionsCallbackInterfaces.Clear();
            AddCallbacks(instance);
        }
    }
    public GameplayActions @gameplay => new GameplayActions(this);
    private int m_KeyboardSchemeIndex = -1;
    public InputControlScheme KeyboardScheme
    {
        get
        {
            if (m_KeyboardSchemeIndex == -1) m_KeyboardSchemeIndex = asset.FindControlSchemeIndex("Keyboard");
            return asset.controlSchemes[m_KeyboardSchemeIndex];
        }
    }
    public interface IGameplayActions
    {
        void OnAccelerate(InputAction.CallbackContext context);
        void OnBrake(InputAction.CallbackContext context);
        void OnRoll(InputAction.CallbackContext context);
        void OnTurn(InputAction.CallbackContext context);
        void OnFirecannon(InputAction.CallbackContext context);
        void OnFiremissile(InputAction.CallbackContext context);
        void OnTogglelandinggear(InputAction.CallbackContext context);
        void OnToggleautospeed(InputAction.CallbackContext context);
    }
}
