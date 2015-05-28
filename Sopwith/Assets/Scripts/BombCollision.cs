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

	void OnCollisionEnter()
	{
		Destroy (Bomb);
	}
}
