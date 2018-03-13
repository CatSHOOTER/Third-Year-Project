using UnityEngine;
using System.Collections;

public class gameManager : MonoBehaviour {

    public GameObject pausePanel;
    public GameObject optionsPanel;
    public GameObject ControlsPanel;
    public bool isPaused;

    // Use this for initialization
    void Start ()
    {
        //Screen.SetResolution(1920, 1080, true);
        isPaused = false;
        optionsPanel.SetActive(false);
        ControlsPanel.SetActive(false);
    }
	
	// Update is called once per frame
	void Update () {

        if (isPaused)
        {
            pause(true);
            Cursor.visible = true;
        }
        else
        {
            pause(false);
            Cursor.visible = false;
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

    public void Controls()
    {
        pausePanel.SetActive(false);
        ControlsPanel.SetActive(true);
    }

    public void back()
    {
        optionsPanel.SetActive(false);
        pause(true);
        pausePanel.SetActive(true);
    }

    public void backToPauseMenu()
    {
        ControlsPanel.SetActive(false);
        pause(true);
        pausePanel.SetActive(true);
    }
}
