/***
 * This code snippet has been adapted from a tutorial found at https://www.youtube.com/watch?v=3I5d2rUJ0pE,
 * https://unitycodemonkey.com/video.php?v=3I5d2rUJ0pE
 **/
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public static class Loader
{
    private class LoadingMonoBehavior : MonoBehaviour { }
    public enum Scene
    {
        Menu,
        Loading,
        Level0
    }

    private static Action onLoaderCallback;
    private static AsyncOperation loadingAsyncOperation;

    public static void Load(Scene scene)
    {

        // loader callback loads the target scene.
        onLoaderCallback = () =>
        {
            GameObject loadingGameObject = new GameObject("Loading GameObject");
            loadingGameObject.AddComponent<LoadingMonoBehavior>();
            loadingGameObject.GetComponent<LoadingMonoBehavior>().StartCoroutine(LoadSceneAsync(scene));
            LoadSceneAsync(scene);
        };

        // loads the Loading scene.
        SceneManager.LoadScene(Scene.Loading.ToString()); 
    }

    private static IEnumerator LoadSceneAsync(Scene scene)
    {
        yield return null;
        loadingAsyncOperation = SceneManager.LoadSceneAsync(scene.ToString());
        while (!loadingAsyncOperation.isDone)
        {
            yield return null;
        }
    }

    public static float GetLoadingProgress()
    {
        if (loadingAsyncOperation != null)
        {
            return loadingAsyncOperation.progress;
        }
        else
        {
            return 1.0f;
        }
    }

    public static void LoaderCallback()
    {
        // triggers after the first Update of LoaderCallbackBehavior which
        // refreshes the screen.
        // executes the onLoaderCallback action which loads the target scene.
        if (onLoaderCallback != null)
        {
            onLoaderCallback();
            onLoaderCallback = null;
        }
    }


}
