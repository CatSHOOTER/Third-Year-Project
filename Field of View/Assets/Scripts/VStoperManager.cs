using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VStoperManager : MonoBehaviour {

	// Use this for initialization
	
    void OnCollisionEnter(Collision coll)
    {
        Physics.IgnoreCollision(coll.collider,this.GetComponent<Collider>());
    }
        
	// Update is called once per frame
	
}
