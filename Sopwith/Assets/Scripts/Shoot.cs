using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

	public GameObject shot;
	public Transform pos;
	public int BulletCount;
	public float spawnWait;
	public float waveWait;


	public int z;

	void Start()
	{
		StartCoroutine (SpawnWaves ());
	}
	/*
	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			StartCoroutine (SpawnWaves ());
		//Debug.Log ("enter");
		//Destroy(other.gameObject);
		
		//StartCoroutine (SpawnWaves ());
	}
	void OnTriggerExit(Collider other)
	{
		//Debug.Log ("exit");
	}

	void OnTriggerStay(Collider other)
	{
		SpawnWaves();
		//StartCoroutine (SpawnWaves ());
		//Debug.Log ("stay");
	}

	void OnTriggerExit(Collider other)
	{
		Debug.Log ("exit");
	}
	void OnTriggerStay(Collider other)
	{
		//StartCoroutine (SpawnWaves ());
		//Debug.Log ("stay");
	}
	*/
	
	IEnumerator SpawnWaves()
	{
		while(true)
		{
			for (int i=0;i<BulletCount;i++) {

				//Quaternion spawnRotation = Quaternion.Euler(Random.Range(-50,0),Random.Range(-30,30), 0);
				Quaternion spawnRotation = Quaternion.Euler(180,180,z);

				Instantiate (shot,pos.position,spawnRotation);

				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}
}
