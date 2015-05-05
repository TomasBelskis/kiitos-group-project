using UnityEngine;
using System.Collections;

public class RockSpawn : MonoBehaviour {
	public GameObject rocks;
	public int numOfRocks=10;
	private float minHeightY=-2.7f;
	private float maxHeightY=9.8f;
	private float maxDistX=40f;
	private float minDistX=30f;
	private float posX=0f;
	private float posY=0f;
	private int spawnCount=0;
	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		posY = Random.Range (minHeightY, maxHeightY);
		posX = Random.Range (minDistX,maxDistX);
		if(spawnCount < numOfRocks)
		{
			
			Instantiate (rocks,new Vector3(spawnCount*posX,posY,0),Quaternion.identity);
			spawnCount++;
		}
	}
}
