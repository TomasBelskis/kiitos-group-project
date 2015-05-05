using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {
	public bool isBoss;
	public Vector2 speed = new Vector2 (10, 10);
	public Vector2 direction = new Vector2 (0, 0);
	private Vector3 movement; 
	private Vector3 bossPoss;
	private bool isBossVisible=false;
	private bool hasPlaced=false;
	
	// Update is called once per frame
	void Update () {
		/*
		if (isBoss && !renderer.IsVisibleFrom (Camera.main)) {
				direction.x=-1;
				} else if (isBoss && renderer.IsVisibleFrom(Camera.main)) {
			direction.x=0;
			direction.y=1;
				}*/
		if (isBoss == false) {
						movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
						movement *= Time.deltaTime;
						transform.Translate (movement);
				} else {
						speed.x=1.5f;
						direction.x =1f; 
						movement = new Vector3 (speed.x * direction.x, speed.y * direction.y, 0);
						movement *= Time.deltaTime;
						transform.Translate (movement);
				}

		if (isBoss&&GetComponent<Renderer>().IsVisibleFrom(Camera.main)&&hasPlaced==false) {
			PlaceBoss();
			hasPlaced=true;
				}
	}

	void PlaceBoss()
	{
		bossPoss=new Vector3(8.6f,0.01f,0);
		transform.position= bossPoss;
	}
	void OnTriggerEnter2D(Collider2D collision)
	{
		if (collision.gameObject.tag == "TopBound") {
			direction.y = -1;
		}
		if (collision.gameObject.tag == "BottomBound") {
			direction.y = 1;
		}
		
		
	}
}
