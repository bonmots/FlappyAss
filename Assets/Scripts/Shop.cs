using UnityEngine;
using System.Collections;

public class Shop : MonoBehaviour {
	public static int selectedPlayerType;
	bool analyticSalmonPurchased;
	bool kirbyPurchased;
//	bool hotdogPurchased;
	
	// Player objects
	public Texture2D butt;
	public Texture2D buttGreyed;
	public Texture2D buttNotBought;
	Texture2D usedButt;
	float buttX = Screen.width/2-450;
	float buttY = Screen.height/2-100;	
	
	public Texture2D analyticSalmon;
	public Texture2D analyticSalmonGreyed;
	public Texture2D analyticSalmonNotBought;
	Texture2D usedAnalyticSalmon;
	float analyticSalmonX = Screen.width/2-70;
	float analyticSalmonY = Screen.height/2-100;
	float analyticSalmonPrice = 1000f;

	public Texture2D kirby;
	public Texture2D kirbyGreyed;
	public Texture2D kirbyNotBought;
	Texture2D usedKirby;
	float kirbyX = Screen.width/2+300;
	float kirbyY = Screen.height/2-100;
	float kirbyPrice = 2100f;
	
//	public Texture2D hotdog;
//	float hotdogX = 25; 
//	float hotdogY = Screen.height/2 + 25;
		
	// Button	
	public Texture2D back;
	float backX = 25;
	float backY = Screen.height - 150;
	public Texture2D muted;
	float mutedX = Screen.width - 50;
	float mutedY = Screen.height - 75;
	public Texture2D unmuted;
	float unmutedX = Screen.width - 50;
	float unmutedY = Screen.height - 75;
	
	void Start() {
		GetPurchaseData();
		SoundEffects.Instance.MakeBuyAssSound();
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel("Menu");
	}
	
	// Get former purchase data on load
	void GetPurchaseData() {	
		if(PlayerPrefs.GetInt("analyticSalmonPurchased") == 1) 
			analyticSalmonPurchased = true;
		else
			analyticSalmonPurchased = false;
		if(PlayerPrefs.GetInt("kirbyPurchased") == 1)
			kirbyPurchased = true;
		else
			kirbyPurchased = false;
	}	
	
	void SetSelectedPlayer() {
		int savedPlayerType = PlayerPrefs.GetInt("selectedPlayerType", 0);
		switch(savedPlayerType) 
		{
			case 0:
				usedButt = butt;
				if(analyticSalmonPurchased)
					usedAnalyticSalmon = analyticSalmonGreyed;
				else
					usedAnalyticSalmon = analyticSalmonNotBought;
				if(kirbyPurchased) 
					usedKirby = kirbyGreyed;
				else
					usedKirby = kirbyNotBought;
				break;
			case 1: 
				usedButt = buttGreyed;
				usedAnalyticSalmon = analyticSalmon;
				if(kirbyPurchased) 
					usedKirby = kirbyGreyed;
				else
					usedKirby = kirbyNotBought;
				break;
			case 2:
				usedButt = buttGreyed;
				if(analyticSalmonPurchased)
					usedAnalyticSalmon = analyticSalmonGreyed;
				else
					usedAnalyticSalmon = analyticSalmonNotBought;
				usedKirby = kirby;
				break;
			default: 
				Debug.LogError("Invalid player type!");
				break;
		}
	}
		
