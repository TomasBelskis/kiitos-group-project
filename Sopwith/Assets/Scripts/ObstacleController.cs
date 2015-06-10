using UnityEngine;
using System.Collections;

public class ObstacleController : MonoBehaviour {

	public int hazardCount;
	public GameObject obstacle;
	public Vector3 spawnValues;
	public float spawnWait;
	public float waveWait;

	void Start () {
		StartCoroutine (SpawnWaves ());
	}

	IEnumerator SpawnWaves()
	{
		while(true)
		{
			for (int i=0;i<hazardCount;i++) {
				Vector3 spawnPosition = new Vector3 (Random.Range (-spawnValues.x, spawnValues.x), spawnValues.y, spawnValues.z);
				Quaternion spawnRotation = Quaternion.identity;
				Instantiate (obstacle, spawnPosition, spawnRotation);
				yield return new WaitForSeconds(spawnWait);
			}
			yield return new WaitForSeconds(waveWait);
		}
	}

}
