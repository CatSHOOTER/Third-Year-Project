using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditPath : MonoBehaviour {

    public Color rayC = Color.white;
    public List<Transform> pathObjs = new List<Transform>();
    Transform[] Array;
	// Use this for initialization
	void OnDrawGizmos ()
    {
        Gizmos.color = rayC;
        Array = GetComponentsInChildren <Transform> ();
        pathObjs.Clear();

        foreach (Transform pathObj in Array)
        {
            if (pathObj != this.transform)
            {
                pathObjs.Add(pathObj);
            }
        }
        for (int i = 0; i < pathObjs.Count; i++)
        {
            Vector3 position = pathObjs[i].position;
            if (i > 0)
            {
                Vector3 previous = pathObjs[i - 1].position;
                Gizmos.DrawLine(previous, position);
                Gizmos.DrawWireSphere(position, 0.3f);
            }
        }
	}
	
	
}
