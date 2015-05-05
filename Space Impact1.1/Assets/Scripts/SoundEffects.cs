using UnityEngine;
using System.Collections;

public class SoundEffects : MonoBehaviour {
	public static SoundEffects Instance;

	public AudioClip explosion;
	public AudioClip playerShot;
	public AudioClip enemyShot;
	// Use this for initialization
	void Awake () {
	if (Instance != null) {
						Debug.LogError ("Multiple instacne of SoundEffects");
				}
		Instance = this;
	}

	
	public void MakeExplosion()
	{
				MakeSound (explosion);
		}
	public void MakePlayerShot()
	{
		MakeSound (playerShot);
	}
	public void MakeEnemyShot()
	{
				MakeSound (enemyShot);
		}

	private void MakeSound(AudioClip originalClip)
	{
				AudioSource.PlayClipAtPoint (originalClip, transform.position);
		}
}
