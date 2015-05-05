using UnityEngine;
using System.Collections;

public class ScoreCounter : MonoBehaviour {
	private int score=0;
	private int highScore = 0;
	public GameObject ship;
	public GameObject trigger;
	public bool hasScored=false;
	//GameObject spaceship = GameObject.Find ("fallingSpaceShip");

	
	// Use this for initialization
	void Start () {
		highScore = PlayerPrefs.GetInt ("highScore",0);

	}

	// Update is called once per frame
	void Update () {
		if (score > highScore) {
						highScore = score;
				}
		PlayerPrefs.SetInt ("highScore", highScore);
		}



	public void ScoreCount()
	{

		score++;

	}
	void OnGUI()
	{
	
		GUI.Box (new Rect (Screen.width - 200f, Screen.height/10f, 100f, 50f),"Score: "+ score+"");
		GUI.Box (new Rect (Screen.width - 100f, Screen.height/10f, 100f, 50f),"Highscore: "+ highScore+"");
	}
	
	
}
