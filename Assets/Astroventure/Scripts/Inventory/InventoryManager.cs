using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<string> Inventory;


    void Awake()
    {
        Inventory = new List<string>();
    }

    public void AddItem(string itemName)
    {
        Inventory.Add(itemName);
    }

    public void RemoveItem(string itemName)
    {
        if (Inventory.Contains(itemName))
        {
            Inventory.Remove(itemName);
        }
    }
}
