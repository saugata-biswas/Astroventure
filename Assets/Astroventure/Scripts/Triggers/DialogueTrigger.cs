using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public GameObject DialogueGmObj;
    bool dialogueShown = false;
    void OnTriggerEnter(Collider other)
    {
        if (other.name == "Player" && dialogueShown == false)
        {
            DialogueGmObj.SetActive(true);
            dialogueShown = true;
        }
    }
}
