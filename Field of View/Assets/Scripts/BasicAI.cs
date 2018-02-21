using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

namespace UnityStandardAssets.Characters.ThirdPerson
{
    public class BasicAI : MonoBehaviour
    {

        public NavMeshAgent agent;
        public ThirdPersonCharacter character;
        public enum State {Patrol,ChaseDog,ChasePlayer,Investigate }
        float distance;
        public State state;
        private bool alive;
        public GameObject[] waypoints;
        private int waypointIndex = 0;
        public float patrolSpeed = 0.5f;
        float TargetDistance;
        public float chaseSpeed = 1f;
        public GameObject target;
        private bool waitActive = false;

        public Animator anim;

        List <GameObject> dog;
        private float timer = 0;
        public float investigateTime = 10;

        

        public float kickzone = 0.5f;


        public float viewHeigth;
        public float viewDistance=10;
        public float heightMultiplier = 1.56f;
        // Use this for initialization
        void Start()
        {
            anim.GetComponent<Animator>();
            agent = GetComponent<NavMeshAgent>();
            character = GetComponent<ThirdPersonCharacter>();
            //stickyColl = stickyBullet.GetComponent<Collider>();
            agent.updatePosition = true;
            agent.updateRotation = false;

            viewHeigth = 1.36f;
            
            state = State.Patrol;
            alive = true;
            StartCoroutine("FSM");

            anim.SetBool("IsIdle", true);

        }
        void Update()
        {
            
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
                    case State.ChaseDog:
                        ChaseDog();
                        break;
                    case State.ChasePlayer:
                        ChasePlayer();
                        break;
                        //case State.Investigate:
                        //   Investigate();
                        //   break;

                } yield return null;
            }
        }

        void Patrol()
        {
            anim.SetBool("IsIdle", false);
            anim.SetBool("HumanRunning", false);
            anim.SetBool("IsKicking", false);
            anim.SetBool("HumanWalking", true);

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
        void ChaseDog()
        {
            dog = GameObject.FindGameObjectsWithTag("Dog").ToList();
                if (dog.Count > 0)
                {
                    target = dog.FirstOrDefault().gameObject;
                    TargetDistance = Vector3.Distance(this.transform.position, target.transform.position);
                }

                foreach (GameObject P in dog)
                {

                    distance = Vector3.Distance(this.transform.position, P.transform.position);
                    if (distance <= TargetDistance)
                    {
                        TargetDistance = distance;
                        target = P;
                    }

                }
                dog.Clear();
            

            if (target != null)
            {
                anim.SetBool("IsIdle", false);
                anim.SetBool("HumanRunning", true);
                anim.SetBool("IsKicking", false);
                anim.SetBool("HumanWalking", false);

                timer += Time.deltaTime;
                agent.speed = chaseSpeed;
                agent.SetDestination(target.transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            if (timer >= investigateTime)
                {
                    state = State.Patrol;
                    timer = 0;

                }
            
            if(target==null)
            {
                state = State.Patrol;
                
                timer = 0;
            }
           


        }

        void ChasePlayer()
        {
            target = GameObject.FindGameObjectWithTag("Player");

            if (target != null)
            {
                anim.SetBool("IsIdle", false);
                anim.SetBool("HumanRunning", true);
                anim.SetBool("IsKicking", false);
                anim.SetBool("HumanWalking", false);

                timer += Time.deltaTime;
                agent.speed = chaseSpeed;
                agent.SetDestination(target.transform.position);
                character.Move(agent.desiredVelocity, false, false);
            }
            if (timer >= investigateTime)
            {
                state = State.Patrol;
                target = null;
                timer = 0;
            }

            if (target == null)
            {
                state = State.Patrol;

                timer = 0;
            }



        }
        void OnCollisionEnter(Collision coll)
        {
            if ((state == State.ChasePlayer) && (coll.gameObject.tag == "Player"))
            {
                anim.SetBool("IsIdle", false);
                anim.SetBool("IsKicking", true);
                anim.SetBool("HumanRunning", false);
                anim.SetBool("HumanWalking", false);

                coll.gameObject.GetComponent<PlayerRespawn>().Died();
                state = State.Patrol;
                target = null;
            }
        }
    void OnTriggerEnter(Collider coll)
        {
            if(coll.gameObject.tag == "Player")
            {
                if(coll.gameObject.GetComponent<SwitchWeapon>().CurWeapon != 3)
                {
                    state = State.ChasePlayer;
                }
                
            }
            if(coll.tag=="StickyBullet")
            {
                if (coll.GetComponent<Rigidbody>().velocity.magnitude == 0)
                {
                    Destroy(coll.gameObject);
                    CheckForPlayer(coll.gameObject.transform.position);
                }
                
            }
            else { }
            
                
            if ((state==State.ChaseDog)&&(coll.tag=="Dog"))
            {
                if(target!=null)
                {
                    
                    anim.SetBool("IsIdle", false);
                    anim.SetBool("IsKicking", true);
                    anim.SetBool("HumanRunning", false);
                    anim.SetBool("HumanWalking", false);
                    

                    coll.gameObject.GetComponent<NavMeshAgent>().enabled = false;
                    coll.gameObject.GetComponent<Rigidbody>().AddForce((transform.forward + Vector3.up) * 500, ForceMode.Impulse);
                    
                    // target.GetComponent<Rigidbody>().AddForce(new Vector3(0, -100, 0), ForceMode.Impulse);

                    GameObject flyingDog = target;
                    state = State.Patrol;
                    target = null;

                    if (!waitActive)
                    {
                        StartCoroutine(Wait(flyingDog));
                        
                        
                    }
                }
                else
                {
                    state = State.Patrol;
                }
            }
        }

        void CheckForPlayer(Vector3 stickyBulletTransform)
        {
            RaycastHit hit;
            Debug.DrawRay(transform.position, transform.forward * 10, Color.green);
            Debug.DrawRay(transform.position, (transform.forward+transform.right).normalized * 10, Color.green);
            Debug.DrawRay(transform.position, (transform.forward-transform.right).normalized * 10, Color.green);

            if (Physics.Raycast(transform.position,stickyBulletTransform,out hit,100))
            {
                state = State.ChaseDog;
            }
        }

        IEnumerator Wait(GameObject target)
        {
            waitActive = true;
            yield return new WaitForSeconds(5.0f);
            Destroy(target);
            CageDogSpawner.SpawnDoginCage();
            waitActive = false;

            if (!waitActive)
            {
                StartCoroutine(Wait());
            }
            
        }

        IEnumerator Wait()
        {
            waitActive = true;
            yield return new WaitForSeconds(5.0f);
            GameObject.FindGameObjectWithTag("KennelCam").gameObject.GetComponent<Camera>().enabled = false;
            waitActive = false;
        }
    }
}