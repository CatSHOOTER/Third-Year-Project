using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrafficLightsScript : MonoBehaviour {

    public GameObject Stoper1;
    public GameObject Stoper2;
    public GameObject Stoper3;
    public GameObject FristLightRed;
    public GameObject FristLightGreen;
    public GameObject FristLightAmber;
    public GameObject SecondLightRed;
    public GameObject SecondLightGreen;
    public GameObject SecondLightAmber;
    float timeLeft = 10f;
    float timeLeft2 = 10f;
    float Delaytime = 2f;
    float Delaytime2 = 2f;
    // Use this for initialization
    void Start () {
		
        Stoper2 = GameObject.Find("Cube (1)");
        Stoper3 = GameObject.Find("Cube (2)");
        Stoper1 = GameObject.Find("Cube");
        FristLightRed = GameObject.Find("FRed");
        FristLightGreen = GameObject.Find("FGreen");
        FristLightAmber = GameObject.Find("Famber");
        SecondLightRed = GameObject.Find("SRed");
        SecondLightGreen = GameObject.Find("SGreen");
        SecondLightAmber = GameObject.Find("Samber");
        Stoper2.GetComponent<BoxCollider>().enabled = false;

        
        Behaviour Red = (Behaviour)FristLightRed.GetComponent("Halo");
        Red.enabled = true;
        Behaviour Amber = (Behaviour)FristLightAmber.GetComponent("Halo");
        Amber.enabled = false;
        Behaviour Green = (Behaviour)FristLightGreen.GetComponent("Halo");
        Green.enabled = false;

        Behaviour SRed = (Behaviour)SecondLightRed.GetComponent("Halo");
        SRed.enabled = false;
        Behaviour SAmber = (Behaviour)SecondLightAmber.GetComponent("Halo");
        SAmber.enabled = false;
        Behaviour SGreen = (Behaviour)SecondLightGreen.GetComponent("Halo");
        SGreen.enabled = true;


    }
	
	// Update is called once per frame
	void Update ()
    {


        //if (Lights.GetComponent<BoxCollider>().enabled == true)
        //{
            timeLeft -= Time.deltaTime;
            if (timeLeft < 0)
            {
            Behaviour Red = (Behaviour)FristLightRed.GetComponent("Halo");
            Red.enabled = false;

            Behaviour Amber = (Behaviour)FristLightAmber.GetComponent("Halo");
            Amber.enabled = true;

            Behaviour SGreen = (Behaviour)SecondLightGreen.GetComponent("Halo");
            SGreen.enabled = false;

            Behaviour SAmber = (Behaviour)SecondLightAmber.GetComponent("Halo");
            SAmber.enabled = true;

            Stoper2.GetComponent<BoxCollider>().enabled = true;

                Delaytime -= Time.deltaTime;
                if (Delaytime < 0)
                {
                Behaviour Amber2 = (Behaviour)FristLightAmber.GetComponent("Halo");
                Amber2.enabled = false;

                Behaviour Green = (Behaviour)FristLightGreen.GetComponent("Halo");
                Green.enabled = true;

                Behaviour SAmber2 = (Behaviour)SecondLightAmber.GetComponent("Halo");
                SAmber2.enabled = false;

                Behaviour SRed = (Behaviour)SecondLightRed.GetComponent("Halo");
                SRed.enabled = true;

                Stoper1.GetComponent<BoxCollider>().enabled = false;
                Stoper3.GetComponent<BoxCollider>().enabled = false;

                timeLeft2 -= Time.deltaTime;
                if (timeLeft2 < 0)
                {
                    Behaviour Amber3 = (Behaviour)FristLightAmber.GetComponent("Halo");
                    Amber3.enabled = true;

                    Behaviour Green2 = (Behaviour)FristLightGreen.GetComponent("Halo");
                    Green2.enabled = false;

                    Behaviour SAmber3 = (Behaviour)SecondLightAmber.GetComponent("Halo");
                    SAmber3.enabled = true;

                    Behaviour SRed2 = (Behaviour)SecondLightRed.GetComponent("Halo");
                    SRed2.enabled = false;

                    Stoper1.GetComponent<BoxCollider>().enabled = true;
                    Stoper3.GetComponent<BoxCollider>().enabled = true;
                    Delaytime2 -= Time.deltaTime;
                    if (Delaytime2 < 0)
                    {
                        Behaviour Amber4 = (Behaviour)FristLightAmber.GetComponent("Halo");
                        Amber4.enabled = false;

                        Behaviour Red2 = (Behaviour)FristLightRed.GetComponent("Halo");
                        Red2.enabled = true;

                        Behaviour SAmber4 = (Behaviour)SecondLightAmber.GetComponent("Halo");
                        SAmber4.enabled = false;

                        Behaviour SGreen2 = (Behaviour)SecondLightGreen.GetComponent("Halo");
                        SGreen2.enabled = true;

                        Stoper2.GetComponent<BoxCollider>().enabled = false;
                        timeLeft2 = 10f;
                        Delaytime2 = 2f;
                        timeLeft = 10f;
                        Delaytime = 2f;

                    }
                }

                }
                
            }
           
        
        //else if (Lights.GetComponent<BoxCollider>().enabled == false)
        //{
        //    timeLeft -= Time.deltaTime;
        //    while (timeLeft < 0)
        //    {
        //        Lights.GetComponent<BoxCollider>().enabled = true;
        //        Delaytime -= Time.deltaTime;
        //        while (Delaytime < 0)
        //        {
        //            Lights2.GetComponent<BoxCollider>().enabled = false;
        //            timeLeft = 2f;
        //        }
        //        timeLeft = 10f;
        //    }

        //}




    }
}
