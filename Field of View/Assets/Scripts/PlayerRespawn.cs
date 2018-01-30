using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {
    Vector3 StartPos;
	// Use this for initialization
	void Start () {
        StartPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	}

    // Update is called once per frame
    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Dog" || coll.gameObject.tag == "RespawnV")
        {

            gameObject.transform.position = StartPos;
            playerController.currentlives--;
            //Destroy(coll.gameObject);
            Debug.Log("Dog Hit");

        }
    }
}
