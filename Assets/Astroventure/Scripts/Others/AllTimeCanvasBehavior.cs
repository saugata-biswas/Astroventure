using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class AllTimeCanvasBehavior : MonoBehaviour
{
    [SerializeField] private TMP_Text Hints;
    private bool hintsShowing = false;

    [SerializeField] private InventoryManager inventoryManager;

    [SerializeField] private TMP_Text InventoryTxt;
    private bool inventoryShowing = false;

    [SerializeField] private GameObject mysteryObj;
    [SerializeField] private TMP_Text mysteryObjHealth;

    void Start()
    {
        
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            hintsShowing = !hintsShowing;
        }
        if (hintsShowing == false)
        {
            Hints.text = "Press H for hints, I for inventory.";
        }
        else
        {
            Hints.text = "Hints: Hit red spheres on the doors to break them. Sentinals cant hit above waist height. Particle walls are deadly. It is hard to aim without focusing. Press mouse right click to focus. Press H to turn off.";
        }


        if (Input.GetKeyDown(KeyCode.I))
        {
            inventoryShowing = !inventoryShowing;
        }
        if (inventoryShowing == false)
        {
            //Hints.text = "Press H for hints, I for inventory.";
            InventoryTxt.text = "";
        }
        else
        {
            string inventroy_items = inventoryManager.GetInventoryListString();
            InventoryTxt.text = inventroy_items + " Press I to close.";
        }

        if (mysteryObj != null && mysteryObj.activeSelf)
        {
            mysteryObjHealth.text = "Enemy health: " + mysteryObj.GetComponent<DestroyByBulletBehavior>().GetHealth();
        }
    }
}
