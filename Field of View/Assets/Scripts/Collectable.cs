using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
    public bool collect = false;
    bool first = true;
    int hits = 1;
	// Use this for initialization
	void Start () {
        
    }
	
	// Update is called once per frame
	void Update () {
		if(collect == true && hits <= 5)
        {
            int paintAmount = 51;
            //Color myColor = new Color();
            gameObject.GetComponent<Renderer>().material.color += new Color(0, 0, 0,51);
            //ColorUtility.TryParseHtmlString("FFFFFFFF", out myColor);
            first = false;
        }
	}
}
