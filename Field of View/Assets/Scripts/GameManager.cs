using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text DogsLeft;
    GameObject[] Dogs;
    int dog;
   public static float sectime = 0;
    public static int minTime = 0;
    Animator anim1, anim2;
    public GameObject leftGate, rightGate;
    public Camera P1Cam, CutSceneCam;
    private bool waitActive = false;
    public static bool playedCutScene = false;
    // Use this for initialization

    void Start ()
    {
        //anim.GetComponent<Animator>();
        sectime = 0;
        CutSceneCam.enabled = false;
    }
	
	// Update is called once per frame
	void Update() {

        sectime += Time.deltaTime;
        if (sectime >= 60)
        {
            minTime++;
            sectime = 0;
        }
        dog = 0;

        Dogs = GameObject.FindGameObjectsWithTag("Dog");

        foreach (GameObject P in Dogs)
        {
            dog++;

        }
        DogsLeft.text = (dog.ToString());

        if (playerController.currentlives == 0)
        {
            SceneManager.LoadScene("dynamic menu");

        }

        if (Dogs.Length == 0 && playedCutScene == false)
        {
            PlayScrapardCutscene();
            
            //menuCamControl.WinEndGame = true;
            //SceneManager.LoadScene("dynamic menu");
        }

        
    }

    void PlayScrapardCutscene()
    {
        P1Cam.enabled = false;
        CutSceneCam.enabled = true;
        

        anim1 = leftGate.GetComponent<Animator>();
        anim1.enabled = true;
        anim1.Play("GatesAnim1");

        anim2 = rightGate.GetComponent<Animator>();
        anim2.enabled = true;
        anim2.Play("GatesAnim");

        if (!waitActive)
        {
            StartCoroutine(Wait());

            
            
        }
        
        
    }

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(3.0f);
        playedCutScene = true;
        CutSceneCam.enabled = false;
        P1Cam.enabled = true;
        waitActive = false;
    }

   
}
