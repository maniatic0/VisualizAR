using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DebugVectorPos : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Text vectorText;

	[SerializeField]
	private Transform vector1;

	private Vector3 vector1Pos = Vector3.zero;

	private bool updateVector1 = false;

	[SerializeField]
	private Transform vector2;

	private Vector3 vector2Pos = Vector3.zero;

	private bool updateVector2 = false;

	[SerializeField]
	private Transform center;

	private Vector3 centerPos = Vector3.zero;

	private bool updateCenter = false;

	public void UpdateVector1Pos() {
		updateVector1 = true;
	}

	public void StopUpdateVector1Pos() {
		updateVector1 = false;
	}

	public void UpdateVector2Pos() {
		updateVector2 = true;
	}

	public void StopUpdateVector2Pos() {
		updateVector2 = false;
	}

	public void UpdateCenterPos() {
		updateCenter = true;
	}

	public void StopUpdateCenterPos() {
		updateCenter = false;
	}
	
	private void Start() {
		Tracker track;
		track = vector1.GetComponent<Tracker>();

		track.OnTrackingFound += UpdateVector1Pos;
		track.OnTrackingLost += StopUpdateVector1Pos;

		track = vector2.GetComponent<Tracker>();

		track.OnTrackingFound += UpdateVector2Pos;
		track.OnTrackingLost += StopUpdateVector2Pos;

		track = center.GetComponent<Tracker>();

		track.OnTrackingFound += UpdateCenterPos;
		track.OnTrackingLost += StopUpdateCenterPos;
	}

	// Update is called once per frame
	void FixedUpdate () {

		if (updateVector1)
		{
			vector1Pos = vector1.position;
		}

		if (updateVector2)
		{
			vector2Pos = vector2.position;
		}

		if (updateCenter)
		{
			centerPos = center.position;
		}

		vectorText.text = string.Format(
			"Center[{0}]: {1}\nVector1[{2}]: {3}\nVector2[{4}]: {5}",
			updateCenter.ToString(),
			centerPos.ToString(),  
			updateVector1.ToString(),
			vector1Pos.ToString(),
			updateVector2.ToString(), 
			vector2Pos.ToString()
		);
	}
}
