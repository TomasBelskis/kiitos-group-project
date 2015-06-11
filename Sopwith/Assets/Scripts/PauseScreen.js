#pragma strict
var pauseCanvas : Canvas;



	// Use this for initialization
	function Start () {
		Screen.lockCursor = true;
		Cursor.visible = false;

	}
	
	// Update is called once per frame
	function Update () {
		if (Input.GetKeyDown (KeyCode.Escape)) {
			
			pauseCanvas.enabled=true;
			Time.timeScale = 0;
			Screen.lockCursor = false;
			Cursor.visible = true;
		}
	}

	function resumeGame () {
		   	pauseCanvas.enabled=false;
			Time.timeScale = 1;
			Screen.lockCursor = true;
			Cursor.visible = false;
	}
	
	function restartGame(){
		Application.LoadLevel(Application.loadedLevel);
		Time.timeScale = 1;
	}
	function returnToMainMenu(){
		Application.LoadLevel(0);
	}
