﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{

    public class DogAi : MonoBehaviour
    {
        public GameObject Target;
        public GameObject[] waypoints;
        private int waypointIndex = 0;

        public NavMeshAgent agent;
        public ThirdPersonCharacter character;

        public enum State { Patrol, Chase, Investigate }

        public static State state;
        public bool alive = true;

        private float timer = 0;
        public float investigateTime = 10;

        public float patrolSpeed = 0.5f;

        public float chaseSpeed = 10f;

        public AudioClip AttackBark;
        public AudioClip BallChaseBark;

        // Use this for initialization
        void Start()
        {
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            //stickyColl = stickyBullet.GetComponent<Collider>();
            agent.updatePosition = true;
            agent.updateRotation = false;

            state = State.Patrol;

            alive = true;
            StartCoroutine("FSM");
        }

        IEnumerator FSM()
        {
            while (alive)
            {
                switch (state)
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

                }
                yield return null;
            }
        }

        // Update is called once per frame
        //void Update()
        //{

        //}
        void Chase()
        {
            if (Target != null)
            {
                timer += Time.deltaTime;
                agent.speed = chaseSpeed;
                agent.SetDestination(Target.transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            else
            {
                state = State.Patrol;
                timer = 0;
            }
            

            if (timer >= investigateTime)
            {
                state = State.Patrol;
                timer = 0;
                Target = null;
            }

        }
        void Patrol()
        {
            agent.speed = patrolSpeed;
            if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) >= 2)
            {
                agent.SetDestination(waypoints[waypointIndex].transform.position);
                character.Move(agent.desiredVelocity, false, false);

            }

            else if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) <= 2)
            {
                waypointIndex++;
                if (waypointIndex >= waypoints.Length)
                {
                    waypointIndex = 0;
                }
            }
            else
            {
                character.Move(Vector3.zero, false, false);
            }

        }
        void OnTriggerEnter(Collider coll)
        {
            if (coll.tag == "Player" && state != State.Chase)
            {
                AudioSource audio = GetComponentInChildren<AudioSource>();
                audio.clip = AttackBark;
                audio.Play();

                state = State.Chase;
                Target = coll.gameObject;
            }
           

            if (coll.tag == "bouncyBullet")
            {
                AudioSource audio = GetComponentInChildren<AudioSource>();
                audio.clip = BallChaseBark;
                audio.Play();

                state = State.Chase;
                Target = coll.gameObject;
            }
        }

        void OnCollisionEnter(Collision coll)
        {          
            if (coll.gameObject.tag == "Player" && state == State.Chase)
            {
                this.gameObject.transform.position = waypoints[waypointIndex].transform.position;
                Target = null;
                this.gameObject.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
                state = State.Patrol;
                Debug.Log("collide with player");
                
                
                coll.gameObject.GetComponent<PlayerRespawn>().Died();
                
                
            }
        }
    }
}