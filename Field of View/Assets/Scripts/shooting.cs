using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class shooting : MonoBehaviour {

    GameObject player;
    public GameObject StickyBullet;
    public GameObject BouncyBullet;
    public static int stickyAmmo = 3;
    public static int bouncyAmmo = 2;
    public float bulletImpulse = 10f;
    private Transform cam;
    LineRenderer lr;
    public float meshWidth;
    public float angle = 45;
    float g;
    float radianAngle;
    public int resolution = 10;
    public float lastAngle = 0f;
    public AudioClip thump;
    public AudioClip lowThump;
    private RaycastHit Hit;
    public Animator anim;
    private bool waitActive = false;
    public GameObject bulletSpawner;
    public GameObject Paint;

    //float lifeSpan = 5.0f;




    void Awake()
    {
        lr = GetComponent<LineRenderer>();
        g = Mathf.Abs(Physics.gravity.y);
    }

    // Use this for initialization
    void Start()
    {
        //cam = playerController.FindObjectOfType<Camera> ().transform;
        cam = GameObject.FindWithTag("player1cam").transform;
        player = GameObject.FindWithTag("Player");
        angle = Mathf.Clamp(angle, player.GetComponent<playerController>().verticalRotation * -2, 0);
        
        RenderArc();

        anim.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            Reload();
        }

        if (Input.GetKey(KeyCode.C))
        {
            player.GetComponent<CharacterController>().height = 1;
        }
        else
        {
            player.GetComponent<CharacterController>().height = 2;
        }

        if (Input.GetKey(KeyCode.Q) && lastAngle != player.GetComponent<playerController>().verticalRotation * -2)
        {
            angle = Mathf.Clamp(angle, player.GetComponent<playerController>().verticalRotation * -2, 0);
            lastAngle = angle;
            RenderArc();
        }
        else if (Input.GetKey(KeyCode.Q) && lastAngle == player.GetComponent<playerController>().verticalRotation * -2)
        {

        }
        else
        {
            angle = 0;
            RenderArc();
        }

        if (Input.GetButtonDown("Fire1"))
        {
            

            //player.gameObject.GetComponent<Transform>().rotation = cam.localRotation ;

            #region Sticky Weapon
            if (SwitchWeapon.CurrentWeapon == 0 && stickyAmmo > 0)
            {
                if (StickyBullet != null && Time.timeScale == 1)
                {
                    anim.SetBool("IsShooting", true);

                    AudioSource audio = GetComponent<AudioSource>();
                    audio.clip = thump;
                    audio.Play();

                    GameObject theBullet = (GameObject)Instantiate(StickyBullet,bulletSpawner.transform.position + cam.forward, transform.rotation);
                    theBullet.GetComponent<Rigidbody>().AddForce(player.gameObject.transform.forward * bulletImpulse + new Vector3(0, 4, 0), ForceMode.Impulse);

                    stickyAmmo--;

                    if (!waitActive)
                    {
                        StartCoroutine(Wait());

                    }
                    

                }
                else
                {
                    Debug.LogWarning("No stickybullet object attached to player/shooting script");
                }
            }
            #endregion
            #region Bouncy Weapon
            if (SwitchWeapon.CurrentWeapon == 1 && bouncyAmmo > 0)
            {
                if (BouncyBullet != null && Time.timeScale == 1)
                {
                    anim.SetBool("IsShooting", true);

                    AudioSource audio = GetComponent<AudioSource>();
                    audio.clip = lowThump;
                    audio.Play();

                    GameObject theBullet = (GameObject)Instantiate(BouncyBullet, bulletSpawner.transform.position + cam.forward, transform.rotation);
                    theBullet.GetComponent<Rigidbody>().AddForce(player.gameObject.transform.forward * bulletImpulse + new Vector3(0, 4, 0), ForceMode.Impulse);

                    bouncyAmmo--;

                    if (!waitActive)
                    {
                        StartCoroutine(Wait());

                    }


                }
                else
                {
                    Debug.LogWarning("No bouncybullet object attached to player/shooting script");
                }

            }
            #endregion
            #region Paint Can
            if (SwitchWeapon.CurrentWeapon == 2 && Time.timeScale == 1)
            {
                anim.SetBool("IsShooting", true);
                Paint.SetActive(true);

                Vector3 Transform = player.transform.forward;
                if (Physics.Raycast(transform.position, Transform, out Hit, 15))
                {
                    
                    if (Hit.collider.gameObject.CompareTag("Collectable"))
                    {
                        
                        
                           Hit.collider.gameObject.tag = "Collected";
                        
                            Hit.collider.gameObject.GetComponent<Collectable>().collect = true;
                        Debug.Log("Hit Collectable");
                        
                    }
                }
                if (!waitActive)
                {
                    StartCoroutine(Wait());

                }
            }
            #endregion
           
        }


    }

    IEnumerator Wait()
    {
        waitActive = true;
        yield return new WaitForSeconds(0.5f);
        Paint.SetActive(false);
        anim.SetBool("IsShooting", false);
        waitActive = false;

    }

    void RenderArc()

    {
            lr.positionCount = (resolution + 1);
            lr.SetPositions(CalculateArray());
        }

        Vector3[] CalculateArray()

    {
            Vector3[] arcArray = new Vector3[resolution + 1];
            radianAngle = Mathf.Deg2Rad * angle;
            float maxDistance = (bulletImpulse * bulletImpulse * Mathf.Sin(2 * radianAngle)) / g;

            for (int i = 0; i <= resolution; i++)
            {
                float t = (float)i / (float)resolution;
                arcArray[i] = CalculateArcPoint(t, maxDistance);
            }
            return arcArray;
        }

        Vector3 CalculateArcPoint (float t, float maxDistance)
    
        {
            float z = t * maxDistance;
            float y = z * Mathf.Tan(radianAngle) - ((g * z * z) / (2 * bulletImpulse * bulletImpulse * Mathf.Cos(radianAngle) * Mathf.Cos(radianAngle)));
            return new Vector3(0.5f, y, z);
        }

    void Reload()
    {
            GameObject[] sbullets = GameObject.FindGameObjectsWithTag("StickyBullet");
            GameObject[] bbullets = GameObject.FindGameObjectsWithTag("bouncyBullet");
            //remove bullets from scene and reset ammo
            foreach (var bullet in sbullets)
            {
                GameObject.Destroy(bullet);
            }
            foreach (var bullet in bbullets)
            {
                GameObject.Destroy(bullet);
            }
            stickyAmmo = 3;
            bouncyAmmo = 2;
        }
    }

 
