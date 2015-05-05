using UnityEngine;
using System.Collections;

public class RandomEnemy : MonoBehaviour {
	public GameObject enemyPrefab;
	public GameObject bossPrefab;
	public float numEnemy;
	public float xMin=20f;
	public float xMax=85f;
	public float yMin=3.5f;
	public float yMax=-4.5f;
	// Use this for initialization
	void Start () {
		GameObject parent = GameObject.Find ("1-BackgroundElements");
		for (int i=0; i<numEnemy; i++) {
			Vector3 newPos = new Vector3(Random.Range(xMin,xMax),Random.Range(yMin,yMax),0);
			GameObject enemy = Instantiate(enemyPrefab,newPos, Quaternion.identity) as GameObject;
			enemy.transform.parent=parent.transform;
				}
		GameObject boss = Instantiate (bossPrefab, new Vector3 (xMax, yMin - 1f, 0), Quaternion.identity) as GameObject;
		boss.transform.parent = parent.transform;
	}
	

}
