using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class MissileManager : MonoBehaviour
{
    public GameObject friendlyMissile, enemyMissiles, turret1, turret2, turret3, city1, city2, city3, city4, city5, city6, enemySpawnCorner1, enemySpawnCorner2;

    private Vector2 turret1Pos, turret2Pos, turret3Pos, mainTurret;

    private float turret1Distance, turret2Distance, turret3Distance, lowestIndex, lowestValue, enemyMissileAmmount;

    [HideInInspector] public Vector2 currentEnemyMissileDestination;

    private float[] distanceValues = new float[3];
    private Vector2[] buildingLocations = new Vector2[9];
    //ammo stuff
    private float maxAmmo = 15;
    public float currentAmmo;
    private float t1CAmmo;
    private float t2CAmmo;
    private float t3CAmmo;
    //ammo text stuff
    [SerializeField]
    TextMeshProUGUI ammoOne;
    [SerializeField]
    TextMeshProUGUI ammoTwo;
    [SerializeField]
    TextMeshProUGUI ammoThree;

    // Start is called before the first frame update
    void Start()
    {
        //sets the turretpos vectors to the position of the turrets
        turret1Pos = turret1.transform.position;
        turret2Pos = turret2.transform.position;
        turret3Pos = turret3.transform.position;

        lowestIndex = -1;

        //adds all the locations of the buildings to the array
        buildingLocations[0] = turret1.transform.position;
        buildingLocations[1] = turret2.transform.position;
        buildingLocations[2] = turret3.transform.position;
        buildingLocations[3] = city1.transform.position;
        buildingLocations[4] = city2.transform.position;
        buildingLocations[5] = city3.transform.position;
        buildingLocations[6] = city4.transform.position;
        buildingLocations[7] = city5.transform.position;
        buildingLocations[8] = city6.transform.position;

        enemyMissileAmmount = 12;
        //resets ammo capacity for turrets
        currentAmmo = maxAmmo;
		t1CAmmo = maxAmmo;
		t2CAmmo = maxAmmo;
		t3CAmmo = maxAmmo;
		
		//initialize text
		ammoOne = GetComponent<TextMeshProUGUI>();
		ammoTwo = GetComponent<TextMeshProUGUI>();
		ammoThree = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        ChooseMainTurret();

        ChooseEnemyMissileDestination();

        if (enemyMissileAmmount >= 0)
        {
            SpawnEnemyMissile();
            enemyMissileAmmount-= 1;
            
        //update UI ammo text
        ammoOne.text = t1CAmmo.ToString();
        ammoTwo.text = t2CAmmo.ToString();
        ammoThree.text = t3CAmmo.ToString();
        }
    }
	
    private void ChooseMainTurret()
    {
        //sets mousePos to the position of the mouse
        Vector2 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        //tracks the distance between the mouse and each of the turrets
        turret1Distance = Vector2.Distance(mousePos, turret1Pos);
        turret2Distance = Vector2.Distance(mousePos, turret2Pos);
        turret3Distance = Vector2.Distance(mousePos, turret3Pos);

        //assigns the distances of all the turrest to the floats in the disatnce array
        distanceValues[0] = turret1Distance;
        distanceValues[1] = turret2Distance;
        distanceValues[2] = turret3Distance;

        //resets the lowest value of the array so that it can be retested
        lowestValue = 100;

        //checks all the distances of the turrest to find the closest one
        for (int i = 0; i < distanceValues.Length; i++)
        {
            if (distanceValues[i] < lowestValue)
            {
                lowestValue = distanceValues[i];
                lowestIndex = i;
            }
        }

        //assigns the location of the main turret to the one that is closest to the mouse
        if(lowestIndex == 0)
        {
            mainTurret = turret1Pos;
            if(Input.GetMouseButtonDown(0) && t1CAmmo > 0)
            {
				Instantiate(friendlyMissile, mainTurret, Quaternion.identity);
				t1CAmmo -= 1;
			}    
        }
        else if (lowestIndex == 1)
        {
            mainTurret = turret2Pos;
            if(Input.GetMouseButtonDown(0) && t2CAmmo > 0)
            {
				Instantiate(friendlyMissile, mainTurret, Quaternion.identity);
				t2CAmmo -= 1;
			}    
        }
        else if (lowestIndex == 2)
        {
            mainTurret = turret3Pos;
            if(Input.GetMouseButtonDown(0) && t3CAmmo > 0)
            {
				Instantiate(friendlyMissile, mainTurret, Quaternion.identity);
				t3CAmmo -= 1;
			}    
        }

    }

	private void Ammunition()
	{
		
	}

    private void ChooseEnemyMissileDestination()
    {
        float randomBuilding = UnityEngine.Random.Range(0, buildingLocations.Length);
        
        currentEnemyMissileDestination = buildingLocations[Mathf.FloorToInt(randomBuilding)];
    }





    private void SpawnEnemyMissile()
    {
        Instantiate(enemyMissiles, new Vector2(UnityEngine.Random.Range(enemySpawnCorner1.transform.position.x, enemySpawnCorner2.transform.position.x), UnityEngine.Random.Range(enemySpawnCorner1.transform.position.y, enemySpawnCorner2.transform.position.y)), Quaternion.identity);
    }
}
