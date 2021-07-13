using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject DialogueGmObj;
    bool dialogueShown = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "ThirdPersonPlayer" && dialogueShown == false)
        {
            DialogueGmObj.SetActive(true);
            dialogueShown = true;
        }
    }
}
