using UnityEngine;
using System.Collections;

public class enemyBulletMov : MonoBehaviour {
	public GameObject target;
	// Use this for initialization
	void Start () {
		///*
		target = GameObject.FindGameObjectWithTag ("Player");
		Vector3 bang = target.transform.position - this.transform.position;
		GetComponent<Rigidbody> ().velocity = bang.normalized* 5;
	//	*/
	}
	void OnCollisionEnter(Collision collision)
	{
		//Debug.Log ("enemybullet collision");
		if (collision.gameObject.tag!="Enemy"||collision.gameObject.tag!="Turret_head")
			Destroy (this.gameObject);
	}
}
