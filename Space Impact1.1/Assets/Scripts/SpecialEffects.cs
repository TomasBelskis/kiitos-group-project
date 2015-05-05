using UnityEngine;
using System.Collections;

public class SpecialEffects : MonoBehaviour {
	public static SpecialEffects Instance;

	public ParticleSystem smokeEffect;
	public ParticleSystem fireEffect;
	// Use this for initialization
	void Awake () {
	if (Instance != null) {
			Debug.LogError("Multiple Instance of SpecialEffects");

				}
		Instance = this;
	}
	
	// Update is called once per frame
	public void Explosion(Vector3 position)
	{
		instantiate (smokeEffect, position);
		instantiate (fireEffect, position);

	}

	private ParticleSystem instantiate(ParticleSystem prefab, Vector3 pos)
	{
				ParticleSystem newParticleSystem = Instantiate (
			prefab,
			pos,
			Quaternion.identity)as ParticleSystem;

				Destroy (
			newParticleSystem.gameObject,
			newParticleSystem.startLifetime
				);
				return newParticleSystem;
		}
}
