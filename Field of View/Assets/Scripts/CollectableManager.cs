using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableManager : MonoBehaviour
{
    GameObject[] Collectable;
    GameObject[] Collected;
    int collectable = 0;
    int collect = 0;
    public Camera P1Cam, CutSceneCam;
    public GameObject leftGate, rightGate;
    Animator anim1, anim2;
    public Text collectableDisplay;
    private bool waitActive = false;
    public static bool playedCutScene = false;
    bool first = true;
    // Use this for initialization
    void Start()
    {
        CutSceneCam.enabled = false;
        collectable = 0;
    Collectable = GameObject.FindGameObjectsWithTag("Collectable");
    foreach (GameObject P in Collectable)
        {
            collectable++;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
        collect = 0;
        
        Collected = GameObject.FindGameObjectsWithTag("Collected");
        
        foreach (GameObject P in Collected)
        {
            collect++;

        }
        collectableDisplay.text = ("" + collect + " out of "+"" +collectable+" Tagged" );

        if(Collectable.Length == Collected.Length && first == true)
        {
            PlayplaygroundCutscene();
            first = false;
        }

    }
    void PlayplaygroundCutscene()
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
