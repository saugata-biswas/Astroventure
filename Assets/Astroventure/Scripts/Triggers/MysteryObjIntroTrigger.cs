using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MysteryObjIntroTrigger : MonoBehaviour, GuiControls.IGuiActions
{
    [SerializeField] private GameObject CanvasGmObj;
    [SerializeField] private GameObject mysteryObject;
    private GuiControls guiControls;
    [SerializeField] private GameObject player;


    void Awake()
    {
        guiControls = new GuiControls();
        guiControls.Gui.SetCallbacks(this);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            CanvasGmObj.SetActive(true);
        }
    }

    public void OnClose(InputAction.CallbackContext context)
    {
        if (context.performed && Vector3.Distance(gameObject.transform.position, player.transform.position) < 10.0f)
        {
            mysteryObject.SetActive(true);
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
