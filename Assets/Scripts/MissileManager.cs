using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MissileManager : MonoBehaviour
{
    public GameObject friendlyMissile, turret1, turret2, turret3;

    private Vector2 turret1Pos, turret2Pos, turret3Pos, mainTurret;

    private float turret1Distance, turret2Distance, turret3Distance, lowestIndex, lowestValue;

    private float[] distanceValues = new float[3];


    // Start is called before the first frame update
    void Start()
    {
        //sets the turretpos vectors to the position of the turrets
        turret1Pos = turret1.transform.position;
        turret2Pos = turret2.transform.position;
        turret3Pos = turret3.transform.position;

        lowestIndex = -1;

    }

    // Update is called once per frame
    void Update()
    {
        ChooseMainTurret();

        //instantiates a friendly missile when the mouse is clicked
        if (Input.GetMouseButtonDown(0))
        {
            Instantiate(friendlyMissile, mainTurret, Quaternion.identity);
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
        }
        else if (lowestIndex == 1)
        {
            mainTurret = turret2Pos;
        }
        else if (lowestIndex == 2)
        {
            mainTurret = turret3Pos;
        }

    }
}
