using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ActivatePlane : MonoBehaviour {

    public GameObject plane;

    public bool activate = false;

    public void planeactivatefunc()
    {
        activate = true;
    }

    public void planedeactivatefunc()
    {
        activate = false;
    }

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		
        if (activate)
        {
            plane.SetActive(true);
        }
        else
        {
            plane.SetActive(false);
        }
	}
}
 