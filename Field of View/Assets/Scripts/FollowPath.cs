﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPath : MonoBehaviour {

    public EditPath PathToFollow;

    public int CurrentWayPointPos = 0;
    public float Currentspeed ;
    public float Maxspeed;
    private float distanceToWayPoint = 2.0f;
    public float turnSpeed = 5.0f;
    public string pathID;
    public string LastpathID;
    Vector3 previousPos;
    Vector3 currentPos;
    bool first = true;

    // Use this for initialization
    void Start ()
    {
        
        //PathToFollow = GameObject.Find(pathID).GetComponent<EditPath>();
        previousPos = transform.position;
        //PathToFollow = GameObject.Find(pathID).GetComponent<EditPath>();
        //this.gameObject.transform.position = PathToFollow.pathObjs[CurrentWayPointPos].transform.position;
        //float distance = Vector3.Distance(PathToFollow.pathObjs[CurrentWayPointPos].position, transform.position);
        //transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathObjs[CurrentWayPointPos].position, 1000);

    }

    // Update is called once per frame
    void Update()
    {

        PathToFollow = GameObject.Find(pathID).GetComponent<EditPath>();
        if (first == true && PathToFollow != null)
        {
            this.gameObject.transform.position = PathToFollow.pathObjs[CurrentWayPointPos].transform.position;
            first = false;
        }
        PathToFollow = GameObject.Find(pathID).GetComponent<EditPath>();
        previousPos = transform.position;

        LastpathID = pathID;

        float distance = Vector3.Distance(PathToFollow.pathObjs[CurrentWayPointPos].position, transform.position);
        transform.position = Vector3.MoveTowards(transform.position, PathToFollow.pathObjs[CurrentWayPointPos].position, Time.deltaTime * Currentspeed);

        var turn = Quaternion.LookRotation(PathToFollow.pathObjs[CurrentWayPointPos].position - transform.position);
        transform.rotation = Quaternion.Slerp(transform.rotation, turn, Time.deltaTime * turnSpeed);

        

        if (distance <= distanceToWayPoint)
        {
            CurrentWayPointPos++;
        }
        if(CurrentWayPointPos >= PathToFollow.pathObjs.Count)
        {
            //delete vehicle here
           
            Destroy(this.gameObject);

        }

	}
}
