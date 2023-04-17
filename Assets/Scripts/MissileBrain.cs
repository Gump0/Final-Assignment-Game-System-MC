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

    // Start is called before the first frame update
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();


        Vector2 targetPosition = destination.transform.position;
        Vector2 startPosition = transform.position;
        float angle = Mathf.Atan2(targetPosition.y - startPosition.y, targetPosition.x - startPosition.x);

        transform.eulerAngles = new Vector3(0, 0, Mathf.Rad2Deg * angle - 90);

        //rb.velocity = Vector2.up * missileSpeed;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(Vector2.up * missileSpeed * Time.deltaTime); 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == destination)
        {
            Explode();
        }
    }




    private void Explode()
    {
        Instantiate(explosion, destination.transform.position, Quaternion.identity);

        Destroy(destination);
        Destroy(gameObject);
    }
}
