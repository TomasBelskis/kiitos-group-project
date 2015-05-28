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




	//

	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private bool keyPressed;

	//

	
	void Start () {
		Respawn ();
	}

	void Update () {
		GetComponent<Rigidbody> ().freezeRotation = true;

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


			/*
			Rigidbody rigidbody = GetComponent<Rigidbody> ();

			
			Vector3 movement = new Vector3(moveHorizontal,moveVertical,0.0f);
			
			rigidbody.velocity = movement * speed;
			*/
		}
		if (Input.GetKeyDown ("space"))
		{
			keyPressed = true;
		}
		else if(Input.GetKeyUp ("space"))
		{
			keyPressed = false;
		}
		
		if(keyPressed && Time.time > nextFire) 
		{
			nextFire = Time.time + fireRate;
			Instantiate (shot, shotSpawn.position, shotSpawn.rotation);
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
		if (col.gameObject.tag == "Enemy")
		{
			Respawn();
		}
		if (col.gameObject.tag == "Bullet")
		{
			Respawn();
		}
	}
	void OnCollisionStay(Collision col)
	{
		if (col.gameObject.name == "PlayerBase")
		{
			timeRemaining = 5f;
		}
	}


}  // This part of the code could be used for the collider.