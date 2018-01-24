using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    public bool collect = false;
    bool first = true;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(collect == true && first == true)
        {

            //Color myColor = new Color();
            gameObject.GetComponent<Renderer>().material.color = new Color(254, 254, 254,250);
            //ColorUtility.TryParseHtmlString("FFFFFFFF", out myColor);
            first = false;
        }
	}
}
