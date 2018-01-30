using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerLivesDisplay : MonoBehaviour {
    public GameObject DisplayLives;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {

        DisplayLives.GetComponent<Text>().text = "" + playerController.currentlives;
		
	}
}
