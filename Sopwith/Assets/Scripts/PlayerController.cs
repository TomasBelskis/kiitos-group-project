using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	
	public float speed; // No we can adjust the speed in the inspector
	
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis("Vertical");
		
		Vector3 movement = new Vector3(moveHorizontal, moveVertical);
		GetComponent<Rigidbody>().AddForce(movement * speed * Time.deltaTime);
	}
	/*
        void OnTriggerEnter(Collider other){
 
        if (other.gameObject.tag == "TopCollider, LeftCollider, Ground") {
                        Application.LoadLevel (0);
 
        }
 
   } */ // This part of the code could be used for the collider.
}