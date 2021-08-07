using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MysteryObjExtraBehavior : MonoBehaviour
{
    public GameObject GmObjToSetActive;

    void OnDestroy()
    {
        GmObjToSetActive.SetActive(true);    
    }
}
