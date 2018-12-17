using UnityEngine;
using System.Collections;

public class TouchController : MonoBehaviour {
	
	public int Layer;
	int layerMask;
	
	// Use this for initialization
	void Start () {
		layerMask = 1<<Layer;
	}
	
	// Update is called once per frame
	void Update () {
	
		
		
		RaycastHit hit = new RaycastHit();
	        for (int i = 0; i < Input.touchCount; ++i) {
	            if (Input.GetTouch(i).phase.Equals(TouchPhase.Began)) {
	            // Construct a ray from the current touch coordinates
	            Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(i).position);
	            if (Physics.Raycast(ray, out hit, layerMask)) {
	                hit.transform.gameObject.SendMessage("TouchEvent");
					Debug.Log("Touch event is called "+ hit.transform.gameObject);
              	}
			}
		}
	}
}
