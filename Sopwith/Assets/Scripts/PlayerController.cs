using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour {


	public float speed; // No we can adjust the speed in the inspector
	// Use this for initialization
	public GameObject Player;
	public GameObject PlayerBase;
	public Vector3 pos;
	private float timeRemaining = 5f;
	bool keysOn = true;
	
	void Start () {
		Respawn ();
	}

	void Update () {
		if (timeRemaining > -1) {
			//Debug.Log ("Time left: " + timeRemaining);
			timeRemaining -= Time.deltaTime;
			if (timeRemaining < 0) {
				keysOn = false;
			} 
		}
	}
	// Update is called once per frame

	void FixedUpdate () {
		if (keysOn == true) {
			float moveHorizontal = Input.GetAxis ("Horizontal");
			float moveVertical = Input.GetAxis ("Vertical");
		
			Vector3 movement = new Vector3 (moveHorizontal, moveVertical);
			GetComponent<Rigidbody> ().AddForce (movement * speed * Time.deltaTime);
		}

	}


	
	void Respawn()
	{
		keysOn = true;
		Player.transform.position = PlayerBase.transform.position + pos;
		Player.transform.rotation = Quaternion.identity;
	}

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.name == "Terrain") {
			Respawn ();
		}
		if (col.gameObject.name == "TopCollider") {
			Respawn();
		}
		if (col.gameObject.name == "LeftCollider") {
			Respawn();
		}
		if (col.gameObject.name == "RightCollider") {
			Respawn();
		}


	}

	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.name == "PlayerBase") {
			timeRemaining = 5f;
		}
	}


}  // This part of the code could be used for the collider.