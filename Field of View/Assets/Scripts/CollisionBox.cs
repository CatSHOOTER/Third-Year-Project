using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionBox : MonoBehaviour
{
    //Collider CarCollider;
    public bool collided;
    public GameObject showDetails;
    
    public GameObject Vehicle;
    private RaycastHit Hit;
    private float speed;
    // Use this for initialization
    void Start()
    {

        Vehicle = this.gameObject;
        
        
    }

    void OnCollisionEnter(Collision coll)
    {

        if (coll.gameObject.tag == "Dog")
        {

            Destroy(coll.gameObject);
            CageDogSpawner.SpawnDoginCage();
        }
        

    }

    // Update is called once per frame
    void Update()
    {
        
        speed = this.GetComponent<FollowPath>().Currentspeed;
        Vector3 Transform = Vehicle.transform.forward;
        Debug.DrawRay(transform.position * 1, Vehicle.transform.forward, Color.red);
        
        if(Physics.Raycast(transform.position, Transform, out Hit, 12))
        {
            //if Raycast Hit other car or Traffic lights
            if(Hit.collider.gameObject.CompareTag("RespawnV") || Hit.collider.gameObject.CompareTag("VStoper"))
            {
                //if the car is still moving slow down more
                if (this.GetComponent<FollowPath>().Currentspeed >= 0.0f)
                {
                    this.GetComponent<FollowPath>().Currentspeed -= 2f;
                    //incase of car entering - numbers
                    if(this.GetComponent<FollowPath>().Currentspeed <= 0.0f)
                    {
                        this.GetComponent<FollowPath>().Currentspeed = 0f;
                    }
                }

            }
            

        }
        else
            {
                    //speed up
                    if (this.GetComponent<FollowPath>().Currentspeed <= this.GetComponent<FollowPath>().Maxspeed)
                    {

                     this.GetComponent<FollowPath>().Currentspeed += 1f;

                
                    }
             }
        }
}