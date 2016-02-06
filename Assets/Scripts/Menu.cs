using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	public string version;	
	public static bool isMuted;

	public Texture2D muted;
	float mutedX = Screen.width - 50;
	float mutedY = Screen.height - 75;
	public Texture2D unmuted;
	float unmutedX = Screen.width - 50;
	float unmutedY = Screen.height - 75;
	
	public Texture2D shop;
	float shopX = Screen.width/2 - 500;
	float shopY = Screen.height/2 + 60;	
	public Texture2D start;
	float startX = Screen.width/2 - 170;
	float startY = Screen.height/2 + 30;	
	public Texture2D stats;
	float statsX = Screen.width/2 + 250;
	float statsY = Screen.height/2 + 60;	
	public Texture2D instructions;
	float instructionsX = Screen.width/2 - 350;
	float instructionsY = Screen.height/2 + 180;
	public Texture2D credits;
	float creditsX = Screen.width/2 + 100;
	float creditsY= Screen.height/2 + 180;
	
	// Use this for initialization
	void Start() {
		GoogleAdsScript.Instance.ShowBanner();
		SoundEffects.Instance.MakeWelcomeSound();
	}
	
	// Update is called once per frame
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape))
			Application.Quit();
	}
	
	void OnGUI() {
		Color normal = GUI.color;
		if(Screen.width * Screen.height / 40000 > 35)
			GUI.skin.label.fontSize = 35;
		else	
			GUI.skin.label.fontSize = Screen.width * Screen.height / 40000;
		GUI.color = Color.black;
		GUI.skin.label.alignment = TextAnchor.UpperLeft;
		GUI.Label(new Rect(0, 0, 500, 75), " High Score: " + PlayerPrefs.GetFloat("globalHighScore").ToString("F2") + " \"A$$-ca$h\"");
		
		GUI.skin.label.alignment = TextAnchor.UpperRight;
		GUI.Label(new Rect(Screen.width-500, 0, 500, 75), "A$$ Bank: " + PlayerPrefs.GetFloat("bankScore").ToString("F2") + " \"A$$-ca$h\"\t");
		
		if(Screen.width * Screen.height / 50000 > 30)
			GUI.skin.label.fontSize = 30;
		else	
			GUI.skin.label.fontSize = Screen.width * Screen.height / 50000;
		GUI.Label(new Rect(Screen.width-300, Screen.height-30, 300, 30), "v" + version + "\t");
		
		GUI.color = normal;	
		GUI.backgroundColor = Color.clear;	
		
		if(GUI.Button(new Rect(shopX, shopY, shop.width*0.8f, shop.height*0.8f), shop)) {
			Application.LoadLevel("Shop");
		}
		if(GUI.Button(new Rect(startX, startY, start.width, start.height), start)) {
			Application.LoadLevel("Play");
		}
		if(GUI.Button(new Rect(statsX, statsY, stats.width*0.8f, stats.height*0.8f), stats)) {
			Application.LoadLevel("Stats");
		}
		if(GUI.Button(new Rect(instructionsX, instructionsY, instructions.width*0.8f, instructions.height*0.8f), instructions)) {
			Application.LoadLevel("Instructions");
		}
		if(GUI.Button(new Rect(creditsX, creditsY, credits.width*0.8f, credits.height*0.8f), credits)) {
			Application.LoadLevel("Credits");
		}
		
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
