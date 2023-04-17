using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{
    public float expansionRate, pauseDurration;

    float size;

    private bool expanding = true;
    private bool shrinking = false;

    // Start is called before the first frame update
    void Start()
    {
        transform.localScale = Vector3.zero;

        size = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.localScale = Vector3.one * size;

        if (expanding)
        {
            size += expansionRate;
        }
        
        if (size > 1)
        {
            expanding= false;
            Invoke("StartShrinking", pauseDurration);
        }
        
        if (shrinking)
        {
            size -= expansionRate;
        }
        
        if (size < 0)
        {
            Destroy(gameObject);
        }
    }

    void StartShrinking()
    {
        shrinking= true;
    }
}
