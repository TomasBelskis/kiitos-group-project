using UnityEngine;
using System.Collections;

public class Fire : MonoBehaviour {
	
	public float speed;

	void Start() 	
	{
		Rigidbody rigidbody = GetComponent<Rigidbody> ();
		rigidbody.velocity = transform.right * speed;
	}
}
