using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VehicleDetection : MonoBehaviour {

    // Use this for initialization
    public bool collide;
    public void OnCollisionEnter(Collision coll)
    {
        if (coll.gameObject.name == "stopper" || coll.gameObject.tag == "RespawnV")
            collide = true;
    }

    public void OnCollisionExit()
    {
        collide = false;
    }
}
