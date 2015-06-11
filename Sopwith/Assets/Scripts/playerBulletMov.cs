using UnityEngine;
using System.Collections;

public class playerBulletMov : MonoBehaviour {
	private GameObject target;
	// Use this for initialization
	void Start () {

		Vector3 spd = new Vector3 (0.0f, 0.0f, 0.0f);

		bool up = Input.GetKey (KeyCode.UpArrow);
		bool down=Input.GetKey(KeyCode.DownArrow);
		bool right=Input.GetKey(KeyCode.RightArrow);
		bool left=Input.GetKey(KeyCode.LeftArrow);

		if (up && !right && !left) {//UP
			spd.y = 1;
		} else if (down && !right && !left) {//DOWN
			spd.y = -1;
		} else if (right && !up && !down) {//RIGHT
			spd.x = 1;
		} else if (left && !up && !down) {//LEFT
			spd.x = -1;
		} else if (up && right) {// UP RIGHT
			spd.x = 1;
			spd.y = 1;
		} else if (up && left) {//UP LEFT
			spd.x = -1;
			spd.y = 1;
		} else if (down && right) {//DOWN RIGHT
			spd.x = 1;
			spd.y = -1;
		} else if (down && left) {//DOWN LEFT
			spd.x = -1;
			spd.y = -1;
		} else {
			spd.x = 1;
		}




		//Vector3 bang = target.GetComponent<Rigidbody> ().velocity.normalized * 20;
		Vector3 bang = spd.normalized * 20;

		this.GetComponent<Rigidbody> ().velocity = bang;

		//Ignore the collision between player and its bullet
		target = GameObject.FindGameObjectWithTag ("Player");
		Physics.IgnoreCollision (target.GetComponent<Collider> (), GetComponent<Collider> ()); 
	}
	
	void OnCollisionEnter(Collision collision) {
		Destroy (gameObject);
		if (collision.gameObject.tag == "Enemy") {
			Destroy (collision.gameObject);
		} 
	}
}
