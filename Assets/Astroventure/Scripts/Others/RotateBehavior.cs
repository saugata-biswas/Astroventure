using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateBehavior : MonoBehaviour
{ 
    // Update is called once per frame
    void Update()
    {
        transform.Rotate(0.01f, 0.2f, 0.01f);
    }
}
