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
        // CarCollider = this.GetComponentInChildren<BoxCollider>();
        
    }

    // Update is called once per frame
    void Update()
    {

        speed = this.GetComponent<FollowPath>().Currentspeed;
        Vector3 Transform = Vehicle.transform.forward;
        Debug.DrawRay(transform.position * 1, Vehicle.transform.forward, Color.red);
        
        if(Physics.Raycast(transform.position, Transform, out Hit, 11))
        {
            if(Hit.collider.gameObject.CompareTag("RespawnV") || Hit.collider.gameObject.CompareTag("VStoper"))
            {
                if (this.GetComponent<FollowPath>().Currentspeed >= 0.0f)
                {
                    this.GetComponent<FollowPath>().Currentspeed -= 0.32f;
                    if(this.GetComponent<FollowPath>().Currentspeed <= 0.0f)
                    {
                        this.GetComponent<FollowPath>().Currentspeed = 0f;
                    }
                }
                
                //if(speed >= Hit.collider.gameObject.GetComponent<FollowPath>().speed)
                //{
                //    speed -= 0.01f;
                //(speed - Hit.collider.gameObject.GetComponent<FollowPath>().speed / 2);
                //this.GetComponent<FollowPath>().speed = speed;
                //}


                //    //GetComponent<FollowPath>().enabled = false;

                //if (Hit.collider.tag=="VStoper")
                //{
                //    this.GetComponent<FollowPath>().Currentspeed -= 0.1f;
                //}
                //else
                //{
                //    this.GetComponent<FollowPath>().Currentspeed = Hit.collider.gameObject.GetComponent<FollowPath>().Currentspeed;
                //}



            }
            

        }
        else
            {
            if (this.GetComponent<FollowPath>().Currentspeed <= this.GetComponent<FollowPath>().Maxspeed)
            {

                this.GetComponent<FollowPath>().Currentspeed += 0.05f;

                
            }
            }
        //GetComponent<FollowPath>().enabled = true;
        //RaycastHit hit;
        //Ray ray = CapsuleCollider.main.ScreenPointToRay(Input.mousePosition);
        //if (Physics.Raycast(ray, out hit))
        //    if (hit.rigidbody != null)
        //        hit.rigidbody.AddForce(ray.direction * hitForce);

        ////RaycastHit hit;
        ////Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        ////if (Physics.Raycast(ray, out hit))
        ////    if (hit.rigidbody != null)
        ////        hit.rigidbody.AddForce(ray.direction * hitForce);





        //collided = GetComponent<VehicleDetection>().collide;
        //if (collided)
        //{
        //    GetComponent<FollowPath>().enabled = false;
        //}
        //else
        //{
        //    GetComponent<FollowPath>().enabled = true;
        //}

    }


    //void OnCollisionEnter(Collision coll)
    //{

    //    if (coll.gameObject.name == "stopper" || coll.gameObject.tag == "RespawnV")
    //    {
    //        GetComponent<FollowPath>(). enabled = false;



    //    }
    //    GetComponent<FollowPath>().enabled = true;

    //}
    //public void OnCollisionEnter(Collision coll)
    //{
    //    if (coll.gameObject.name == "stopper" || coll.gameObject.tag == "RespawnV")
    //        collide = true;
    //}

    //public void OnCollisionExit()
    //{
    //    collide = false;
    //}

}