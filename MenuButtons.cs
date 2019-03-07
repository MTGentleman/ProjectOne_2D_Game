using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MenuButtons : MonoBehaviour
{
    public GameObject mainMenuUI;
    public GameObject playMenuUI;
    public GameObject sparkles;
    public GameObject background;
    public Dropdown dropdown;
    public Light birdSpotlight;
    public Light frontSpotlight;
    public Material newMaterial;
    public Slider volumeSlider;
    public string chosenShip;
//  public ParticleSystem ps;
//  public string chosenTheme;
    private void Start()
    {
//        particleSystem.renderer.sortingLayerName = "Foreground";
        selectSubmarine();
//        dropdown.onValueChanged.AddListener(delegate { changeBackground(); });
        //        ps = sparkles.GetComponent<ParticleSystem>();
        sparkles.transform.position = new Vector3(0, 0);
        exitToMainMenu();
    }
    public void Update()
    {
        //print(AudioListener.volume);
    }
    public void goToPlayMenu()
    {
        playMenuUI.SetActive(true);
        mainMenuUI.SetActive(false);
        sparkles.GetComponent<ParticleSystem>().Play();
    }
    public void playGame()
    {
        //Application.LoadLevel();
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void exitToMainMenu()
    {
        playMenuUI.SetActive(false);
        mainMenuUI.SetActive(true);
    }
    public void selectDestroyer()
    {
        chosenShip = "Destroyer";
        sparkles.transform.position = new Vector3(0, 0);
    }
    public void selectCruiser()
    {
        chosenShip = "Cruiser";
        sparkles.transform.position = new Vector3(0, 0);
    }
    public void selectSubmarine()
    {
        chosenShip = "Submarine";
        sparkles.transform.position = new Vector3(0, 0);
    }
    public void selectBattleship()
    {
        chosenShip = "Battleship";
        sparkles.transform.position = new Vector3(0, 0);
    }
    public void selectSuperBattleship()
    {
        chosenShip = "Super Battleship";
        sparkles.transform.position = new Vector3(0, 0);
    }
    public void test()
    {
        print("alive.");
    }
    public void changeLights(Color color)
    {
        birdSpotlight.color = color;
        frontSpotlight.color = color;
    }
    public void changeBackground()
    {
        //newColour(1, 1, 1);
        string backgroundName = dropdown.options[dropdown.value].text;
        //print(background.GetComponent<SpriteRenderer>().material.ToString());
        newMaterial = Resources.Load("Materials/" + backgroundName, typeof(Material)) as Material;
        //print(newMaterial.ToString());
        if (backgroundName == "Normal") { changeLights( newColour(255, 100, 0) ); }
        if (backgroundName == "Swamp") { changeLights(newColour(0, 25, 0)); }
        if (backgroundName == "Ice") { changeLights(newColour(190, 255, 240)); }
        if (backgroundName == "Storm") { changeLights(newColour(255, 132, 0)); }
        if (backgroundName == "Dark Calm") { changeLights(newColour(31, 31, 31)); }
        if (backgroundName == "Dark Storm") { changeLights(newColour(255, 0, 0)); }
        if (backgroundName == "Sunset")
        {
            frontSpotlight.color = newColour(255, 0, 0);
            birdSpotlight.color = newColour(255, 0, 0);
            //baseBrightness = 20;
            //extraBrightness = 0;
            //brightnessChanges = 0;
            //goingUp = true;
            //maxBrightnessIncrease = 60;
            //brightnessIncrements = 1;
        }
        else
        {
            //baseBrightness = 10;
            //extraBrightness = 0;
            //brightnessChanges = 0;
            //goingUp = true;
            //maxBrightnessIncrease = 15;
            //brightnessIncrements = 0.25f;
        }
        background.GetComponent<SpriteRenderer>().material = newMaterial;
    }
    public void changeMuic()
    {

    }
    public void changeVolume()
    {
        AudioListener.volume = volumeSlider.value;
    }
    public Color newColour(float r, float g, float b)
    {
        //This method exists to translate from RGB values from integers with a maximum of
        //255 to floats with a maximum of 1, so they can be used by the built in new Color(e, g, b)
        //method, which works with integers... Poorly.
        r = r / 255;
        g = g / 255;
        b = b / 255;
        return new Color(r, g, b);
    }

}