using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyCity : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision)
    {
		if (collision.gameObject.CompareTag("City"))
		{
			Destroy(gameObject);
		}
	}
}
