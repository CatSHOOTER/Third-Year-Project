using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CageDogSpawner : MonoBehaviour {

    public Transform transforn;
    public GameObject Spawn;
    public static bool SpawnDog = false;
    static Transform tan;
    static GameObject spawn;
    public Camera KennelCam;
    static Camera kennelCam;

    // Use this for initialization
    void Start ()
    {
		tan = transforn;
        spawn = Spawn;
        kennelCam = KennelCam;
    }
	
	// Update is called once per frame
	//void Update ()
 //   {
 //       if (SpawnDog == true)
 //       {
 //           int X = Random.Range(-10, 10);
 //           int z = Random.Range(-10, 10);
 //           Instantiate(Spawn, transforn.position + new Vector3(X, 0, z), transform.rotation);
 //           SpawnDog = false;
 //       }
 //   }
    public static void SpawnDoginCage()
    {

            kennelCam.enabled = true;
            int X = UnityEngine.Random.Range(-2, 2);
            int z = UnityEngine.Random.Range(-2, 2);
            Instantiate(spawn, tan.position + new Vector3(X, 0, z), tan.rotation);

    }


}
