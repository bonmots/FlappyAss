using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {
	public float dickSpeed;
	Vector2 velocity;
	public float range;
	public float lifetime;
	
	// Use this for initialization
	void Start () {
		dickSpeed = dickSpeed - Generate.Instance.GetDickSpeedChange();
		Debug.Log("speed: " + dickSpeed);
		velocity = new Vector2(dickSpeed, 0);
		rigidbody2D.velocity = velocity;
		if(Random.value > 0.5f)
			transform.position = new Vector2(transform.position.x, transform.position.y - range * Random.value);
		else
			transform.position = new Vector2(transform.position.x, transform.position.y + range * Random.value);
		Invoke("Destroy", lifetime);
	}
	
	// Destroy old
	void Destroy() {
		Destroy(gameObject);
	}
}