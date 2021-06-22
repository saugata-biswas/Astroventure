using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GetBallTrigger : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "ThirdPersonPlayer")
        {
            this.transform.parent.gameObject.SetActive(false);
            other.gameObject.GetComponent<Astroventure.Controls.ThirdPersonMovement>().currentInventory.Add("Ball");
        }
    }
}
