using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject DialogueGmObj;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "ThirdPersonPlayer")
        {
            DialogueGmObj.SetActive(true);
        }
    }
}
