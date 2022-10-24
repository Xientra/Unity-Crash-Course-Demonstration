using UnityEngine;
using TMPro;

public class MouseAttacker_Finished : MonoBehaviour
{
	[SerializeField]
	private float shootDelay = 0.5f;
	private float timestamp = 0;

	private Camera cam;

	public GameObject projectilePrefab;

	private void Start()
	{
		cam = Camera.main;
	}

	private void Update()
	{
		if (Input.GetMouseButtonDown(0) && Time.time > timestamp)
		{
			Shoot();
			timestamp = Time.time + shootDelay;
		}

		if (Input.GetKeyDown(KeyCode.Escape))
		{
#if UNITY_EDITOR
			UnityEditor.EditorApplication.isPlaying = false;
#else
			Application.Quit();
#endif
		}
	}

	private void Shoot()
	{
		Ray cameraRay = cam.ScreenPointToRay(Input.mousePosition);

		RaycastHit hit;
		if (Physics.Raycast(cameraRay, out hit))
		{
			Vector3 direction = hit.point - transform.position;

			GameObject temp = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
			temp.transform.forward = direction;
		}
	}
}
