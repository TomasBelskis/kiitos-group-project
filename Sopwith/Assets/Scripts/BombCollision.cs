using UnityEngine;
using System.Collections;

public class BombCollision : MonoBehaviour {

	public GameObject Bomb;
	public GameObject Turret;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Enemy") {
			Destroy (collision.gameObject);
			Destroy (this.gameObject);
		} 
		if (collision.gameObject.name == "Terrain") {
			
			Destroy (this.gameObject);
		} 
		if (collision.gameObject.name == "PlayerBase") {
			
			Destroy (this.gameObject);
		} 
	}
}
