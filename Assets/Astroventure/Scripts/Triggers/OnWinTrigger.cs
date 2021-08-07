using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class OnWinTrigger : MonoBehaviour, GuiControls.IGuiActions
{
    private GuiControls guiControls;

    void Awake()
    {
        guiControls = new GuiControls();
        guiControls.Gui.SetCallbacks(this);
    }

    public void OnClose(InputAction.CallbackContext context)
    {

    }

    public void OnChoose1(InputAction.CallbackContext context)
    {
        Loader.Load(Loader.Scene.Menu);
    }

    public void OnChoose2(InputAction.CallbackContext context)
    {
        Application.Quit();
    }

    private void OnEnable()
    {
        guiControls.Enable();
    }

    private void OnDisable()
    {
        guiControls.Disable();
    }
}
