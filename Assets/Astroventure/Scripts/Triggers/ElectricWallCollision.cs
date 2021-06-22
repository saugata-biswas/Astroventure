using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWallCollision : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ThirdPersonPlayer")
        {
            other.GetComponent<Astroventure.Controls.ThirdPersonMovement>().health -= 50;
        }
    }
}
