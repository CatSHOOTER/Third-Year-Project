using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FindPath : MonoBehaviour {

    public GameObject[] allPaths;
	// Use this for initialization
	void Start ()
    {
        int num = Random.Range(0, allPaths.Length);
        transform.position = allPaths[num].transform.position;
        FollowPath vehiclePath = GetComponent<FollowPath>();
        vehiclePath.pathID = allPaths[num].name;

    }
	
	
	
}
