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

    public string GetInventoryListString()
    {
        if (Inventory.Count == 0)
            return "";

        string itemList = "Inventory items: ";
        for (int i = 0; i < Inventory.Count; i++)
        {
            itemList = itemList + Inventory[i] + ", ";
        }

        return itemList;
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
