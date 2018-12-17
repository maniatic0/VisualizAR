using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsHandler : MonoBehaviour {

	[SerializeField]
	private AnimateLineAxis xAxis;

	[SerializeField]
	private AnimateLineAxis yAxis;

	[SerializeField]
	private AnimateLineAxis zAxis;

	private int currState = 0;

	private readonly int maxState = 4;
	
	public void Click () {
		currState = (currState + 1) % maxState;
		switch (currState)
		{
			case 0:
				xAxis.noaxisfunc();
				yAxis.noaxisfunc();
				zAxis.noaxisfunc();
				break;
			case 1:
				xAxis.negaxisfunc();
				yAxis.negaxisfunc();
				zAxis.negaxisfunc();
				break;
			case 2:
				xAxis.regularaxisfunc();
				yAxis.regularaxisfunc();
				zAxis.regularaxisfunc();
				break;
			case 3:
				xAxis.doubleaxisfunc();
				yAxis.doubleaxisfunc();
				zAxis.doubleaxisfunc();
				break;
			default:
				Debug.LogError("What!!!", this);
				break;
		}
	}
}
