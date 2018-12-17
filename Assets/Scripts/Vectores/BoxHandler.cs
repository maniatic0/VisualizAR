using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxHandler : MonoBehaviour {

	[SerializeField]
	private UnityEngine.UI.Image background;

	[SerializeField]
	private AnimateLine line1;

	[SerializeField]
	private AnimateLine line2;

	[SerializeField]
	private Color toggleColor = Color.green;

    [SerializeField]
    private Color toggleColor2 = Color.blue;

    private bool state = false;

    private int activate = 0;

	private Color original;

	private void Start() {
		original = background.color;
	}

	public void OnClick() {
		state = !state;

        activate++;

        if (activate > 2)
        {
            activate = 0;
        }

		if (activate == 1)
		{
			line1.proyectedfunc();
			background.color = toggleColor;
		}
        else if (activate == 2)
        {
            line1.unproyectedfunc();
            line2.proyectedfunc();
            background.color = toggleColor2;
        }
        else {
			line2.unproyectedfunc();
			background.color = original;
		}
	}
}
