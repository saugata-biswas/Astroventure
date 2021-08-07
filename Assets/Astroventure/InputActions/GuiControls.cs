// GENERATED AUTOMATICALLY FROM 'Assets/Astroventure/InputActions/GuiControls.inputactions'

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Utilities;

public class @GuiControls : IInputActionCollection, IDisposable
{
    public InputActionAsset asset { get; }
    public @GuiControls()
    {
        asset = InputActionAsset.FromJson(@"{
    ""name"": ""GuiControls"",
    ""maps"": [
        {
            ""name"": ""Gui"",
            ""id"": ""95f15681-9f0d-40fc-b6a2-f69fce16ce39"",
            ""actions"": [
                {
                    ""name"": ""Close"",
                    ""type"": ""Button"",
                    ""id"": ""a563489a-c322-44a5-9389-8279757acea4"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Choose1"",
                    ""type"": ""Button"",
                    ""id"": ""8311803a-2027-4d19-97ac-b7a7ad4dfa27"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                },
                {
                    ""name"": ""Choose2"",
                    ""type"": ""Button"",
                    ""id"": ""13a2d39d-e4cd-4004-8e4a-b4f208069384"",
                    ""expectedControlType"": ""Button"",
                    ""processors"": """",
                    ""interactions"": """"
                }
            ],
            ""bindings"": [
                {
                    ""name"": """",
                    ""id"": ""e96890fe-f9e9-43e2-a644-8694d9e36a03"",
                    ""path"": ""<Keyboard>/x"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Close"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""063125d8-861e-4a56-8e02-80c61ca123d6"",
                    ""path"": ""<Keyboard>/1"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Choose1"",
                    ""isComposite"": false,
                    ""isPartOfComposite"": false
                },
                {
                    ""name"": """",
                    ""id"": ""28f1ee8b-dcc5-427c-997c-a264e28352b2"",
                    ""path"": ""<Keyboard>/2"",
                    ""interactions"": """",
                    ""processors"": """",
                    ""groups"": ""KeyboardAndMouse"",
                    ""action"": ""Choose2"",
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
            ""devices"": []
        }
    ]
}");
        // Gui
        m_Gui = asset.FindActionMap("Gui", throwIfNotFound: true);
        m_Gui_Close = m_Gui.FindAction("Close", throwIfNotFound: true);
        m_Gui_Choose1 = m_Gui.FindAction("Choose1", throwIfNotFound: true);
        m_Gui_Choose2 = m_Gui.FindAction("Choose2", throwIfNotFound: true);
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

    // Gui
    private readonly InputActionMap m_Gui;
    private IGuiActions m_GuiActionsCallbackInterface;
    private readonly InputAction m_Gui_Close;
    private readonly InputAction m_Gui_Choose1;
    private readonly InputAction m_Gui_Choose2;
    public struct GuiActions
    {
        private @GuiControls m_Wrapper;
        public GuiActions(@GuiControls wrapper) { m_Wrapper = wrapper; }
        public InputAction @Close => m_Wrapper.m_Gui_Close;
        public InputAction @Choose1 => m_Wrapper.m_Gui_Choose1;
        public InputAction @Choose2 => m_Wrapper.m_Gui_Choose2;
        public InputActionMap Get() { return m_Wrapper.m_Gui; }
        public void Enable() { Get().Enable(); }
        public void Disable() { Get().Disable(); }
        public bool enabled => Get().enabled;
        public static implicit operator InputActionMap(GuiActions set) { return set.Get(); }
        public void SetCallbacks(IGuiActions instance)
        {
            if (m_Wrapper.m_GuiActionsCallbackInterface != null)
            {
                @Close.started -= m_Wrapper.m_GuiActionsCallbackInterface.OnClose;
                @Close.performed -= m_Wrapper.m_GuiActionsCallbackInterface.OnClose;
                @Close.canceled -= m_Wrapper.m_GuiActionsCallbackInterface.OnClose;
                @Choose1.started -= m_Wrapper.m_GuiActionsCallbackInterface.OnChoose1;
                @Choose1.performed -= m_Wrapper.m_GuiActionsCallbackInterface.OnChoose1;
                @Choose1.canceled -= m_Wrapper.m_GuiActionsCallbackInterface.OnChoose1;
                @Choose2.started -= m_Wrapper.m_GuiActionsCallbackInterface.OnChoose2;
                @Choose2.performed -= m_Wrapper.m_GuiActionsCallbackInterface.OnChoose2;
                @Choose2.canceled -= m_Wrapper.m_GuiActionsCallbackInterface.OnChoose2;
            }
            m_Wrapper.m_GuiActionsCallbackInterface = instance;
            if (instance != null)
            {
                @Close.started += instance.OnClose;
                @Close.performed += instance.OnClose;
                @Close.canceled += instance.OnClose;
                @Choose1.started += instance.OnChoose1;
                @Choose1.performed += instance.OnChoose1;
                @Choose1.canceled += instance.OnChoose1;
                @Choose2.started += instance.OnChoose2;
                @Choose2.performed += instance.OnChoose2;
                @Choose2.canceled += instance.OnChoose2;
            }
        }
    }
    public GuiActions @Gui => new GuiActions(this);
    private int m_KeyboardAndMouseSchemeIndex = -1;
    public InputControlScheme KeyboardAndMouseScheme
    {
        get
        {
            if (m_KeyboardAndMouseSchemeIndex == -1) m_KeyboardAndMouseSchemeIndex = asset.FindControlSchemeIndex("KeyboardAndMouse");
            return asset.controlSchemes[m_KeyboardAndMouseSchemeIndex];
        }
    }
    public interface IGuiActions
    {
        void OnClose(InputAction.CallbackContext context);
        void OnChoose1(InputAction.CallbackContext context);
        void OnChoose2(InputAction.CallbackContext context);
    }
}
