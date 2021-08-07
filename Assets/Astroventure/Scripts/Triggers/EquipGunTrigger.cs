using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipGunTrigger : MonoBehaviour
{
    public GameObject PlayerObj;
    public AnimationSwitcher animationSwitcher;
    public GameObject GunOnAnimator;

    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player")
        {
            InventoryManager inventoryManager = PlayerObj.GetComponent<InventoryManager>();
            inventoryManager.AddItem("Gun");

            Astroventure.Controls.SimpleMoveAndAnimationController moveCrtlr = PlayerObj.GetComponent<Astroventure.Controls.SimpleMoveAndAnimationController>();
            moveCrtlr.HasGunAtHand = true;

            animationSwitcher.weaponAtHand = true;
            GunOnAnimator.SetActive(true);

            Destroy(gameObject);
        }
    }
}
