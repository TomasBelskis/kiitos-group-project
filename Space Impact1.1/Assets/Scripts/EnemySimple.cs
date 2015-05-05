using UnityEngine;
using System.Collections;

public class EnemySimple : MonoBehaviour {
	private bool hasSpawn;
	private Movement movement;
	private Weapon[] weapons;
	void Awake()
	{
		weapons = GetComponentsInChildren<Weapon> ();
		movement = GetComponent<Movement> ();
		}
	// Use this for initialization
	void Start () {
		hasSpawn = false;

		GetComponent<Collider2D>().enabled = false;
		movement.enabled = false;
		foreach (Weapon weapon in weapons) {
			weapon.enabled=false;
				}
	
	}
	
	// Update is called once per frame
	void Update () {
		if (hasSpawn == false) {
						if (GetComponent<Renderer>().IsVisibleFrom (Camera.main)) {

								Spawn ();
							
						}
				} else {
		
						foreach (Weapon weapon in weapons) {
								if (weapon != null && weapon.enabled && weapon.CanAttack) {
										weapon.Attack (true);
										SoundEffects.Instance.MakeExplosion ();
								
								}
						
						}
				
		
	
						if (GetComponent<Renderer>().IsVisibleFrom (Camera.main) == false) {
								Destroy (gameObject);
						}

				}
	}
	
		private void Spawn()
		{
			hasSpawn = true;
			
			GetComponent<Collider2D>().enabled = true;
			movement.enabled = true;
			foreach (Weapon weapon in weapons) {
				weapon.enabled=true;
			}
		}
	void OnDestroy()
	{
		GameObject score = GameObject.FindWithTag ("Scripts");
		score.GetComponent<ScoreCounter>().ScoreCount();
	}
}
