using UnityEngine;
using System.Collections;


public class menuCamControl : MonoBehaviour
{ 
    public Transform currentMount;
    public float speedFactor = 0.1f;
    public static bool WinEndGame = false;

    void Start()
    {

    }

    public void Update()
    {
        transform.position = Vector3.Lerp(transform.position, currentMount.position, speedFactor);
        transform.rotation = Quaternion.Slerp(transform.rotation, currentMount.rotation, speedFactor);

        if (WinEndGame == true)
        {
            setMount(GameObject.Find("WinnerInputMount").transform);
            WinEndGame = false;
        }
    }

    public void setMount(Transform newMount)
    {
        currentMount = newMount;
    }
}