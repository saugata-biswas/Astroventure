// GENERATED AUTOMATICALLY FROM 'Assets/Astroventure/InputActions/LookControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

namespace Astroventure.Controls
{
    public class @LookControls : IInputActionCollection, IDisposable
    {
        public InputActionAsset asset { get; }
        public @LookControls()
        {
            asset = InputActionAsset.FromJson(@"{
    ""name"": ""LookControls"",
    ""maps"": [
        {
            ""name"": ""Mouse"",
            ""id"": ""a4609511-851a-466f-8f00-9759d8f6fe60"",
            ""actions"": [
                {
                    ""name"": ""MouseLook"",
                    ""type"": ""PassThrough"",
                    ""id"": ""f8bf212f-2167-49db-a3af-9b9360637a04"",
                    ""expectedControlType"": ""Vector2"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""FocusAim"",
                    ""type"": ""Button"",
                    ""id"": ""506ccff5-ad30-43bc-ae5d-925818434c51"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""b2c03381-7f3d-42e2-8fb6-c0b33c5dae1d"",
                    ""path"": ""<Mouse>/delta"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""e18f546c-7309-4c4c-9272-0f333b0a2fe3"",
                    ""path"": ""<Gamepad>/rightStick"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""MouseLook"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""245f3d61-a0ec-4d7e-aeee-99620d4fe278"",
                    ""path"": ""<Mouse>/rightButton"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""FocusAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""fbf7aa9f-0286-42a0-a2a7-70d70cdbf9cc"",
                    ""path"": ""<Gamepad>/rightShoulder"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""Gamepad"",
                    ""action"": ""FocusAim"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                }
            ]
        }
    ],
    ""controlSchemes"": [
        {
            ""name"": ""KeyboardAndMouse"",
            ""bindingGroup"": ""KeyboardAndMouse"",
            ""devices"": [
                {
                    ""devicePath"": ""<Keyboard>"",
                    ""isOptional"": false,
                    ""isOR"": false
                },
                {
                    ""devicePath"": ""<Mouse>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        },
        {
            ""name"": ""Gamepad"",
            ""bindingGroup"": ""Gamepad"",
            ""devices"": [
                {
                    ""devicePath"": ""<XInputController>"",
                    ""isOptional"": false,
                    ""isOR"": false
                }
            ]
        }
    ]
}");
            // Mouse
            m_Mouse = asset.FindActionMap("Mouse", throwIfNotFound: true);
            m_Mouse_MouseLook = m_Mouse.FindAction("MouseLook", throwIfNotFound: true);
            m_Mouse_FocusAim = m_Mouse.FindAction("FocusAim", throwIfNotFound: true);
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

        // Mouse
        private readonly InputActionMap m_Mouse;
        private IMouseActions m_MouseActionsCallbackInterface;
        private readonly InputAction m_Mouse_MouseLook;
        private readonly InputAction m_Mouse_FocusAim;
        public struct MouseActions
        {
            private @LookControls m_Wrapper;
            public MouseActions(@LookControls wrapper) { m_Wrapper = wrapper; }
            public InputAction @MouseLook => m_Wrapper.m_Mouse_MouseLook;
            public InputAction @FocusAim => m_Wrapper.m_Mouse_FocusAim;
            public InputActionMap Get() { return m_Wrapper.m_Mouse; }
            public void Enable() { Get().Enable(); }
            public void Disable() { Get().Disable(); }
            public bool enabled => Get().enabled;
            public static implicit operator InputActionMap(MouseActions set) { return set.Get(); }
            public void SetCallbacks(IMouseActions instance)
            {
                if (m_Wrapper.m_MouseActionsCallbackInterface != null)
                {
                    @MouseLook.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
                    @MouseLook.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
                    @MouseLook.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnMouseLook;
                    @FocusAim.started -= m_Wrapper.m_MouseActionsCallbackInterface.OnFocusAim;
                    @FocusAim.performed -= m_Wrapper.m_MouseActionsCallbackInterface.OnFocusAim;
                    @FocusAim.canceled -= m_Wrapper.m_MouseActionsCallbackInterface.OnFocusAim;
                }
                m_Wrapper.m_MouseActionsCallbackInterface = instance;
                if (instance != null)
                {
                    @MouseLook.started += instance.OnMouseLook;
                    @MouseLook.performed += instance.OnMouseLook;
                    @MouseLook.canceled += instance.OnMouseLook;
                    @FocusAim.started += instance.OnFocusAim;
                    @FocusAim.performed += instance.OnFocusAim;
                    @FocusAim.canceled += instance.OnFocusAim;
                }
            }
        }
        public MouseActions @Mouse => new MouseActions(this);
        private int m_KeyboardAndMouseSchemeIndex = -1;
        public InputControlScheme KeyboardAndMouseScheme
        {
            get
            {
                if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
                return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
            }
        }
        private int m_GamepadSchemeIndex = -1;
        public InputControlScheme GamepadScheme
        {
            get
            {
                if (m_GamepadSchemeIndex == -1) m_GamepadSchemeIndex = asset.FindControlSchemeIndex("Gamepad");
                return asset.controlSchemes[m_GamepadSchemeIndex];
            }
        }
        public interface IMouseActions
        {
            void OnMouseLook(InputAction.CallbackContext context);
            void OnFocusAim(InputAction.CallbackContext context);
        }
    }
}
