﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class BasicAI : MonoBehaviour
    {

        public NavMeshAgent agent;
        public ThirdPersonCharacter character;
        public enum State {Patrol,Chase,Investigate }

        public State state;
        private bool alive;
        public GameObject[] waypoints;
        private int waypointIndex = 0;
        public float patrolSpeed = 0.5f;

        public float chaseSpeed = 1f;
        public GameObject target;

        
       private float timer = 0;
        public float investigateTime = 10;

        

        public float kickzone = 0.5f;


        public float viewHeigth;
        public float viewDistance=10;
        public float heightMultiplier = 1.56f;
        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            //stickyColl = stickyBullet.GetComponent<Collider>();
            agent.updatePosition = true;
            agent.updateRotation = false;

            viewHeigth = 1.36f;
            
            state = State.Patrol;
            alive = true;
            StartCoroutine("FSM");
                
        }

        // Update is called once per frame
        IEnumerator FSM()
        {
            while(alive)
            {
                switch(state)
                {
                    case State.Patrol:
                        Patrol();
                        break;
                    case State.Chase:
                        Chase();
                        break;
                    //case State.Investigate:
                    //   Investigate();
                    //   break;

                } yield return null;
            }
        }

        void Patrol()
        {
            agent.speed = patrolSpeed;
            if(Vector3.Distance(this.transform.position,waypoints[waypointIndex].transform.position)>=2)
            {
                agent.SetDestination(waypoints[waypointIndex].transform.position);
                character.Move(agent.desiredVelocity, false, false);

            }

           else if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) <= 2)
            {
                waypointIndex++;
                if(waypointIndex>=waypoints.Length)
                {
                    waypointIndex = 0;
                }
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }

        }
        void Chase()
        {
            //List<GameObject> dogs = new List<GameObject>();
            //dogs.Add(GameObject.FindGameObjectWithTag("Dog"));
            //RaycastHit hitResult;
            //float ShortestRay = 500;

            //foreach (GameObject dog in dogs)
            //{
            //    if (Physics.Raycast(transform.position, dog.transform.position, out hitResult, 100))
            //    {
            //        if (hitResult.distance < ShortestRay)
            //        {
            //            ShortestRay = hitResult.distance;
            //            target = dog;
            //        }
            //    }


            //}
            target = GameObject.FindGameObjectWithTag("Dog");
            timer += Time.deltaTime;
            agent.speed = chaseSpeed;
            agent.SetDestination(target.transform.position);
            character.Move(agent.desiredVelocity, false, false);

            if (timer>=investigateTime)
            {
                state = State.Patrol;
                timer = 0;

            }
           


            }
        //void Update()
        //{
        //    if (state == State.Chase)
        //    {
        //        RaycastHit kill;
        //        if (Physics.Raycast(transform.position + Vector3.up * viewHeigth, transform.forward, out kill, kickzone))
        //        {
        //            if (kill.collider.tag == "Dog")
        //            {
        //                Destroy(target);
        //                Debug.DrawRay(transform.position + Vector3.up * viewHeigth, transform.forward, Color.green, kickzone);
        //            }
        //        }
        //    }


        //}

        //void Investigate()
        //{
        //    timer += Time.deltaTime;
        //    RaycastHit hit;

        //    Debug.DrawRay(transform.position + Vector3.up * viewHeigth, transform.forward * viewDistance, Color.green);
        //    Debug.DrawRay(transform.position + Vector3.up * viewHeigth, (transform.forward + transform.right).normalized * viewDistance, Color.green);
        //    Debug.DrawRay(transform.position + Vector3.up * viewHeigth, (transform.forward - transform.right).normalized * viewDistance, Color.green);

        //    if (Physics.Raycast(transform.position + Vector3.up * viewHeigth, transform.forward, out hit, viewDistance))
        //    {
        //        if (hit.collider.tag == "Player")
        //        {
        //            state = State.Chase;
        //            target = hit.collider.gameObject;
        //        }

        //    }
        //    if (Physics.Raycast(transform.position + Vector3.up * viewHeigth, (transform.forward + transform.right).normalized, out hit, viewDistance))
        //    {
        //        if (hit.collider.tag == "Player")
        //        {
        //            state = State.Chase;
        //            target = hit.collider.gameObject;
        //        }

        //    }
        //    if (Physics.Raycast(transform.position + Vector3.up * viewHeigth, (transform.forward - transform.right).normalized, out hit, viewDistance))
        //    {
        //        if (hit.collider.tag == "Player")
        //        {
        //            state = State.Chase;
        //            target = hit.collider.gameObject;

        //        }

        //    }


        //    if (timer == 2.5f)
        //    { transform.LookAt(transform.forward); }
        //    if (timer == 5f)
        //    {
        //        transform.LookAt(transform.forward + transform.right);
        //    }
        //    if (timer == 7.5f)
        //    {
        //        transform.LookAt(transform.forward - transform.right);
        //    }
        //    agent.SetDestination(stickyBullet.transform.position);
        //    character.Move(agent.desiredVelocity, false, false);


        //    if (timer >= investigateTime)
        //    {
        //        state = State.Patrol;
        //        timer = 0;
        //    }
        //}
        void OnTriggerEnter(Collider coll)
        {
            
            
            if(coll.tag=="StickyBullet")
            {
                Debug.Log("Player Sighted");
                CheckForPlayer();
            }
            else { }
            if((state==State.Chase)&&(coll.tag=="Dog"))
            {
                if(target!=null)
                {
                    target.GetComponent<Rigidbody>().AddForce(new Vector3(0, 10, 10), ForceMode.Impulse);

                    Destroy(target);
                    state = State.Patrol;
                    target = null;
                }
            }
        }

        void CheckForPlayer()
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
            Debug.DrawRay(transform.position, (transform.forward+transform.right).normalized * 10, Color.green);
            Debug.DrawRay(transform.position, (transform.forward-transform.right).normalized * 10, Color.green);
            if (Physics.Raycast(transform.position,transform.forward,out hit,10))
            {
                state = State.Chase;
                

                Debug.Log("hit");
            }
            if (Physics.Raycast(transform.position, (transform.forward+transform.right).normalized, out hit, 10))
            {
                state = State.Chase;


                Debug.Log("hit");
            }
            if (Physics.Raycast(transform.position, (transform.forward - transform.right).normalized, out hit, 10))
            {
                state = State.Chase;


                Debug.Log("hit");
            }

            if (Physics.Raycast(transform.position, transform.forward*heightMultiplier, out hit, 10))
            {
                state = State.Chase;


                Debug.Log("hit");
            }
            if (Physics.Raycast(transform.position, (transform.forward + transform.right).normalized*heightMultiplier, out hit, 10))
            {
                state = State.Chase;


                Debug.Log("hit");
            }
            if (Physics.Raycast(transform.position, (transform.forward - transform.right).normalized*heightMultiplier, out hit, 10))
            {
                state = State.Chase;


                Debug.Log("hit");
            }
        }
    }
}