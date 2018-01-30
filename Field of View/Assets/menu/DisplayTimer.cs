using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DisplayTimer : MonoBehaviour {
  public  GameObject DisplayText;
    
    // Use this for initialization
    void Start () {
		
	}

    // Update is called once per frame
    void Update() {

        
        DisplayText.GetComponent<Text>().text = string.Format("{0}:{1:F2}", GameManager.minTime, GameManager.sectime);
	}
}
