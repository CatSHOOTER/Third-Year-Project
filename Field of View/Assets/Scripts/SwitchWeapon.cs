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
            CWeapon.texture = sticky;
            PWeapon.texture = unarmed;
            FWeapon.texture = bouncy;
        }
        else if (CurrentWeapon == 1)
        {
            CWeapon.texture = bouncy;
            PWeapon.texture = sticky;
            FWeapon.texture = Paint;
        }
        else if (CurrentWeapon == 2)
        {
            CWeapon.texture = Paint;
            PWeapon.texture = bouncy;
            FWeapon.texture = unarmed;
        }
        else
        {
            CWeapon.texture = unarmed;
            PWeapon.texture = Paint;
            FWeapon.texture = sticky;
        }
    }
}
