using UnityEngine;
using System.Collections;

public class SpriteChanger : MonoBehaviour {
	public static SpriteChanger Instance;
	
	// Sprite files
	public Sprite butt;
	public Sprite analyticSalmon;
	public Sprite kirby;
//	public Sprite hotdog; 
		
	private SpriteRenderer spriteRenderer; 
	
	void Start() {
		spriteRenderer = GetComponent<SpriteRenderer>(); // we are accessing the SpriteRenderer that is attached to the Gameobject
	}
	
	void Awake() {
		Instance = this;
	}
	
	// Sets player's new sprite
	public void SetPlayerSprite(int playerType)	{
		switch(playerType) 
		{
			case 0: 
				spriteRenderer.sprite = butt;
				break;
			case 1: 
				spriteRenderer.sprite = analyticSalmon;
				break;
			case 2:  
				spriteRenderer.sprite = kirby;
				break;
			default:
				Debug.LogError("Invalid player type!");
				break;
		}
	}
}
