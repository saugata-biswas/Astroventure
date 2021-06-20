/***
 * This code snippet has been adapted from a tutorial found at https://www.youtube.com/watch?v=3I5d2rUJ0pE,
 * https://unitycodemonkey.com/video.php?v=3I5d2rUJ0pE
 **/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadingProgressBar : MonoBehaviour
{
    private Image image;

    private void Awake()
    {
        image = transform.GetComponent<Image>();
    }

    private void Update()
    {
        image.fillAmount = Loader.GetLoadingProgress();
    }

}
