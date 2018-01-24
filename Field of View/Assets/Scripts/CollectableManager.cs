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
    public Text collectableDisplay;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        collectable = 0;
        collect = 0;
        Collectable = GameObject.FindGameObjectsWithTag("Collectable");
        Collected = GameObject.FindGameObjectsWithTag("Collected");
        foreach (GameObject P in Collectable)
        {
            collectable++;

        }
        foreach (GameObject P in Collected)
        {
            collect++;

        }
        collectableDisplay.text = ("" + collect + " out of "+"" +collectable+" Collected" );

    }
}
