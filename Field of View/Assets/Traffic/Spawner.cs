using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public float NumVehicle;
    public Transform spawnPos;
    public GameObject spawn;
    public GameObject[] respawns;
    public float delaySpawn;
    public float delayreset;
    // Update is called once per frame
    void Start()
    {
        //Instantiate(spawn, spawnPos.position, spawnPos.rotation);
        delayreset = delaySpawn;
    }

    void Update ()
    {
        
        if(delaySpawn > 0)
        {
            delaySpawn -= Time.deltaTime;
            
        }
        else
        {
            
            respawns = GameObject.FindGameObjectsWithTag("RespawnV");

                if (respawns.Length <= NumVehicle)
                {
                Instantiate(spawn, spawnPos.position, spawnPos.rotation);
                    delaySpawn = delayreset;
                }
            

        }
       
    }
}
