using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject optionsPanel;
    public bool isPaused;

    // Use this for initialization
    void Start ()
    {
        Screen.SetResolution(1024, 576, false);
        isPaused = false;
        optionsPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (isPaused)
        {
            pause(true);
        }
        else
        {
            pause(false);
        }

        if (Input.GetButtonDown("Cancel1"))
        {
            Debug.Log("paused");
            switchPause();
        }
	}

    public void pause(bool state)
    {
        AudioSource[] aud = FindObjectsOfType<AudioSource>();

        if (state)
        {
            if (optionsPanel.activeSelf == false)
            {
                pausePanel.SetActive(true);
            }
            
            foreach (AudioSource sound in aud)
            {
                sound.Pause();
            }
            Time.timeScale = 0f;
        }
        else
        {
            foreach (AudioSource sound in aud)
            {
                sound.UnPause();
            }
            Time.timeScale = 1f;
            pausePanel.SetActive(false);
        }
    }

    public void switchPause()
    {
        if (isPaused)
        {
            isPaused = false;
        }
        else
        {
            isPaused = true;
        }
    }

    public void options()
    {
        pausePanel.SetActive(false);
        optionsPanel.SetActive(true);
    }

    public void back()
    {
        optionsPanel.SetActive(false);
        pause(true);
        pausePanel.SetActive(true);
    }
}
