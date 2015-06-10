using UnityEngine;
using System.Collections;

public class SmoothCamera : MonoBehaviour {
	public Transform target;
	public float smoothTime = 0.3F;
	private float yVelocity = 0.0F;


	// Update is called once per frame
	void Update () {

		float newPosition = Mathf.SmoothDamp(transform.position.y, target.position.y+5, ref yVelocity, smoothTime);
		transform.position = new Vector3(transform.position.x, newPosition, transform.position.z);
	}
}
