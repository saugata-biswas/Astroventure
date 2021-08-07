using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


public class GameOverBehavior : MonoBehaviour, GuiControls.IGuiActions
{
    private GuiControls guiControls;

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

    void Awake()
    {
        guiControls = new GuiControls();
        guiControls.Gui.SetCallbacks(this);
    }
}
