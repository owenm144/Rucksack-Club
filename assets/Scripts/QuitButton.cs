using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class QuitButton : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            QuitGame();
    }

    public void QuitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.isPlaying = false;
        #endif

        Application.Quit();
    }
}