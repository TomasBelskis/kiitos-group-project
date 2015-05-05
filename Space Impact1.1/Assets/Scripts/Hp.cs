using UnityEngine;
using System.Collections;

public class Hp : MonoBehaviour {

	public int hp = 2;
	public bool isEnemy=true;
	public bool isBoss=false;

	void OnTriggerEnter2D(Collider2D collider){
				Shooting shot = collider.gameObject.GetComponent<Shooting> ();
				if (shot != null) {
						if (shot.isEnemyShot != isEnemy) {
								hp -= shot.damage;
								Destroy (shot.gameObject);
								if (hp <= 0) {
										SpecialEffects.Instance.Explosion (transform.position);
										SoundEffects.Instance.MakeExplosion ();
										Destroy (gameObject);
									if(isBoss)
									{
						Application.LoadLevel("Level_2");
									}


						}
				}
		}

}
	void OnGUI()
	{
		if (isEnemy == false) {
		
						GUI.Box (new Rect (Screen.width / 10f, Screen.height / 10f, 150f, 50f), "LIVES:" + hp + "");
				}

	}
}
