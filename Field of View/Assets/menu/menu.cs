using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using UnityEngine.UI;


public class menu : MonoBehaviour {

    public AudioSource[] gameSounds;
    public float[] soundVolumes;
    public Slider[] volumeSliders;
    public Toggle[] resolutionToggles;
    public int[] screenSizes;
    int activeScreenResIndex;
    

    void Start()
    {
        gameSounds = FindObjectsOfType<AudioSource>();
        
        for (int i = 0; i < gameSounds.Length; i++)
        {
            soundVolumes[i] = gameSounds[i].volume;
        }
    }

    public void play()
    {
       SceneManager.LoadScene("Book");
        GameManager.minTime = 0;
        GameManager.sectime = 0;
    }

    public void quit()
    {
        Debug.Log("Quit game");
        //Application.Quit();
        SceneManager.LoadScene("dynamic menu");
    }

    public void setScreenResolution(int i)
    {
        if (resolutionToggles[i].isOn)
        {
            activeScreenResIndex = i;
            float aspectRatio = 16 / 9f;
            Screen.SetResolution(screenSizes[i], (int)(screenSizes[i] / aspectRatio), false);
        }
    }

    public void setFullscreen(bool isFullscreen)
    {
        for (int i = 0; i < resolutionToggles.Length; i++)
        {
            resolutionToggles[i].interactable = !isFullscreen;
        }

        if (isFullscreen)
        {
            Resolution[] allResolutions = Screen.resolutions;
            Resolution maxResolution = allResolutions [allResolutions.Length - 1];
            Screen.SetResolution(maxResolution.width, maxResolution.height, true);
        }
        else
        {
            setScreenResolution(activeScreenResIndex);
        }
    }

    public void setGameVolume(float value)
    {
        AudioSource[] aud = FindObjectsOfType<AudioSource>();
        float master = volumeSliders[0].value;
        float music = volumeSliders[1].value;
        float effects = volumeSliders[2].value;

        for (int i = 0; i < aud.Length; i++)
        {
                aud[i].volume = ((soundVolumes[i] / 100) * (master));
            
            if (aud[i].tag == "music")
            {
                aud[i].volume = ((soundVolumes[i]) * (master) * (music))/10000;
            }
            else if (aud[i].tag == "sfx")
            {
                aud[i].volume = ((soundVolumes[i]) * (master) * (effects))/10000;
            }
        }
    }
}
