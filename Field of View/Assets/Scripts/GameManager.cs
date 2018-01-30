using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {
    public Text DogsLeft;
    GameObject[] Dogs;
    int dog;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update() { 

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

        if (Dogs.Length == 0)
        {
            menuCamControl.WinEndGame = true;
            //menuCamControl.setMount(GameObject.Find("WinnerInputMount").transform);
            //GameObject.Find("cameraguide").GetComponent<menuCamControl>().currentMount = GameObject.Find("WinnerInputMount").transform;
            SceneManager.LoadScene("dynamic menu");
            
        }

        
    }
}
