using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchWeapon : MonoBehaviour {
    public static int CurrentWeapon = 0;
    public  int CurWeapon = 0;
    public RawImage CWeapon;
    public RawImage PWeapon;
    public RawImage FWeapon;
    public Text AmmoDisplay;
    public GameObject paintCan, Gun;

    public Texture sticky, bouncy, unarmed, Paint;

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        CurWeapon = CurrentWeapon;
        // 0 is Stick
        // 1 is Bouncy
        // 2 is Paint
        // 3 is unarmed

        if (Time.timeScale == 1)
        {
            if (Input.GetButtonDown("ItemSwitchRight"))
            {
                if (CurrentWeapon >= 3)
                {
                    CurrentWeapon = 0;
                   
                }
                else
                {
                    CurrentWeapon++;

                }
            }
            if (Input.GetButtonDown("ItemSwitchleft"))
            {
                if (CurrentWeapon <= 0)
                {
                    CurrentWeapon = 3;
                    
                }
                else
                {
                    CurrentWeapon--;
                    
                }
            }
        }
        
        if(CurrentWeapon == 0)
        {
            paintCan.SetActive(false);
            Gun.SetActive(true);
            
            CWeapon.texture = sticky;
            PWeapon.texture = unarmed;
            FWeapon.texture = bouncy;

            AmmoDisplay.text = shooting.stickyAmmo.ToString();

        }
        else if(CurrentWeapon == 1)
        {
            paintCan.SetActive(false);
            Gun.SetActive(true);

            CWeapon.texture = bouncy;
            PWeapon.texture = sticky;
            FWeapon.texture = Paint;

            AmmoDisplay.text = shooting.bouncyAmmo.ToString();

        }
        else if(CurrentWeapon == 2)
        {
            Gun.SetActive(false);
            paintCan.SetActive(true);
            
            CWeapon.texture = Paint;
            PWeapon.texture = bouncy;
            FWeapon.texture = unarmed;

            AmmoDisplay.text = "\u221E";
        }
        else
        {
            Gun.SetActive(false);
            paintCan.SetActive(false);

            CWeapon.texture = unarmed;
            PWeapon.texture = Paint;
            FWeapon.texture = sticky;

            AmmoDisplay.text = "\u221E";

        }
    }
}
