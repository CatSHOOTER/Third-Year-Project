using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDogSpawner : MonoBehaviour {

    public Transform transforn;
    public GameObject Spawn;
    public static bool SpawnDog = false;
    Transform tan;
    // Use this for initialization
    void Start ()
    {
		tan = transforn;
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (SpawnDog == true)
        {
            int X = Random.Range(-10, 10);
            int z = Random.Range(-10, 10);
            Instantiate(Spawn, transforn.position + new Vector3(X, 0, z), transform.rotation);
            SpawnDog = false;
        }
    }
}
