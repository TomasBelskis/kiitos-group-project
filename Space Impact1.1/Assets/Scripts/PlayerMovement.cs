using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

	public Vector2 speed = new Vector2(25,25);
	public Vector2 movement;
	public Vector2 direction;
	//public var  mainCam;
	private float topBorder;
	private float bottomBorder;
	private float leftBorder;
	private float rightBorder;
	private Vector3 pos;
	private Vector3 view;
	private float halfView;
	private float dist;
	private float camHeight;
	private float camWidth;
	private Vector3 screenBound;
	private Vector2 horizontal;
	private Vector2 vertical;

	void Start(){
				 view = Camera.main.ScreenToWorldPoint (new Vector3 (Screen.width, Screen.height, 0));
				 //halfView = Camera.main.renderer.bounds.size.x / 2;
				//transform.position(new Vector3(
		}
	// Update is called once per frame
	void Update () {


		//topBorder = new Vector2(mainCam.ScreentoWorldPoint (new Vector3(Screen.width),1f
		/*
		direction = new Vector2 (0,0);
		screenBound = new Vector3(Screen.width, 0, Screen.height);

		if (Input.GetKey (KeyCode.S))
		{
						direction.x = 1;
		}
		else if(Input.GetKey(KeyCode.W)){
						direction.x = -1;
		}	
		else if(Input.GetKey(KeyCode.D)){
						direction.y = 1;
		}	
		else if(Input.GetKey(KeyCode.A))
		{
						direction.y = -1;
		}	

						movement = new Vector2 (speed.x * direction.x, speed.y * direction.y);
						movement *= Time.deltaTime;

						pos = transform.position;
						pos.x = pos.x + movement.x;
						//transform.Translate (movement);
						transform.position = pos;
		if(pos.x > screenBound.x)
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenBound.x,pos.y,1));
		}
		else if(pos.x < screenBound.x/2)//not where I want the player at the moment, ignore this
		{
			transform.position = Camera.main.ScreenToWorldPoint(new Vector3(screenBound.x/2,pos.y,1));
			
		}
		/*
		pos.x = Mathf.Clamp (pos.x + movement.x, 0-view.x, view.x);
		pos.y = Mathf.Clamp (pos.y + movement.y, 0-view.y, view.y);
		*/
		//transform.position = pos;
		bool shoot = Input.GetButtonDown ("Fire1");
		if (shoot) {
						Weapon weapon = GetComponent<Weapon> ();
						if (weapon != null && weapon.enabled && weapon.CanAttack) {
								weapon.Attack (false);
								SoundEffects.Instance.MakePlayerShot ();
						}
				}
				

		//view = Camera.main.transform.position;
		horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
		vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;

	
		Vector3 pos = transform.position;
		pos.x = Mathf.Clamp(pos.x + horizontal.x, -10.5f, 1);
		pos.y = Mathf.Clamp(pos.y + vertical.y, -5.4f, 5.4f);
		transform.position = pos;
	}
	void OnDestroy()
	{
		transform.parent.gameObject.AddComponent<GameOver>();
		transform.parent.gameObject.GetComponent<GameOver> ().SetScene ("Level_1");

	}
}

