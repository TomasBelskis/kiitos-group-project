using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class Player2Controller : MonoBehaviour {
	
	public float speed; // No we can adjust the speed in the inspector
	// Use this for initialization
	public GameObject Player;
	public GameObject PlayerBase;
	public Vector3 pos;
	private float timeRemaining = 5f;
	private float maxFuel = 60.0f;
	public Text fuelText;
	bool keysOn = true;

	//
	
	public GameObject shot;
	public Transform shotSpawn;
	public float fireRate;
	private float nextFire;
	private bool keyPressed;

	// Use this for initialization
	void Start () {
		Respawn ();
	}
	
	// Update is called once per frame
	void Update () {

		GetComponent<Rigidbody> ().freezeRotation = true;
		
		if (timeRemaining > -1) {
			//Debug.Log ("Time left: " + timeRemaining);
			timeRemaining -= Time.deltaTime;
			if (timeRemaining < 0) {
				keysOn = false;
			} 

		}
		
		
		if (Input.GetKey(KeyCode.LeftArrow))
		{
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.RightArrow))
		{
			transform.position += Vector3.right * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.UpArrow))
		{
			transform.position += Vector3.up * speed * Time.deltaTime;
		}
		if (Input.GetKey(KeyCode.DownArrow))
		{
			transform.position += Vector3.down * speed * Time.deltaTime;
		}

	}
	void FixedUpdate () {
	
		

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


	

}
