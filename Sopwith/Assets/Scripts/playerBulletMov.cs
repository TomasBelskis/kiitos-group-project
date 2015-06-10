using UnityEngine;
using System.Collections;

public class playerBulletMov : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody> ().velocity = ((new Vector3(1,0,0))* 10);
	}

	void OnCollisionEnter(Collision collision) {
		Destroy (gameObject);
		if (collision.gameObject.tag == "Enemy") {
			Destroy (collision.gameObject);
		}
	}
	/*
	void OnTriggerEnter(Collider col){
		if (col.gameObject.tag == "Enemy") {
			Destroy (col.gameObject);
		}
	}
	*/
}
