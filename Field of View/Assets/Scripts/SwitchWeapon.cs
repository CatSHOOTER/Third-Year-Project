using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SwitchWeapon : MonoBehaviour {
    public static int CurrentWeapon = 0;
    public Text CWeapon;
    public Text PWeapon;
    public Text FWeapon;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        // 0 is Stick
        // 1 is Bouncy
        // 2 is Paint
        if(Input.GetButtonDown("ItemSwitchRight"))
        {
            if (CurrentWeapon >= 2)
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
                CurrentWeapon = 2;
                Debug.Log(CurrentWeapon);
            }
            else
            {
                CurrentWeapon--;
                Debug.Log(CurrentWeapon);
            }
        }
        if(CurrentWeapon == 0)
        {
            CWeapon.text = "S";
            PWeapon.text = "P";
            FWeapon.text = "B";
        }
        else if(CurrentWeapon == 1)
        {
            CWeapon.text = "B";
            PWeapon.text = "S";
            FWeapon.text = "P";
        }
        else
        {
            CWeapon.text = "P";
            PWeapon.text = "B";
            FWeapon.text = "S";
        }
    }
}
