﻿using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {
	public int damage = 1;
	public bool isEnemyShot = false;
	// Use this for initialization
	void Start () {
		Destroy (gameObject, 20);
	}
	
	// Update is called once per frame

}
