using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

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

        if (currentMount.parent.name == "Radio")
        {
            EventSystem.current.SetSelectedGameObject(currentMount.parent.transform.GetChild(3).gameObject);
        }
        else if (currentMount.parent.name == "TVset")
        {
            EventSystem.current.SetSelectedGameObject(currentMount.parent.parent.transform.GetChild(1).gameObject);
            Debug.Log(currentMount.parent.parent.transform.GetChild(1).gameObject);
        }
        else if (currentMount.parent.name == "LeaderBoardPanel" || currentMount.parent.name == "WinnerInputPanel")
        {
            EventSystem.current.SetSelectedGameObject(currentMount.parent.transform.GetChild(2).gameObject);
        }
        else
        {
            EventSystem.current.SetSelectedGameObject(currentMount.parent.transform.GetChild(0).GetChild(0).gameObject);
        }


    }
}