//------------------------------------------------------------------------------
// <auto-generated>
//     This code was auto-generated by com.unity.inputsystem:InputActionCodeGenerator
//     version 1.3.0
//     from Assets/NotStupid.inputactions
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

public partial class @NotStupid : IInputActionCollection2, IDisposable
{
    public InputActionAsset asset { get; }
    public @NotStupid()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""NotStupid"",
    ""maps"": [
        {
            ""name"": ""CharacterMove"",
            ""id"": ""c5796bb9-eea3-42e9-ba6b-e54208b20ad1"",
            ""actions"": [
                {
                    ""name"": ""Move"",
                    ""type"": ""Value"",
                    ""id"": ""3952c785-6827-4c07-b72d-e9b13b074eb4"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": ""NormalizeVector2"",
                    ""interactions"": """",
                    ""initialStateCheck"": true
                },
                {
                    ""name"": ""Run"",
                    ""type"": ""Button"",
                    ""id"": ""b3a82bbe-e57f-4ea8-8c03-36fcf4af0de0"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FireWeapon"",
                    ""type"": ""Button"",
                    ""id"": ""5189dcbc-321f-4dc6-bb5d-90d4f536f4b9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""FireSplitter"",
                    ""type"": ""Button"",
                    ""id"": ""0f2da9ec-b4be-4c99-8dc3-593085d7e4ec"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Jump"",
                    ""type"": ""Button"",
                    ""id"": ""54bf17fa-880b-4cea-9d39-ed719a89f9e9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""ReturntoOrigin"",
                    ""type"": ""Button"",
                    ""id"": ""804aeb41-e0d3-4cee-8447-a347cf5d10a9"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Interact"",
                    ""type"": ""Button"",
                    ""id"": ""71f350e7-bb7b-44fe-900a-082fffe383f4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                },
                {
                    ""name"": ""Dismiss Opening"",
                    ""type"": ""Button"",
                    ""id"": ""6d6f3f8b-d417-4e69-a28c-9c9e9afcf0b2"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """",
                    ""initialStateCheck"": false
                }
            ],
            ""bindings"": [
                {
                    ""name"": ""2D Vector"",
                    ""id"": ""cf080b6c-9049-4552-b79d-764eb87c0651"",
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
                    ""id"": ""abb1970e-11ee-45e3-87a5-ac5fee7c7ae3"",
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
                    ""id"": ""177e83db-d767-4a1a-883a-5670217b90ea"",
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
                    ""id"": ""d3c0dfb7-a2c1-4ede-9163-35df595235e2"",
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
                    ""id"": ""dc57f9cd-b491-4673-8416-ce7a121505b2"",
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
                    ""id"": ""5108c401-8225-4b84-b3da-361a7f69361c"",
                    ""path"": ""<Keyboard>/shift"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Run"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""3f5fb617-fc60-4b1e-905c-02e31920b88d"",
                    ""path"": ""<Mouse>/leftButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireWeapon"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""cae9efe0-8556-443f-bed3-674dd3ffbdab"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""FireSplitter"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""afc68db5-cbaf-4c82-844d-210a45144f91"",
                    ""path"": ""<Keyboard>/space"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Jump"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""562645f9-d44e-4199-a079-2dc4d1127a20"",
                    ""path"": ""<Keyboard>/q"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""ReturntoOrigin"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""f29335ff-d47d-44e8-92a8-b92a00a7f518"",
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
                    ""id"": ""9de51f52-d68c-4709-a9c9-fb99b9da72bf"",
                    ""path"": ""<Keyboard>/enter"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": """",
                    ""action"": ""Dismiss Opening"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": []
}");
        // CharacterMove
        m_CharacterMove = asset.FindActionMap("CharacterMove", throwIfNotFound: true);
        m_CharacterMove_Move = m_CharacterMove.FindAction("Move", throwIfNotFound: true);
        m_CharacterMove_Run = m_CharacterMove.FindAction("Run", throwIfNotFound: true);
        m_CharacterMove_FireWeapon = m_CharacterMove.FindAction("FireWeapon", throwIfNotFound: true);
        m_CharacterMove_FireSplitter = m_CharacterMove.FindAction("FireSplitter", throwIfNotFound: true);
        m_CharacterMove_Jump = m_CharacterMove.FindAction("Jump", throwIfNotFound: true);
        m_CharacterMove_ReturntoOrigin = m_CharacterMove.FindAction("ReturntoOrigin", throwIfNotFound: true);
        m_CharacterMove_Interact = m_CharacterMove.FindAction("Interact", throwIfNotFound: true);
        m_CharacterMove_DismissOpening = m_CharacterMove.FindAction("Dismiss Opening", throwIfNotFound: true);
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

    // CharacterMove
    private readonly InputActionMap m_CharacterMove;
    private ICharacterMoveActions m_CharacterMoveActionsCallbackInterface;
    private readonly InputAction m_CharacterMove_Move;
    private readonly InputAction m_CharacterMove_Run;
    private readonly InputAction m_CharacterMove_FireWeapon;
    private readonly InputAction m_CharacterMove_FireSplitter;
    private readonly InputAction m_CharacterMove_Jump;
    private readonly InputAction m_CharacterMove_ReturntoOrigin;
    private readonly InputAction m_CharacterMove_Interact;
    private readonly InputAction m_CharacterMove_DismissOpening;
    public struct CharacterMoveActions
    {
        private @NotStupid m_Wrapper;
        public CharacterMoveActions(@NotStupid wrapper) { m_Wrapper = wrapper; }
        public InputAction @Move => m_Wrapper.m_CharacterMove_Move;
        public InputAction @Run => m_Wrapper.m_CharacterMove_Run;
        public InputAction @FireWeapon => m_Wrapper.m_CharacterMove_FireWeapon;
        public InputAction @FireSplitter => m_Wrapper.m_CharacterMove_FireSplitter;
        public InputAction @Jump => m_Wrapper.m_CharacterMove_Jump;
        public InputAction @ReturntoOrigin => m_Wrapper.m_CharacterMove_ReturntoOrigin;
        public InputAction @Interact => m_Wrapper.m_CharacterMove_Interact;
        public InputAction @DismissOpening => m_Wrapper.m_CharacterMove_DismissOpening;
        public InputActionMap Get() { return m_Wrapper.m_CharacterMove; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(CharacterMoveActions set) { return set.Get(); }
        public void SetCallbacks(ICharacterMoveActions instance)
        {
            if (m_Wrapper.m_CharacterMoveActionsCallbackInterface != null)
            {
                @Move.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnMove;
                @Move.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnMove;
                @Move.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnMove;
                @Run.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnRun;
                @Run.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnRun;
                @Run.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnRun;
                @FireWeapon.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnFireWeapon;
                @FireWeapon.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnFireWeapon;
                @FireWeapon.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnFireWeapon;
                @FireSplitter.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnFireSplitter;
                @FireSplitter.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnFireSplitter;
                @FireSplitter.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnFireSplitter;
                @Jump.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnJump;
                @Jump.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnJump;
                @Jump.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnJump;
                @ReturntoOrigin.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnReturntoOrigin;
                @ReturntoOrigin.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnReturntoOrigin;
                @ReturntoOrigin.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnReturntoOrigin;
                @Interact.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnInteract;
                @Interact.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnInteract;
                @Interact.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnInteract;
                @DismissOpening.started -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnDismissOpening;
                @DismissOpening.performed -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnDismissOpening;
                @DismissOpening.canceled -= m_Wrapper.m_CharacterMoveActionsCallbackInterface.OnDismissOpening;
            }
            m_Wrapper.m_CharacterMoveActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Move.started += instance.OnMove;
                @Move.performed += instance.OnMove;
                @Move.canceled += instance.OnMove;
                @Run.started += instance.OnRun;
                @Run.performed += instance.OnRun;
                @Run.canceled += instance.OnRun;
                @FireWeapon.started += instance.OnFireWeapon;
                @FireWeapon.performed += instance.OnFireWeapon;
                @FireWeapon.canceled += instance.OnFireWeapon;
                @FireSplitter.started += instance.OnFireSplitter;
                @FireSplitter.performed += instance.OnFireSplitter;
                @FireSplitter.canceled += instance.OnFireSplitter;
                @Jump.started += instance.OnJump;
                @Jump.performed += instance.OnJump;
                @Jump.canceled += instance.OnJump;
                @ReturntoOrigin.started += instance.OnReturntoOrigin;
                @ReturntoOrigin.performed += instance.OnReturntoOrigin;
                @ReturntoOrigin.canceled += instance.OnReturntoOrigin;
                @Interact.started += instance.OnInteract;
                @Interact.performed += instance.OnInteract;
                @Interact.canceled += instance.OnInteract;
                @DismissOpening.started += instance.OnDismissOpening;
                @DismissOpening.performed += instance.OnDismissOpening;
                @DismissOpening.canceled += instance.OnDismissOpening;
            }
        }
    }
    public CharacterMoveActions @CharacterMove => new CharacterMoveActions(this);
    public interface ICharacterMoveActions
    {
        void OnMove(InputAction.CallbackContext context);
        void OnRun(InputAction.CallbackContext context);
        void OnFireWeapon(InputAction.CallbackContext context);
        void OnFireSplitter(InputAction.CallbackContext context);
        void OnJump(InputAction.CallbackContext context);
        void OnReturntoOrigin(InputAction.CallbackContext context);
        void OnInteract(InputAction.CallbackContext context);
        void OnDismissOpening(InputAction.CallbackContext context);
    }
}