using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class locationTester : MonoBehaviour
{
    public MissileManager script;

    // Update is called once per frame
    void Update()
    {
        transform.position = script.currentEnemyMissileDestination;
    }
}
