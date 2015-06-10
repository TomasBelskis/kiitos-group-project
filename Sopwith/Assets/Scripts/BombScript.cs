using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BombScript : MonoBehaviour {
	
	public GameObject Player;
	public GameObject Bomb;
	public Vector3 pos;
	public Quaternion identity;
	public int bombAmount;
	public Text bombText;

	// Use this for initialization
	void Start () {
		setBombText ();
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
				setBombText();
			}
			
		}
	}

	void OnCollisionEnter(Collision Bomb)
	{
		if (Bomb.gameObject.name == "PlayerBase") {
			bombAmount = 5;
			setBombText();
		}
	}

	void setBombText()
	{
		bombText.text = "Bombs: " + bombAmount;
	}
}

