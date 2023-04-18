using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDestination : MonoBehaviour
{
    private GameObject missileManager;
    private MissileManager missileManagerscript;


    // Start is called before the first frame update
    void Awake()
    {
        missileManager = GameObject.Find("Missile Manager");
        missileManagerscript = missileManager.GetComponent<MissileManager>();

        transform.position = missileManagerscript.currentEnemyMissileDestination;
    }
}
