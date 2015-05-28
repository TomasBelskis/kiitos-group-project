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
