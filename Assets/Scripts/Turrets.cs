using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Turrets : MonoBehaviour
{
	//lists all available turrets
	public List<GameObject> turrets;
	//shooting cooldown boolean
	private bool isInCooldown = false;
	//float value to calculate the distance between mousePos and turrets
	public float distanceToMouse;
	//detirmines the turret with the shortest distance
	float shortestDistance = Mathf.Infinity;
	//checks if the turret is capable of shooting based of closest distance logic
	[SerializeField]
	private bool canShoot = false;
	
    void Update()
    {
		//on click, the game outputs the players current mouse position
		var posVector = Camera.main.ScreenToWorldPoint(Input.mousePosition);
		posVector.z = transform.position.z;
			
		//allows this to update every frame
		shortestDistance = Mathf.Infinity;
		
		//loop through all the turret tagged game objects
		GameObject[] turrets = GameObject.FindGameObjectsWithTag("turret");
		foreach (GameObject turret in turrets)
		{
			//calculate the distance between the turret and mouse position
			float distance = Vector3.Distance(posVector, turret.transform.position);
			
			//update the values between mouse and turrets
			if(distance < shortestDistance)
			{
				shortestDistance = distance;
				canShoot = true;
			}
		}
		
		FaceMouse();
		
		if(Input.GetMouseButton(0) && !isInCooldown)
		
		{
			//calculate the distance between the turret and the mouse position
			distanceToMouse = Vector3.Distance(transform.position, posVector);
			
			//Checks to see if position checking works ;)
			Debug.Log("MousePosX" + posVector.x);
			Debug.Log("MousePosY" + posVector.y);
			
			//shoot
			Shoot();
    }
		else
    {
		//shooting cooldown
       Invoke("ResetCooldown", 2f);
       isInCooldown = true;
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
	
	public void Shoot()
	{
		if(canShoot)
		{
    //put future shooting logic here
    Debug.Log("Turret is shooting!");
	}
}
}
