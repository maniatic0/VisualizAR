using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class MenuController : MonoBehaviour {
	
	public GameObject menuButton;
	
	public GameObject[] contentAssociated;
	
	public GameObject[] fellowBtns;
	
	GameObject thisBtn;
	
	SphereCollider InvisibleButton;
	Vector3 ButtonPosition;
	float ButtonRadius;
	
	public Vector3 ExitButtonPosition;
	public float ExitButtonRadius;
	
	//true = Menu Mode & false = Content Mode
	bool mode;
	//true = Usable & fale = unusable
	bool hideState;
	
	// Use this for initialization
	void Start () {
		
		thisBtn = this.gameObject;
		
		//Getting pointers to main button sphere collider and its position/scale
		InvisibleButton = this.GetComponent<SphereCollider>();
		ButtonPosition = InvisibleButton.center;
		ButtonRadius = InvisibleButton.radius;

		//Setting Initial Conditions
		mode = true;
		hideState = true;
	}
	
	// Update is called once per frame
	void Update () {

			//Menu Mode
			if(mode==true && hideState==true)
			{
				//Keeps the button size/position as initially created
				InvisibleButton.center = ButtonPosition;
				InvisibleButton.radius = ButtonRadius;

				
				menuButton.SetActive(true);
				foreach(GameObject content in contentAssociated)
				{
					content.SetActive(false);
				}
				
			
				thisBtn.SetActive(true);
				

			}
			
			//Content Mode
			if(mode==false && hideState==true)
			{
				//Changes the shape of the button into the developer defined exit size/position
				InvisibleButton.center = ExitButtonPosition;
				InvisibleButton.radius = ExitButtonRadius;

				
				menuButton.SetActive(false);
				foreach(GameObject content in contentAssociated)
				{
					content.SetActive(true);
				}
			
				thisBtn.SetActive(true);

			
			}
			//Hide Mode
			if(mode==true && hideState==false)
			{

				menuButton.SetActive(false);
								
				thisBtn.SetActive(false);
			}
			
		}
	
	//}
	
	void TouchEvent()
	{
		mode = !mode;
		if (mode==false && hideState==true)
		{
				foreach (GameObject btn in fellowBtns)
				{
					btn.SendMessage("NotMe");
				}
		}
		else{
				foreach (GameObject btn in fellowBtns)
				{
					btn.SetActive(true);
					btn.SendMessage("NotMe");
				}
		}
		
	}
	
	void NotMe ()
	{
		hideState = !hideState;
	}
	
}


