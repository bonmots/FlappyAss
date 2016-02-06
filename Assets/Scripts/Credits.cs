using UnityEngine;
using System.Collections;

public class Credits : MonoBehaviour {

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
		SoundEffects.Instance.MakeCreditsSound();
	}
	
	void Update() {
		if(Input.GetKeyDown(KeyCode.Escape)) 
			Application.LoadLevel("Menu");
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
	}
}
