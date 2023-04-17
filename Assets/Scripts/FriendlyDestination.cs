using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendlyDestination : MonoBehaviour
{
    void Awake()
    {
        //makes itself no longer a child of the missile
        transform.parent = null;

        //sets the position of the destination to the position of the mouse
        transform.position = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.position = new Vector3(transform.position.x, transform.position.y, Camera.main.nearClipPlane);
    }
}
