using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFade : MonoBehaviour {
    public int brightnessChanges = 0;
    public bool goingUp = true;
    public float extraBrightness = 0;
    Light light;
    void Start() {
        light = GetComponent<Light>();
    }

    void Update()
    {
        if (Time.time - brightnessChanges * 0.05 > 0.05)
        { changeBrightness(); }
        light.intensity = 10 + extraBrightness;
    }

    void changeBrightness()
    {
        brightnessChanges += 1;
        if (goingUp)
        { extraBrightness += 0.5f; }
        else { extraBrightness -= 0.5f; }
        if (extraBrightness == 30) { goingUp = false; }
        if (extraBrightness == 0) { goingUp = true; }
    }
}
