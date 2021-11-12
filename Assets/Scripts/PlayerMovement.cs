using System.Collections; // <- IEnumerator is from this
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	[SerializeField]
	private float speed = 1f;

	public Material defaultMaterial;
	public Material redMaterial;

	private Rigidbody rb;
	private MeshRenderer mr;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
		mr = GetComponent<MeshRenderer>();
	}

	private void Update()
	{
		if (Input.GetKey(KeyCode.W))
			rb.AddForce(0, 0, speed);
		if (Input.GetKey(KeyCode.A))
			rb.AddForce(-speed, 0, 0);
		if (Input.GetKey(KeyCode.S))
			rb.AddForce(0, 0, -speed);
		if (Input.GetKey(KeyCode.D))
			rb.AddForce(speed, 0, 0);
	}

	public void GetHit()
	{
		StartCoroutine(BecomeRed(3));
	}

	public IEnumerator BecomeRed(float duration)
	{
		mr.material = redMaterial;
		yield return new WaitForSeconds(duration);
		mr.material = defaultMaterial;
	}
}
