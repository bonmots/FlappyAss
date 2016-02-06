using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundEffects : MonoBehaviour {

	public static SoundEffects Instance;
	
	public AudioClip buyAssSound;
	public AudioClip candyAssSound;
	public AudioClip creditsSound;
	public AudioClip feeeshSound;
	public AudioClip getYourRankOnSound;
	public AudioClip googabsSound;
	public AudioClip holyAssSound;
	public AudioClip instructionsSound;
	public AudioClip laughSound;
	public AudioClip sonOfAnAssSound;
	public AudioClip welcomeSound;
	public AudioClip woahSound;
	
	// Kirby Sounds
	public AudioClip fuckSound;
	public AudioClip shitSound;
	public AudioClip ughhhSound;
	
	// Stutter Pack
	public AudioClip ehSound;
	public AudioClip oopsSound;
	public AudioClip soSound;
	public AudioClip uhSound;
	public AudioClip umSound;
	
	void Awake() {
		if(Instance != null) {
			Debug.LogError("Multiple instances of SoundEffects!");
		} 
		Instance = this;
	}
	
	public void MakeSound(AudioClip audioClip) {
		AudioSource.PlayClipAtPoint(audioClip, transform.position);
	}
	
	public void MakeSound(AudioClip audioClip, float volume) {
		AudioSource.PlayClipAtPoint(audioClip, transform.position, volume);
	}
	
	// Ready to buy some ass?!
	public void MakeBuyAssSound() { 
		MakeSound(buyAssSound);
	}
	
	// Candy ass!!
	public void MakeCandyAssSound() {
		MakeSound(candyAssSound);
	}
	
	// Credits 
	public void MakeCreditsSound() { 
		MakeSound(creditsSound);
	}
	
	// Feeesh
	public void MakeFeeeshSound() {
		MakeSound(feeeshSound);
	}
	
	// Get your rank on!
	public void MakeGetYourRankOnSound() {
		MakeSound(getYourRankOnSound);
	}
	
	// Goo gabs!
	public void MakeGoogabsSound() {
		MakeSound(googabsSound);
	}
	
	// Holy ass!
	public void MakeHolyAssSound() {
		MakeSound(holyAssSound);
	}
	
	// Instructions
	public void MakeInstructionsSound() {
		MakeSound(instructionsSound);
	}
	
	// Laughing
	public void MakeLaughSound() {
		MakeSound(laughSound);
	}
	
	// Son of an ass!
	public void MakeSonOfAnAssSound() {
		MakeSound(sonOfAnAssSound);
	}
	
	// Welcome to Flappy Ass 
	public void MakeWelcomeSound() {
		MakeSound(welcomeSound);
	}	
	
	// Woah
	public void MakeWoahSound() {
		MakeSound(woahSound);
	}
	
	/********** Kirby Sounds **********/
	public void MakeFuckSound() {
		MakeSound(fuckSound);
	}
	
	public void MakeShitSound() {
		MakeSound(shitSound);
	}
	
	public void MakeUghhhSound() {
		MakeSound(ughhhSound);
	}
	
	/********** Stutter Pack **********/
	public void MakeEhSound() {
		MakeSound(ehSound);
	}
	
	public void MakeOopsSound() {
		MakeSound(oopsSound);
	}
	
	public void MakeSoSound() {
		MakeSound(soSound);
	}
	
	public void MakeUhSound() {
		MakeSound(uhSound);
	}
	
	public void MakeUmSound() {
		MakeSound(umSound);
	}
}
