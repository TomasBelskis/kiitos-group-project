using UnityEngine;
using System.Collections;

public class movement2 : MonoBehaviour {
	public float gravity=0.1f;
	public Vector3 velocity= Vector3.zero;
	private Vector3 pos;
	public Vector2 force;
	private bool jumped=false;
	private bool scored=false;
	private GameObject over;
	Rigidbody2D rigidbody2d = new Rigidbody2D();

	// Use this for initialization
	void Start () {
		force = new Vector2 (0, 0.1000f);
	}

	
	// Update is called once per frame
	void FixedUpdate () {

		if (Input.GetButtonDown("Jump")) {
			GetComponent<Rigidbody2D>().AddForce(force);
				}
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "Rock") {
						Destroy (gameObject);
				} else if (collision.gameObject.tag == "Bounds") {
						Destroy (gameObject);
				} else if (collision.gameObject.tag == "Score") {
						scored = true;
				}
	}
		
	public bool Scored()
	{
		return scored;
		}

	void OnDestroy()
	{
		transform.parent.gameObject.AddComponent<GameOver>();
		transform.parent.gameObject.GetComponent<GameOver> ().SetScene ("Level_2");
	}
}
