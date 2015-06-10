using UnityEngine;
using System.Collections;

public class enemyBulletMov : MonoBehaviour {
	private GameObject target;
	private GameObject[] enemys;
	// Use this for initialization
	void Start () {
	
		enemys = GameObject.FindGameObjectsWithTag ("Enemy");

		target = GameObject.FindGameObjectWithTag ("Player");
		Vector3 bang = target.transform.position - this.transform.position;
		GetComponent<Rigidbody> ().velocity = bang.normalized* 5;
	
		foreach (GameObject obj in enemys) {
			if(obj.GetComponent<Collider> () != null)
				Physics.IgnoreCollision (obj.GetComponent<Collider> (), GetComponent<Collider> ()); 
		}

	}
	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("enemybullet collision"+collision.gameObject.name);
		//Debug.Log ("enemybullet collision");
		if (collision.gameObject.tag != "Enemy") {

			Destroy (this.gameObject);
		} 
		//	Physics.IgnoreCollision(collision.collider, GetComponent<Collider>());
	}
}
