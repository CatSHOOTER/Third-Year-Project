using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boundaryFogWall : MonoBehaviour {

    void OnCollisionEnter(Collision coll)
    {
        if (coll.collider.gameObject.tag != "Player")
        {
            Physics.IgnoreCollision(coll.collider, this.GetComponent<Collider>());
        }
        else
        {
            Debug.Log("boundary wall");
        }
        
    }
}
