using UnityEngine;
using System.Collections;


public class BombScript : MonoBehaviour {
	
	public GameObject Player;
	public GameObject Bomb;
	public Vector3 pos;
	public Quaternion identity;
	public int bombAmount;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (bombAmount != 0)
		{
			if (Input.GetKeyDown (KeyCode.J))
			{
				//Bomb.transform.position = Player.transform.position + pos;
				Instantiate (Bomb, Player.transform.position + pos, identity);
				bombAmount--;
				
			}
			
		}
	}

	void OnCollisionEnter(Collision Bomb)
	{
		if (Bomb.gameObject.name == "PlayerBase") {
			bombAmount = 5;
		}
	}
}

