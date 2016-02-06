using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	
	// Status screens
	public Texture2D deathScreen;
	public Texture2D highScreen;
	public Texture2D restart;
	float restartX = Screen.width/2 - 150;
	float restartY = Screen.height/2 + 75;
	public Texture2D mainMenu;
	float mainMenuX = Screen.width/2 - 200;
	float mainMenuY = Screen.height/2 + 160;
	public Texture2D muted;
	float mutedX = Screen.width - 50;
	float mutedY = Screen.height - 75;
	public Texture2D unmuted;
	float unmutedX = Screen.width - 50;
	float unmutedY = Screen.height - 75;
	
	bool dead;
	bool high;
	bool passedHighScore; 
	int timesDead;
	
	// Player movement
	public Vector2 jumpForce;
	public float wobbleAngle;
	public float wobbleFrequency;
	float wobbleTime;
	
	float score = 0;
	
	void Start() {	
		GoogleAdsScript.Instance.HideBanner();		
			
		SpriteChanger.Instance.SetPlayerSprite(Shop.selectedPlayerType);
		SetPlayerSpecs(Shop.selectedPlayerType);
		dead = false;
		high = false;
		passedHighScore = false;
		timesDead = 0;
	}
	
	void Update() {
		// Wobbly
		wobbleTime = wobbleTime + Time.deltaTime;
		float phase = Mathf.Sin(wobbleTime * wobbleFrequency);
		transform.localRotation = Quaternion.Euler(new Vector3(0, 0, phase * wobbleAngle));
	
		// Jump
		if(Input.GetMouseButtonDown(0) && !dead) {
			switch(Shop.selectedPlayerType)
			{
				case 0: 
					jumpForce = RandomizeJump(Shop.selectedPlayerType, 275, 325);
					SoundEffects.Instance.MakeWoahSound();
					break;
				case 1: 
					jumpForce = RandomizeJump(Shop.selectedPlayerType, 250, 400);
					SoundEffects.Instance.MakeFeeeshSound();
					break;
				case 2:
					jumpForce = RandomizeJump(Shop.selectedPlayerType, 300, 450);
					if(Random.Range(0, 2) == 0)
						SoundEffects.Instance.MakeFuckSound();
					else
						SoundEffects.Instance.MakeShitSound();
					break;
				default:
					Debug.LogError("Player type does not exist!");
					break;					
			}			
			rigidbody2D.velocity = Vector2.zero;	
			rigidbody2D.AddForce(jumpForce);
		}
	
		// Die from falling off
		Vector2 screenPosition = Camera.main.WorldToScreenPoint(transform.position);
		if(screenPosition.y > Screen.height || screenPosition.y < 0) {
			if(screenPosition.y > Screen.height) 
				high = true;
			OffMapDeath();
		}	
		
		// Score
		if(!IsDead()) {
			score++;
		}			
	}
	
	// Increments games played
	void IncreaseGamesPlayed() {
		int lifetimeTotalPlayed = PlayerPrefs.GetInt("lifetimeTotalPlayed");
		lifetimeTotalPlayed++;
		PlayerPrefs.SetInt("lifetimeTotalPlayed", lifetimeTotalPlayed);
		
		int selectedPlayerType = Shop.selectedPlayerType;
		switch(selectedPlayerType) {
			case 0:
				int buttPlayed = PlayerPrefs.GetInt("buttPlayed");
				buttPlayed++;
				PlayerPrefs.SetInt("buttPlayed", buttPlayed);
				break;
			case 1:
				int analyticSalmonPlayed = PlayerPrefs.GetInt("analyticSalmonPlayed");
				analyticSalmonPlayed++;
				PlayerPrefs.SetInt("analyticSalmonPlayed", analyticSalmonPlayed);
				break;
			case 2:
				int kirbyPlayed = PlayerPrefs.GetInt("kirbyPlayed");
				kirbyPlayed++;
				PlayerPrefs.SetInt("kirbyPlayed", kirbyPlayed);
				break;
			default: 
				Debug.LogError("Invalid player type!");
				break;
		}		
	}	
	
	// Randomize jump stats
	Vector2 RandomizeJump(int selectedPlayerType, int low, int high) {
		Vector2 newJumpForce = new Vector2(0, Random.Range(low, high)); 
		return newJumpForce;
	}
	
	// Die from collision
	void OnCollisionEnter2D(Collision2D other) {
		CollisionDeath();		
	}
	
	// Off map death
	void OffMapDeath() {
		dead = true;
		timesDead++;
		if(dead && timesDead == 1) {
			if(high)
				SoundEffects.Instance.MakeLaughSound();
			else {
				if(Shop.selectedPlayerType == 2)
					SoundEffects.Instance.MakeUghhhSound();
				else
					SoundEffects.Instance.MakeCandyAssSound();
			}			
			IncreaseGamesPlayed();
			SaveScore();
		}	
		if(Input.GetKeyUp("return")) 
			Application.LoadLevel("Menu");
		if(Input.GetKeyUp("space")) 
			Application.LoadLevel("Play");			
	}
	
	// Collision death
	void CollisionDeath() {
		dead = true;
		timesDead++;
		if(dead && timesDead == 1) {
			if(Shop.selectedPlayerType == 2)
				SoundEffects.Instance.MakeUghhhSound();
			else
				SoundEffects.Instance.MakeCandyAssSound();
			IncreaseGamesPlayed();
			SaveScore();
		}
		OffMapDeath(); 
	}	
	
	// Saves score; keeps highscore
	void SaveScore() {
		if(timesDead == 1) {
			// Sets global high score
			float globalHighScore = PlayerPrefs.GetFloat("globalHighScore");
			float thisScore = score/60;
			if(thisScore > globalHighScore) 
				PlayerPrefs.SetFloat("globalHighScore", thisScore);
			
			// Sets lifetime total score
			float lifetimeTotalScore = PlayerPrefs.GetFloat("lifetimeTotalScore");
			float newLifetimeTotalScore = lifetimeTotalScore + thisScore;
			PlayerPrefs.SetFloat("lifetimeTotalScore", newLifetimeTotalScore);	
						
			// Sets bank score	
			float bankScore = PlayerPrefs.GetFloat("bankScore");
			float newBankScore = bankScore + thisScore;
			PlayerPrefs.SetFloat("bankScore", newBankScore);
			
			// Sets player type scores
			switch(Shop.selectedPlayerType) 
			{
				case 0:
					float buttHighScore = PlayerPrefs.GetFloat("buttHighScore");
					if(thisScore > buttHighScore) 
						PlayerPrefs.SetFloat("buttHighScore", thisScore);
					break;
				case 1:
					float analyticSalmonHighScore = PlayerPrefs.GetFloat("analyticSalmonHighScore");
					if(thisScore > analyticSalmonHighScore)
						PlayerPrefs.SetFloat("analyticSalmonHighScore", thisScore);
					break;
				case 2:
					float kirbyHighScore = PlayerPrefs.GetFloat("kirbyHighScore");
					if(thisScore > kirbyHighScore) 
						PlayerPrefs.SetFloat("kirbyHighScore", thisScore);
					break;
				default: 
					Debug.LogError("Player type does not exist!");
					break;
			}			
		}
	}
	
	// Check if current score beats global high score
	void CheckPassedHighScore(float currentScore, float highScore) {
		if(!passedHighScore && currentScore > highScore) {
			SoundEffects.Instance.MakeHolyAssSound();
			passedHighScore = true;
		}
	}
	
	// Sets the type of player
	void SetPlayerSpecs(int selectedPlayerType) {
		switch(selectedPlayerType) 
		{
			case 0: // default butt
				jumpForce = new Vector2(0, 300);
				wobbleAngle = 15f;
				wobbleFrequency = 15f;
				break;
			case 1: // analytic slamon
				jumpForce = new Vector2(0, 400);
				wobbleAngle = 30f;
				wobbleFrequency = 15f;
				break;
			case 2: // hotdog
				jumpForce = new Vector2(0, 350);
				wobbleAngle = 20f;
				wobbleFrequency = 20f;
				break;
			default: 
				Debug.LogError("Player type does not exist!");
				break;	
		}		
	}
	
	// Checks if dead or not
	public bool IsDead() {
		return dead;
	}
	
	// For the death screen	
	void OnGUI() {
		Color normal = GUI.color;
		if(Screen.width * Screen.height / 40000 > 35)
			GUI.skin.label.fontSize = 35;
		else	
			GUI.skin.label.fontSize = Screen.width * Screen.height / 40000;
		int gap = GUI.skin.label.fontSize * 2;
				
		GUI.color = Color.black;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Label(new Rect(0, 0, 500, gap), " High Score: " + PlayerPrefs.GetFloat("globalHighScore").ToString("F2") + " \"A$$-ca$h\"");
		
		float thisScore = score/60;
		GUI.Label(new Rect(0, gap, 600, gap), " Produced: " + thisScore.ToString("F2") + " \"A$$-ca$h\"");
		
		GUI.skin.label.alignment = TextAnchor.UpperRight;
		GUI.Label(new Rect(Screen.width-500, 0, 500, 75), "A$$ Bank: " + PlayerPrefs.GetFloat("bankScore").ToString("F2") + " \"A$$-ca$h\"\t");		
		
		CheckPassedHighScore(thisScore, PlayerPrefs.GetFloat("globalHighScore"));
		
		GUI.color = normal;
		if(dead) {
			if(high) 
				GUI.Label(new Rect(Screen.width/2-300, 25, highScreen.width, highScreen.height), highScreen);
			else
				GUI.Label(new Rect(Screen.width/2-300, 25, deathScreen.width*0.95f, deathScreen.height*0.95f), deathScreen);
			GUI.backgroundColor = Color.clear;
			if(GUI.Button(new Rect(restartX, restartY, restart.width, restart.height), restart))
				Application.LoadLevel("Play");	
			if(GUI.Button(new Rect(mainMenuX, mainMenuY, mainMenu.width, mainMenu.height), mainMenu))
				Application.LoadLevel("Menu");
			if(Input.GetKeyDown(KeyCode.Escape)) 
				Application.LoadLevel("Menu");
		}
		
		GUI.backgroundColor = Color.clear;
		// Mute/Unmute button	
		if(Menu.isMuted) {
			// Sound on
			if(GUI.Button(new Rect(mutedX, mutedY, muted.width, muted.height), muted)) {
				Menu.isMuted = false;
				AudioListener.pause = false;
				SoundEffects.Instance.MakeGoogabsSound();				
			}
		}
		else {
			// Sound off
			if(GUI.Button(new Rect(unmutedX, unmutedY, unmuted.width, unmuted.height), unmuted)) {
				Menu.isMuted = true;
				AudioListener.pause = true;
			}
		}				
	}
}
