using UnityEngine;
using System.Collections;

public class Weapon : MonoBehaviour {

	public Transform shotPrefab;
	public float shootingRate = 0.25f;
	public float shootCooldown;
	public bool isBoss;
	private Vector3 playerShot;
	private Vector3 enemyShot;



	// Use this for initialization
	void Start () {
		shootCooldown = 0f;
	}
	
	// Update is called once per frame
	void Update () {
	
		if (shootCooldown > 0) {
			shootCooldown -=Time.deltaTime;
				}

		}


	public void Attack(bool isEnemy)
	{
		if (CanAttack) {
			shootCooldown=shootingRate;

			Transform shotTransform = Instantiate(shotPrefab)as Transform;

			shotTransform.position = transform.position;

			Shooting shot = shotTransform.gameObject.GetComponent<Shooting>();
			if(shot != null)
			{
				shot.isEnemyShot = isEnemy;
			}

			Movement move = shotTransform.gameObject.GetComponent<Movement>();
			if(move !=null)
			{
				if(isEnemy)
				{
					move.direction = this.transform.right*-1;
				}else if (isEnemy==false)
				{
					move.direction = this.transform.up;
				}
			}
		}
	}
	public bool CanAttack
	{
		get
		{
			return shootCooldown <= 0f;
		}
	}
}
