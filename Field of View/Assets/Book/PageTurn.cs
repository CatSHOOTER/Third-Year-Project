using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PageTurn : MonoBehaviour
{
    public GameObject rotatorL;
    public GameObject rotatorR;
    public float speed = 90f;
    private bool leftRotate = false;
    private bool rightRotate = false;

    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;
    public GameObject Page5;
    public GameObject Page6;
    public GameObject Page7;
    public GameObject Page8;
    public AudioClip TurnPage;
    private bool Set1Visible = false;
    private bool Set2Visible = false;
    private bool Set3Visible = false;
    private bool Set4Visible = false;
    public CanvasGroup LoadingCanves;
    public Animator left;
    public Animator right;
    


    // Use this for initialization
    void Start ()
    {
        Set1Visible = true;
        left = GetComponentInChildren<Animator>();
        right = GetComponentInChildren<Animator>();
        
	}
	
	// Update is called once per frame
	void Update ()
    {
        if(Set1Visible == true)
        {
            Page1.SetActive(true);
            Page2.SetActive(true);
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page5.SetActive(false);
            Page6.SetActive(false);
            Page7.SetActive(false);
            Page8.SetActive(false);
        }
        else if(Set2Visible == true)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(true);
            Page4.SetActive(true);
            Page5.SetActive(false);
            Page6.SetActive(false);
            Page7.SetActive(false);
            Page8.SetActive(false);
        }
        else if (Set3Visible == true)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page5.SetActive(true);
            Page6.SetActive(true);
            Page7.SetActive(false);
            Page8.SetActive(false);
        }
        else if (Set4Visible == true)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(false);
            Page5.SetActive(false);
            Page6.SetActive(false);
            Page7.SetActive(true);
            Page8.SetActive(true);
        }
        if (leftRotate == true)
        {
            right.Play("RPageFlip");
            leftRotate = false;
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = TurnPage;
            audio.Play();
            leftRotate = false;


        }
        else if (rightRotate == true)
        {
            left.Play("LPageFlip");
            rightRotate = false;
            AudioSource audio = GetComponent<AudioSource>();
            audio.clip = TurnPage;
            audio.Play();
            rightRotate = false;

        }


        if (Input.GetButtonDown("ItemSwitchleft") || Input.GetButtonDown("Fire1"))
        {
            //go back a page
            //rotate page -180
            //possible to reset page rotation?
            if(Set1Visible== true)
            {

            } 
            else if(Set2Visible == true)
            {
                Set1Visible = true;
                Set2Visible = false;
                Set3Visible = false;
                Set4Visible = false;
            }
            else if(Set3Visible == true)
            {
                Set1Visible = false;
                Set2Visible = true;
                Set3Visible = false;
                Set4Visible = false;
            }
            else if(Set4Visible == true)
            {
                Set1Visible = false;
                Set2Visible = false;
                Set3Visible = true;
                Set4Visible = false;
            }
            leftRotate = true;
            rightRotate = false;
            //rotatorR.transform.Rotate(Page * Time.deltaTime * speed);

        }
        else if(Input.GetButtonDown("ItemSwitchRight") || Input.GetButtonDown("Jump"))
        {
            //go forward a page
            //rotate page 180
            //rotatorL.transform.Rotate(-Page * Time.deltaTime * speed);
            if (Set1Visible == true)
            {
                Set1Visible = false;
                Set2Visible = true;
                Set3Visible = false;
                Set4Visible = false;
            }
            else if (Set2Visible == true)
            {
                Set1Visible = false;
                Set2Visible = false;
                Set3Visible = true;
                Set4Visible = false;
            }
            else if(Set3Visible == true)
            {
                Set1Visible = false;
                Set2Visible = false;
                Set3Visible = false;
                Set4Visible = true;
            }
            else if (Set4Visible == true)
            {
                LoadingCanves.alpha = 1;
                SceneManager.LoadScene("FOV");
            }
            rightRotate = true;
            leftRotate = false;
        }
	}
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Book")
        {

        }
    }
}
