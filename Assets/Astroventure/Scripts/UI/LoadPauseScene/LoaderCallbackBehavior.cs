/***
 * This code snippet has been adapted from a tutorial found at https://www.youtube.com/watch?v=3I5d2rUJ0pE,
 * https://unitycodemonkey.com/video.php?v=3I5d2rUJ0pE
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Runs the Loader class callbacks.
/// </summary>
public class LoaderCallbackBehavior : MonoBehaviour
{
    private bool isFirstUpdate = true;

    /// <summary>
    /// After one Update cycle, calls the Loader's callback to load the scene.
    /// </summary>
    private void Update()
    {
        if (isFirstUpdate)
        {
            isFirstUpdate = false;
            Loader.LoaderCallback();
        }
    }
}
