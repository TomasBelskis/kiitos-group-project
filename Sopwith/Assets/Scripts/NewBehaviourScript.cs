using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Turret_Enemy") {
			//Debug.Log("TURRET!");
			Destroy (gameObject);
			Destroy (other.gameObject);
		}
	}
}
