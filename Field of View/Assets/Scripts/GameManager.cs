using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text DogsLeft;
    GameObject[] Dogs;
    int dog;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        dog = 0;

        Dogs = GameObject.FindGameObjectsWithTag("Dog");

        foreach (GameObject P in Dogs)
        {
            dog++;

        }
        DogsLeft.text = (dog.ToString());
    }
}
