using UnityEngine;

public class Projectile_Finished : MonoBehaviour
{
	public float speed = 20;

	private void Update()
	{
		transform.position += transform.forward * speed * Time.deltaTime;
	}

	private void OnTriggerEnter(Collider other)
	{
		if (other.CompareTag("Player"))
			other.GetComponent<PlayerMovement_Finished>().GetHit();

		// Destroy only after 3 seconds so the trail can dissapear nicely
		speed = 0;
		GetComponent<Collider>().enabled = false;
		Destroy(gameObject, 3);
	}
}
