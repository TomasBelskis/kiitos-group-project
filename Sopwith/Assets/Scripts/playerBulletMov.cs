using UnityEngine;
using System.Collections;

public class playerBulletMov : MonoBehaviour {
	private GameObject target;
	// Use this for initialization
	void Start () {

		target = GameObject.FindGameObjectWithTag ("Player");
		Vector3 bang = target.GetComponent<Rigidbody> ().velocity * 3;
		this.GetComponent<Rigidbody> ().velocity = bang;
		Physics.IgnoreCollision (target.GetComponent<Collider> (), GetComponent<Collider> ()); 
	}
	
	void OnCollisionEnter(Collision collision) {
		Destroy (gameObject);
		if (collision.gameObject.tag == "Enemy") {
			Destroy (collision.gameObject);
		} 
	}
}
