using UnityEngine;
using System.Collections;


public class EnemyPlane : MonoBehaviour {

	public Transform Player;
	public GameObject Enemy;
	public GameObject EnemyBase;
	public Vector3 pos;
	public Quaternion identity;

	private float MoveSpeed = 7;
	private float MaxDist = 10;
	private float MinDist = 5;
	
	void Start () 
	{
		
	}
	
	void Update () 
	{
		transform.LookAt(Player);
		
		if(Vector3.Distance(transform.position,Player.position) >= MinDist){
			
			transform.position += transform.forward*MoveSpeed*Time.deltaTime;
			
			
			
			if(Vector3.Distance(transform.position,Player.position) <= MaxDist)
			{
				//Here Call any function U want Like Shoot at here or something
			} 
			
		}

		
		if(Enemy == null || Enemy.Equals(null))
		{
			//Respawn();	
		}
}

/*	void Respawn()
	{
		Enemy = (GameObject)Instantiate (Enemy, EnemyBase.transform.position + pos, Quaternion.identity);
	}*/

	void OnCollisionEnter(Collision col)
	{
		if (col.gameObject.tag == "Player")
		{
			//Respawn();
		}
	}
	
}