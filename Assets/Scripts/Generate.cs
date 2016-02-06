using UnityEngine;
using System.Collections;

public class Generate : MonoBehaviour {
	public static Generate Instance;
	
	// Obstacle object
	public GameObject dicks;
	
	// Game specs
	public float delay;
	public float difference;
//	Player player;
	float dickSpeedChange = 0f;
	
	// Use this for initialization
	void Start() {
		InvokeRepeating("CreateObstacle", delay, difference);
//		GameObject playerObject = GameObject.Find("GameObject");
//		player = playerObject.GetComponent<Player>();
	}
	
	void Awake() {
		Instance = this;
	}
	
	// Creates new obstacles	
	void CreateObstacle() {
		Instantiate(dicks);	
		Faster();
	}
	
	// Speeds up with time
	void Faster() {
		dickSpeedChange = dickSpeedChange + 0.25f;
//		Debug.Log("change: " + dickSpeedChange);
	}
	
	public float GetDickSpeedChange() {
		return dickSpeedChange;
	}
}
