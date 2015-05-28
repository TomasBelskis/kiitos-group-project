using UnityEngine;
using System.Collections;

public class playerBulletMov : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		
		GetComponent<Rigidbody> ().velocity = ((new Vector3(1,0,0))* 10);
	}

	void OnCollisionEnter(Collision collision) {
		//Debug.Log ("playerbullet collision");
		Destroy (gameObject);
		//Debug.Log (collision.gameObject.name);
	}
}
