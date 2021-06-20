// This example is taken from: 
// https://learn.unity.com/tutorial/time-0fbw/?projectId=5df2611eedbc2a0020d90217&tab=overview&uv=2019.4#
// Basically to show how to run updates based on real-time.
// Same result would be generated if you use Time.deltaTime :)

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondsUpdate : MonoBehaviour
{
    float timeStartOffset = 0;
    bool gotStartTime = false;

    void Update()
    {
        if (!gotStartTime)
        {
            timeStartOffset = Time.realtimeSinceStartup;
            gotStartTime = true;
        }

        // example move based on real-time
        this.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, 
            Time.realtimeSinceStartup - timeStartOffset);
    }
}
