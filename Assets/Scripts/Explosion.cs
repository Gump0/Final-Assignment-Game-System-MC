using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float expansionRate, maxSize;

    float size;

    private bool expanding = true;
    private bool shrinking = false;




    void Start()
    {
        //sets the scale to 0
        transform.localScale = Vector3.zero;

        size = 0;
    }




    void FixedUpdate()
    {
        transform.localScale = Vector3.one * size;

        //increases the size of the explosion
        if (expanding)
        {
            size += expansionRate;
        }
        
        //stops expanding and start shrinking
        if (size > maxSize)
        {
            expanding = false;
            shrinking = true;
        }
        
        //decrese the size of the explosion
        if (shrinking)
        {
            size -= expansionRate;
        }
        
        //destroys itse;f when it's done shrinking
        if (size < 0)
        {
            Destroy(gameObject);
        }
    }
}
