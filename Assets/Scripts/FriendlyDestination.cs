using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDestination : MonoBehaviour
{
    // Start is called before the first frame update
    void Awake()
    {
        //makes itself no longer a child of the missile
        transform.parent = null;

        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.nearClipPlane);
    }

    // Update is called once per frame
    void Update()
    {
    }
}
