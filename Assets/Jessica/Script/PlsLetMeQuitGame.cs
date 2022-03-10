using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlsLetMeQuitGame : MonoBehaviour
{
    private void Update()
    {
        Quit();
    }

    public void Quit()
    {

        if (Input.GetKeyDown(KeyCode.Escape))
            {
#if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
#else
         Application.Quit();
#endif
        }
    }
}
