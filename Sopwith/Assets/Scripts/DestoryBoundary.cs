using UnityEngine;
using System.Collections;

public class DestoryBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		if (other.tag == "Bullet") {
			Destroy (other.gameObject);
		}
	}
}
