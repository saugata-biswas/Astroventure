using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour
{
    public void LoadLevel0()
    {
        Loader.Load(Loader.Scene.Level0);
    }
}
