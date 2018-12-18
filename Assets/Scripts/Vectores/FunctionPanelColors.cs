using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunctionPanelColors : MonoBehaviour
{
    [SerializeField]
	private UnityEngine.UI.Image suma;

    [SerializeField]
	private UnityEngine.UI.Image resta;

    [SerializeField]
	private UnityEngine.UI.Image punto;

    [SerializeField]
	private UnityEngine.UI.Image cruz;

    [SerializeField]
	private Color toggleColor = Color.green;

    [SerializeField]
	private Color inactiveColor = Color.white;

    // Start is called before the first frame update
    void Start()
    {
        LimpiarColor();
    }

    public void LimpiarColor() 
    {
        suma.color = inactiveColor;
        resta.color = inactiveColor;
        punto.color = inactiveColor;
        cruz.color = inactiveColor;
    }

    public void SumaColor() 
    {
        suma.color = toggleColor;
        resta.color = inactiveColor;
        punto.color = inactiveColor;
        cruz.color = inactiveColor;
    }

    public void RestaColor() 
    {
        suma.color = inactiveColor;
        resta.color = toggleColor;
        punto.color = inactiveColor;
        cruz.color = inactiveColor;
    }

    public void PuntoColor() 
    {
        suma.color = inactiveColor;
        resta.color = inactiveColor;
        punto.color = toggleColor;
        cruz.color = inactiveColor;
    }

    public void CruzColor() 
    {
        suma.color = inactiveColor;
        resta.color = inactiveColor;
        punto.color = inactiveColor;
        cruz.color = toggleColor;
    }
}
