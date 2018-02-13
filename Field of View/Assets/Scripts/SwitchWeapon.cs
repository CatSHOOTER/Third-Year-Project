using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchWeapon : MonoBehaviour {
    public static int CurrentWeapon = 0;
    public  int CurWeapon = 0;
<<<<<<< HEAD
    public Text CWeapon;
    public Text PWeapon;
    public Text FWeapon;
=======
    public RawImage CWeapon;
    public RawImage PWeapon;
    public RawImage FWeapon;
    public Text AmmoDisplay;

    public Texture sticky, bouncy, unarmed, Paint;
>>>>>>> 8e6c19a0f46f38ff56de1aaafe5b7f55a5811433
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
                    Debug.Log(CurrentWeapon);
                }
                else
                {
                    CurrentWeapon++;
                    Debug.Log(CurrentWeapon);
                }
            }
            if (Input.GetButtonDown("ItemSwitchleft"))
            {
                if (CurrentWeapon <= 0)
                {
                    CurrentWeapon = 3;
                    Debug.Log(CurrentWeapon);
                }
                else
                {
                    CurrentWeapon--;
                    Debug.Log(CurrentWeapon);
                }
            }
        }
        
        if(CurrentWeapon == 0)
        {
<<<<<<< HEAD
            CWeapon.text = "S";
            PWeapon.text = "U";
            FWeapon.text = "B";
=======
            CWeapon.texture = sticky;
            PWeapon.texture = unarmed;
            FWeapon.texture = bouncy;

            AmmoDisplay.text = shooting.stickyAmmo.ToString();
>>>>>>> 8e6c19a0f46f38ff56de1aaafe5b7f55a5811433
        }
        else if(CurrentWeapon == 1)
        {
<<<<<<< HEAD
            CWeapon.text = "B";
            PWeapon.text = "S";
            FWeapon.text = "P";
=======
            CWeapon.texture = bouncy;
            PWeapon.texture = sticky;
            FWeapon.texture = Paint;

            AmmoDisplay.text = shooting.bouncyAmmo.ToString();
>>>>>>> 8e6c19a0f46f38ff56de1aaafe5b7f55a5811433
        }
        else if(CurrentWeapon == 2)
        {
<<<<<<< HEAD
            CWeapon.text = "P";
            PWeapon.text = "B";
            FWeapon.text = "U";
        }
        else
        {
            CWeapon.text = "U";
            PWeapon.text = "P";
            FWeapon.text = "S";
=======
            CWeapon.texture = Paint;
            PWeapon.texture = bouncy;
            FWeapon.texture = unarmed;

            AmmoDisplay.text = "~";
        }
        else
        {
            CWeapon.texture = unarmed;
            PWeapon.texture = Paint;
            FWeapon.texture = sticky;

            AmmoDisplay.text = "~";
>>>>>>> 8e6c19a0f46f38ff56de1aaafe5b7f55a5811433
        }
    }
}
