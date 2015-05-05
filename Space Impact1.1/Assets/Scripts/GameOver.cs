using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	public string scene;
	private GUISkin skin;
	// Use this for initialization
	void Start () {
		skin = Resources.Load ("GUISkin") as GUISkin;
	}
	public void SetScene(string sn)
	{
		scene = sn;
		Debug.LogError("Scene =" + sn);
	}
	// Update is called once per frame
	void OnGUI () {
		const int buttonWidth = 84;
		const int buttonHeight = 60;

		if (
			GUI.Button (
			new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 3) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Retry!"
			)
			)
		{
			Application.LoadLevel (scene);

		}

		if (
			GUI.Button (
			new Rect (
			Screen.width / 2 - (buttonWidth / 2),
			(1 * Screen.height / 2) - (buttonHeight / 2),
			buttonWidth,
			buttonHeight
			),
			"Quit!"
			)
			)
		{
			Application.Quit();
			
		}
	}
}
