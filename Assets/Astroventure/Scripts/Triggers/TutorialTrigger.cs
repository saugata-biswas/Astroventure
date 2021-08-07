using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class TutorialTrigger : MonoBehaviour, GuiControls.IGuiActions
{
    public GameObject TutorialCanvas;
    private GuiControls guiControls;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            TutorialCanvas.SetActive(true);
        }
    }

    public void CloseDoorTutorial()
    {
        Destroy(gameObject);
    }

    void Awake()
    {
        guiControls = new GuiControls();
        guiControls.Gui.SetCallbacks(this);
    }

    public void OnClose(InputAction.CallbackContext context)
    {
        if (context.performed)
        {
            Destroy(gameObject);
        }
    }

    public void OnChoose1(InputAction.CallbackContext context)
    { 
    }

    public void OnChoose2(InputAction.CallbackContext context)
    { 
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
