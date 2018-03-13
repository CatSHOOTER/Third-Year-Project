using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class bullet : MonoBehaviour {

	GameObject player;
	float lifeSpan = 5.0f;

    //public static Text bouncyCounttx;
    //public static Text stickyCounttx;

    // Use this for initialization
    void Start () 
	{
		player = GameObject.FindWithTag ("Player");
	}
	
	// Update is called once per frame
	void Update () 
	{
        if (Mathf.Round(transform.position.x) == Mathf.Round(player.transform.position.x) && Mathf.Round(transform.position.z) == Mathf.Round(player.transform.position.z))
        {
            if (this.gameObject.tag == "StickyBullet")
            {
                shooting.stickyAmmo++;
                // gameObject.GetComponent<PlayerUI>().stickyCounttx.text ="Sticky " + player.GetComponent<shooting>().stickyAmmo.ToString();
                Destroy(this.gameObject);
            }

        }

        if (this.gameObject.tag == "bouncyBullet")
        {
            lifeSpan -= Time.deltaTime;

            if (lifeSpan <= 0)
            {
                shooting.bouncyAmmo++;
                // gameObject.GetComponent<PlayerUI>().bouncyCounttx.text = "Bouncy " + player.GetComponent<shooting>().stickyAmmo.ToString();
                Destroy(this.gameObject);
            }
        }

    }

    void OnCollisionEnter(Collision collision)
    {
        if (this.gameObject.tag == "StickyBullet")
        {
            if (collision.gameObject.tag != "Human" && collision.gameObject.tag != "Dog")
            {

                FixedJoint fj = this.gameObject.AddComponent(typeof(FixedJoint)) as FixedJoint;
                fj.connectedBody = collision.rigidbody;
            }
            
            
        }

    }
}
