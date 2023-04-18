using UnityEngine;

public class FriendlyStructures : MonoBehaviour
{
	void start()
	{
		//Declares the GameObject tag
		gameObject.tag = "Explosion";
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.CompareTag("City"))
		{
			Debug.Log("AN EXPLOSION HAS COLLIDED WITH A BUILDING! OOH NOO!");
			Destroy(gameObject);
		}
	}
}
