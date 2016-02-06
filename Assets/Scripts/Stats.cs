using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	// Buttons
	public Texture2D back;
	float backX = 25;
	float backY = Screen.height - 150;
	public Texture2D muted;
	float mutedX = Screen.width - 50;
	float mutedY = Screen.height - 75;
	public Texture2D unmuted;
	float unmutedX = Screen.width - 50;
	float unmutedY = Screen.height - 75;
	
	// Stat keeping variables
	float lifetimeTotalScore;
	float globalHighScore;
	float buttHighScore;
	float analyticSalmonHighScore;
	float kirbyHighScore;
//	float hotdogHighScore;
	float lifetimeTotalPlayed;
	float buttPlayed;
	float analyticSalmonPlayed;
	float kirbyPlayed;
//	float hotdogPlayed;
	
	
	void Start() {
		SoundEffects.Instance.MakeGetYourRankOnSound();
		UpdateStats();		
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel("Menu");
	}
	
	void UpdateStats() {
		// Scores
		lifetimeTotalScore = PlayerPrefs.GetFloat("lifetimeTotalScore");
		globalHighScore = PlayerPrefs.GetFloat("globalHighScore");
		buttHighScore = PlayerPrefs.GetFloat("buttHighScore");
		analyticSalmonHighScore = PlayerPrefs.GetFloat("analyticSalmonHighScore");
		kirbyHighScore = PlayerPrefs.GetFloat("kirbyHighScore");
//		hotdogHighScore = PlayerPrefs.GetFloat("hotdogHighScore");

		// Games played
		lifetimeTotalPlayed = PlayerPrefs.GetInt("lifetimeTotalPlayed");
		buttPlayed = PlayerPrefs.GetInt("buttPlayed");
		analyticSalmonPlayed = PlayerPrefs.GetInt("analyticSalmonPlayed");
		kirbyPlayed = PlayerPrefs.GetInt("kirbyPlayed");
//		hotdogPlayed = PlayerPrefs.GetInt("hotdogPlayed");
	}
	
	// Clear all highscores
	private void ClearAllHighScores() {
		ClearGlobalHighScore();
		ClearButtHighScore();
		ClearAnalyticSalmonHighScore();
		ClearKirbyHighScore();
		ClearHotdogHighScore();

		UpdateStats();		
	}
	
	// Clears the global highscore
	private void ClearGlobalHighScore() {
		PlayerPrefs.DeleteKey("globalHighScore");
		Debug.Log("Global highscore has been cleared!");
	}	
	
	// Clears the butt's highscore
	private void ClearButtHighScore() {
		PlayerPrefs.DeleteKey("buttHighScore");
		Debug.Log("Butt's highscore has been cleared!");
	}
	
	// Clears the analytic salmon's highscore
	private void ClearAnalyticSalmonHighScore() {
		PlayerPrefs.DeleteKey("analyticSalmonHighScore");
		Debug.Log("Analytic salmon's highscore has been cleared!");		
	}
	
	// Clears Kirby's highscore
	private void ClearKirbyHighScore() {
		PlayerPrefs.DeleteKey("kirbyHighScore");
		Debug.Log("Kirby's highscore has been cleared!");
	}
	
	// Clears the hotdog's highscore
	private void ClearHotdogHighScore() {
		PlayerPrefs.DeleteKey("hotdogHighScore");
		Debug.Log("Hotdog's highscore has been cleared!");
	}
	
	// Clears the bank's money
	private void ClearBank() {
		PlayerPrefs.DeleteKey("bankScore"); 
		Debug.Log("Bank has been cleared!");
	}	
	
	// Clears all stats
	private void ClearAll() {
		PlayerPrefs.DeleteAll();
		Debug.Log("All Player Prefs have been cleared!");
	}
	
	void OnGUI() {
		UpdateStats();
	
		Color normal = GUI.color;
		if(Screen.width * Screen.height / 40000 > 35)
			GUI.skin.label.fontSize = 35;
		else	
			GUI.skin.label.fontSize = Screen.width * Screen.height / 40000;
		
		// Statistics/Scores
		GUI.color = Color.black;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Label(new Rect(0, 0, 500, 75), " High Score: " + PlayerPrefs.GetFloat("globalHighScore").ToString("F2") + " \"A$$-ca$h\"");
		
		GUI.skin.label.alignment = TextAnchor.UpperRight;
		GUI.Label(new Rect(Screen.width-500, 0, 500, 75), "A$$ Bank: " + PlayerPrefs.GetFloat("bankScore").ToString("F2") + " \"A$$-ca$h\"\t");
		
		
		GUI.skin.label.fontSize = Screen.width * Screen.height / 30000;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		string baseStats = "All-time A$$-ca$h made: " + lifetimeTotalScore.ToString("F2") + " \"A$$-ca$h\"\n\n" 
						  + "Best High Score: " + globalHighScore.ToString("F2") + " \"A$$-ca$h\"\n\n"
						  + "Best Score with Flappy A$$: " + buttHighScore.ToString("F2") + " \"A$$-ca$h\"\n"; 
		string analyticSalmonStats = "Best Score with Flappy Analytic Slamon: " + analyticSalmonHighScore.ToString("F2") + " \"A$$-ca$h\"\n";
		string kirbyStats = "Best Score with Flappy Fast Red Car: " + kirbyHighScore.ToString("F2") + " \"A$$-ca$h\"\n";
//		string hotdogStats = " BestScore with Flappy Hot Dog: " + hotdogHighScore.ToString("F2") + " \"A$$-ca$h\"\n";

		string baseGamesPlayed = "Total Games Played: " + lifetimeTotalPlayed.ToString() + " games\n\n"
								+ "Flappy A$$: " + buttPlayed.ToString() + " games\n";
		string analyticSalmonGamesPlayed = "Flappy Analytic Slamon: " + analyticSalmonPlayed.ToString() + " games\n";
		string kirbyGamesPlayed = "Flappy Fast Red Car: " + kirbyPlayed.ToString() + " games\n";
//		string hotdogGamesPlayed = "Flappy Hot Dog: " + hotdogPlayed.ToString() + " games\n";
		
		string output = baseStats;
		if(PlayerPrefs.GetInt("analyticSalmonPurchased") == 1)
			output += analyticSalmonStats;
		if(PlayerPrefs.GetInt("kirbyPurchased") == 1) 
			output += kirbyStats;
				
		output = output + "\n" + baseGamesPlayed;
		if(PlayerPrefs.GetInt("analyticSalmonPurchased") == 1)
			output += analyticSalmonGamesPlayed;
		if(PlayerPrefs.GetInt("kirbyPurchased") == 1)
			output += kirbyGamesPlayed;
		
		GUI.Label(new Rect(Screen.width/2-300, Screen.height/2-200, 800, 500), output);
		
		GUI.color = normal;	
		GUI.backgroundColor = Color.clear;	
		if(GUI.Button(new Rect(backX, backY, back.width, back.height), back))
			Application.LoadLevel("Menu");
		
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
		
		// Clear high score button
		GUI.color = Color.gray;
		GUI.skin.button.fontSize = Screen.width * Screen.height / 50000;
		if(GUI.Button(new Rect(Screen.width-200, Screen.height-50, 200, 50), "Clear Highscores\t")) {
			ClearAllHighScores();
			SoundEffects.Instance.MakeGoogabsSound();
		}
	}	
}
