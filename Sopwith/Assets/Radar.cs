using UnityEngine;
using System.Collections;

public class Radar : MonoBehaviour {
	
	void Update ()
	{
		transform.Rotate (Vector3.up, 100f * Time.deltaTime); 
	}
}
