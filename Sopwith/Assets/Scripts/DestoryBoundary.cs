using UnityEngine;
using System.Collections;

public class DestoryBoundary : MonoBehaviour {

	void OnTriggerExit(Collider other) {
		Destroy(other.gameObject); 
	}
}
