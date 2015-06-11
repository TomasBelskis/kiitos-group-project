using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System;

public class PlayerController : MonoBehaviour {


	public float speed; // No we can adjust the speed in the inspector
	// Use this for initialization
	public GameObject Player;
	public GameObject PlayerBase;
	private GameObject[] bullets;
	private GameObject[] p_bullets;
	public Vector3 pos;
	private float timeRemaining = 60f;
	private float maxFuel = 60.0f;
	public Text fuelText;
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
		setFuelText ();
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

			//Rigidbody rigidbody = GetComponent<Rigidbody> ();
			
			//rigidbody.velocity = movement * 500 * Time.deltaTime;//speed;

		}/*
		float L = 0.5f * Globals.AirDensity(transform.position.y, AltUnit.Meters) * GetComponent<Rigidbody>().velocity.magnitude * m_Planform * 2.0f * Mathf.PI * Vector3.Angle(transform.forward, Vector3.up);
		float pitch = Input.GetAxis("pitch");
		float roll = Input.GetAxis("roll");
		float yaw = Input.GetAxis("yaw");
		float finalRotFactor = m_RotSpeed * (Thrust / MaxThrust);
			
			
		GetComponent<Rigidbody>().AddRelativeTorque(Vector3.right * pitch * finalRotFactor, ForceMode.Impulse);
		GetComponent<Rigidbody>().AddRelativeTorque(Vector3.up * yaw * finalRotFactor, ForceMode.Impulse);
		GetComponent<Rigidbody>().AddRelativeTorque(Vector3.forward * roll * finalRotFactor * 4, ForceMode.Impulse);
			
		GetComponent<Rigidbody>().AddForce(transform.forward * Thrust * 2, ForceMode.Impulse);
		GetComponent<Rigidbody>().AddForce(Vector3.up * L, ForceMode.Force);
			
		m_Lift = L;
		m_Velocity = GetComponent<Rigidbody>().velocity.magnitude;
		*/
		if(Input.GetKeyDown ("space"))
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
		bullets = GameObject.FindGameObjectsWithTag ("Bullet");
		p_bullets = GameObject.FindGameObjectsWithTag ("Player_Bullet");

		foreach (GameObject obj in bullets)
		{
			if(obj!=null)
				Destroy (obj);
		}
		foreach (GameObject obj in p_bullets)
		{
			if(obj!=null)
				Destroy (obj);
		}

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
			timeRemaining = 60f;
		}
	}
	void setFuelText()
	{
		fuelText.text = "Fuel: " + Math.Round(timeRemaining/maxFuel*100,0) + "%";
	}


}  // This part of the code could be used for the collider.