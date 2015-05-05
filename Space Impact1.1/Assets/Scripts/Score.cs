using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	// Use this for initialization

	
	// Update is called once per frame

	void OnTriggerEnter2D(Collider2D collision)
	{
		GameObject score = GameObject.FindWithTag ("Scripts");
		if (collision.gameObject.tag == "Player") {
			score.GetComponent<ScoreCounter>().ScoreCount();
			Debug.LogError("HAS Scoreed");
		} 
	}
}