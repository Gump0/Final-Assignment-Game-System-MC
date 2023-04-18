using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]

public class MissileBrain : MonoBehaviour
{
    [Header("Where the Missile is going")]
    public GameObject destination, explosion;

    public float missileSpeed;

    private Rigidbody2D rb;





    void Start()
    {
        rb= GetComponent<Rigidbody2D>();

        //calculates the angle between where the missile is and where the destination is
        Vector2 targetPosition = destination.transform.position;
        Vector2 startPosition = transform.position;
        float angle = Mathf.Atan2(targetPosition.y - startPosition.y, targetPosition.x - startPosition.x);

        //rotates the missile to the angle just calcualted
        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angle - 90);
    }





    void FixedUpdate()
    {
        //moves the missile in the direction that it's facing
        transform.Translate(Vector2.up * missileSpeed * Time.deltaTime); 
    }





    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == destination)
        {
            Explode();
        }

        if (collision.gameObject.CompareTag("Explosion"))
        {
            if (gameObject.tag == ("Enemy Missile"))
            {
                Explode();
            }
        }
    }

    




    private void Explode()
    {
        if (gameObject.tag == ("Enemy Missile"))
        {
            Instantiate(explosion, transform.position, Quaternion.identity);
        }
        else
        {
            Instantiate(explosion, destination.transform.position, Quaternion.identity);
        }

        Destroy(destination);
        Destroy(gameObject);
    }   
}
