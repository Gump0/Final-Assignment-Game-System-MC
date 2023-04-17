using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
	private bool isInCooldown = false;
	
    void Update()
    {
		FaceMouse();
		
		if(Input.GetMouseButton(0) && !isInCooldown)
		
		{
			//on click, the game outputs the players current mouse position
			var posVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
			posVector.z = transform.position.z;
			//Checks to see if position checking works ;)
			Debug.Log("MousePosX" + posVector.x);
			Debug.Log("MousePosY" + posVector.y);
    }
}
    
    public void FaceMouse()
    {
		//grabs current mouse position
		Vector3 mousePos = Input.mousePosition;
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		//draws a vector from moise to turret
		Vector2 direction = new Vector2(
		mousePos.x - transform.position.x, mousePos.y - transform.position.y);
		
		//by defualt the turret is looking up, this sets the defualt transform to be dependant on mouse
		transform.up = direction;
	}
	private void ResetCooldown()
	{
		isInCooldown = false;	
	}
}
