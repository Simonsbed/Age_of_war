using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
	public float minMove, maxMove;

	[SerializeField]
	private float cameraSpeed = 3f;
	private float xMin = -7f;
	private float xMax = 27.38f;
	private Vector2 camMovement = Vector2.zero;

	

	void Cameramovement()
	{
		if (Input.GetKey(KeyCode.Mouse0))
		{
			//camMovement.x = Mathf.Clamp(-transform.right.x * cameraSpeed * Time.deltaTime, minMove,maxMove);
			//1

			camMovement.x = -transform.right.x * cameraSpeed * Time.deltaTime;
			Camera.main.transform.Translate(camMovement);


		}

		if (Input.GetKey(KeyCode.Mouse1))
		{

			// camMovement.x = Mathf.Clamp(transform.right.x * cameraSpeed * Time.deltaTime, minMove,maxMove);
			camMovement.x = transform.right.x * cameraSpeed * Time.deltaTime;
			Camera.main.transform.Translate(camMovement);

		}
		 Camera.main.transform.position = new Vector3(Mathf.Clamp(Camera.main.transform.position.x, minMove, maxMove), 0, -10f);
		
		
	}

	private void Update()
	{

		
		Cameramovement();

	}

}
