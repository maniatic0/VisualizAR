using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneHandler : MonoBehaviour {

    [SerializeField]
    private UnityEngine.UI.Image background;

    [SerializeField]
    private ActivatePlane axisx;

    [SerializeField]
    private ActivatePlane axisy;

    [SerializeField]
    private ActivatePlane axisz;

    private int activate = 0;

    // Use this for initialization
    private void Start () {
		
	}

    // Update is called once per frame
    public void OnClick()
    {

        activate++;

        if (activate > 4)
        {
            activate = 0;
        }

        switch (activate)
        {
            case 4:
                axisx.planeactivatefunc();
                axisy.planeactivatefunc();
                axisz.planeactivatefunc();
                break;
            case 3:
                axisy.planedeactivatefunc();
                axisz.planeactivatefunc();
                break;
            case 2:
                axisx.planedeactivatefunc();
                axisy.planeactivatefunc();
                break;
            case 1:
                axisx.planeactivatefunc();
                break;
            case 0:
                axisx.planedeactivatefunc();
                axisy.planedeactivatefunc();
                axisz.planedeactivatefunc();
                break;
        }

	}
}
