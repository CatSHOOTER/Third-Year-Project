using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour {
    Vector3 StartPos;
    public CanvasGroup Fade;
    
    // Use this for initialization
    void Start () {
        StartPos = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z);
	}

    

    public void Died()
    {
            Fade.alpha = 1;
       
        
            StartCoroutine(FadeIN(Fade,Fade.alpha,0));
        
        gameObject.transform.position = StartPos;
            playerController.currentlives--;
        
    }
   public IEnumerator FadeIN(CanvasGroup AP,float StartA,float EndA,float speed = 0.15f)
    {
        
        while (true)
        {
            

            float AlphaValue = AP.alpha;
            AlphaValue -= speed * Time.deltaTime;


            AP.alpha = AlphaValue;
            if( AlphaValue >= 1 ) break;

        yield return new WaitForEndOfFrame();
        }
        
        
    }
}
