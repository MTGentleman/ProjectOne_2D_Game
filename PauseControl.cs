using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class PauseControl : MonoBehaviour
{
    public bool paused = false;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        { pause(); }
    }
    void pause()
    {
        if (paused) { paused = false; }
        else if (!paused) { paused = true; }
        if (Time.timeScale == 1f)
        { Time.timeScale = 0; }
        else if (Time.timeScale == 0f)
        { Time.timeScale = 1; }
    }
}