	void OnGUI() {
		SetSelectedPlayer();
		
		Color normal = GUI.color;
		if(Screen.width * Screen.height / 40000 > 35)
			GUI.skin.label.fontSize = 35;
		else	
			GUI.skin.label.fontSize = Screen.width * Screen.height / 40000;
			
		GUIStyle smallItalics = new GUIStyle(GUI.skin.label);
		smallItalics.fontStyle = FontStyle.Italic;
		if(Screen.width * Screen.height / 50000 > 30)
			smallItalics.fontSize = 30;
		else	
			smallItalics.fontSize = Screen.width * Screen.height / 50000;
			
		GUIStyle bigBold = new GUIStyle(GUI.skin.label);
		bigBold.fontStyle = FontStyle.Bold;
		if(Screen.width * Screen.height / 40000 > 35)
			bigBold.fontSize = 35;
		else	
			bigBold.fontSize = Screen.width * Screen.height / 40000;
		
		// High score
		GUI.color = Color.black;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Label(new Rect(0, 0, 500, 75), " High Score: " + PlayerPrefs.GetFloat("globalHighScore").ToString("F2") + " \"A$$-ca$h\"");
		
		// Bank score
		GUI.skin.label.alignment = TextAnchor.UpperRight;
		GUI.Label(new Rect(Screen.width-500, 0, 500, 75), "A$$ Bank: " + PlayerPrefs.GetFloat("bankScore").ToString("F2") + " \"A$$-ca$h\"\t");
		
		// Buttons to select player types
		GUI.backgroundColor = Color.clear;
																
		// Butt player
		GUI.color = Color.black;
		GUI.Label(new Rect(buttX-130, buttY+130, 350, 50), "\"Why does Ben always get camel toes?\"", smallItalics);
		GUI.color = Color.green;
		if(GUI.Button(new Rect(buttX-130, buttY+180, 300, 50), "ALREADY OWNED!", bigBold)) {
			selectedPlayerType = 0;
			PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
			SoundEffects.Instance.MakeSonOfAnAssSound();
		}
		GUI.color = normal;
		if(GUI.Button(new Rect(buttX, buttY, butt.width*0.5f, butt.height*0.5f), usedButt)) {
			selectedPlayerType = 0;
			PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
			SoundEffects.Instance.MakeSonOfAnAssSound();
		}		
		
		// Analytic salmon player
		GUI.color = Color.black;
		GUI.Label(new Rect(analyticSalmonX-130, analyticSalmonY+130, 350, 50), "\"In the end of time, we had no time...\"", smallItalics);
		if(analyticSalmonPurchased) {
			GUI.color = Color.green;
			if(GUI.Button(new Rect(analyticSalmonX-120, analyticSalmonY+180, 300, 50), "ALREADY OWNED!", bigBold)) {
				selectedPlayerType = 1;
				PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
				SoundEffects.Instance.MakeFeeeshSound();
			}			
		}
		else {
			GUI.color = Color.red;
			if(GUI.Button(new Rect(analyticSalmonX-90, analyticSalmonY+180, 300, 50), "Buy for " + analyticSalmonPrice + " \"A$$-ca$h\"", bigBold)) {
				float bankScore = PlayerPrefs.GetFloat("bankScore");
				if(bankScore >= analyticSalmonPrice) {
					analyticSalmonPurchased = true;
					PlayerPrefs.SetInt("analyticSalmonPurchased", 1);
					PlayerPrefs.SetFloat("bankScore", bankScore - analyticSalmonPrice);
					selectedPlayerType = 1;
					PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
					SoundEffects.Instance.MakeFeeeshSound();
				}
				else
					SoundEffects.Instance.MakeOopsSound();
			}
		}
		GUI.color = normal;
		if(GUI.Button(new Rect(analyticSalmonX, analyticSalmonY, analyticSalmon.width*0.5f, analyticSalmon.height*0.5f), usedAnalyticSalmon)) {
			if(analyticSalmonPurchased) {
				selectedPlayerType = 1;
				PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
				SoundEffects.Instance.MakeFeeeshSound();
			}
			else
				SoundEffects.Instance.MakeOopsSound();			
		}
		
		// Kirby player
		GUI.color = Color.black;
		GUI.Label(new Rect(kirbyX-150, kirbyY+130, 350, 50), "\"Life is like a roll of toilet paper.\"", smallItalics);
		if(kirbyPurchased) {
			GUI.color = Color.green;
			if(GUI.Button(new Rect(kirbyX-120, kirbyY+180, 300, 50), "ALREADY OWNED!", bigBold)) {
				selectedPlayerType = 2;
				PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
				SoundEffects.Instance.MakeUghhhSound();
			}
		}
		else {
			GUI.color = Color.red;
			if(GUI.Button (new Rect(kirbyX-90, kirbyY+180, 300, 50), "Buy for " + kirbyPrice + " \"A$$-ca$h\"", bigBold)) {
				float bankScore = PlayerPrefs.GetFloat("bankScore");
				if(bankScore >= kirbyPrice) {
					kirbyPurchased = true;
					PlayerPrefs.SetInt("kirbyPurchased", 1);
					PlayerPrefs.SetFloat("bankScore", bankScore - kirbyPrice);
					selectedPlayerType = 2;
					PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
					SoundEffects.Instance.MakeUghhhSound();
				}
				else
					SoundEffects.Instance.MakeOopsSound();
			}
		}		
		GUI.color = normal;
		if(GUI.Button(new Rect(kirbyX, kirbyY, kirby.width*0.5f, kirby.height*0.5f), usedKirby)) {
			if(kirbyPurchased) {
				selectedPlayerType = 2;
				PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
				SoundEffects.Instance.MakeUghhhSound();
			}
			else
				SoundEffects.Instance.MakeOopsSound();			
		}	
		
		// Hotdog player
//		if(GUI.Button(new Rect(hotdogX, hotdogY, hotdog.width*0.5f, hotdog.height*0.5f), hotdog)) {
//			selectedPlayerType = 2;
//			PlayerPrefs.SetInt("selectedPlayerType", selectedPlayerType);
//			SoundEffects.Instance.MakeOopsSound();
//		}
		
		// Back button
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
	}	
}
