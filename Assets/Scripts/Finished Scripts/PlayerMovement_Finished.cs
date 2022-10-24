using System.Collections; // <- IEnumerator is from this
using UnityEngine;
using TMPro; // <- this is for Text Mesh Pro UI

public class PlayerMovement_Finished : MonoBehaviour
{
	private Rigidbody rb;
	private MeshRenderer mr;

	[Header("Settings:")]

	[SerializeField]
	private float speed = 1f;
	private int hits = 0;

	[Header("References:")]

	public Material defaultMaterial;
	public Material redMaterial;

	[Space(5)]

	public TMP_Text hitsLabel;

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
		hits++;
		hitsLabel.text = "Hits: " + hits;
		StartCoroutine(BecomeRed(3));
	}

	public IEnumerator BecomeRed(float duration)
	{
		mr.material = redMaterial;
		yield return new WaitForSeconds(duration);
		mr.material = defaultMaterial;
	}
}
