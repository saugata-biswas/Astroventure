using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuBehavior : MonoBehaviour
{
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Confined;
    }
    public void LoadLevel0()
    {
        Loader.Load(Loader.Scene.Level0);
    }
}
