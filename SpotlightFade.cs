using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightFade : MonoBehaviour
{
    public int brightnessChanges = 0;
    public float baseBrightness;
    public float extraBrightness = 0;
    public float brightnessIncrements;
    public float maxBrightnessIncrease;
    public bool goingUp = true;
    public Light light;

    void Update()
    {
        if (Time.time - brightnessChanges * 0.05 > 0.05)
        { changeBrightness(); }
        light.intensity = baseBrightness + extraBrightness;
        maxBrightnessIncrease = 15;
    }

    void changeBrightness()
    {
        brightnessChanges += 1;
        if (goingUp)
        { extraBrightness += brightnessIncrements; }
        else { extraBrightness -= brightnessIncrements; }
        if (extraBrightness == maxBrightnessIncrease) { goingUp = false; }
        if (extraBrightness == 0) { goingUp = true; }
    }
}
