using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SceneUiManager : MonoBehaviour
{
    public void SwitchToMenu()
    {
        Loader.Load(Loader.Scene.Menu);
    }
}
